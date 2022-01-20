namespace WebAppAspNetMvcIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticlesEvents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Provider = c.String(nullable: false),
                        News_Id = c.Int(),
                        News_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.News_Id)
                .ForeignKey("dbo.News", t => t.News_Id1)
                .Index(t => t.News_Id)
                .Index(t => t.News_Id1);
            
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CinemaPlace = c.String(nullable: false),
                        NumberOfBilets = c.Int(nullable: false),
                        QRcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kinoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NextArrivalDate = c.DateTime(),
                        KinoTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFilm = c.String(nullable: false),
                        FilmYears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmCovers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Size = c.Long(nullable: false),
                        Path = c.String(),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartImport = c.DateTime(nullable: false),
                        EndImport = c.DateTime(nullable: false),
                        SuccessCount = c.Int(nullable: false),
                        FailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Featured = c.Boolean(),
                        Title = c.String(nullable: false),
                        Url = c.String(),
                        ImageUrl = c.String(),
                        NewsSite = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                        PublishedAt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KinoCinemas",
                c => new
                    {
                        Kino_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kino_Id, t.Cinema_Id })
                .ForeignKey("dbo.Kinoes", t => t.Kino_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id, cascadeDelete: true)
                .Index(t => t.Kino_Id)
                .Index(t => t.Cinema_Id);
            
            CreateTable(
                "dbo.FormatFilms",
                c => new
                    {
                        Format_Id = c.Int(nullable: false),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Format_Id, t.Film_Id })
                .ForeignKey("dbo.Formats", t => t.Format_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Format_Id)
                .Index(t => t.Film_Id);
            
            CreateTable(
                "dbo.FilmKinoes",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Kino_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Kino_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kinoes", t => t.Kino_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Kino_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ArticlesEvents", "News_Id1", "dbo.News");
            DropForeignKey("dbo.ArticlesEvents", "News_Id", "dbo.News");
            DropForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FormatFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FormatFilms", "Format_Id", "dbo.Formats");
            DropForeignKey("dbo.FilmCovers", "Id", "dbo.Films");
            DropForeignKey("dbo.KinoCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.KinoCinemas", "Kino_Id", "dbo.Kinoes");
            DropIndex("dbo.FilmKinoes", new[] { "Kino_Id" });
            DropIndex("dbo.FilmKinoes", new[] { "Film_Id" });
            DropIndex("dbo.FormatFilms", new[] { "Film_Id" });
            DropIndex("dbo.FormatFilms", new[] { "Format_Id" });
            DropIndex("dbo.KinoCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.KinoCinemas", new[] { "Kino_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FilmCovers", new[] { "Id" });
            DropIndex("dbo.ArticlesEvents", new[] { "News_Id1" });
            DropIndex("dbo.ArticlesEvents", new[] { "News_Id" });
            DropTable("dbo.FilmKinoes");
            DropTable("dbo.FormatFilms");
            DropTable("dbo.KinoCinemas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.News");
            DropTable("dbo.LogHistories");
            DropTable("dbo.Infoes");
            DropTable("dbo.Formats");
            DropTable("dbo.FilmCovers");
            DropTable("dbo.Films");
            DropTable("dbo.Kinoes");
            DropTable("dbo.Cinemas");
            DropTable("dbo.ArticlesEvents");
        }
    }
}
