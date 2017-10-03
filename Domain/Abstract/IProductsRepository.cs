using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Concrete;
using Domain.Entitis;

namespace Domain.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }
        Product DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
