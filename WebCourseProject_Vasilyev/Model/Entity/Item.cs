namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string? PhotoPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public Seller Seller { get; set; }
    }
}
