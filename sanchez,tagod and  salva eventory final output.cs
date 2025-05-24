using System;
using System.Collections.Generic;
using System.Linq;

namespace eventory
{
    
    class Product
    {
        public int ID;
        public string Name;
        public int Quantity;
        public decimal Price;

      
        public void Show()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}, Quantity: {Quantity}, Price: {Price} Pesos");
        }
    }

    class Program
    {
        static HashSet<int> deletedProductIds = new HashSet<int>(); 

        static void Main()
        {
            List<Product> inventory = new List<Product>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== Inventory Menu ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddProduct(inventory);
                        break;
                    case "2":
                        ShowAllProducts(inventory);
                        break;
                    case "3":
                        EditProduct(inventory);
                        break;
                    case "4":
                        RemoveProduct(inventory);
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

       
        static void AddProduct(List<Product> inventory)
        {
            Product product = new Product();

            Console.Write("Enter Product ID: ");
            product.ID = Convert.ToInt32(Console.ReadLine());

           
            if (inventory.Any(p => p.ID == product.ID) || deletedProductIds.Contains(product.ID))
                return;

            Console.Write("Enter Product Name: ");
            product.Name = Console.ReadLine();

            
            if (inventory.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            Console.Write("Enter Quantity: ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            inventory.Add(product);
            Console.WriteLine("Product added successfully!");
        }

        static void ShowAllProducts(List<Product> inventory)
        {
            Console.WriteLine("\n--- Product List ---");

            if (inventory.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                return;
            }

            foreach (var product in inventory)
            {
                product.Show();
            }
        }

        static void EditProduct(List<Product> inventory)
        {
            Console.Write("Enter Product ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product product = inventory.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new Name (press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
                product.Name = newName;

            Console.Write("Enter new Quantity (press Enter to keep current): ");
            string newQty = Console.ReadLine();
            if (!string.IsNullOrEmpty(newQty))
                product.Quantity = Convert.ToInt32(newQty);

            Console.Write("Enter new Price (press Enter to keep current): ");
            string newPrice = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPrice))
                product.Price = Convert.ToDecimal(newPrice);

            Console.WriteLine("Product updated.");
        }

       
        static void RemoveProduct(List<Product> inventory)
        {
            Console.Write("Enter Product ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product product = inventory.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            inventory.Remove(product);
            deletedProductIds.Add(product.ID); 
            Console.WriteLine("Product deleted.");
            Console.WriteLine("You do not return the product.");
        }
    }
}
