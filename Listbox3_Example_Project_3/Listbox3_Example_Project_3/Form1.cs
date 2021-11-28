using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listbox3_Example_Project_3
{
    public partial class Form1 : Form
    {
        List<Person> gPersonList = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a database. A practical source would be a file or real time entry.
            // See the Constructor method within the class Person.
            gPersonList.Add(new Person("Andy", "Anselman", 29, 1));
            gPersonList.Add(new Person("Boyd", "Braterschight", 45, 200));
            gPersonList.Add(new Person("Charlie", "Chaleston", 17, 324));
            gPersonList.Add(new Person("Danno", "Devenschultz", 56, 245));
            gPersonList.Add(new Person("Everest", "Enselman", 62, 573));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = gPersonList;
            listBox1.DisplayMember = "NameFirst";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton whichBox = (RadioButton)sender;

            if (whichBox.Checked == true)
            {
                if (whichBox.Name == "radioButton1")
                {
                    listBox1.DisplayMember = "NameFirst";
                }
                else if (whichBox.Name == "radioButton2")
                {
                    listBox1.DisplayMember = "NameLast";
                }
                else
                {
                    listBox1.DisplayMember = "GetUserDetails";
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the selected item, but you have to cast it to the correct class
            var mySelectedItem = (Person)((ListBox) sender).SelectedItem;

            if (mySelectedItem != null)
            {
                MessageBox.Show(string.Format("The person you selected is {0} {1},\r\nage {2}, and\r\nemployee number {3}.",
                    mySelectedItem.NameFirst, mySelectedItem.NameLast, mySelectedItem.Age, mySelectedItem.EmployeeNumber),
                    "Selected Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

// Class to be used with the ListBox
public class Person
{
    // Properties
    public string NameFirst { get; set; }
    public string NameLast { get; set; }
    public int Age { get; set; }
    public int EmployeeNumber { get; set; }

    // Constructor
    public Person(string firstname, string lastname, int age, int employeeNumber)
    {
        NameFirst = firstname;
        NameLast = lastname;
        Age = age;
        EmployeeNumber = employeeNumber;
    }

    // Methods
    public string GetUserDetails
    {
        get{ return string.Format("Name: {0} {1}, Age: {2}", NameFirst, NameLast, Age); }
    }
}

