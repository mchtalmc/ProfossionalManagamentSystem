using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagamentSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fix_fix_fixedauthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "UserPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserPermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "UserPermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "UserPermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "UserPermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovedBy",
                table: "UserPermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "UserPermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "RolePermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "RolePermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovedBy",
                table: "RolePermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "CustomRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "CustomRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "CustomRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CustomRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovedBy",
                table: "CustomRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "CustomRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "CustomPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomPermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "CustomPermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "CustomPermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CustomPermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovedBy",
                table: "CustomPermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "CustomPermissions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "RemovedBy",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "RemovedBy",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "RemovedBy",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "CustomRoles");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "CustomPermissions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CustomPermissions");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "CustomPermissions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CustomPermissions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CustomPermissions");

            migrationBuilder.DropColumn(
                name: "RemovedBy",
                table: "CustomPermissions");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "CustomPermissions");
        }
    }
}
