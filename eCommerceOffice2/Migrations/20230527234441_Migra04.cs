using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Office.Migrations
{
    public partial class Migra04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorVeiculo_Colaboradores_ColaboradorId",
                table: "ColaboradorVeiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorVeiculo_Veiculos_VeiculoId",
                table: "ColaboradorVeiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradorVeiculo",
                table: "ColaboradorVeiculo");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorVeiculo_VeiculoId",
                table: "ColaboradorVeiculo");

            migrationBuilder.RenameTable(
                name: "ColaboradorVeiculo",
                newName: "ColaboradoresVeiculos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradoresVeiculos",
                table: "ColaboradoresVeiculos",
                columns: new[] { "VeiculoId", "ColaboradorId" });

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 2, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 3, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 4, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8914), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 5, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 6, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 7, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8922), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresVeiculos_ColaboradorId",
                table: "ColaboradoresVeiculos",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresVeiculos_Colaboradores_ColaboradorId",
                table: "ColaboradoresVeiculos",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresVeiculos_Veiculos_VeiculoId",
                table: "ColaboradoresVeiculos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresVeiculos_Colaboradores_ColaboradorId",
                table: "ColaboradoresVeiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresVeiculos_Veiculos_VeiculoId",
                table: "ColaboradoresVeiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradoresVeiculos",
                table: "ColaboradoresVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradoresVeiculos_ColaboradorId",
                table: "ColaboradoresVeiculos");

            migrationBuilder.RenameTable(
                name: "ColaboradoresVeiculos",
                newName: "ColaboradorVeiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradorVeiculo",
                table: "ColaboradorVeiculo",
                columns: new[] { "ColaboradorId", "VeiculoId" });

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 2, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9587), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 3, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 4, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9595), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9598), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 5, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9601), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 6, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9615), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 7, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2023, 5, 27, 19, 46, 28, 101, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorVeiculo_VeiculoId",
                table: "ColaboradorVeiculo",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorVeiculo_Colaboradores_ColaboradorId",
                table: "ColaboradorVeiculo",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorVeiculo_Veiculos_VeiculoId",
                table: "ColaboradorVeiculo",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
