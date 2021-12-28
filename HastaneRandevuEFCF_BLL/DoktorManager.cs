using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HastaneRandevuEFCF_DAL;
using HastaneRandevuEFCF_Entities;

namespace HastaneRandevuEFCF_BLL
{
    public class DoktorManager
    {
        
        //Global Alan
        MyContext myDBContext = new MyContext();

        public bool  YeniDoktorEkle(Doktor yeniDr)
        {
            try
            {
                //1. yöntem
                myDBContext.Doktorlar.Add(yeniDr);

                //2. yöntem: ilerleyen derslerde repository konusunda kullanılacak
                //myDBContext.Set<Doktor>().Add(yeniDr);

                myDBContext.SaveChanges();
                return true;
                
                
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
        }

        public List<Doktor> TumAktifDoktorlariGetir()
        {
            try
            {
                //1.Yöntem
                //List<Doktor> drList = new List<Doktor>();
                //drList = myDBContext.Doktorlar.ToList();
                //return drList;


                //2.Yöntem
                //where ile sadece aktif doktorlar çekilecek
                return myDBContext.Doktorlar.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        
        public List<Doktor> BransaGoreDoktorlariGetir(Branslar brans)
        {
            try
            {
                return 
                    myDBContext.Doktorlar.Where(x => x.Brans == brans).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
