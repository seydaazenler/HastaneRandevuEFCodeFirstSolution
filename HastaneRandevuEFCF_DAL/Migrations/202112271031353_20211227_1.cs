namespace HastaneRandevuEFCF_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20211227_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doktorlar",
                c => new
                    {
                        DoktorID = c.Int(nullable: false, identity: true),
                        DoktorAd = c.String(nullable: false, maxLength: 50),
                        DoktorSoyad = c.String(nullable: false, maxLength: 50),
                        Brans = c.Byte(nullable: false),
                        Maas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TCNumarasi = c.String(nullable: false, maxLength: 11),
                        Telefon = c.String(maxLength: 11),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.DoktorID);
            
            CreateTable(
                "dbo.RandevuBilgileri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoktorID = c.Int(nullable: false),
                        HastaID = c.Int(nullable: false),
                        RandevuTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doktorlar", t => t.DoktorID, cascadeDelete: true)
                .ForeignKey("dbo.Hastalar", t => t.HastaID, cascadeDelete: true)
                .Index(t => t.DoktorID)
                .Index(t => t.HastaID);
            
            CreateTable(
                "dbo.Hastalar",
                c => new
                    {
                        HastaID = c.Int(nullable: false, identity: true),
                        HastaAd = c.String(nullable: false, maxLength: 50),
                        HastaSoyad = c.String(nullable: false, maxLength: 50),
                        TCNumarasi = c.String(nullable: false, maxLength: 11),
                        Telefon = c.String(maxLength: 11),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.HastaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RandevuBilgileri", "HastaID", "dbo.Hastalar");
            DropForeignKey("dbo.RandevuBilgileri", "DoktorID", "dbo.Doktorlar");
            DropIndex("dbo.RandevuBilgileri", new[] { "HastaID" });
            DropIndex("dbo.RandevuBilgileri", new[] { "DoktorID" });
            DropTable("dbo.Hastalar");
            DropTable("dbo.RandevuBilgileri");
            DropTable("dbo.Doktorlar");
        }
    }
}
