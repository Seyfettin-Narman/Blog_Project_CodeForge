using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeyfBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("45573ef1-1130-4544-b975-d2a2b44ef2b1"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("55d0a250-dcba-4a93-9717-3de16758e1f0"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("82f6f374-ff04-4444-be78-f03031e4ad60"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "eaee603e-8727-4436-b299-cbba12526c3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b48aa289-340a-4694-9f72-c11e5d95c581"),
                column: "ConcurrencyStamp",
                value: "e7a37843-3d00-4ce9-a005-d0d52286b0b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4d0283b-3499-4189-a720-62b0f778de6b"),
                column: "ConcurrencyStamp",
                value: "5ae2dee5-74d2-4887-bc97-400444c3dd6c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b35a3fd6-698f-4bb9-af71-8c4e8478c2e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cc34a42-7270-4ad0-a871-0ec045ca15d2", "AQAAAAIAAYagAAAAEFUBOjTGq3nI2te6GpIYcOJOG9vZeE1QpzCPCgYa10MHAUnrCq2z+vxa8ohy0doDoQ==", "9a06dbd1-b732-4a85-9db6-432570a6a1c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38c270c2-304a-4aca-b965-f452052b6a1d", "AQAAAAIAAYagAAAAEI0XZ+29RqnoklfqQye3lBNqgoPzsP2v4m8eIEmvzf/jWq6HBjCRVy7T6FR9mK4R1g==", "5c0f6924-5866-4f49-afa1-d34218553311" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2edffa17-0a93-4b0a-b8fb-7b1662f68611"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f935ac0-fc48-4404-8a3e-f4d092223e8e"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e139175-6c2d-4f87-b26b-f3fdac76ef6d"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("026dd0d1-07f7-4f83-9324-d091ca7403f2"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("18339c9c-0871-4f8f-8ee1-eaaf482b813d"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9ed22153-c44e-4b44-84cd-072e889fb62c"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "ModifiedBy", "ModifiedDate", "Title", "UserId", "Views", "isActive" },
                values: new object[,]
                {
                    { new Guid("45573ef1-1130-4544-b975-d2a2b44ef2b1"), new Guid("9e139175-6c2d-4f87-b26b-f3fdac76ef6d"), "Curabitur cursus ullamcorper sapien, at fermentum elit finibus at. Nunc tristique nec sapien eu feugiat. Ut quis dictum turpis. Proin", "Murat", new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(6281), null, null, new Guid("026dd0d1-07f7-4f83-9324-d091ca7403f2"), null, null, "CodeRoots: Planting the Seeds of JavaScript", new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"), 10, false },
                    { new Guid("55d0a250-dcba-4a93-9717-3de16758e1f0"), new Guid("2edffa17-0a93-4b0a-b8fb-7b1662f68611"), "Nullam eleifend, nisl vel molestie iaculis, metus lorem mollis mi, vitae interdum odio lorem id odio. Duis aliquet est orci.", "Seyfettin", new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(6340), null, null, new Guid("9ed22153-c44e-4b44-84cd-072e889fb62c"), null, null, "The Evolution of Avionics Networks From ARINC 429 to AFDX", new Guid("c1315bb8-4d09-450e-a549-8ba87d8fa228"), 40, false },
                    { new Guid("82f6f374-ff04-4444-be78-f03031e4ad60"), new Guid("2f935ac0-fc48-4404-8a3e-f4d092223e8e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse consectetur dolor non ex gravida, at.", "Seyfettin", new DateTime(2024, 3, 21, 16, 26, 30, 739, DateTimeKind.Local).AddTicks(6276), null, null, new Guid("18339c9c-0871-4f8f-8ee1-eaaf482b813d"), null, null, "Back-End CodeForge Bootcamp", new Guid("b35a3fd6-698f-4bb9-af71-8c4e8478c2e4"), 4, false }
                });
        }
    }
}
