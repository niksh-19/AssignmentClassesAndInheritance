namespace AssignmentClassesAndInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> allAppliances = Manager.ParseAppliances("C://cprg211//AssignmentClassesAndInheritance//appliances.txt");
            

            while (true)
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("How may we asist you?");
                Console.WriteLine("1 - Check out appliance");
                Console.WriteLine("2 - Find appliances by brand");
                Console.WriteLine("3 - Display appliances by type");
                Console.WriteLine("4 - Produce random appliance list");
                Console.WriteLine("5 - Save & Exit");

                Console.WriteLine("Enter option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Manager.PurchaseAppliance(allAppliances);
                        break;
                    case "2":
                        Manager.DisplayAppliancesByBrand(allAppliances);
                        break;
                    case "3":
                        Manager.DisplayByType(allAppliances);
                        break;
                    case "4":
                        Manager.DisplayRandomAppliances(allAppliances);
                        break;
                    case "5":
                        Manager.SaveAppliancesToFile(allAppliances, "C://cprg211//AssignmentClassesAndInheritance//appliances.txt");
                        Console.WriteLine("Thank you for visiting the Modern Appliances Store!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                        break;
                }
            }
        }
    }
}
