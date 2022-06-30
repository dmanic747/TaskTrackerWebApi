using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Data.Migrations
{
    public partial class SeedTestingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CompletionDate", "Name", "Priority", "StartDate", "Status" },
                values: new object[] { new Guid("32504d45-34a0-4315-ab00-99caad137b8e"), new DateTime(2022, 7, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), "Project1", 1, new DateTime(2022, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CompletionDate", "Name", "Priority", "StartDate", "Status" },
                values: new object[] { new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352"), new DateTime(2022, 7, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), "Project2", 2, new DateTime(2022, 7, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CompletionDate", "Name", "Priority", "StartDate", "Status" },
                values: new object[] { new Guid("c2f3eab5-ed1f-474f-add4-b6d14cf69564"), new DateTime(2022, 7, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), "Project3", 3, new DateTime(2022, 7, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[,]
                {
                    { new Guid("2ac3dd2a-261f-4b91-9c09-fa1622cbe192"), "Description for Task1", "Task1", 1, new Guid("32504d45-34a0-4315-ab00-99caad137b8e"), (byte)1 },
                    { new Guid("2ee99086-6031-4624-b891-034ff894c247"), "Description for Task2", "Task2", 1, new Guid("32504d45-34a0-4315-ab00-99caad137b8e"), (byte)1 },
                    { new Guid("51f1f31d-1c1f-4b8a-b982-35c73bf5a59a"), "Description for Task3", "Task3", 1, new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352"), (byte)1 },
                    { new Guid("aa63cc96-b539-4d5b-8de2-bb9dbb36cab6"), "Description for Task4", "Task4", 1, new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352"), (byte)1 },
                    { new Guid("612ba24a-f8ac-410e-8343-40af1faab47a"), "Description for Task5", "Task5", 1, new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352"), (byte)1 },
                    { new Guid("a0cce7c0-26f0-4379-9f10-c96912cb12bb"), "Description for Task6", "Task6", 1, new Guid("c2f3eab5-ed1f-474f-add4-b6d14cf69564"), (byte)1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("2ac3dd2a-261f-4b91-9c09-fa1622cbe192"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("2ee99086-6031-4624-b891-034ff894c247"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("51f1f31d-1c1f-4b8a-b982-35c73bf5a59a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("612ba24a-f8ac-410e-8343-40af1faab47a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("a0cce7c0-26f0-4379-9f10-c96912cb12bb"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("aa63cc96-b539-4d5b-8de2-bb9dbb36cab6"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("32504d45-34a0-4315-ab00-99caad137b8e"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("c2f3eab5-ed1f-474f-add4-b6d14cf69564"));
        }
    }
}
