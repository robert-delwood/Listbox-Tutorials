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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNumbericValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTextValues();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = "(No item selected)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }

        //Add a number of value to the list. Change length to add more or fewer items each time.
        private void AddNumbericValues()
        {
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                listBox1.Items.Add(i);
            }

            //This is optional. If nothing is already selected, select the first item as a help to the user.
            if (listBox1.SelectedIndex == -1) listBox1.SelectedIndex = 0;
        }

        //Add the value from textbox1 to the list.
        private void AddTextValues()
        {
            string theString = textBox1.Text.Trim();
            listBox1.Items.Add(theString);
            //This is optional. If nothing is already selected, select the first item as a help to the user.
            if (listBox1.SelectedIndex == -1) listBox1.SelectedIndex = 0;
        }

        private void DeleteSelectedItem()
        {
            int selectedIndex = listBox1.SelectedIndex;

            //If nothing is selected, return. There will be nothing to report. Added as a safety check.
            if (selectedIndex == -1) return;

            listBox1.Items.RemoveAt(selectedIndex);

            //Reset the selected row to the same row as just deleted.
            //There are three cases to account for.
            //1) It's the last item in the listbox. In that case, nothing needs to be highlighted.
            //2) It's the last item in the list of items. Then, highlight the one before it.
            //3) it's not the last item in the list. Then, highlight the replacement item.
            if (listBox1.Items.Count == 0) return;
            if (selectedIndex >= listBox1.Items.Count)
            {
                listBox1.SelectedIndex = selectedIndex -1;
                return;
            }
            if (listBox1.SelectedIndex == -1) listBox1.SelectedIndex = selectedIndex;
        }

        //This event occurs whenever the user makes a new selection in the list.
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            //If nothing is selected, return. There will be nothing to report. Added as a safety check.
            if (selectedIndex == -1) return;

            var selectedValue = listBox1.SelectedItem;
            label1.Text = string.Format("Selected index/value: {0}/{1}", selectedIndex, selectedValue);
        }
    }
}
