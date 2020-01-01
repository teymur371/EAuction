using EAuction.Enums;

namespace EAuction.Services
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double StartPrice { get; set; }
        public Currency Currency { get; set; }
    }
}