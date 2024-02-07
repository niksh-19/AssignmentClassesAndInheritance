using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClassesAndInheritance
{
     public abstract class Appliance
    {
        public int ItemNumber;
        public string Brand;
        public int Quantity;
        public int Wattage;
        public string Color;
        public double Price;

        public abstract string ToFileFormat();
    }
    
    
}
