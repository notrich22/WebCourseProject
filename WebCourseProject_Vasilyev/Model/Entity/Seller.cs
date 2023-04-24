namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Seller
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Order> Sells { get; set; }
    }
}
