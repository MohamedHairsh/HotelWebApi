using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationLayer.Migrations
{
    /// <inheritdoc />
    public partial class addstafftodbssdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Staffs");
        }
    }
}
