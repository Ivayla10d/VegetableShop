using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegetableProject.Controller;
using VegetableProject.Model;

namespace VegetableProject
{
    public partial class Form1 : Form
    {
        VegetablesLogic vegetableLogic = new VegetablesLogic();
        VegetableTypeLogic vegetableTypeLogic = new VegetableTypeLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<VegetableType> allVegetables = vegetableTypeLogic.GetAllVegetables();
            cmbType.DataSource = allVegetables;
            cmbType.DisplayMember = "TypeName";
            cmbType.ValueMember = "Id";
        }
        private void LoadRecord(Vegetable vegetable)
        {

            txtId.BackColor = Color.White;
            txtId.Text = vegetable.Id.ToString();
            txtName.Text = vegetable.Name;
            txtDescription.Text = vegetable.Description;
            txtPrice.Text = vegetable.Price.ToString();
            cmbType.Text = vegetable.VegetableTypeId.ToString();
        }
        private void ClearScreen()
        {
            txtId.BackColor = Color.White;
            txtId.Clear();
            txtDescription.Clear();
            txtName.Clear();
            txtPrice.Clear();
            cmbType.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Name) || txtName.Text == "")
            {
                MessageBox.Show("Въведи данни:");
                txtName.Focus();
                return;
            }
            Vegetable newVegetable = new Vegetable();
            newVegetable.Price = decimal.Parse(txtPrice.Text);  
            newVegetable.Name = txtName.Text;
            newVegetable.Description = txtDescription.Text;

            newVegetable.VegetableTypeId = (int)cmbType.SelectedValue;

            newVegetable.Registration = DateTime.Now;

            vegetableLogic.Create(newVegetable);
            MessageBox.Show("Записът е успешно добавен");
            ClearScreen();
            btnSelectAll_Click(sender,  e);


        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Vegetable> allVegans = vegetableLogic.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allVegans)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} Description: {item.Description} {item.Price}лв. Тип: {item.VegetableTypes.TypeName}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Vegetable findedVegetable = vegetableLogic.Get(findId);
                if (findedVegetable == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете Id:");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(findedVegetable);
            }
            else
            {
                Vegetable uddatedVegetable = new Vegetable();
                uddatedVegetable.Name = txtName.Text;
                uddatedVegetable.Price = decimal.Parse(txtPrice.Text);
                uddatedVegetable.Description = txtDescription.Text;
                uddatedVegetable.VegetableTypeId = (int)cmbType.SelectedValue;
                vegetableLogic.Update(findId, uddatedVegetable);
                MessageBox.Show("ЗАПИСА БЕШЕ УСПЕШНО ДОБАВЕН!");
            }

            btnSelectAll_Click(sender, e);


        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Vegetable findedVegetable = vegetableLogic.Get(findId);
            if (findedVegetable == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете ID!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findedVegetable);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Vegetable findedVegetable = vegetableLogic.Get(findId);
            if (findedVegetable == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете Id!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findedVegetable);

            DialogResult answear = MessageBox.Show("Наистина ли искате да изтриете запис № " + findId + " ?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answear == DialogResult.Yes)
            {
                vegetableLogic.Delete(findId);
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Vegetable findedVegetable = vegetableLogic.Get(findId);
            if (findedVegetable == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете Id!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findedVegetable);
        }
    }
}
