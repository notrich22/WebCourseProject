using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;
using static WebCourseProject_Vasilyev.Records;

namespace WebCourseProject_Vasilyev.LogicServices
{
    public class ItemsLogicService
    {
        //Create
        public async Task<Item> AddItemAsync(Item Item, int sellerId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    Item.Seller = await db.Sellers.FirstOrDefaultAsync(seller => seller.Id == sellerId);
                    await db.Items.AddAsync(Item);
                    await db.SaveChangesAsync();
                    return Item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Read
        public async Task<List<Item>> GetItemsBySellerAsync(int id)
        {
            try
            {
                using (var db = new DBContext())
                {
                    return await db.Items.Include(n => n.Seller).Where(n=>n.Seller.Id == id).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            try
            {
                using (var db = new DBContext())
                {
                    return await db.Items.Include(n => n.Seller).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public async Task<Item> GetItemAsync(int id)
        {
            try
            {
                using (var db = new DBContext())
                {
                    return await db.Items.Include(n=>n.Seller).FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Update
        public async Task<Item> UpdateItemAsync(int id, Item Item)
        {
            try
            {
                //TODO
                using (var db = new DBContext())
                {
                    var oldItem = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
                    oldItem.PhotoPath = Item.PhotoPath;
                    oldItem.Name = Item.Name;
                    oldItem.Price = Item.Price;
                    oldItem.InStock = Item.InStock;
                    await db.SaveChangesAsync();
                    return oldItem;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Delete
        public async Task<bool> DeleteItem(int id)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Remove(await db.Items.FirstOrDefaultAsync(x => x.Id == id));
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
