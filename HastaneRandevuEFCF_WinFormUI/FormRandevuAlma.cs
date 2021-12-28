using HastaneRandevuEFCF_BLL;
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

namespace HastaneRandevuEFCF_WinFormUI
{
    public partial class FormRandevuAlma : Form
    {
        public FormRandevuAlma()
        {
            InitializeComponent();
        }
        //Global Alan
        HastaManager hastaManagerim = new HastaManager();
        DoktorManager doktorManagerim = new DoktorManager();


        private void FormRandevuAlma_Load(object sender, EventArgs e)
        {
            //Servis GroupBox'ı ve TarihSaat GroupBoxları pasif olmalı
            ServisGroupBoxiniPasiflestir();
            RandevuTarihveSaatGroupBoxiniPasiflestir();
            HastaListBoxiniDoldur();

            //datetimePicker'ı formatla

            DateTimePickeriAyarla(DateTime.Now);
            
                
        }

        private void DateTimePickeriAyarla(DateTime trh)
        {
            dateTimePickerRandevuTarihi.Format = DateTimePickerFormat.Custom;
            dateTimePickerRandevuTarihi.CustomFormat = "dd-MM-yyyy";
            dateTimePickerRandevuTarihi.MinDate = trh;
            dateTimePickerRandevuTarihi.MaxDate = dateTimePickerRandevuTarihi.MinDate.AddDays(15);
            dateTimePickerRandevuTarihi.Value = trh;
        }

        private void HastaListBoxiniDoldur()
        {
            listBoxHastalar.DataSource = hastaManagerim.TumHastalariGetir();
            listBoxDoktorlar.SelectedIndex = -1;
        }

        private void RandevuTarihveSaatGroupBoxiniPasiflestir()
        {
            groupBoxRandevu.Enabled = false;
        }

        private void RandevuTarihveSaatGroupBoxiniAktiflestir()
        {
            groupBoxRandevu.Enabled = true;
        }
        private void ServisGroupBoxiniPasiflestir()
        {
            groupBoxServis.Enabled = false;
        }

        private void txtHastaTCArama_TextChanged(object sender, EventArgs e)
        {
            if (txtHastaTCArama.Text.Trim().Length>=2)
            {
                listBoxHastalar.DataSource = hastaManagerim.TCNumarasinaGoreHastayiBul(txtHastaTCArama.Text);
            }
            else
            {
                HastaListBoxiniDoldur();
            }
        }

        private void listBoxHastalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHastalar.SelectedIndex>=0)
            {
                ServisGroupBoxiniAktiflestir();
            }
            else
            {
                ServisGroupBoxiniPasiflestir();
                RandevuTarihveSaatGroupBoxiniPasiflestir();
            }
        }

        private void ServisGroupBoxiniAktiflestir()
        {
            groupBoxServis.Enabled = true;
            //aktifleşme işlemi olur olmaz servis combonun içi dolmalı
            comboBoxServisiDoldur();
        }

        private void comboBoxServisiDoldur()
        {
            comboBoxServis.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServis.DataSource = Enum.GetValues(typeof(Branslar));
            comboBoxServis.SelectedIndex = -1;

        }

        private void comboBoxServis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServis.SelectedIndex>=0)
            {
                Branslar drBransi;
                Enum.TryParse(comboBoxServis.SelectedValue.ToString(), out drBransi);
                listBoxDoktorlar.DataSource = doktorManagerim.BransaGoreDoktorlariGetir(drBransi);
            }
            else
            {
                listBoxDoktorlar.DataSource = null;
            }
            listBoxDoktorlar.SelectedIndex = -1;
            DateTimePickeriAyarla(DateTime.Now);
        }

        private void listBoxDoktorlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTimePickeriAyarla(DateTime.Now);
            if (listBoxDoktorlar.SelectedIndex >=0)
            {
                RandevuTarihveSaatGroupBoxiniAktiflestir();
            }
            else
            {
                
                RandevuTarihveSaatGroupBoxiniPasiflestir();
            }
        }

        private void dateTimePickerRandevuTarihi_ValueChanged(object sender, EventArgs e)
        {
            DateTimePickeriAyarla(dateTimePickerRandevuTarihi.Value);
        }
    }
}
