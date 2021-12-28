namespace HastaneRandevuEFCF_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HastaneRandevuEFCF_DAL.MyContext>
    {
        public Configuration()
        {
            //eğer burası false olsun istersek add-migration ile ekleme yapılır
            //true kalsın istersek böyle bir kullanıma gerek yok
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HastaneRandevuEFCF_DAL.MyContext context)
        {
           
        }
    }
}
