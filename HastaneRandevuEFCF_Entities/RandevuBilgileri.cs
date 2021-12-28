using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_Entities
{
    [Table("RandevuBilgileri")]
    public class RandevuBilgileri
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }
        public int DoktorID { get; set; }
        public int HastaID { get; set; }
        public DateTime RandevuTarihi { get; set; }

        //ilişki
        //virtual sanal property oluşturuldu
        [ForeignKey("DoktorID")]
        public virtual Doktor Doktor { get; set; }
        [ForeignKey("HastaID")]
        public virtual Hasta Hasta { get; set; }
    }
}
