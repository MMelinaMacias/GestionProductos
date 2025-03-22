using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos
{
    public interface IProduct
    {
        void ShowAvailableProducts();
        void AddProduct(string name, decimal price);
        void SearchProduct(string name);
        void DeleteProduct(int id);
    }
}
