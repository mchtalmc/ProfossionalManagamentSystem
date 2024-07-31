using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagamentSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_CustomPermissions_CustomPermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_CustomRoles_CustomRoleId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_CustomPermissionId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_CustomRoleId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "CustomPermissionId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "CustomRoleId",
                table: "RolePermissions");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RolePermissions",
                newName: "CustomRolesId");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "RolePermissions",
                newName: "CustomPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CustomPermissionsId",
                table: "RolePermissions",
                column: "CustomPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CustomRolesId",
                table: "RolePermissions",
                column: "CustomRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_CustomPermissions_CustomPermissionsId",
                table: "RolePermissions",
                column: "CustomPermissionsId",
                principalTable: "CustomPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_CustomRoles_CustomRolesId",
                table: "RolePermissions",
                column: "CustomRolesId",
                principalTable: "CustomRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_CustomPermissions_CustomPermissionsId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_CustomRoles_CustomRolesId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_CustomPermissionsId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_CustomRolesId",
                table: "RolePermissions");

            migrationBuilder.RenameColumn(
                name: "CustomRolesId",
                table: "RolePermissions",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "CustomPermissionsId",
                table: "RolePermissions",
                newName: "PermissionId");

            migrationBuilder.AddColumn<int>(
                name: "CustomPermissionId",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomRoleId",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CustomPermissionId",
                table: "RolePermissions",
                column: "CustomPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CustomRoleId",
                table: "RolePermissions",
                column: "CustomRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_CustomPermissions_CustomPermissionId",
                table: "RolePermissions",
                column: "CustomPermissionId",
                principalTable: "CustomPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_CustomRoles_CustomRoleId",
                table: "RolePermissions",
                column: "CustomRoleId",
                principalTable: "CustomRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
