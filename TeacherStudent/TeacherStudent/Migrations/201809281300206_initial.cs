namespace TeacherStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        Class = c.String(maxLength: 50, unicode: false),
                        Section = c.String(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(maxLength: 100, unicode: false),
                        Address = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Student", new[] { "TeacherId" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
        }
    }
}
