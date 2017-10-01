namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoCampoFechaCreacionEnDocumento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documentos", "FechaCreacion", c => c.DateTime(nullable: false,defaultValueSql:"GetDate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documentos", "FechaCreacion");
        }
    }
}
