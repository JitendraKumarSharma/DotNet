namespace TeacherStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class StudentAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Address", c => c.String(nullable: false, defaultValue: ""));
        }

        public override void Down()
        {
            DropColumn("dbo.Student", "Address");
        }
    }
}
