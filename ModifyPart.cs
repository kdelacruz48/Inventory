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
    public partial class ModifyPart : Form
    {
        public ModifyPart()
        {
            InitializeComponent();
        }
        string ID1;
        int ID2;
        string Name1;
        int Name2;
        decimal Price1;
        int InStock1;
        int Min1;
        int Max1;
        string CompanyName1;
        int CompanyName2;
        int MachineID1;
        string Source1;

        string TempPri;
        string TempInS;
        string TempMin;
        string TempMax;
        string TempID;

        decimal Price3;

        private void radioButtonInHouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInHouse.Checked == true)
            {
                label7.Text = "MachineID(Source)";
            }
            else
            {
                label7.Text = "Company Name(Source)";
            }
        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (radioButtonInHouse.Checked == true)
            {
                ID1 = Main.IndexRow.Cells[0].Value + string.Empty;
                Int32.TryParse(ID1, out ID2);
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
                TempID = textBoxSource.Text;
                Int32.TryParse(TempID, out MachineID1);


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

                else if (textBoxSource.Text == string.Empty || Int32.TryParse(TempID, out MachineID1) == false)
                {
                    MessageBox.Show("Please enter a valid Machine ID");
                }
                else if (Min1 > Max1 || Max1 < Min1 || InStock1 < Min1 || InStock1 > Max1)
                {
                    MessageBox.Show("Inventory must fall between min and max");
                }

                else
                {
                    


                    Inhouse inhouse = new Inhouse(ID2,Name1,Price1,InStock1,Min1,Max1,MachineID1);
                    Inventory.UpdatePart(ID2, inhouse);


                    this.Close();
                }

            }

            else
            {
                ID1 = Main.IndexRow.Cells[0].Value + string.Empty;
                Int32.TryParse(ID1, out ID2);
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
                CompanyName1 = textBoxSource.Text;
                Int32.TryParse(CompanyName1, out CompanyName2);



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

                else if (textBoxSource.Text == string.Empty || Int32.TryParse(CompanyName1, out CompanyName2) == true)
                {
                    MessageBox.Show("Please enter a Company Name");
                }
                else if (Min1 > Max1 || Max1 < Min1 || InStock1 < Min1 || InStock1 > Max1)
                {
                    MessageBox.Show("Inventory must fall between min and max");
                }
                else
                {

                    Outsourced outsourced = new Outsourced(ID2, Name1, Price1, InStock1, Min1, Max1, CompanyName1);
                    Inventory.UpdatePart(ID2, outsourced);

                    this.Close();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyPart_Load(object sender, EventArgs e)
        {

        }
    }
}
