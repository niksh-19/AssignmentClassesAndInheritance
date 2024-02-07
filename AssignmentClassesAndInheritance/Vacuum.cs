using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClassesAndInheritance
{
    class Vacuum: Appliance
    {
        public string Grade;
        public int BatteryVoltage;
        public Vacuum()
        { }

        public Vacuum(int ItemNumber, string Brand, int Quantity, int Wattage,
            string Color, double Price, string Grade, int BatteryVoltage)
        {
            this.ItemNumber = ItemNumber;
            this.Brand = Brand;
            this.Quantity = Quantity;
            this.Wattage = Wattage;
            this.Color = Color;
            this.Price = Price;
            this.Grade = Grade;
            this.BatteryVoltage = BatteryVoltage;
        }
        public override string ToString()
        {
            return $"Item number: {ItemNumber} \nBrand: {Brand} \nQuantity: {Quantity} " +
                $"\nWattage: {Wattage} \nColor: {Color} \nPrice: {Price} \nGrade: {Grade}" +
                $"\nBatteryVoltage: {BatteryVoltage}";
        }
        public override string ToFileFormat()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage}";
        }
    }
}
