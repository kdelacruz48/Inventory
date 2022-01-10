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
    public partial class ModifyProduct : Form
    {
        public ModifyProduct()
        {
            InitializeComponent();

            dgvModifyAllParts.DataSource = Inventory.AllParts;
            dgvAssociatedParts.DataSource = Inventory.Products[Main.SelectedProduct].AssociatedParts;
            dgvAssociatedParts.EndEdit();
            dgvAssociatedParts.Refresh();
            dgvAssociatedParts.Update();


            bool equalss = Inventory.Products[Main.SelectedProduct].AssociatedParts.SequenceEqual(Inventory.Products[Main.SelectedProduct].TempList);
            if (equalss is false)
                foreach (Part p in Inventory.Products[Main.SelectedProduct].AssociatedParts)
                {
                    Inventory.Products[Main.SelectedProduct].TempList.Add(p);
                }
            


            foreach (Part p in Inventory.Products[Main.SelectedProduct].AssociatedParts)
            {
                Inventory.Products[Main.SelectedProduct].Copy.Add(p);
            }

            foreach (Part p in Inventory.Products[Main.SelectedProduct].AssociatedParts)
            {
                Inventory.Products[Main.SelectedProduct].Copy2.Add(p);
            }
            
            
        }


        public static DataGridViewRow IndexRow;
        public static DataGridViewRow NewIndex;

        Product product = new Product();

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
        int AddAfter;
        int Addcount;
        decimal Price3;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            BindingList<Part> Temp2 = new BindingList<Part>();
            bool found = false;
            if (textBoxSearch.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    dgvModifyAllParts.DataSource = Inventory.AllParts;

                    IndexRow = dgvModifyAllParts.Rows[i];

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
                    dgvModifyAllParts.DataSource = Temp2;
                }


                if (!found)
                {
                    MessageBox.Show("Nothing found");
                    dgvModifyAllParts.DataSource = Inventory.AllParts;
                }


            }

            else
            {
                dgvModifyAllParts.DataSource = Inventory.AllParts;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {




            Inventory.Products[Main.SelectedProduct].AssociatedParts.Clear();
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();


            if (dgvModifyAllParts.SelectedRows.Count == 1)

                {
                
                

                    IndexRow = dgvModifyAllParts.SelectedRows[0];


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

                    Inhouse inhouse = new Inhouse(a2, b1, c2, d2, e2, f2, g2);

          

                    Inventory.Products[Main.SelectedProduct].addAssociatedPart(inhouse);
                
                    dgvAssociatedParts.DataSource = Inventory.Products[Main.SelectedProduct].TempList;


                }

            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            {

                var ID1 = Main.SelectedProduct;
                Name1 = textBoxName.Text;
                TempPri = textBoxPrice.Text;               //
                decimal.TryParse(TempPri, out Price1);  //
                var Price2 = Price1.ToString("F2");    //   makes 2 decimal places 
                decimal.TryParse(Price2, out Price3);   //
                TempInS = textBoxInventory.Text;
                Int32.TryParse(TempInS, out InStock1);
                TempMin = textBoxMin.Text;
                Int32.TryParse(TempMin, out Min1);
                TempMax = textBoxMax.Text;
                Int32.TryParse(TempMax, out Max1);
                
                
                bool equal = Inventory.Products[Main.SelectedProduct].Copy.SequenceEqual(Inventory.Products[Main.SelectedProduct].TempList);

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

                else if (textBoxPrice.Text == string.Empty || decimal.TryParse(TempPri, out Price1) == false)
                {
                    MessageBox.Show("Please enter a valid decimal");
                }

                else if (textBoxInventory.Text == string.Empty || Int32.TryParse(TempInS, out InStock1) == false)
                {
                    MessageBox.Show("Please enter a valid Inventory number");
                }

                else if (textBoxMin.Text == string.Empty || Int32.TryParse(TempMin, out Min1) == false)
                {
                    MessageBox.Show("Please enter a valid minumum number");
                }

                else if (textBoxMax.Text == string.Empty || Int32.TryParse(TempMax, out Max1) == false)
                {
                    MessageBox.Show("Please enter a valid maximum number");
                }
                else if (Min1 > Max1 || Max1 < Min1 || InStock1 < Min1 || InStock1 > Max1)
                {
                    MessageBox.Show("Inventory must fall between min and max");
                }

              

                else
                {
                        
                        Inventory.Products[Main.SelectedProduct].Name = Name1;
                        Inventory.Products[Main.SelectedProduct].Price = Price3;
                        Inventory.Products[Main.SelectedProduct].Inventory = InStock1;
                        Inventory.Products[Main.SelectedProduct].Min = Min1;
                        Inventory.Products[Main.SelectedProduct].Max = Max1;


                        Inventory.CurrentIndex = Main.SelectedProduct;

                        Inventory.Products[Main.SelectedProduct].AssociatedParts.Clear();

                        foreach (var p in Inventory.Products[Main.SelectedProduct].TempList)
                        {
                            Inventory.Products[Main.SelectedProduct].AssociatedParts.Add(p);
                        }




                        Inventory.Products[Main.SelectedProduct].Copy.Clear();
        
                        dgvAssociatedParts.Refresh();
                        this.Close();
                   
                }
                
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
          
            
            if (dgvAssociatedParts.SelectedRows.Count == 1)
            {


               

                Inhouse tempPart = new Inhouse();
                tempPart = (Inhouse)dgvAssociatedParts.CurrentRow.DataBoundItem;

                dgvAssociatedParts.DataSource = Inventory.Products[Main.SelectedProduct].TempList;


                Inventory.Products[Main.SelectedProduct].removeAssociatedPart(tempPart.PartID);
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            bool equale = Inventory.Products[Main.SelectedProduct].AssociatedParts.SequenceEqual(Inventory.Products[Main.SelectedProduct].TempList);

            if (equale is false)
            {
                MessageBox.Show("PLease save changes to part list");
            }

            else
            {
                Inventory.Products[Main.SelectedProduct].TempList.Clear();
                dgvAssociatedParts.Refresh();
                this.Close();
            }
            
        }

        private void ModifyProduct_Load(object sender, EventArgs e)
        {
            
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();
        }

        private void dgvAssociatedParts_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();


        }

        private void dgvAssociatedParts_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();
        }

        private void dgvAssociatedParts_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void dgvAssociatedParts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void dgvAssociatedParts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();
        }

        private void dgvAssociatedParts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();
        }

        private void dgvAssociatedParts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();
        }

        private void dgvAssociatedParts_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvAssociatedParts.EndEdit();
            this.dgvAssociatedParts.Refresh();
            this.dgvAssociatedParts.Update();
        }

        private void dgvAssociatedParts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }
    }
}
