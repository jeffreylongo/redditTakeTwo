namespace redditTakeTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RedditPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        UpVotes = c.Int(nullable: false),
                        DownVotes = c.Int(nullable: false),
                        PostedAt = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RedditPosts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RedditPosts", new[] { "UserId" });
            DropTable("dbo.RedditPosts");
        }
    }
}
