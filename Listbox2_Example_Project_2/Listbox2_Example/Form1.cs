using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listbox1_Example
{
    public partial class Form1 : Form
    {
        // Any collection, including arrays could be used. 
        // A List<string> is used here. This is a List object designated for use with strings.
        List<string> gStringsSource = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            AddNumbericValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNumbericValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderByAscending(gStringsSource);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderByDescending(gStringsSource);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetToOriginalOrder(gStringsSource);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FindNumber(gStringsSource);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gStringsSource.Clear();
            UpdateListBox(gStringsSource);
        }

        //Add a number of value to the list. Change length to add more or fewer items each time.
        private void AddNumbericValues()
        {
            // This represents gather the information, and is not not a direct part of the demo.
            // You can create or collect the information from a variety of places including a 
            // file.

            // Making this much larger slows the application down, not because loading the Listbox
            // takes longer, but the loop mechanism is slow. Ignore any delays caused by a large number here.
            long length = 30000;
            for (long i = 0; i < length; i++)
            {
                string theItem = string.Format("This is item: {0}", i);
                gStringsSource.Add(theItem);

                Application.DoEvents();
            }


            // Update the listbox.
            UpdateListBox(gStringsSource);

            //This is optional. If nothing is already selected, select the first item as a help to the user.
            if (listBox1.SelectedIndex == -1) listBox1.SelectedIndex = 0;
        }

        private void OrderByAscending(List<string> myStringList)
        {
            // This is a Microsoft LINQ call. LINQ is a vertasile utility to sort or search
            //  collections. It is very fast and convenient.
            var ascendingOrderList = myStringList.OrderBy(x => x).ToList();
            UpdateListBox(ascendingOrderList);

            // Optionally, it can one line.
            // UpdateListBox(myStringList.OrderBy(x => x).ToList());
        }

        private void OrderByDescending(List<string> myStringList)
        {
            // This is a Microsoft LINQ call. LINQ is a vertasile utility to sort or search
            //  collections. It is very fast and convenient.
            var descendingOrderList = myStringList.OrderByDescending(x => x).ToList();
            UpdateListBox(descendingOrderList);
        }

        private void SetToOriginalOrder(List<string> myStringList)
        {
            // No sorting needed. Just use the original List.
            UpdateListBox(myStringList);
        }

        private void FindNumber(List<string> myStringList)
        {
            string theNumber = textBox1.Text.Trim();

            // Check that the value is numeric.
            int n;
            bool isNumeric = int.TryParse(theNumber, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("The value is not numeric.\r\n\r\nPlease enter a numeric value.", "Not numeric", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Search for strings containing that number.
            var numberList = gStringsSource.Where(s => s.Contains(theNumber.ToString())).ToList();

            UpdateListBox(numberList);
        }

        private void UpdateListBox(List<string> theList)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = theList;
            label1.Text = string.Format("Items in list: {0:n0}", listBox1.Items.Count);
        }
    }
}
