using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClassesAndInheritance
{
    class Microwave: Appliance
    {
        public decimal Capacity;
        public string RoomType;
        public Microwave()
        { }
        public Microwave(int ItemNumber, string Brand, int Quantity, int Wattage,
            string Color, double Price, decimal Capacity, string RoomType)
        {
            this.ItemNumber = ItemNumber;
            this.Brand = Brand;
            this.Quantity = Quantity;
            this.Wattage = Wattage;
            this.Color = Color;
            this.Price = Price;
            this.Capacity = Capacity;
            this.RoomType = RoomType;
        }
        public override string ToString()
        {
            return $"Item number: {ItemNumber} \nBrand: {Brand} \nQuantity: {Quantity} " +
                $"\nWattage: {Wattage} \nColor: {Color} \nPrice: {Price} \nCapacity: {Capacity} " +
                $"\nRoom Type: {RoomType}";
        }
        public override string ToFileFormat()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{RoomType}";
        }
    }
}
