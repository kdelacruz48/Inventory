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
    public partial class Main : Form
    {
        public Main()
        {


            InitializeComponent();
            dgvParts.DataSource = Inventory.AllParts;
            dgvProducts.DataSource = Inventory.Products;


            dgvProducts.ReadOnly = true;
            dgvParts.ReadOnly = true;


            
            Inventory.AddData();
            Inventory.AddProducts();

            dgvLastPart = dgvParts.RowCount;
            dgvLastProduct = dgvProducts.RowCount;

            dgvProductCount = dgvLastProduct + 1;
            dgvPartCount = dgvLastPart + 1;

           

        }



        public static int dgvLastPart;
        public static int dgvLastProduct;
        public static int dgvPartCount;
        public static int dgvProductCount;
        public static DataGridViewRow IndexRow;
        public static int SelectedProduct;
        public static int SelectedPart;

        private void buttonModifyProduct_Click(object sender, EventArgs e)
        {
            ModifyProduct mp1 = new ModifyProduct();

            
            mp1.FormClosed += new FormClosedEventHandler(Form_Closed);  //found this online https://stackoverflow.com/questions/30536808/know-when-child-form-closed
                                                                        //could not make updates happen without clicking another cell
            void Form_Closed(object sender1, EventArgs e1)
            { 
                ModifyProduct form = (ModifyProduct)sender1;
                
                dgvProducts.EndEdit();
                dgvProducts.Refresh();
                dgvProducts.Update();

            }


            mp1.Show();


            if (dgvProducts.SelectedRows.Count == 1)

            {

                string NameM;
                string InventoryM;
                string PriceM;
                string MinM;
                string MaxM;
                string IDM;


                IDM = dgvProducts.SelectedRows[0].Cells[0].Value + string.Empty;
                NameM = dgvProducts.SelectedRows[0].Cells[1].Value + string.Empty;
                InventoryM = dgvProducts.SelectedRows[0].Cells[2].Value + string.Empty; ;
                PriceM = dgvProducts.SelectedRows[0].Cells[3].Value + string.Empty;
                MinM = dgvProducts.SelectedRows[0].Cells[4].Value + string.Empty;
                MaxM = dgvProducts.SelectedRows[0].Cells[5].Value + string.Empty;

                mp1.textBoxID.Text = IDM;
                mp1.textBoxName.Text = NameM;
                mp1.textBoxInventory.Text = InventoryM;
                mp1.textBoxPrice.Text = PriceM;
                mp1.textBoxMin.Text = MinM;
                mp1.textBoxMax.Text = MaxM;

                SelectedProduct = dgvProducts.SelectedRows[0].Index;
                

                var current = Convert.ToInt32(IDM);



                Inventory.CurrentIndex = current;


                mp1.dgvAssociatedParts.DataSource = Inventory.Products[SelectedProduct].AssociatedParts;
 

            }

            else
            {
                mp1.Close();
                MessageBox.Show("please select a row");
            }
        }

        private void SearchParts_Click(object sender, EventArgs e)  //This code was based on the webinar provided by the class, but I added my own code as well
        {
            BindingList<Part> Temp = new BindingList<Part>();
            bool found = false;
            if (textBoxSearch.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    dgvParts.DataSource = Inventory.AllParts;

                    IndexRow = dgvParts.Rows[i];

                    var a1 = IndexRow.Cells[1].Value + string.Empty;
                    var b1 = IndexRow.Cells[2].Value + string.Empty;
                    var c1 = IndexRow.Cells[3].Value + string.Empty;
                    var d1 = IndexRow.Cells[4].Value + string.Empty;
                    var e1 = IndexRow.Cells[5].Value + string.Empty;
                    var f1 = IndexRow.Cells[6].Value + string.Empty;

                    string row = a1 + b1 + c1 + d1 + e1 + f1;



                    if (row.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                    {
                        Temp.Add(Inventory.AllParts[i]);
                        found = true;
                    }




                }
                if (found)
                {
                    dgvParts.DataSource = Temp;
                }


                if (!found)
                {
                    MessageBox.Show("Nothing found");
                    dgvParts.DataSource = Inventory.AllParts;
                }


            }

            else
            {
                dgvParts.DataSource = Inventory.AllParts;
            }

        }
    

        private void searchProducts_Click(object sender, EventArgs e)
        {
            BindingList<Product> Temp2 = new BindingList<Product>();
            bool found = false;
            if (textBoxSearch2.Text != "")
            {
                for (int i = 0; i < Inventory.Products.Count; i++)
                {
                    dgvProducts.DataSource = Inventory.Products;

                    IndexRow = dgvProducts.Rows[i];

                    var a1 = IndexRow.Cells[1].Value + string.Empty;
                    var b1 = IndexRow.Cells[2].Value + string.Empty;
                    var c1 = IndexRow.Cells[3].Value + string.Empty;
                    var d1 = IndexRow.Cells[4].Value + string.Empty;
                    var e1 = IndexRow.Cells[5].Value + string.Empty;


                    string row = a1 + b1 + c1 + d1 + e1;





                    if (row.ToUpper().Contains(textBoxSearch2.Text.ToUpper()))
                    {
                        Temp2.Add(Inventory.Products[i]);
                        found = true;
                    }




                }
                if (found)
                {
                    dgvProducts.DataSource = Temp2;
                }


                if (!found)
                {
                    MessageBox.Show("Nothing found");
                    dgvProducts.DataSource = Inventory.Products;
                }


            }

            else
            {
                dgvProducts.DataSource = Inventory.Products;
            }
        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            AddPart a1 = new AddPart();
            a1.Show();
        }

        private void buttonModifyPart_Click(object sender, EventArgs e)
        {

            ModifyPart m1 = new ModifyPart();
            m1.Show();

            if (dgvParts.SelectedRows.Count == 1)

            {

                string NameM;
                string InventoryM;
                string PriceM;
                string MinM;
                string MaxM;
                string SourceM;


                NameM = dgvParts.SelectedRows[0].Cells[1].Value + string.Empty;
                InventoryM = dgvParts.SelectedRows[0].Cells[2].Value + string.Empty; ;
                PriceM = dgvParts.SelectedRows[0].Cells[3].Value + string.Empty;
                MinM = dgvParts.SelectedRows[0].Cells[4].Value + string.Empty;
                MaxM = dgvParts.SelectedRows[0].Cells[5].Value + string.Empty;
                SourceM = dgvParts.SelectedRows[0].Cells[6].Value + string.Empty;

                m1.textBoxName.Text = NameM;
                m1.textBoxInventory.Text = InventoryM;
                m1.textBoxPrice.Text = PriceM;
                m1.textBoxMin.Text = MinM;
                m1.textBoxMax.Text = MaxM;
                m1.textBoxSource.Text = SourceM;


                IndexRow = dgvParts.SelectedRows[0];


                

            }

            else
            {
                m1.Close();
                MessageBox.Show("please select a row");
            }
        }

        private void buttonDeletePart_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 1)

            {

                Inhouse tempPart = new Inhouse();
                tempPart = (Inhouse) dgvParts.CurrentRow.DataBoundItem;

               
                Inventory.DeletePart(tempPart);

            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {


            AddProduct AP1 = new AddProduct();
            AP1.Show();

            var currentAdd = dgvLastProduct - 1;


            Inventory.CurrentIndex = currentAdd;


        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 1)

            {

                IndexRow = dgvProducts.SelectedRows[0];
                var index1 = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                Product Temporary = new Product();
                Temporary = (Product)dgvProducts.CurrentRow.DataBoundItem;



                if (index1 == 1 || index1 == 2 || index1 == 3)
                
                {

                   

                    MessageBox.Show("Cannot Delete Original Products");
                    
                }


                else if (Temporary.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("Cannot delete products with parts");
                }

                else
                {
                    Product tempProduct = new Product();
                    tempProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;




                    Inventory.RemoveProduct(tempProduct.ProductID);

                    dgvLastProduct--;
                    dgvProductCount--;
                }
            }

            


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void dgvParts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //IndexRow = dgvProducts.SelectedRows[0];
            //var current = (int)IndexRow.Cells[0].Value;
            dgvProducts.Rows.GetRowState(0);
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();

            //Inventory.CurrentIndex = current;

        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }

        private void dgvProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            dgvProducts_CellClick(null, null);
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();


        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }

        private void dgvProducts_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            
        }

        private void dgvProducts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }

        private void dgvProducts_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.EndEdit();
            dgvProducts.Refresh();
            dgvProducts.Update();
        }
    }
}
