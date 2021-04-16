using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public static class ColorsClass
    {
        public static bool DarkTheme { get; set; } = false;
        private static Color DarkGray { get; set; } = Color.FromArgb(45, 45, 45);
        private static Color DarkDarkGray { get; set; } = Color.FromArgb(36, 36, 36);
        public static Color BackColor { get; set; } = Color.White;
        public static Color BackColorDarker { get; set; } = Color.WhiteSmoke;
        public static Color ForeColor { get; set; } = DarkDarkGray;

        private static void LoopTableLayout(TableLayoutPanel tableLayoutPanel)
        {
            foreach (var control in tableLayoutPanel.Controls)
            {
                var textBox = control as TextBox;
                if (textBox != null)
                {
                    if (textBox.Name.Last() == '2')
                    {
                        textBox.BackColor = BackColor;
                    }
                    else
                    {
                        textBox.BackColor = BackColorDarker;
                    }
                    textBox.ForeColor = ForeColor;
                }
            }
        }

        private static void ColorDetailsForm(DetailsForm form)
        {
            form.BackColor = BackColor;
            form.tabPage1.BackColor = BackColor;
            form.tabPage2.BackColor = BackColor;

            form.buttonFlat1.BackColor = BackColorDarker;
            form.buttonFlat1.FlatAppearance.MouseOverBackColor = BackColorDarker;
            form.buttonFlat1.FlatAppearance.MouseDownBackColor = BackColorDarker;

            form.button2.BackColor = BackColorDarker;
            form.button2.FlatAppearance.MouseOverBackColor = BackColorDarker;
            form.button2.FlatAppearance.MouseDownBackColor = BackColorDarker;

            form.pictureBoxFlag.BackColor = BackColorDarker;
            form.textBoxIso.BackColor = BackColorDarker;
            form.textBoxIso.ForeColor = ForeColor;
            form.textBoxIso2.BackColor = BackColorDarker;

            form.labelContinentCode.BackColor = BackColorDarker;
            form.labelContinentCode.ForeColor = ForeColor;
            form.textBoxContinentCode2.BackColor = BackColorDarker;

            form.labeCurrencyCode.BackColor = BackColorDarker;
            form.labeCurrencyCode.ForeColor = ForeColor;
            form.textBoxCurrencyCode2.BackColor = BackColorDarker;

            form.labelSymbol.BackColor = BackColorDarker;
            form.labelSymbol.ForeColor = ForeColor;
            form.textBoxSymbol2.BackColor = BackColorDarker;

            form.tabPage1.BackColor = BackColor;
            form.tabPage2.BackColor = BackColor;
            form.tabPage3.BackColor = BackColor;

            LoopTableLayout(form.tableLayoutPanel1);
            LoopTableLayout(form.tableLayoutPanel2);
        }

        public static void ColorComponents(MainForm mainForm, FormCollection detailsForms, DetailsForm detailsForm = null)
        {
            mainForm.BackColor = BackColor;
            mainForm.dataGridViewIP.BackgroundColor = BackColor;
            mainForm.dataGridViewIP.DefaultCellStyle.BackColor = BackColor;
            mainForm.dataGridViewIP.DefaultCellStyle.ForeColor = ForeColor;
            mainForm.dataGridViewIP.AlternatingRowsDefaultCellStyle.BackColor = BackColorDarker;
            mainForm.dataGridViewIP.GridColor = BackColor;
            mainForm.tabPage1.BackColor = BackColor;
            mainForm.tabPage2.BackColor = BackColor;
            mainForm.radioButtonAscending.BackColor = BackColorDarker;
            mainForm.radioButtonDescending.BackColor = BackColorDarker;

            mainForm.textBoxImport.BackColor = BackColor;
            mainForm.textBoxImport.ForeColor = ForeColor;
            mainForm.textBoxImport.WaterMarkForeColor = BackColorDarker;
            mainForm.textBoxImport.WaterMarkActiveForeColor = BackColorDarker;        

            mainForm.TextBoxSearch.BackColor = BackColor;
            mainForm.TextBoxSearch.ForeColor = ForeColor;
            mainForm.TextBoxSearch.WaterMarkForeColor = BackColorDarker;
            mainForm.TextBoxSearch.WaterMarkActiveForeColor = BackColorDarker;

            mainForm.checkBoxComboBoxCountries.BackColor = BackColor;
            //mainForm.checkBoxComboBoxCountries.ForeColor = ForeColor;

            for(int i = 0; i < detailsForms.Count; i++)
            {
                if(detailsForms[i].GetType().Equals(typeof(DetailsForm)))
                {
                    DetailsForm form = (DetailsForm)detailsForms[i];
                    ColorDetailsForm(form);
                }
            }

            if(detailsForm != null)
                ColorDetailsForm(detailsForm);
        }

        public static void ChangeTheme()
        {
            if(DarkTheme)
            {
                BackColor = Color.White;
                BackColorDarker = Color.WhiteSmoke;
                ForeColor = DarkGray;
                DarkTheme = false;
            }
            else
            {
                BackColor = DarkGray;
                BackColorDarker = DarkDarkGray;
                ForeColor = Color.WhiteSmoke;
                DarkTheme = true;
            }
        }
    }
}
