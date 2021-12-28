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
    public partial class FormDoktorlar : Form
    {
        public FormDoktorlar()
        {
            InitializeComponent();

        }
        //Global Alan
        DoktorManager drManager = new DoktorManager();


        private void FormDoktorlar_Load(object sender, EventArgs e)
        {
            //datagrid
            DrGrideVerileriGetir();
            //comboBox
            comboBoxDrBranslar.DropDownStyle = ComboBoxStyle.DropDownList;

            //comboBoxDrBranslar.DisplayMember = "TheValue";
            //comboBoxDrBranslar.ValueMember = "TheKey";
            //comboBoxDrBranslar.DataSource = EnumManager.TumBranslariGetir();
            //comboBoxDrBranslar.SelectedValue = (int)Branslar.BransYok;

            comboBoxDrBranslar.DataSource = Enum.GetValues(typeof(Branslar));

            //maskedtext maske ayarlaması
            //maskedTextBoxDrTel.Mask = "(530) 000-00-00"; //11 hane. - ler yok edilecek
            maskedTextBoxDrTel.Mask = @"\0\5##-###-##-##";

        }
        private void btnDrEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //kontrol edilmesi gereken durumlar
                //ad soyad en az 2 karakter olmalı
                if (txtDrAd.Text.Trim().Length < 2)
                {
                    throw new Exception("Lütfen! Doktor adını doğru giriniz.."); //2 karakterden az olması durumu
                }

                if (txtDrSoyad.Text.Trim().Length < 2)
                {
                    throw new Exception("Lütfen! Doktor soyadını doğru giriniz.."); //2 karakterden az olması durumu
                }

                //tc kimlik numarası 11 karakter olmalı

                if (txtDrTC.Text.Trim().Length!=11) {

                    throw new Exception("TC Kimlik numarası 11 haneli olmalıdır!");
                }
                if (txtDrTC.Text.Any(x=> !char.IsDigit(x))) //gönderdiği karakteri decimal digit rakam olup olmadığına bakar.
                                                            //boolean bir değer döner.
                {
                    throw new Exception("TC Kimlik numarası rakamlardan oluşacak şekilde 11 haneli olmalıdır!");
                }
                





                Branslar drBransi;
                //selectedValue() string metin verir.ENUM tipinde dışarıya parse edilebilir
                Enum.TryParse(comboBoxDrBranslar.SelectedValue.ToString(), out drBransi);
                Doktor yeniDoktor = new Doktor()
                {

                    DoktorAd = txtDrAd.Text.Trim(),
                    DoktorSoyad = txtDrSoyad.Text.Trim(),
                    Brans = drBransi,
                    EMail = txtDrEmail.Text,
                    Telefon = maskedTextBoxDrTel.Text.Replace("-",""),
                    TCNumarasi = txtDrTC.Text
                };
                //veritabanına ekleme yapılmalı

                if (drManager.YeniDoktorEkle(yeniDoktor))
                {
                    MessageBox.Show($"{txtDrAd.Text.Trim()}\n{txtDrSoyad.Text.Trim()} sisteme yeni doktor eklenmiştir..");
                    //temizlik
                    DrEkleSayfasiTemizle();
                    DrGrideVerileriGetir();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA:" +ex.Message);
            }
           
        }

        private void DrGrideVerileriGetir()
        {
            dataGridViewDoktor.DataSource=drManager.TumAktifDoktorlariGetir();
        }

        private void DrEkleSayfasiTemizle()
        {
            txtDrAd.Clear();
            txtDrSoyad.Clear();
            txtDrTC.Clear();
            txtDrEmail.Clear();
            comboBoxDrBranslar.SelectedValue = 0;
            maskedTextBoxDrTel.Clear();

        }

        private void comboBoxDrBranslar_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }   
    }
}
