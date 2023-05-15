using System.Runtime.CompilerServices;

namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public string Contacts { get; set; }
        public string UserID { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Order> Sells { get; set; }
    }
}
