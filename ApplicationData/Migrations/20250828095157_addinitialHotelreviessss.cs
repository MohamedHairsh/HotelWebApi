using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationLayer.Migrations
{
    /// <inheritdoc />
    public partial class addinitialHotelreviessss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Staffs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Staffs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Staffs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "Staffs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "Staffs",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCode",
                table: "Staffs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Staffs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Staffs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Staffs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Staffs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportingManagerId",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Staffs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Staffs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                table: "Staffs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Amenities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReservationRequired",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Amenities",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HotelReview",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReviewerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReview", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_HotelReview_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_HotelId",
                table: "HotelReview",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelReview");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "EmployeeCode",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ReportingManagerId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "IsReservationRequired",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Amenities");
        }
    }
}
