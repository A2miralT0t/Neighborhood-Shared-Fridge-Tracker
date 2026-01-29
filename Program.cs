using System;
using System.Collections.Generic;

class FridgeItem
{
    public string Name { get; set; }
    public string Donor { get; set; }
    public DateTime ExpirationDate { get; set; }

    public override string ToString()
    {
        string status = ExpirationDate < DateTime.Now ? "Expired" : "Fresh";
        return $"{Name} (Donated by: {Donor}, Expires: {ExpirationDate.ToShortDateString()}) - {status}";
    }
}

class SharedFridge
{
    private List<FridgeItem> items = new List<FridgeItem>();

    public void AddItem(string name, string donor, DateTime expiration)
    {
        items.Add(new FridgeItem { Name = name, Donor = donor, ExpirationDate = expiration });
        Console.WriteLine($"Item '{name}' added successfully!");
    }

    public void ListItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("The fridge is empty.");
            return;
        }

        Console.WriteLine("\n--- Items in the Shared Fridge ---");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void RemoveItem(string name)
    {
        var item = items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine($"✔ Item '{name}' removed from the fridge.");
        }
        else
        {
            Console.WriteLine($"Item '{name}' not found.");
        }
    }
}

partial class Program
{
    static void Main()
    {
        SharedFridge fridge = new SharedFridge();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Shared Fridge Menu ---");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. List Items");
            Console.WriteLine("3. Remove Item");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter donor name: ");
                    string donor = Console.ReadLine();
                    Console.Write("Enter expiration date (yyyy-mm-dd): ");
                    DateTime expiration = DateTime.Parse(Console.ReadLine());
                    fridge.AddItem(name, donor, expiration);
                    break;

                case "2":
                    fridge.ListItems();
                    break;

                case "3":
                    Console.Write("Enter item name to remove: ");
                    string removeName = Console.ReadLine();
                    fridge.RemoveItem(removeName);
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
