using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_Entities
{
    public class SaatViewModel
    {
        public int Id { get; set; }
        public string SaatDilimi { get; set; }

        public static List<SaatViewModel> SaatlerListesiniGetir()
        {
            List<SaatViewModel> liste = new List<SaatViewModel>()
            {
            (new SaatViewModel
                {
                    Id=9,
                    SaatDilimi="09:00",
                }),
            (new SaatViewModel
                {
                Id = 10,
                SaatDilimi = "10:00",
                }),
            (new SaatViewModel
                {
                Id = 11,
                SaatDilimi = "11:00",
                }),
            (new SaatViewModel
                {
                Id = 12,
                SaatDilimi = "12:00",
                }),
            (new SaatViewModel
                {
                Id = 13,
                SaatDilimi = "13:00",
                }),
            (new SaatViewModel
                {
                Id = 14,
                SaatDilimi = "14:00",
                }),
            (new SaatViewModel
                {
                Id = 15,
                SaatDilimi = "15:00",
                }),
        };
            return liste;
        }
    }
}
