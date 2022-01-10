using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KyleDelacruzc968
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        

        int Instock { get; set; }

        public  BindingList<Part> AssociatedParts = new BindingList<Part>();
        public BindingList<Part> TempList = new BindingList<Part>();
        public BindingList<Part> TempList2 = new BindingList<Part>();
        public BindingList<Part> Copy = new BindingList<Part>();
        public BindingList<Part> Copy2 = new BindingList<Part>();

        public static bool removed;




        public Product(int ProductID, string Name, decimal Price, int InStock, int Min, int Max)
        {

            

            this.ProductID = ProductID;
            this.Name = Name;
            this.Price = Price;
            this.Inventory = InStock;
            this.Min = Min;
            this.Max = Max;
            

           
            
        }
            
         
        public Product()
        {

        }

        

        public void addAssociatedPart(Part part)
        {

            
            TempList.Add(part);
            
        }




        public bool removeAssociatedPart(int PartID)
        {

            foreach (Part p in TempList)
            {
                if (PartID == p.PartID)
                {
                    TempList.Remove(p);
                    return true;
                }



            }
            return false;

            

        }

        public bool removeAssociatedPartM(int PartID)
        {
            foreach (Part p in AssociatedParts)
            {
                if (PartID == p.PartID)
                {
                    AssociatedParts.Remove(p);
                }
            }
            return false;
        }

        public  Part lookupAssociatedPart(int PartID)
        {
            foreach (Part p in AssociatedParts)
            {
                if (p.PartID == PartID)
                {

                    // AddPart(p); -----verified fuctionality with this, but made what I think is a better search funtion without using it,
                    //                   as this would only search by PartID, but my search can find individual letters. Hope that is fine :)
                    return p;
                }
            }
            return null;
        }







    }
}
