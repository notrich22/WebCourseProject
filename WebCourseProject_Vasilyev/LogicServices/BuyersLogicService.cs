using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.LogicServices
{
    public class BuyersLogicService
    {
        //Create
        public async Task<Buyer> AddBuyerAsync(Buyer buyer)
        {
            try
            {
                using (var db = new DBContext())
                {
                    await db.Buyers.AddAsync(buyer);
                    await db.SaveChangesAsync();
                    return buyer;
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Read
        public async Task<List<Buyer>> GetBuyersAsync()
        {
            try
            {
                using (var db = new DBContext())
                {
                    return await db.Buyers.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public async Task<Buyer> GetBuyerAsync(int id)
        {
            try
            {
                using (var db = new DBContext()) {
                    return await db.Buyers.FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Update
        public async Task<Buyer> UpdateBuyerAsync(int id, Buyer buyer)
        {
            try
            {
                //TODO
                using (var db = new DBContext()) {
                    var oldBuyer = await db.Buyers.FirstOrDefaultAsync(x => x.Id == id);
                    oldBuyer.FirstName = buyer.FirstName;
                    oldBuyer.LastName = buyer.LastName;
                    oldBuyer.OrdersCount = buyer.OrdersCount;
                    oldBuyer.Contacts = buyer.Contacts;
                    await db.SaveChangesAsync();
                    return oldBuyer;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Delete
        public async Task<bool> DeleteBuyer(int id)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Remove(await db.Buyers.FirstOrDefaultAsync(x => x.Id == id));
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
