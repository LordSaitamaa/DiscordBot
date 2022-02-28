using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Thirain.Data.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rolle",
                table: "EventParticipants");

            migrationBuilder.RenameColumn(
                name: "TemplateBeschreibung",
                table: "Templates",
                newName: "TemplateDescription");

            migrationBuilder.RenameColumn(
                name: "SID",
                table: "Event",
                newName: "Template");

            migrationBuilder.RenameColumn(
                name: "Beschreibung",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "SID",
                table: "Config",
                newName: "ServerID");

            migrationBuilder.RenameColumn(
                name: "CID",
                table: "Config",
                newName: "ChannelID");

            migrationBuilder.AddColumn<long>(
                name: "RoleID",
                table: "EventParticipants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ServerID",
                table: "Event",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventID = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ServerID",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "TemplateDescription",
                table: "Templates",
                newName: "TemplateBeschreibung");

            migrationBuilder.RenameColumn(
                name: "Template",
                table: "Event",
                newName: "SID");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "Beschreibung");

            migrationBuilder.RenameColumn(
                name: "ServerID",
                table: "Config",
                newName: "SID");

            migrationBuilder.RenameColumn(
                name: "ChannelID",
                table: "Config",
                newName: "CID");

            migrationBuilder.AddColumn<int>(
                name: "Rolle",
                table: "EventParticipants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
