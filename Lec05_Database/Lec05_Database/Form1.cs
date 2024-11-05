using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lec05_Database
{
    public partial class Form1 : Form
    {
        DatabaseDataContext db_dc = new DatabaseDataContext();
        public Form1()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void ReadDatabase()
        {
            listBoxPersons.Items.Clear();
            foreach (Person person in db_dc.Persons)
            //foreach (Person person in db_dc.Persons.Where(o => o.Age<20))
            {
                listBoxPersons.Items.Add(person);
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = textBoxName.Text;
            p.Age = (int)numericUpDownAge.Value;

            db_dc.Persons.InsertOnSubmit(p);


            db_dc.SubmitChanges();
            ReadDatabase();

            textBoxName.Text = "";
            numericUpDownAge.Value = 0;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxPersons.SelectedItem != null)
            {
                if (listBoxPersons.SelectedItem is Person)
                {
                    Person personToDelete = listBoxPersons.SelectedItem as Person;

                    db_dc.Persons.DeleteOnSubmit(personToDelete);

                    db_dc.SubmitChanges();
                    ReadDatabase();

                    textBoxName.Text = "";
                    numericUpDownAge.Value = 0;
                    buttonInsert.Enabled = true;
                    buttonUpdate.Enabled = false;
                    buttonDelete.Enabled = false;
                }
            }
        }

        private void listBoxPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPersons.SelectedItem != null)
            {
                if (listBoxPersons.SelectedItem is Person)
                {
                    Person personToUpdate = listBoxPersons.SelectedItem as Person;

                    textBoxName.Text = personToUpdate.Name;
                    numericUpDownAge.Value = personToUpdate.Age;

                    buttonInsert.Enabled = false;
                    buttonUpdate.Enabled = true;
                    buttonDelete.Enabled = true;
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxPersons.SelectedItem != null)
            {
                if (listBoxPersons.SelectedItem is Person)
                {
                    Person personToUpdate = listBoxPersons.SelectedItem as Person;

                    personToUpdate.Name = textBoxName.Text;
                    personToUpdate.Age = (int) numericUpDownAge.Value;

                    db_dc.SubmitChanges();
                    ReadDatabase();

                    textBoxName.Text = "";
                    numericUpDownAge.Value = 0;
                    buttonInsert.Enabled = true;
                    buttonUpdate.Enabled = false;
                    buttonDelete.Enabled = false;
                }
            }
        }
    }
}
