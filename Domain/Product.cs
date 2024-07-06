using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }
        public int Price { get; set; }
        public int StoreId { get; set; }
        public Domain.Store.Store Store { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
