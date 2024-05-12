using CrudSystem.BLL.InterfacesRepositiries;
using CrudSystem.DAL.Contexts;
using CrudSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSystem.BLL.Repositiries
{
    public class ProductRepo : IProductRepo
    {
        private readonly CrudSystemDb _dbContext;
        public ProductRepo(CrudSystemDb dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Product product)
        {
            _dbContext.Products.Add(product);
            return _dbContext.SaveChanges();
        }

        public int Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList() ;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }
        public int Update(Product product)
        {
            _dbContext.Products.Update(product);
            return _dbContext.SaveChanges();
        }
    }
}
