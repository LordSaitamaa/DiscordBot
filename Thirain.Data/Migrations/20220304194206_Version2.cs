using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thirain.Data.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Templates_TemplatesID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRoles_Templates_TemplatesID",
                table: "EventRoles");

            migrationBuilder.RenameColumn(
                name: "TemplatesID",
                table: "EventRoles",
                newName: "TemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_EventRoles_TemplatesID",
                table: "EventRoles",
                newName: "IX_EventRoles_TemplateID");

            migrationBuilder.RenameColumn(
                name: "TemplatesID",
                table: "Event",
                newName: "TemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_Event_TemplatesID",
                table: "Event",
                newName: "IX_Event_TemplateID");

            migrationBuilder.AddColumn<int>(
                name: "Inline",
                table: "Templates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ServerID",
                table: "Templates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Templates_TemplateID",
                table: "Event",
                column: "TemplateID",
                principalTable: "Templates",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRoles_Templates_TemplateID",
                table: "EventRoles",
                column: "TemplateID",
                principalTable: "Templates",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Templates_TemplateID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRoles_Templates_TemplateID",
                table: "EventRoles");

            migrationBuilder.DropColumn(
                name: "Inline",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "ServerID",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubRoles");

            migrationBuilder.RenameColumn(
                name: "TemplateID",
                table: "EventRoles",
                newName: "TemplatesID");

            migrationBuilder.RenameIndex(
                name: "IX_EventRoles_TemplateID",
                table: "EventRoles",
                newName: "IX_EventRoles_TemplatesID");

            migrationBuilder.RenameColumn(
                name: "TemplateID",
                table: "Event",
                newName: "TemplatesID");

            migrationBuilder.RenameIndex(
                name: "IX_Event_TemplateID",
                table: "Event",
                newName: "IX_Event_TemplatesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Templates_TemplatesID",
                table: "Event",
                column: "TemplatesID",
                principalTable: "Templates",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRoles_Templates_TemplatesID",
                table: "EventRoles",
                column: "TemplatesID",
                principalTable: "Templates",
                principalColumn: "ID");
        }
    }
}
