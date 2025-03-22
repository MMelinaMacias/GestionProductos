using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GestionProductos.Model;


namespace GestionProductos
{
    internal class ProductService: IProduct
    {

        private List<Product> availableProducts;

        public ProductService() {
            //AvailableProducts = [new Product(1, "Cafe", 25.3m), new Product(2, "Cookie", 5.90m)];
            availableProducts = [];
        }


        public void ShowAvailableProducts()
        {
            if (availableProducts == null || availableProducts.Count == 0)
            {
                Console.WriteLine("Al momento no existen productos registrados!");
                return;
            }
            Console.WriteLine("Productos Registrados");
            foreach (Product product in availableProducts)
            {
                Console.WriteLine(product);
            }
            
        }


        public void AddProduct(string name, decimal price)
        {

            Product newProduct = new(GenerateId(), name, price);
            availableProducts.Add(newProduct);
            Console.WriteLine("Producto agregado exitosamente con ID: " + newProduct.Id);
        }


        public void SearchProduct(string name)
        {
            List<Product> prodsFound = [.. availableProducts.Where(p  => p.Name.ToLower() == name.ToLower())];
            if (prodsFound.Count == 0)
            {
                Console.WriteLine("No existen registros que tengan el nombre " + name + " asociado");
                return;
            }

            Console.WriteLine("Productos registrados con el nombre " + name + ":");
            foreach (Product product in prodsFound)
            {
                Console.WriteLine(product);
            }

        }

        public void DeleteProduct(int id)
        {

            Product prod = availableProducts.FirstOrDefault(pr => pr.Id == id);
            if (prod== null)
            {
                Console.WriteLine("El producto con ID " + id + " no existe");
                return;
            }

            availableProducts.Remove(prod);
            Console.WriteLine("El producto con ID " + id + " fue eliminado exitosamente!");
         
        }


        private int GenerateId()
        {
            Random rnd = new Random();
            int newId;

            do
            {
                newId = rnd.Next(1, 200);
            }
            while (availableProducts.Any(pr => pr.Id == newId));
            return newId;
        }


    }
}
