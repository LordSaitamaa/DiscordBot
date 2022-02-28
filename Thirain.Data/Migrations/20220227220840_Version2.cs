using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Thirain.Data.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "EventCreator",
                table: "Event",
                newName: "Initiator");

            migrationBuilder.RenameColumn(
                name: "EventBeschreibung",
                table: "Event",
                newName: "Beschreibung");

            migrationBuilder.AddColumn<int>(
                name: "Rolle",
                table: "EventParticipants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "EventParticipants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TemplateType = table.Column<int>(type: "integer", nullable: false),
                    TemplateName = table.Column<string>(type: "text", nullable: false),
                    TemplateBeschreibung = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropColumn(
                name: "Rolle",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "EventParticipants");

            migrationBuilder.RenameColumn(
                name: "Initiator",
                table: "Event",
                newName: "EventCreator");

            migrationBuilder.RenameColumn(
                name: "Beschreibung",
                table: "Event",
                newName: "EventBeschreibung");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Klasse = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }
    }
}
