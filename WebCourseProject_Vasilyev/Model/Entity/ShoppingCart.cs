namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public virtual ICollection<ShoppingCartComponent> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
    }

}
