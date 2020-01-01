using EAuction.DataContext;
using EAuction.Dtos;
using EAuction.Models;
using EAuction.Services;
using EAuction.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService, ApplicationDbContext context)
        {
            _context = context;
            _itemService = itemService;
        }

        [HttpGet]
        [Route("AllItems")]
        public IActionResult GetAllItems()
        {
            var items = _itemService.GetAllItems();
            return Ok(items);
        }

        [HttpPost]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateItem(UpdateItemDto dto)
        {
            var newItem = await _itemService.UpdateItem(dto);
            await _context.SaveChangesAsync();
            return Ok(newItem);
        }

        [HttpGet]
        [Route("RemoveItem")]
        public async Task<int> DeleteItem (int itemId)
        {
            var deletableItemId = await _itemService.RemoveItem(itemId);
            _context.Items.Remove(await _context.Items.FindAsync(deletableItemId));
            await _context.SaveChangesAsync();
            return deletableItemId;
            
        }

        [HttpGet]
        [Route("Item/{itemId}")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            var item = await _itemService.GetItem(itemId);
            return Ok(item);
        }

        [HttpPost]
        [Route("CreateItem")]
        public async Task<IActionResult> CreateItem(CreateItemDto dto)
        {
            var newItem = await _itemService.CreateItem(dto);
            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return Ok(newItem);
        }
    }
}
