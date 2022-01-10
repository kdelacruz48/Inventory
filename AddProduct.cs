using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KyleDelacruzc968
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
            

            dgvAddAllParts.DataSource = Inventory.AllParts;
           

        }

        

        public static DataGridViewRow IndexRow;
         


        string Name1;
        int Name2;
        decimal Price1;
        int InStock1;
        int Min1;
        int Max1;


        string TempPri;
        string TempInS;
        string TempMin;
        string TempMax;


        decimal Price3;
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            BindingList<Part> Temp2 = new BindingList<Part>();
            bool found = false;
            if (textBoxSearch.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    dgvAddAllParts.DataSource = Inventory.AllParts;

                    IndexRow = dgvAddAllParts.Rows[i];

                    var a1 = IndexRow.Cells[1].Value + string.Empty;
                    var b1 = IndexRow.Cells[2].Value + string.Empty;
                    var c1 = IndexRow.Cells[3].Value + string.Empty;
                    var d1 = IndexRow.Cells[4].Value + string.Empty;
                    var e1 = IndexRow.Cells[5].Value + string.Empty;


                    string row = a1 + b1 + c1 + d1 + e1;





                    if (row.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                    {
                        Temp2.Add(Inventory.AllParts[i]);
                        found = true;
                    }




                }
                if (found)
                {
                    dgvAddAllParts.DataSource = Temp2;
                }


                if (!found)
                {
                    MessageBox.Show("Nothing found");
                    dgvAddAllParts.DataSource = Inventory.AllParts;
                }


            }

            else
            {
                dgvAddAllParts.DataSource = Inventory.AllParts;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dgvAddAllParts.SelectedRows.Count == 1)

            {



                IndexRow = dgvAddAllParts.SelectedRows[0];
                
                
                int a2;
                decimal c2;
                int d2;
                int e2;
                int f2;
                int g2;



                var a1 = IndexRow.Cells[0].Value + string.Empty;
                int.TryParse(a1, out a2);
                var b1 = IndexRow.Cells[1].Value + string.Empty;
                var c1 = IndexRow.Cells[3].Value + string.Empty;
                decimal.TryParse(c1, out c2);
                var d1 = IndexRow.Cells[2].Value + string.Empty;
                int.TryParse(d1, out d2);
                var e1 = IndexRow.Cells[4].Value + string.Empty;
                int.TryParse(e1, out e2);
                var f1 = IndexRow.Cells[5].Value + string.Empty;
                int.TryParse(f1, out f2);
                var g1 = IndexRow.Cells[6].Value + string.Empty;
                int.TryParse(g1, out g2);

                Inhouse inhouse = new Inhouse( a2, b1, c2, d2, e2, f2, g2);

                Inventory.CurrentIndex = Main.dgvLastProduct-1;

                Inventory.Products[Inventory.CurrentIndex].TempList2.Add(inhouse);
                dgvAssociatedParts.DataSource = Inventory.Products[Inventory.CurrentIndex].TempList2;


            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {

            try
            {
                Inhouse spare = new Inhouse();

                IndexRow = dgvAssociatedParts.SelectedRows[0];
                spare = (Inhouse)dgvAssociatedParts.CurrentRow.DataBoundItem; 
                Inventory.Products[Inventory.CurrentIndex].TempList2.Remove(spare);
            }
            catch (Exception)
            {



                if (dgvAssociatedParts.SelectedRows.Count == 1)
                {


                    Inhouse spare = new Inhouse();

                    IndexRow = dgvAssociatedParts.SelectedRows[0];
                    spare = (Inhouse)dgvAssociatedParts.CurrentRow.DataBoundItem;
                    Inventory.Products[Inventory.CurrentIndex].TempList2.Remove(spare);
                }

            }    
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            {

                var ID1 = Main.dgvProductCount;
                Name1 = textBoxName.Text;
                TempPri = textPrice.Text;               //
                decimal.TryParse(TempPri, out Price1);  //
                var Price2 = Price1.ToString("F2");    //   makes 2 decimal places 
                decimal.TryParse(Price2, out Price3);   //
                TempInS = textBoxInventory.Text;
                Int32.TryParse(TempInS, out InStock1);
                TempMin = textMin.Text;
                Int32.TryParse(TempMin, out Min1);
                TempMax = textMax.Text;
                Int32.TryParse(TempMax, out Max1);



                //Input validation

                if (textBoxName.Text == string.Empty)
                {
                    MessageBox.Show("No Name Input");
                    return;
                }

                else if (int.TryParse(Name1, out Name2) == true)
                {
                    MessageBox.Show("Please enter a valid name");
                }

                else if (textPrice.Text == string.Empty || decimal.TryParse(TempPri, out Price1) == false)
                {
                    MessageBox.Show("Please enter a valid decimal");
                }

                else if (textBoxInventory.Text == string.Empty || Int32.TryParse(TempInS, out InStock1) == false)
                {
                    MessageBox.Show("Please enter a valid Inventory number");
                }

                else if (textMin.Text == string.Empty || Int32.TryParse(TempMin, out Min1) == false)
                {
                    MessageBox.Show("Please enter a valid minumum number");
                }

                else if (textMax.Text == string.Empty || Int32.TryParse(TempMax, out Max1) == false)
                {
                    MessageBox.Show("Please enter a valid maximum number");
                }

                else if (Min1 > Max1 || Max1 < Min1 || InStock1 < Min1 || InStock1 >Max1)
                {
                    MessageBox.Show("Inventory must fall between min and max");
                }

                //create and add part
                else
                {

                    Product product = new Product();


                    product.ProductID = ID1;
                    product.Name = Name1;
                    product.Price = Price3;
                    product.Inventory = InStock1;
                    product.Min = Min1;
                    product.Max = Max1;


                    

                    Inventory.AddProduct(product);

                    Inventory.CurrentIndex = Main.dgvLastProduct-1;
                    Inventory.CurrentIndex++;
                    

                    foreach (Part p in Inventory.Products[Inventory.CurrentIndex -1].TempList2)
                    {
                        Inventory.Products[Inventory.CurrentIndex].AssociatedParts.Add(p);
                        
                        
                        this.dgvAssociatedParts.EndEdit();
                        this.dgvAssociatedParts.Refresh();
                        this.dgvAssociatedParts.Update();


                    }

                    foreach (Part p in Inventory.Products[Inventory.CurrentIndex - 1].TempList2)
                    {
                        Inventory.Products[Inventory.CurrentIndex].TempList.Add(p);


                        this.dgvAssociatedParts.EndEdit();
                        this.dgvAssociatedParts.Refresh();
                        this.dgvAssociatedParts.Update();


                    }

                  
                    Inventory.Products[Inventory.CurrentIndex-1].TempList2.Clear();
              
                    Main.dgvProductCount++;
                    Main.dgvLastProduct++;

                    

                    this.Close();
                    
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            
                Inventory.Products[Inventory.CurrentIndex].TempList2.Clear();
                
            
            this.Close();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            dgvAssociatedParts.EndEdit();
            dgvAssociatedParts.Refresh();
            dgvAssociatedParts.Update();
        }

        private void dgvAddAllParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAddAllParts_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvAssociatedParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvAssociatedParts_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void dgvAssociatedParts_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvAssociatedParts.EndEdit();
            dgvAssociatedParts.Refresh();
            dgvAssociatedParts.Update();
        }

        private void AddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
