using HastaneRandevuEFCF_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HastaneRandevuEFCF_BLL;


namespace HastaneRandevuEFCF_WinFormUI
{
    public partial class UC_RandevuSaat : UserControl
    {
        public UC_RandevuSaat()
        {
            InitializeComponent();
        }

        //Global Alan

        private void UC_RandevuSaat_Load(object sender, EventArgs e)
        {
            comboBoxSaatler.DisplayMember = "SaatDilimi";
            comboBoxSaatler.ValueMember = "Id";
            comboBoxSaatler.DataSource = SaatViewModel.SaatlerListesiniGetir();

        }

        private void comboBoxSaatler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSaatler.SelectedIndex>=0)
            {
                string saatim = comboBoxSaatler.SelectedValue.ToString().Substring(0, 3); //09:

                foreach (Button item in tableLayoutPanelRandevuButonlar.Controls)
                {
                    switch (item.Name)
                    {
                        case "btn0015":
                            btn0015.Text = $"{saatim}00 - {saatim}15";
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {

            }
        }
    }
}
