using Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Store
{
    public class Store : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }

        public List<WorkingHours> WorkingHours { get; set; } = new List<WorkingHours>();
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
