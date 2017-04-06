namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addingmoredays : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Days ( Name) VALUES ('Lunes y Miercoles')");
            Sql("INSERT INTO Days ( Name) VALUES ('Martes y Jueves')");
            Sql("INSERT INTO Days ( Name) VALUES ('Miercoles y Jueves')");
            Sql("INSERT INTO Days ( Name) VALUES ('Lunes y Martes')");

        }

        public override void Down()
        {
        }
    }
}
