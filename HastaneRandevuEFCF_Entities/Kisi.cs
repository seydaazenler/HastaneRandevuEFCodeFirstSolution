using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_Entities
{
    public abstract class Kisi
    {
        [Required]
        [StringLength(11)]
        public string TCNumarasi { get; set; }
        
        [StringLength(11)] //Tel: 05073200699
        public string Telefon { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage =
            "Lütfen EMail adresini doru formatta giriniz.." + "ornek@gmail.com")]
        public string EMail { get; set; }
    }
}
