using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClassesAndInheritance
{
    public class Manager
    {
        public static List<Appliance> ParseAppliances(string filePath)
        {
            List<Appliance> appliances = new List<Appliance>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                var ItemNumber = int.Parse(fields[0]);
                var Brand = fields[1];
                var Quantity = int.Parse(fields[2]);
                var Wattage = int.Parse(fields[3]);
                var Color = fields[4];
                var Price = double.Parse(fields[5]);
                char applianceType = fields[0][0];

                switch (applianceType)
                {
                    case '1':
                        var NumberofDoors = int.Parse(fields[6]);
                        appliances.Add(new Refrigerator(ItemNumber, Brand, Quantity, Wattage,
                            Color, Price, NumberofDoors, int.Parse(fields[7]), int.Parse(fields[8])));
                        break;
                    case '2':
                        appliances.Add(new Vacuum(ItemNumber, Brand, Quantity, Wattage, Color,
                            Price, fields[6], int.Parse(fields[7])));
                        break;
                    case '3':
                        var Capacity = decimal.Parse(fields[6]);
                        appliances.Add(new Microwave(ItemNumber, Brand, Quantity, Wattage, Color,
                            Price, Capacity, fields[7]));
                        break;
                    case '4':
                    case '5':
                        appliances.Add(new Dishwasher(ItemNumber, Brand, Quantity, Wattage, Color,
                            Price, fields[6], fields[7]));
                        break;
                    default:
                        Console.WriteLine($"Invalid appliance type: {applianceType}");
                        break;
                }
            }

            return appliances;
        }

        public static void PurchaseAppliance(List<Appliance> appliances)
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            string itemNumber = Console.ReadLine();

            Appliance appliance = appliances.FirstOrDefault(a => a.ItemNumber == int.Parse(itemNumber));
            if (appliance != null)
            {
                if (appliance.Quantity > 0)
                {
                    appliance.Quantity--;
                    Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
            else
            {
                Console.WriteLine("No Appliance found with that item number.");
            }
        }
        public static void DisplayAppliancesByBrand(List<Appliance> appliances)
        {
            Console.WriteLine("Enter brand to search for: ");
            string brandName = Console.ReadLine().Trim();
            var matchingAppliances = appliances.Where(a => string.Equals(a.Brand, brandName, StringComparison.OrdinalIgnoreCase));

            if (matchingAppliances.Any())
            {
                Console.WriteLine("Matching Appliances:");
                foreach (var appliance in matchingAppliances)
                {
                    Console.WriteLine(appliance);
                }
            }
            else
            {
                Console.WriteLine($"No appliances found with brand '{brandName}'.");
            }
        }
        static void DisplayRefrigerators(List<Appliance> appliances)
        {
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
            string doorsInput = Console.ReadLine();
            if (!int.TryParse(doorsInput, out int doors) || (doors != 2 && doors != 3 && doors != 4))
            {
                Console.WriteLine("Invalid input. Please enter 2, 3, or 4.");
                return;
            }

            var matchingRefrigerators = appliances.Where(a => a is Refrigerator && ((Refrigerator)a).NumberOfDoors == doors);
            if (matchingRefrigerators.Any())
            {
                Console.WriteLine("Matching refrigerators:");
                foreach (var refrigerator in matchingRefrigerators)
                {
                    Console.WriteLine(refrigerator);
                }
            }
            else
            {
                Console.WriteLine("No matching refrigerators found.");
            }
        }

        static void DisplayVacuums(List<Appliance> appliances)
        {
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");
            string voltageInput = Console.ReadLine();
            if (voltageInput != "18" && voltageInput != "24")
            {
                Console.WriteLine("Invalid input. Please enter 18 or 24.");
                return;
            }

            var matchingVacuums = appliances.Where(a => a is Vacuum && ((Vacuum)a).BatteryVoltage == int.Parse(voltageInput));
            if (matchingVacuums.Any())
            {
                Console.WriteLine("Matching vacuums:");
                foreach (var vacuum in matchingVacuums)
                {
                    Console.WriteLine(vacuum);
                }
            }
            else
            {
                Console.WriteLine("No matching vacuums found.");
            }
        }

        static void DisplayMicrowaves(List<Appliance> appliances)
        {
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
            string roomType = Console.ReadLine();
            if (roomType != "K" && roomType != "W")
            {
                Console.WriteLine("Invalid input. Please enter K or W.");
                return;
            }

            var matchingMicrowaves = appliances.Where(a => a is Microwave && ((Microwave)a).RoomType == roomType);
            if (matchingMicrowaves.Any())
            {
                Console.WriteLine("Matching microwaves:");
                foreach (var microwave in matchingMicrowaves)
                {
                    Console.WriteLine(microwave);
                }
            }
            else
            {
                Console.WriteLine("No matching microwaves found.");
            }
        }

        static void DisplayDishwashers(List<Appliance> appliances)
        {
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate):");
            string soundRating = Console.ReadLine();
            if (soundRating != "Qt" && soundRating != "Qr" && soundRating != "Qu" && soundRating != "M")
            {
                Console.WriteLine("Invalid input. Please enter Qt, Qr, Qu, or M.");
                return;
            }

            var matchingDishwashers = appliances.Where(a => a is Dishwasher && ((Dishwasher)a).SoundRating == soundRating);
            if (matchingDishwashers.Any())
            {
                Console.WriteLine("Matching dishwashers:");
                foreach (var dishwasher in matchingDishwashers)
                {
                    Console.WriteLine(dishwasher);
                }
            }
            else
            {
                Console.WriteLine("No matching dishwashers found.");
            }
        }
        public static void DisplayByType(List<Appliance> appliances)
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");
            Console.WriteLine("Enter type of appliance:");
            string applianceTypeInput = Console.ReadLine();
            if (!int.TryParse(applianceTypeInput, out int applianceType))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            switch (applianceType)
            {
                case 1:
                    DisplayRefrigerators(appliances);
                    break;
                case 2:
                    DisplayVacuums(appliances);
                    break;
                case 3:
                    DisplayMicrowaves(appliances);
                    break;
                case 4:
                    DisplayDishwashers(appliances);
                    break;
                default:
                    Console.WriteLine("Invalid appliance type. Please enter a valid option.");
                    break;
            }
        }

        public static void DisplayRandomAppliances(List<Appliance> appliances)
        {
            Console.WriteLine("Enter number of appliances: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfAppliances))
            {
                if (numberOfAppliances <= 0)
                {
                    Console.WriteLine("Number of appliances should be greater than 0.");
                    return;
                }

                Random random = new Random();
                HashSet<int> indexes = new HashSet<int>();

                
                while (indexes.Count < Math.Min(numberOfAppliances, appliances.Count))
                {
                    indexes.Add(random.Next(appliances.Count));
                }

                
                Console.WriteLine($"Displaying {Math.Min(numberOfAppliances, indexes.Count)} random appliances:");
                foreach (int index in indexes)
                {
                    Console.WriteLine(appliances[index]);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        public static void SaveAppliancesToFile(List<Appliance> appliances, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Appliance appliance in appliances)
                    {
                        
                        writer.WriteLine(appliance.ToFileFormat());
                    }
                }
                Console.WriteLine("Appliances saved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving appliances to file: {ex.Message}");
            }
        }
    }
}
           

