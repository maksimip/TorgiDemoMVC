using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entitis;

namespace Domain.Concrete
{
    public class ProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();
        
        public IQueryable<Product> Products {get { return context.Products; }}
        

        public Product DeleteProduct(int id)
        {
            Product dbEntry = context.Products.Find(id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
           
            return dbEntry;
        }

        public void UpdateProduct(Product product)
        {
            if (product.IdItem == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.IdItem);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Category = product.Category;
                    dbEntry.Price = product.Price;
                }
            }

            context.SaveChanges();
        }
    }
    
}
