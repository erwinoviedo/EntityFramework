namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoRedirigidoFechaNoEsMasComputed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documentos", "RedirigidoFecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documentos", "RedirigidoFecha", c => c.DateTime(nullable: false));
        }
    }
}
