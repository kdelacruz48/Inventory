using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyleDelacruzc968
{
    class Outsourced : Part
    {
        public string CompanyName { get; set; }

        public Outsourced(int PartID,string Name, decimal Price, int InStock, int Min, int Max, string CompanyName)
        {
            this.PartID = PartID;
            this.Name = Name;
            this.Price = Price;
            this.Inventory = InStock;
            this.Min = Min;
            this.Max = Max;
            this.Source = CompanyName;

        }
    }
}
