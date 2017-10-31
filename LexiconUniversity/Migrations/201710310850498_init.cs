namespace LexiconUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", "IX_CourseStudent");
            AlterColumn("dbo.Enrollments", "CourseId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Enrollments", new[] { "CourseId", "StudentId" }, unique: true, name: "IX_CourseStudent");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", "IX_CourseStudent");
            AlterColumn("dbo.Enrollments", "CourseId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollments", new[] { "CourseId", "StudentId" }, unique: true, name: "IX_CourseStudent");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "CourseId");
        }
    }
}
