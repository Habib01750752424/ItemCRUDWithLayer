using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopCRUD.BLL;

namespace CoffeeShopCRUD
{
    public partial class ItemsCrud : Form
    {
        ItemManager _itemManager = new ItemManager();
        string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";

        public ItemsCrud()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            double price = Convert.ToDouble(priceTextBox.Text);

            if (name == "" || nameTextBox.Text == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (_itemManager.CheckIfNumeric(name))
            {
                MessageBox.Show("Please enter Item name, not numeric value.");
                nameTextBox.Clear();
                return;
            }

            if (_itemManager.IsNameExist(name))
            {
                MessageBox.Show("Item Name is Already exist..");
                return;
            }

            if (_itemManager.Add(name, price))
            {
                MessageBox.Show("Saved");
                showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Save");
            }
            
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _itemManager.Display();

        }

        private void Clear()
        {
            nameTextBox.Clear();
            priceTextBox.Clear();
        }

        int id;
        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            idTextBox.Text = showDataGridView[0, e.RowIndex].Value.ToString();
            nameTextBox.Text = showDataGridView[1, e.RowIndex].Value.ToString();
            priceTextBox.Text = showDataGridView[2, e.RowIndex].Value.ToString();
            id = Convert.ToInt32(showDataGridView[0, e.RowIndex].Value);

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            int id = Convert.ToInt32(idTextBox.Text);
            double price = Convert.ToDouble(priceTextBox.Text);

            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }

            if (name == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (_itemManager.CheckIfNumeric(name))
            {
                MessageBox.Show("Please enter Item name, not numeric value.");
                nameTextBox.Clear();
                return;
            }

            if (_itemManager.Update(id, name, price))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _itemManager.Display();
                return;
            }
            else
            {
                MessageBox.Show("Not Update");
                return;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(showDataGridView[0, e.RowIndex].Value);
            int id = Convert.ToInt32(idTextBox.Text);

            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please Select Id Field..");
                return;
            }

            if (_itemManager.Delete(id))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = searchTextBox.Text;
            if (name == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }

            showDataGridView.DataSource = "";
            showDataGridView.DataSource = _itemManager.Search(name);
        }
    }
}
