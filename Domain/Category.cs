using Domain.Abstract;

namespace Domain
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }
        public ICollection<Domain.Store.Store> Stores { get; set; }

    }
}