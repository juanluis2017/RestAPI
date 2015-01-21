using System;
using System.Data.Entity.Migrations;

namespace BookService.Migrations
{
    
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.usuarios",
                c => new
                {
                    id = c.Long(nullable: false, identity: true),
                    email = c.String(nullable: false),
                    password = c.String(nullable:false),
                    nombre = c.String(nullable:true),
                    apellidos = c.String(nullable: true),
                    numrotelefono1 = c.String(nullable: true),
                    numerotelefono2 = c.String(nullable: true),
                    created_at = c.String(nullable: true),
                    updated_at = c.String(nullable: true),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.actividades",
                c => new
                {
                    id = c.Long(nullable: false, identity: true),
                    nombre = c.String(nullable: false),
                    informacion = c.String(nullable: true),
                    direccion = c.Decimal(nullable: false, precision: 18, scale: 2),
                    horarioinicial = c.DateTime(nullable: true),
                    horariofinal = c.DateTime(nullable: true),
                    //aqui vamos a los datos relacionados con la geolocalizacion
                    latitud = c.String(nullable: true),
                    longitud = c.String(nullable: true),
                    altitud = c.String(nullable: true),
                    //precision = accuracy cambio el nombre pq MySQL no me deja usar la palabra precision 
                    accuracy = c.String(nullable: true),
                    idusuario  = c.Long(nullable: true),

                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.usuarios", t => t.idusuario, cascadeDelete: true)
                .Index(t => t.idusuario);
            CreateTable("dbo.actividadesamigos",
                c => new
                {
                    idactividad = c.Long(nullable: false),
                    idamigo = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.idactividad)
                .PrimaryKey(t => t.idamigo)
                .ForeignKey("dbo.actividades", t => t.idactividad)
                .ForeignKey("dbo.usuarios", t => t.idamigo)
                .Index(t => t.idactividad)
                .Index(t => t.idamigo);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
    