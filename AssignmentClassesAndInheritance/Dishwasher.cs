using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClassesAndInheritance
{
    class Dishwasher: Appliance
    {
        public string Feature;
        public string SoundRating;

        public Dishwasher()
        { }

        public Dishwasher(int ItemNumber ,string Brand,int Quantity,int Wattage,
            string Color,double Price, string Feature, string SoundRating) 
        {
            this.ItemNumber = ItemNumber;
            this.Brand = Brand; 
            this.Quantity = Quantity;
            this.Wattage = Wattage;
            this.Color = Color;
            this.Price = Price;
            this.Feature = Feature;
            this.SoundRating = SoundRating;
        }
        public override string ToString()
        {
            return $"Item number: {ItemNumber} \nBrand: {Brand} \nQuantity: {Quantity} " +
                $"\nWattage: {Wattage} \nColor: {Color} \nPrice: {Price} \nFeature: {Feature}" +
                $"\nSound rating: {SoundRating}";
        }
        public override string ToFileFormat()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRating};";
        }
    }
}
