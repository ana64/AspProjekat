using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspMovie.DataAccess.Migrations
{
    public partial class AddCertificateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Certificate",
                table: "Certifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "CertificationId", "Certificate" },
                values: new object[,]
                {
                    { 1, "G" },
                    { 2, "PG" },
                    { 3, "PG-13" },
                    { 4, "R" }
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 79, DateTimeKind.Utc).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 79, DateTimeKind.Utc).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 79, DateTimeKind.Utc).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 80, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 80, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 80, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 29, 17, 80, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_Certificate",
                table: "Certifications",
                column: "Certificate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Certifications_Certificate",
                table: "Certifications");

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Certificate",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 705, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 705, DateTimeKind.Utc).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 705, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 707, DateTimeKind.Utc).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 707, DateTimeKind.Utc).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 707, DateTimeKind.Utc).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 0, 19, 41, 707, DateTimeKind.Utc).AddTicks(9190));
        }
    }
}
