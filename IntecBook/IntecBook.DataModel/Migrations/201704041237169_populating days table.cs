namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class populatingdaystable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Days ( Name) VALUES ('Lunes')");
            Sql("INSERT INTO Days ( Name) VALUES ('Martes')");
            Sql("INSERT INTO Days ( Name) VALUES ('Miercoles')");
            Sql("INSERT INTO Days ( Name) VALUES ('Jueves')");
            Sql("INSERT INTO Days ( Name) VALUES ('Viernes')");
            Sql("INSERT INTO Days ( Name) VALUES ('Sábado')");
            Sql("INSERT INTO Days ( Name) VALUES ('Domingo')");
            Sql("INSERT INTO Majors ( MajorName) VALUES ('Ingeniería en Sistemas')");
        }

        public override void Down()
        {
        }
    }
}
