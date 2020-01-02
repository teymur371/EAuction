using EAuction.Dtos;
using EAuction.Enums;
using EAuction.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Attachment> Attachments { get; set; }
        public int UserId { get; set; } // foreign key
    }
    
    public class ItemAuction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ItemId {get; set; } //foreign key
        public Item CurrentItem { get; set; }
        public double StartPrice { get; set; }
        public Currency Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get { return DateTime.Now < this.Deadline; } }
    }
    
    public class ItemAuctionBid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AuctionId {get; set; } //foreign key
        public ItemAuction CurrentAuction { get; set; }
        public double Price { get; set; }
        public Currency Currency { get { return this.ItemAuction.Currency; } } 
        public DateTime MadeDate { get; set; }
        public string UserId { get; set; } // bids should be anonymous.
    }
    
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; } // foreign key
    }
    
    public class User
    {
        // basic info
    }
        
}
