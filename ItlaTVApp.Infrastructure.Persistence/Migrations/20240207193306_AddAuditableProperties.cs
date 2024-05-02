using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItlaTVApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Series",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Series",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Productoras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Productoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Productoras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Productoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Generos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Generos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Productoras");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Productoras");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Productoras");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Productoras");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Generos");
        }
    }
}
