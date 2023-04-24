﻿namespace WebCourseProject_Vasilyev.Model.Entity
{
    public class Buyer
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Contacts { get; set; }
        public long OrdersCount { get; set; }
        public ICollection<Order> Purchases { get; set; }

    }
}