using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Customers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Customers");
        }
    }
}
