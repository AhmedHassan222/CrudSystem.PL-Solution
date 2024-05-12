using CrudSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSystem.BLL.InterfacesRepositiries
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        int Add (Product product);

        int Delete(Product product);

        int Update(Product product);


    }
}
