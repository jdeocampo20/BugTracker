using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Persistence.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tickets",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Dummy project for testing", "Test Project 1" },
                    { 2, "Dummy project for testing", "Test Project 2" }
                });

            migrationBuilder.InsertData(
                table: "TicketPriorities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Trivial problem with little or no impact on progress.", "Trivial" },
                    { 2, "Minor problem or easily worked around.", "Low" },
                    { 3, "Has the potential to affect progress.", "Medium" },
                    { 4, "Serious problem that could block progress.", "High" },
                    { 5, "Problem blocks progress.", "Critical" }
                });

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The issue has been reported and is waiting for the team to action it.", "To Do" },
                    { 2, "The issue is open and ready for the assignee to start work on it.", "Open" },
                    { 3, "This issue is being actively worked on at the moment by the assignee.", "In Progress" },
                    { 4, "A resolution has been taken, and it is awaiting verification by reporter. From here, issues are either reopened, or are closed.", "Resolved" },
                    { 5, "This issue was once resolved, but the resolution was deemed incorrect. From here, issues are either marked assigned or resolved.", "Reopened" },
                    { 6, "The issue is considered finished. The resolution is correct. Issues which are closed can be reopened.", "Closed" }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "There is a defect in the application code or logic", "Bug" },
                    { 2, "There is a request for new functionality for the application", "Enhancement" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "ProjectId", "TicketPriorityId", "TicketStatusId", "TicketTypeId" },
                values: new object[] { 1, new DateTime(2020, 4, 7, 0, 26, 4, 708, DateTimeKind.Local).AddTicks(1900), "User menu item is missing in the nav bar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Missing user nav menu", 1, 4, 1, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "ProjectId", "TicketPriorityId", "TicketStatusId", "TicketTypeId" },
                values: new object[] { 2, new DateTime(2020, 4, 13, 0, 26, 4, 722, DateTimeKind.Local).AddTicks(530), "Link to dashboard page missing in nav", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Missing dashboard nav menu", 1, 4, 3, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "ProjectId", "TicketPriorityId", "TicketStatusId", "TicketTypeId" },
                values: new object[] { 3, new DateTime(2020, 4, 7, 0, 26, 4, 722, DateTimeKind.Local).AddTicks(610), "Create new page where the user can edit the ticket details", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Details page", 2, 3, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024);
        }
    }
}
