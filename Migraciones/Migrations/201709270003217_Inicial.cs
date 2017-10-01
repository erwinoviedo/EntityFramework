namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgendaPersonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documentos",
                c => new
                    {
                        CITE = c.String(),
                        Id = c.Int(nullable: false, identity: true),
                        Referencia = c.String(maxLength: 250),
                        FechaRecepcion = c.DateTime(nullable: false),
                        EmisorId = c.Int(nullable: false),
                        DestinatarioId = c.Int(nullable: false),
                        RedirigidoId = c.Int(nullable: false),
                        RedirigidoFecha = c.DateTime(nullable: false),
                        RecibidoPor = c.String(),
                        HaSidoRecibido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgendaPersonas", t => t.DestinatarioId)
                .ForeignKey("dbo.AgendaPersonas", t => t.EmisorId)
                .ForeignKey("dbo.AgendaPersonas", t => t.RedirigidoId)
                .Index(t => t.EmisorId)
                .Index(t => t.DestinatarioId)
                .Index(t => t.RedirigidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documentos", "RedirigidoId", "dbo.AgendaPersonas");
            DropForeignKey("dbo.Documentos", "EmisorId", "dbo.AgendaPersonas");
            DropForeignKey("dbo.Documentos", "DestinatarioId", "dbo.AgendaPersonas");
            DropIndex("dbo.Documentos", new[] { "RedirigidoId" });
            DropIndex("dbo.Documentos", new[] { "DestinatarioId" });
            DropIndex("dbo.Documentos", new[] { "EmisorId" });
            DropTable("dbo.Documentos");
            DropTable("dbo.AgendaPersonas");
        }
    }
}
