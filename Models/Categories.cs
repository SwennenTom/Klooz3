namespace Klooz3.Models
{
    public class Categories
    {
        public int categoriesId { get; set; }
        public string? name { get; set; }

        public Categories() { }

        public Categories(string name)
        {
            this.name = name;
        }
    }
}
