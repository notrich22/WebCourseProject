using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev
{
    public class Records
    {
        public record IdInfo(int id);
        //Buyer recs
        public record BuyerInfo(string FirstName, string LastName, string Contacts, long OrdersCount);
        public record BuyerUpdateInfo(int id, string FirstName, string LastName, string Contacts, long OrdersCount);
        //Item recs
        public record ItemInfo(string photoPath, string Name, decimal Price, bool inStock, int sellerId);
        public record ItemUpdateInfo(int id, string photoPath, string Name, decimal Price, bool inStock, int sellerId);
    }
}
