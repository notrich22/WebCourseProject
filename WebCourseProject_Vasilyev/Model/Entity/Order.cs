﻿namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
