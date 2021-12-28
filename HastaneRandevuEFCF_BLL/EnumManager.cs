using HastaneRandevuEFCF_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_BLL
{
    public static class EnumManager
    {
        public static List<Enums> TumBranslariGetir()
        {
            List<Enums> data = new List<Enums>();
            foreach (var item in Enum.GetValues(typeof(Branslar)))
            {
                Enums TheEnum = new Enums()
                {
                    TheKey=Convert.ToInt32(item),
                    TheValue=item.ToString()
                };
            data.Add(TheEnum);
            }

         return data;

        }
    }
}
