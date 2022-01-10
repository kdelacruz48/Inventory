using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyleDelacruzc968
{
    public class Inventory
    {


        public static BindingList<Part> AllParts = new BindingList<Part>();
        public static BindingList<Product> Products = new BindingList<Product>();

        public static int CurrentIndex { get; set; }

        public static int lastIndexA = AllParts.Count - 1;
        public static int lastIndexP = Products.Count - 1;
        public static bool removed;


        public static void AddData()
        {


            Inhouse filler = new Inhouse(1, "Wheel", 12.11m, 15, 5, 25, 01);
            AllParts.Add(filler);
            Inhouse filler1 = new Inhouse(2, "Pedal", 8.22m, 11, 5, 25, 02);
            AllParts.Add(filler1);
            Inhouse filler2 = new Inhouse(3, "Chain", 8.33m, 12, 5, 25, 03);
            AllParts.Add(filler2);
            Inhouse filler3 = new Inhouse(4, "Seat", 4.55m, 8, 2, 15, 04);
            AllParts.Add(filler3);

        }
        public static void AddProducts()
        {


            Product filler = new Product(1, "Red Bicycle", 11.44m, 15, 1, 25);
            Products.Add(filler);
            Product filler1 = new Product(2, "Yellow Bicycle", 9.66m, 19, 1, 20);
            Products.Add(filler1);
            Product filler2 = new Product(3, "Blue Bicycle", 12.77m, 5, 1, 25);
            Products.Add(filler2);

        }




        public static void AddProduct(Product products)
        {
            Products.Add(products);
        }

        public static bool RemoveProduct(int ProductID)
        {

            foreach (Product p in Products)
            {
                if (p.ProductID == ProductID)
                {
                    Products.Remove(p);
                    return true;
                }



            }
            return false;
        }

        public static Product lookupProduct(int ProductID)
        {
            foreach (Product p in Products)
            {
                if (p.ProductID == ProductID)
                {

             
                    return p;
                }
            }
            return null;

        }


        public static void UpdateProduct(int ProductID, Product Product)
        {
            

            foreach (Product p in Products)
            {
                if (ProductID == Product.ProductID)
                {

                    var ID = ProductID;

                    Main.IndexRow.Cells[1].Value = Product.Name;
                    Main.IndexRow.Cells[0].Value = ID;
                    Main.IndexRow.Cells[3].Value = Product.Price;
                    Main.IndexRow.Cells[2].Value = Product.Inventory;
                    Main.IndexRow.Cells[4].Value = Product.Min;
                    Main.IndexRow.Cells[5].Value = Product.Max;
                    






                }
            }
        }





        public static void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        public static bool DeletePart(Part part)
        {


            foreach (Part p in AllParts)
            {
                if(p == part)
                {
                    AllParts.Remove(p);
                    return true;
                }

               

            }
            return false;
        }

        public static Part lookupPart(int PartID)
        {
            foreach (Part p in AllParts)
            {
                if(p.PartID == PartID)
                {
                    
                   
                    return p;
                }
            }
            return null;
        }


        public static void UpdatePart(int PartID, Part Part)
        {
            foreach (Part p in AllParts)
            {
                if(PartID == Part.PartID)
                {

                    var ID = PartID;

                    Main.IndexRow.Cells[1].Value = Part.Name;
                    Main.IndexRow.Cells[0].Value = ID;
                    Main.IndexRow.Cells[3].Value = Part.Price;
                    Main.IndexRow.Cells[2].Value = Part.Inventory;
                    Main.IndexRow.Cells[4].Value = Part.Min;
                    Main.IndexRow.Cells[5].Value = Part.Max;
                    Main.IndexRow.Cells[6].Value = Part.Source;




                    

                }
            }
        }
    }
}
