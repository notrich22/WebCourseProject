namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class ShoppingCartComponent
    {
        public int Id { get; set; }
        public Item item { get; set; }
        public int Quantity { get; set; }
    }
}
