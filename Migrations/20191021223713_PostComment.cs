using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIStarter.Migrations
{
    public partial class PostComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            if(ActiveProvider == "Microsoft.EntityFrameworkCore.Sqlite"){
                migrationBuilder.DropTable(
                    name: "Comments");
                migrationBuilder.CreateTable(
                    name: "Comments",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        PostId = table.Column<string>(nullable: false, defaultValue: 0),
                        Text = table.Column<string>(nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Comments", x => x.Id);
                        table.ForeignKey(
                            name: "FK_Comments_Posts_PostId",
                            column: t => t.PostId,
                            principalTable: "Posts",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });
            }else{
                migrationBuilder.AddForeignKey(
                    name: "FK_Comments_Posts_PostId",
                    table: "Comments",
                    column: "PostId",
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);

            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comments");
        }
    }
}
