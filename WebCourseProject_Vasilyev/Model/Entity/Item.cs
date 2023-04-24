namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Item
    {
        public int id { get; set; }
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public Seller Seller { get; set; }
    }
}
