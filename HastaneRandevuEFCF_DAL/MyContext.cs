using HastaneRandevuEFCF_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyCon")
        {

        }
        //tablolar
        public virtual DbSet<Doktor> Doktorlar { get;set; }
        public virtual DbSet<Hasta> Hastalar { get;set; }
        public virtual DbSet<RandevuBilgileri> RandevuBilgileri {get;set;}
    }
}
