using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeyfBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1b5f23cd-d833-458d-b994-8f1d252d526e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("880574f1-c12a-4ad8-b47e-da4c9d335aff"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a8fcc1e6-2a0a-413f-9e3d-a11de81e11a2"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08dd1239-f563-44e7-a389-b692da355ce8"),
                column: "ConcurrencyStamp",
                value: "5ea119a2-3875-4cac-b0aa-452130b22e13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b48aa289-340a-4694-9f72-c11e5d95c581"),
                column: "ConcurrencyStamp",
                value: "292e3d6c-573d-4afd-8a27-43915c56ff33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4d0283b-3499-4189-a720-62b0f778de6b"),
                column: "ConcurrencyStamp",
                value: "ae2ccc64-369a-48b6-93e2-4d71eced4b02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b35a3fd6-698f-4bb9-af71-8c4e8478c2e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f63c094-3d60-4817-9e71-206b4f464163", "AQAAAAIAAYagAAAAEMBVP21rDvMVz2+sU4cxzZEY9JLhahmheekdPi4IFESVTxsK9XWbJ/zqMrx2NJYZeA==", "59de696c-6154-405d-9355-cbc5612dd642" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04616970-8200-453c-872c-4b7e98a2ef1d", "AQAAAAIAAYagAAAAEBCIYU/JiKNL4F8q4Y4Hv2KRXHlmOjMZLeWDoL+5Wrttcso5H/wdFzLCVmqwqnx1fg==", "317230f5-82fb-46a6-844f-c0048656f10b" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2edffa17-0a93-4b0a-b8fb-7b1662f68611"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 11, 32, 36, 450, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f935ac0-fc48-4404-8a3e-f4d092223e8e"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 11, 32, 36, 450, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e139175-6c2d-4f87-b26b-f3fdac76ef6d"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 11, 32, 36, 450, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("026dd0d1-07f7-4f83-9324-d091ca7403f2"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 11, 32, 36, 451, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("18339c9c-0871-4f8f-8ee1-eaaf482b813d"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 11, 32, 36, 451, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9ed22153-c44e-4b44-84cd-072e889fb62c"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 11, 32, 36, 451, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "ModifiedBy", "ModifiedDate", "Title", "UserId", "Views", "isActive" },
                values: new object[,]
                {
                    { new Guid("1d0977ee-48d0-4cef-893e-eb1f5f7319fd"), new Guid("2edffa17-0a93-4b0a-b8fb-7b1662f68611"), "Nullam eleifend, nisl vel molestie iaculis, metus lorem mollis mi, vitae interdum odio lorem id odio. Duis aliquet est orci.", "Seyfettin", new DateTime(2024, 3, 22, 11, 32, 36, 451, DateTimeKind.Local).AddTicks(1798), null, null, new Guid("9ed22153-c44e-4b44-84cd-072e889fb62c"), null, null, "The Evolution of Avionics Networks From ARINC 429 to AFDX", new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"), 40, false },
                    { new Guid("999cdf12-4a9e-4a3e-90a5-4ceb81bbd2d5"), new Guid("9e139175-6c2d-4f87-b26b-f3fdac76ef6d"), "Curabitur cursus ullamcorper sapien, at fermentum elit finibus at. Nunc tristique nec sapien eu feugiat. Ut quis dictum turpis. Proin", "Murat", new DateTime(2024, 3, 22, 11, 32, 36, 451, DateTimeKind.Local).AddTicks(1793), null, null, new Guid("026dd0d1-07f7-4f83-9324-d091ca7403f2"), null, null, "CodeRoots: Planting the Seeds of JavaScript", new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"), 10, false },
                    { new Guid("f3aa68ab-395f-4978-9e58-2cde2e30e799"), new Guid("2f935ac0-fc48-4404-8a3e-f4d092223e8e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse consectetur dolor non ex gravida, at.", "Seyfettin", new DateTime(2024, 3, 22, 11, 32, 36, 451, DateTimeKind.Local).AddTicks(1785), null, null, new Guid("18339c9c-0871-4f8f-8ee1-eaaf482b813d"), null, null, "Back-End CodeForge Bootcamp", new Guid("b35a3fd6-698f-4bb9-af71-8c4e8478c2e4"), 4, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1d0977ee-48d0-4cef-893e-eb1f5f7319fd"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("999cdf12-4a9e-4a3e-90a5-4ceb81bbd2d5"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f3aa68ab-395f-4978-9e58-2cde2e30e799"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08dd1239-f563-44e7-a389-b692da355ce8"),
                column: "ConcurrencyStamp",
                value: "baf5c095-7ad0-4f73-a83c-bd35e4a941c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b48aa289-340a-4694-9f72-c11e5d95c581"),
                column: "ConcurrencyStamp",
                value: "aeb021d2-c63a-4cdf-a700-1a141834b986");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4d0283b-3499-4189-a720-62b0f778de6b"),
                column: "ConcurrencyStamp",
                value: "bb809ea4-9666-450f-898c-5298ec159053");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b35a3fd6-698f-4bb9-af71-8c4e8478c2e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ff3680c-5091-4d26-b78d-853a786734c5", "AQAAAAIAAYagAAAAED56U0dE+91Hf3NQ9Y3bvIHL0lml0Ma8F022RuAOIG4jBryhqUKOgNv/DMjMYeMSDg==", "b14993c7-82c2-447d-bca1-a50e1deae809" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3a12f11-e12f-4fcd-b4e1-91dc53a86639", "AQAAAAIAAYagAAAAEJNT+pv5rrNYRgezVQ5roQ/l/Upxo9cqrqZpfDiD4nx60NhpXuEf0qfCb1msU8z1uw==", "90395d64-68f1-419b-adca-7d97c713b34c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2edffa17-0a93-4b0a-b8fb-7b1662f68611"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f935ac0-fc48-4404-8a3e-f4d092223e8e"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e139175-6c2d-4f87-b26b-f3fdac76ef6d"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("026dd0d1-07f7-4f83-9324-d091ca7403f2"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("18339c9c-0871-4f8f-8ee1-eaaf482b813d"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9ed22153-c44e-4b44-84cd-072e889fb62c"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "ModifiedBy", "ModifiedDate", "Title", "UserId", "Views", "isActive" },
                values: new object[,]
                {
                    { new Guid("1b5f23cd-d833-458d-b994-8f1d252d526e"), new Guid("9e139175-6c2d-4f87-b26b-f3fdac76ef6d"), "Curabitur cursus ullamcorper sapien, at fermentum elit finibus at. Nunc tristique nec sapien eu feugiat. Ut quis dictum turpis. Proin", "Murat", new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(4718), null, null, new Guid("026dd0d1-07f7-4f83-9324-d091ca7403f2"), null, null, "CodeRoots: Planting the Seeds of JavaScript", new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"), 10, false },
                    { new Guid("880574f1-c12a-4ad8-b47e-da4c9d335aff"), new Guid("2f935ac0-fc48-4404-8a3e-f4d092223e8e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse consectetur dolor non ex gravida, at.", "Seyfettin", new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(4712), null, null, new Guid("18339c9c-0871-4f8f-8ee1-eaaf482b813d"), null, null, "Back-End CodeForge Bootcamp", new Guid("b35a3fd6-698f-4bb9-af71-8c4e8478c2e4"), 4, false },
                    { new Guid("a8fcc1e6-2a0a-413f-9e3d-a11de81e11a2"), new Guid("2edffa17-0a93-4b0a-b8fb-7b1662f68611"), "Nullam eleifend, nisl vel molestie iaculis, metus lorem mollis mi, vitae interdum odio lorem id odio. Duis aliquet est orci.", "Seyfettin", new DateTime(2024, 3, 22, 7, 38, 18, 39, DateTimeKind.Local).AddTicks(4723), null, null, new Guid("9ed22153-c44e-4b44-84cd-072e889fb62c"), null, null, "The Evolution of Avionics Networks From ARINC 429 to AFDX", new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"), 40, false }
                });
        }
    }
}
