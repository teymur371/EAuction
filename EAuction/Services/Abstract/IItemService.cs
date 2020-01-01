using EAuction.Dtos;
using EAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Services.Abstract
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        Task<Item> GetItem(int itemId);
        Task<Item> UpdateItem(UpdateItemDto dto);
        Task<int> RemoveItem(int itemId);
        Task<Item> CreateItem(CreateItemDto dto);
    }
}
