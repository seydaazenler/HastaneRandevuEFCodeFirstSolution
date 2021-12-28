using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_Entities
{
    [Table("Hastalar")]
    public class Hasta:Kisi
    {
        [Key]
        [Column(Order = 1)]

        public int HastaID { get; set; }
        
        [Required(ErrorMessage ="Lütfen hastanın Adını giriniz..")]
        [StringLength(50)]
        [Display(Name ="Hasta Adı")]
        public string HastaAd { get; set; }

        [Required(ErrorMessage = "Lütfen hastanın Soyadını giriniz..")]
        [StringLength(50)]
        [Display(Name = "Hasta Soyadı")]
        public string HastaSoyad { get; set; }

        public virtual List<RandevuBilgileri> RandevuBilgileriList { get; set; }

        public override string ToString()
        {
            return $"{this.TCNumarasi}-{this.HastaAd}-{this.HastaSoyad}";
        }
    }
}
