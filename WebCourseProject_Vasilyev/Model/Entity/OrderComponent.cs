namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class OrderComponent
    {
        public int Id { get; set; }
        public Item item { get; set; }
        public int Quantity { get; set; }
    }
}
