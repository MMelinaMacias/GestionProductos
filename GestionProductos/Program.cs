using GestionProductos;
using static GestionProductos.Utils;
class Program
{
    private static ProductService productService = new();
    public static void Main(string[] args)
    {
        Console.WriteLine("***GESTIÓN DE PRODUCTOS***");
        bool showOptions = true;
        while (showOptions)
        {
            GetInput(ref showOptions);
        }
    }

    private static void GetInput(ref bool showOptions)
    {
        //Console.Clear();
        ShowMenu();
        string option = Console.ReadLine();
        int optionMenu;

        bool isValid = int.TryParse(option, out optionMenu);
        while (!isValid)
        {
            Console.WriteLine("Error - Debe ingresar un valor númerico!. Intente nuevamente");
            option = Console.ReadLine(); 
            isValid = int.TryParse(option, out optionMenu);
        }

        switch (optionMenu)
        {
            case 1:
                AddProduct();
                break; 

            case 2:
                DeleteProduct();
                break;

            case 3:
                SearchProduct();
                break;

            case 4:
                productService.ShowAvailableProducts();
                break;

            case 5:
                Console.WriteLine("Finalizando ejecución de programa!");
                showOptions = false;
                break;

            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                break;
        }
    }


    private static void AddProduct()
    {
        Console.WriteLine("Ingrese el nombre del producto: ");
        string productName = ValidateString(Console.ReadLine());
        Console.WriteLine("Nombre Ingresado: " + productName);

        Console.WriteLine("Ingrese el precio del producto: ");
        decimal productPrice = ValidateDecimal(Console.ReadLine());
        Console.WriteLine("Precio Ingresado: " + productPrice);

        productService.AddProduct(productName, productPrice);

    }

    private static void DeleteProduct()
    {
        Console.WriteLine("Ingrese el ID del producto a eliminar: ");
        int productId = ValidateInt(Console.ReadLine());
        productService.DeleteProduct(productId);
    }

    private static void SearchProduct()
    {
        Console.WriteLine("Ingrese el nombre del producto que desea buscar: ");
        string productName = ValidateString(Console.ReadLine());
        productService.SearchProduct(productName);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("1. Agregar Producto");
        Console.WriteLine("2. Eliminar Producto");
        Console.WriteLine("3. Buscar Producto por Nombre");
        Console.WriteLine("4. Mostrar Productos");
        Console.WriteLine("5. Salir");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Ingrese la opción deseada");
    }

}