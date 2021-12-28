using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_Entities
{
    [Table("Doktorlar")]
    //Doktor classı Kişi classından kalıtım alır.
    public class Doktor:Kisi,IMaasAlabilir
    {
        //Data Annotations: Köşeli parantez içerisinde yazılırlar. Ne ile ilgili olursa onun üstünde tanımlanır hemen.
        //Örnek: Property de kullanacağımız için Property üzerinde yazıyoruz
        [Key] // tabloda HastaID'nin PrimaryKey olması için yazdık
        [Column(Order =1)] //1. sırada yer almasını burada veriyoruz
        public int DoktorID { get; set; }

        [Required(ErrorMessage = "Lütfen Doktor Adı giriniz..")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="Doktor Adı en az 2 en çok 50 karakter olmalıdır!")]
        [Display(Name = "Doktor Adı")]
        public string DoktorAd { get; set; }
        
        [Column(TypeName ="nvarchar")]
        [Required(ErrorMessage = "Lütfen Doktor Soyadı giriniz..")]
        [Display(Name = "Doktor Soyadı")]
        [StringLength(50)]
        public string DoktorSoyad { get; set; }
        

        //Branslar enum 'ından property oluşturuldu
        [Display(Name ="Doktor Branşı")]
        public Branslar Brans { get; set; }

        [Display(Name = "Maaş")]
        public decimal Maas { get; set; }

        public virtual List<RandevuBilgileri> RandevuBilgileriList { get; set; }

        public override string ToString()
        {
            return $"Dr. {this.DoktorAd} {this.DoktorSoyad}";
        }
    }
}
 