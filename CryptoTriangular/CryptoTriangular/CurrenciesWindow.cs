using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoTriangular
{
    public partial class CurrenciesWindow : Form
    {
        public CurrenciesWindow()
        {
            InitializeComponent();
            initCheckbox();
        }

        private void SelectCurrency(object sender, EventArgs e)
        {
            
            var checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                if(!Options.Instance.selectedCurrency.Contains(checkbox.Name))
                    Options.Instance.selectedCurrency.Add(checkbox.Name);
            }
            else
            {                                 
                Options.Instance.selectedCurrency.Remove(checkbox.Name);
            }
        }

        private void initCheckbox()
        {
            var checkBoxs = groupBox1.Controls.OfType<CheckBox>();
            foreach (CheckBox rb in checkBoxs)
            {
                if (Options.Instance.selectedCurrency.Contains(rb.Name))
                    rb.Checked = true;
                else
                    rb.Checked = false;
            }
        }

        private void CurrenciesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Options.Instance.selectedCurrency.Count() == 0)
            {
                MessageBox.Show("You must select at least one Currency", "Inncorect value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }
}
