using Domain.Abstract;

namespace Domain
{
    public class Store : BaseEntity<int>
    {
        public string name { get; set; }
        public string Address { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }

        //[Column(TypeName = "json")]
        public List<WorkingHours> WorkingHours { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
