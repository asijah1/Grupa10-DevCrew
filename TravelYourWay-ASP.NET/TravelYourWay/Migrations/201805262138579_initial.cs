namespace TravelYourWay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            

            CreateTable(
                "dbo.Agencija",
                c => new
                    {
                        AgencijaId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        DatumOsnivanja = c.DateTime(nullable: false),
                        Sjediste = c.String(),
                        Email = c.String(),
                        Sifra = c.String(),
                    })
                .PrimaryKey(t => t.AgencijaId);
            
            CreateTable(
                "dbo.Dogadjaji",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        DatumOdrzavanja = c.DateTime(nullable: false),
                        VrijemeTrajanja = c.Int(nullable: false),
                        Mjesto = c.String(),
                        BrojSlobodnihMjesta = c.Int(nullable: false),
                        NazivAgencije = c.String(),
                        DogadjajiId = c.Int(nullable: false),
                        agencija_AgencijaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agencija", t => t.agencija_AgencijaId)
                .Index(t => t.agencija_AgencijaId);
            
            CreateTable(
                "dbo.PrijavaNaDogadjaj",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        idPrijave = c.Int(nullable: false),
                        usernameKorisnika = c.String(),
                        idDogadjaja = c.Int(nullable: false),
                        dogadjaj_Id = c.Int(),
                        korisnik_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dogadjaji", t => t.dogadjaj_Id)
                .ForeignKey("dbo.Korisnik", t => t.korisnik_Id)
                .Index(t => t.dogadjaj_Id)
                .Index(t => t.korisnik_Id);
            
            CreateTable(
                "dbo.Korisnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Drzava = c.String(),
                        Email = c.String(),
                        KorisnickoIme = c.String(),
                        Sifra = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrijavaNaDogadjaj", "korisnik_Id", "dbo.Korisnik");
            DropForeignKey("dbo.PrijavaNaDogadjaj", "dogadjaj_Id", "dbo.Dogadjaji");
            DropForeignKey("dbo.Dogadjaji", "agencija_AgencijaId", "dbo.Agencija");
            DropIndex("dbo.PrijavaNaDogadjaj", new[] { "korisnik_Id" });
            DropIndex("dbo.PrijavaNaDogadjaj", new[] { "dogadjaj_Id" });
            DropIndex("dbo.Dogadjaji", new[] { "agencija_AgencijaId" });
            DropTable("dbo.Korisnik");
            DropTable("dbo.PrijavaNaDogadjaj");
            DropTable("dbo.Dogadjaji");
            DropTable("dbo.Agencija");
        }
    }
}
