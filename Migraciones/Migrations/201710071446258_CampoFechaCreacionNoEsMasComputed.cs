namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoFechaCreacionNoEsMasComputed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documentos", "FechaCreacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documentos", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
