using Domain.Abstract;

namespace Domain
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }
        public ICollection<TheStore.Store> Stores { get; set; }

    }
}