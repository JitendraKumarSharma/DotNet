namespace TeacherStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teacher", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teacher", "Mobile");
        }
    }
}
