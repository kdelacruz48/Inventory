using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyleDelacruzc968
{
    class Inhouse : Part
    {

        public int MachineID { get; set; }


        public Inhouse()
        {

        }

        public Inhouse(int PartID,string Name, decimal Price, int InStock, int Min, int Max, int MachineID)
        {
            this.PartID = PartID;
            this.Name = Name;
            this.Price = Price;
            this.Inventory = InStock;
            this.Min = Min;
            this.Max = Max;
            this.Source = MachineID + string.Empty;



        }

        
    }
}
