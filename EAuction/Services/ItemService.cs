using EAuction.DataContext;
using EAuction.Dtos;
using EAuction.Models;
using EAuction.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Item> GetAllItems()
        {
            var items = _context.Items.ToList();
            if (items == null) throw new Exception("No items were found!");
            return items;
        }
        public async Task<Item> GetItem(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);
            if (item == null) throw new Exception("No such item found!");
            return item;
        }
        public async Task<Item> UpdateItem(UpdateItemDto dto)
        {
            var itemToDelete = await _context.Items.FindAsync(dto.ItemId);
            if (dto == null) throw new Exception("No changes were applied.");
            itemToDelete.Currency = dto.Currency;
            itemToDelete.Description = dto.Description;
            itemToDelete.Name = dto.Name;
            itemToDelete.StartPrice = dto.StartPrice;

            return itemToDelete;
        }

        public async Task<int> RemoveItem(int itemId)
        {
            var deletableItem = await _context.Items.FindAsync(itemId);
            if (deletableItem == null) throw new Exception("No such item found!");
            _context.Items.Remove(deletableItem);
            return deletableItem.Id;
        }
        public async Task<Item> CreateItem(CreateItemDto dto)
        {
            var newItem = new Item()
            {
                Name = dto.Name,
                Currency = dto.Currency,
                Description = dto.Description,
                StartPrice = dto.StartPrice,
            };
            await _context.AddAsync(newItem);
            return newItem;
        }
    }
}
