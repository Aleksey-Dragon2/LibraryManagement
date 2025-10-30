using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateOnly(1828, 9, 9), "Leo Tolstoy" },
                    { 2, new DateOnly(1821, 11, 11), "Fyodor Dostoevsky" },
                    { 3, new DateOnly(1860, 1, 29), "Anton Chekhov" },
                    { 4, new DateOnly(1799, 6, 6), "Alexander Pushkin" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublisherYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1869, "War and Peace" },
                    { 2, 1, 1877, "Anna Karenina" },
                    { 3, 1, 1899, "Resurrection" },
                    { 4, 2, 1880, "The Brothers Karamazov" },
                    { 5, 2, 1866, "Crime and Punishment" },
                    { 6, 2, 1869, "The Idiot" },
                    { 7, 2, 1864, "Notes from Underground" },
                    { 8, 3, 1904, "The Cherry Orchard" },
                    { 9, 3, 1899, "Uncle Vanya" },
                    { 10, 3, 1901, "Three Sisters" },
                    { 11, 3, 1896, "The Seagull" },
                    { 12, 4, 1833, "Eugene Onegin" },
                    { 13, 4, 1825, "Boris Godunov" },
                    { 14, 4, 1836, "The Captain's Daughter" },
                    { 15, 4, 1820, "Ruslan and Ludmila" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
