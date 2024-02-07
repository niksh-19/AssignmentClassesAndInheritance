using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClassesAndInheritance
{
    public class Refrigerator: Appliance
    {
        public int NumberOfDoors;
        public int Height;
        public int Width;
        public Refrigerator()
        { }
        

        public Refrigerator(int ItemNumber, string Brand, int Quantity, int Wattage,
            string Color, double Price, int NumberOfDoors, int Height, int Width)
        {
            this.ItemNumber = ItemNumber;
            this.Brand = Brand;
            this.Quantity = Quantity;
            this.Wattage = Wattage;
            this.Color = Color;
            this.Price = Price;
            this.NumberOfDoors = NumberOfDoors;
            this.Height = Height;
            this.Width = Width;
        }
        
        public override string ToString()
        {
            return $"Item number: {ItemNumber} \nBrand: {Brand} \nQuantity: {Quantity} " +
                $"\nWattage: {Wattage} \nColor: {Color} \nPrice: {Price} \nNumber of Doors: {NumberOfDoors}" +
                $"\nHeight: {Height} \nWidth: {Width}";
        }
        public override string ToFileFormat()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{NumberOfDoors};{Height};{Width}";
        }
    }
}
