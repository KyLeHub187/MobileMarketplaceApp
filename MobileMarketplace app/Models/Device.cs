using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileMarketplace_app.Models
{
    public class Device
    {
        public int DeviceId { get; set; }  
        public string DeviceType { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }  
        public string OS { get; set; }   
        public string Storage { get; set; }  
        public string Color { get; set; }
        public string Description { get; set; }
        public List<string> ImagePaths { get; set; } = new List<string>();
        public int SellerId { get; set; }
        public int? BuyerId { get; set; } 
        public bool IsActive { get; set; }   
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string FirstImagePath => ImagePaths.FirstOrDefault();

    }
}
