using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ComparesDbRepository : IComparesRepository
    {
        private readonly DatabaseContext databaseContext;

        public ComparesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void Add(Product product)
        {

            var existingProductToCompare = databaseContext.ComparingProducts.FirstOrDefault(x => x.Id == product.Id);
            if (existingProductToCompare == null)
            {
                databaseContext.Add(product);
                databaseContext.SaveChanges();
            }         
        }

        public List<ComparingProduct> GetCompare()
        {
            return databaseContext.ComparingProducts.ToList();
        }

        public void Clear()
        {
            databaseContext.ComparingProducts.RemoveRange();
        }
        public void Delete(ComparingProduct product)
        {
            databaseContext.ComparingProducts.Remove(product);
            databaseContext.SaveChanges();
        }
    }
}
