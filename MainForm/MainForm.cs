using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private IP_Repostirory _IP_Repostirory = new IP_Repostirory();
        private BindingSource _tableBindingSource = new BindingSource();
        public MainForm()
        {
            InitializeComponent();

            _tableBindingSource.DataSource = _IP_Repostirory.GetIPMainForm();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _tableBindingSource;

            DataGridViewImageColumn Details = new DataGridViewImageColumn();
            Details.Image = Image.FromFile("../../Resources/delete.png");
            Details.Width = 20;
            Details.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Details.Name = "Delete";
            dataGridViewIP.Columns.Add(Details);

            dataGridViewIP.AutoGenerateColumns = false;

            comboBox.SelectedIndex = 0;

            PopulateCountriesComboBox();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if(textBoxImport.Text.Length == 0)
            {
                MessageBox.Show("Please input IP address");
            }
            else if(_IP_Repostirory.IsValidIP(textBoxImport.Text) == false)
            {
                MessageBox.Show("Invalid IP address");
            }
            else if(_IP_Repostirory.IsUniqueIP(textBoxImport.Text) == false)
            {
                MessageBox.Show("IP address alredy exists in database");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show($"Add IP {textBoxImport.Text}?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _IP_Repostirory.ImportIP(textBoxImport.Text);
                    dataGridViewIP.DataSource = _IP_Repostirory.GetIPMainForm();
                }
                PopulateCountriesComboBox();

                textBoxImport.Text = String.Empty;
            }            
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(true, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
            buttonWriteToTxt.BackColor = Color.FromArgb(0 , 102, 204);
        }

        private void checkBoxIPv4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(true, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
            buttonWriteToTxt.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void checkBoxIPv6_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(true, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
            buttonWriteToTxt.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(false, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
        }

        private void radioButtonAscending_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(false, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
        }

        private void radioButtonDescending_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(false, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
        }

        private void dataGridViewIP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewIP.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show($"Delete IP {dataGridViewIP.Rows[e.RowIndex].Cells[0].Value.ToString()}?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        if (Application.OpenForms[i].Text == dataGridViewIP.Rows[e.RowIndex].Cells[0].Value.ToString() + " Details")
                        {
                            Application.OpenForms[i].Close();
                        }
                    }
                    _IP_Repostirory.DeleteIP(dataGridViewIP.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dataGridViewIP.DataSource = _IP_Repostirory.GetIPMainForm();
                    PopulateCountriesComboBox();
                }
            }
            else if (e.RowIndex != -1)
            {
                bool AlredyOpened = false;
                for(int i = 0; i < Application.OpenForms.Count; i++)
                { 
                    if(Application.OpenForms[i].Text == dataGridViewIP.Rows[e.RowIndex].Cells[0].Value.ToString() + " Details")
                    {
                        AlredyOpened = true;
                        Application.OpenForms[i].Focus();
                    }
                }

                if(AlredyOpened == false)
                {
                    IP ip = _IP_Repostirory.GetIPDetails(dataGridViewIP.Rows[e.RowIndex].Cells[0].Value.ToString());

                    DetailsForm detailsForm = new DetailsForm(ip, this);
                    detailsForm.Show();
                }
            }
        }

        private void buttonWriteToTxt_Click(object sender, EventArgs e)
        {
            if (_IP_Repostirory.SearchList.Count == 0)
            {
                MessageBox.Show("No search logs to save");
            }
            else
            {
                string s = "";
                if(_IP_Repostirory.SearchList.Count != 1)
                {
                    s = "s";
                }

                DialogResult dialogResult = MessageBox.Show($"Save {_IP_Repostirory.SearchList.Count} search log{s}?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _IP_Repostirory.WriteToTxt();
                }
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            textBoxImport.Text = "";
            Random random = new Random();

            switch (random.Next(0, 2))
            {
                case 0:
                    for(int i = 0; i <= 3; i++)
                    {
                        textBoxImport.Text += random.Next(0, 256).ToString();
                        if(i != 3)
                        {
                            textBoxImport.Text += '.';
                        }
                    }
                    break;
                case 1:
                    List<char> ListOfChar = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                    for (int i = 0; i <= 7; i++)
                    {
                        for(int j = 0; j <= 3; j++)
                        {
                            textBoxImport.Text += ListOfChar[random.Next(0, 16)];
                        }
                        if(i != 7)
                        {
                            textBoxImport.Text += ':';
                        }
                    }
                    break;
            }
        }

        private void checkBoxComboBoxCountries_Click(object sender, EventArgs e)
        {
            checkBoxComboBoxCountries.Focus();
        }

        private void CheckAll(bool TrueORFalse)
        {
            checkBoxComboBoxCountries.TextChanged -= checkBoxComboBoxCountries_TextChanged;
            foreach (var v in checkBoxComboBoxCountries.CheckBoxItems.ToList())
            {
                v.Checked = TrueORFalse;
            }
            if(TrueORFalse)
            {
                checkBoxComboBoxCountries.Text = "All countries";
            }
            else
            {
                checkBoxComboBoxCountries.Text = "No countries";
            }
            checkBoxComboBoxCountries.TextChanged += checkBoxComboBoxCountries_TextChanged;
        }

        public void PopulateCountriesComboBox()
        {
            checkBoxComboBoxCountries.Items.Clear();
            
            checkBoxComboBoxCountries.Items.Add("All");  

            //var IpObjects = _IP_Repostirory.SearchAndSort(TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);
            List<string> ListOfCountries = _IP_Repostirory.GetIPMainForm().Select(x => x.country).Distinct().OrderBy(x => x).ToList();

            foreach(var v in ListOfCountries)
            {
                checkBoxComboBoxCountries.Items.Add(v);
            }

            CheckAll(true);
        }

        public List<string> GetCountriesFromComboBox()
        {
            List<string> ListOfCountries = new List<string>();
            foreach (var v in checkBoxComboBoxCountries.CheckBoxItems.ToList())
            {
                if (v.Checked == false)
                {
                    ListOfCountries.Add(v.Text);
                }
            }
            return ListOfCountries;
        }

        private void checkBoxComboBoxCountries_TextChanged(object sender, EventArgs e)
        {
            bool AllClicked = checkBoxComboBoxCountries.CheckBoxItems[0].Focused;

            if(AllClicked == true)
            {
                switch(checkBoxComboBoxCountries.CheckBoxItems[0].Checked)
                {
                    case true:
                        CheckAll(true);
                        break;
                    case false:
                        CheckAll(false);
                        break;
                }
            }
            else
            {
                int CheckedCountries = checkBoxComboBoxCountries.CheckBoxItems.Count() - 1;
                foreach(var v in checkBoxComboBoxCountries.CheckBoxItems)
                {
                    if(v.Text != "All" && v.Checked == false)
                    {
                        CheckedCountries--;
                    }
                }

                if (CheckedCountries == checkBoxComboBoxCountries.CheckBoxItems.Count() - 1)
                {
                    checkBoxComboBoxCountries.TextChanged -= checkBoxComboBoxCountries_TextChanged;
                    checkBoxComboBoxCountries.CheckBoxItems[0].Checked = true;
                    checkBoxComboBoxCountries.Text = "All countries";
                    checkBoxComboBoxCountries.TextChanged += checkBoxComboBoxCountries_TextChanged;
                }
                else
                {
                    checkBoxComboBoxCountries.TextChanged -= checkBoxComboBoxCountries_TextChanged;
                    checkBoxComboBoxCountries.CheckBoxItems[0].Checked = false;
                    checkBoxComboBoxCountries.Text = $"{CheckedCountries} countries";
                    checkBoxComboBoxCountries.TextChanged += checkBoxComboBoxCountries_TextChanged;
                }
            }

            dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(true, TextBoxSearch.Text, checkBoxIPv4.Checked, checkBoxIPv6.Checked, GetCountriesFromComboBox(), comboBox.Text, radioButtonAscending.Checked);

            buttonWriteToTxt.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void dataGridViewIP_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ColumnIndex = dataGridViewIP.Columns[e.ColumnIndex].Index;
            switch (ColumnIndex)
            {
                case 0:
                    comboBox.SelectedIndex = 0;
                    break;
                case 2:
                    comboBox.SelectedIndex = 1;
                    break;
                case 3:
                    comboBox.SelectedIndex = 2;
                    break;
                case 4:
                    comboBox.SelectedIndex = 3;
                    break;
            }
            switch (ColumnIndex)
            {
                case 0:
                    comboBox.SelectedIndex = 0;
                    break;
                case 2:
                    comboBox.SelectedIndex = 1;
                    break;
                case 3:
                    comboBox.SelectedIndex = 2;
                    break;
                case 4:
                    comboBox.SelectedIndex = 3;
                    break;
            }

            if(radioButtonAscending.Checked == true && ColumnIndex != 1 && ColumnIndex != 5)
            {
                radioButtonDescending.Checked = true;
            }
            else if(ColumnIndex != 1 && ColumnIndex != 5)
            {
                radioButtonAscending.Checked = true;
            }
        }
    }
}