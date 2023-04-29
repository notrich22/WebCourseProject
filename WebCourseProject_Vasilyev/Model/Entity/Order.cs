namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        public string Description { get; set; }
    }
}
