namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actividades",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        nombre = c.String(),
                        informacion = c.String(),
                        direccion = c.String(),
                        horarioinicial = c.DateTime(nullable: false),
                        horariofinal = c.DateTime(nullable: false),
                        latitud = c.String(),
                        longitud = c.String(),
                        altitud = c.String(),
                        accuracy = c.String(),
                        idusuario = c.Long(nullable: false),
                        Usuarios_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_id)
                .Index(t => t.Usuarios_id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        email = c.String(),
                        password = c.String(),
                        nombre = c.String(),
                        apellidos = c.String(),
                        numerotelefono1 = c.String(),
                        numerotelefono2 = c.String(),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.actividadesamigos",
                c => new
                    {
                        idactividad = c.Long(nullable: false),
                        idamigo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.idactividad, t.idamigo });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.actividades", "Usuarios_id", "dbo.Usuarios");
            DropIndex("dbo.actividades", new[] { "Usuarios_id" });
            DropTable("dbo.actividadesamigos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.actividades");
        }
    }
}
