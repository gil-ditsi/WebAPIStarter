using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIStarter.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if(ActiveProvider == "Microsoft.EntityFrameworkCore.Sqlite"){
                migrationBuilder.DropTable(
                    name: "Addresses");
                migrationBuilder.CreateTable(
                    name: "Addresses",
                    columns: table => new
                    {
                        Id = table.Column<long>(nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        Line1 = table.Column<string>(nullable: false, maxLength: 100),
                        Line2 = table.Column<string>(nullable: true, maxLength: 100),
                        City = table.Column<string>(nullable: true, maxLength: 50),
                        StateProvice = table.Column<string>(nullable: true, maxLength: 50),
                        Zipcode = table.Column<string>(nullable: true, maxLength: 10),
                        AddressTypeId = table.Column<int>(nullable: false, defaultValue: 0)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Addresses", x => x.Id);
                    });
            }else{
                migrationBuilder.AlterColumn<string>(
                    name: "Line1",
                    table: "Addresses",
                    maxLength: 100,
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "TEXT",
                    oldNullable: true);
            
                migrationBuilder.AddColumn<int>(
                    name: "AddressTypeId",
                    table: "Addresses",
                    nullable: false,
                    defaultValue: 0);
            }


            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    AddressId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => new { x.CustomerId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressId",
                table: "CustomerAddresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Line1",
                table: "Addresses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
