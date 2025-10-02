using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antecipacao.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosAntecipacao_Empresas_EmpresaId",
                table: "CarrinhosAntecipacao");

            migrationBuilder.DropForeignKey(
                name: "FK_FaturamentosMensal_Empresas_EmpresaId",
                table: "FaturamentosMensal");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_CarrinhosAntecipacao_CarrinhoId",
                table: "NotasFiscais");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "NotasFiscais",
                newName: "CarrinhoAntecipacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NotasFiscais_CarrinhoId",
                table: "NotasFiscais",
                newName: "IX_NotasFiscais_CarrinhoAntecipacaoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "FaturamentosMensal",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "CarrinhosAntecipacao",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosAntecipacao_Empresas_EmpresaId",
                table: "CarrinhosAntecipacao",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturamentosMensal_Empresas_EmpresaId",
                table: "FaturamentosMensal",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_CarrinhosAntecipacao_CarrinhoAntecipacaoId",
                table: "NotasFiscais",
                column: "CarrinhoAntecipacaoId",
                principalTable: "CarrinhosAntecipacao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosAntecipacao_Empresas_EmpresaId",
                table: "CarrinhosAntecipacao");

            migrationBuilder.DropForeignKey(
                name: "FK_FaturamentosMensal_Empresas_EmpresaId",
                table: "FaturamentosMensal");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_CarrinhosAntecipacao_CarrinhoAntecipacaoId",
                table: "NotasFiscais");

            migrationBuilder.RenameColumn(
                name: "CarrinhoAntecipacaoId",
                table: "NotasFiscais",
                newName: "CarrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_NotasFiscais_CarrinhoAntecipacaoId",
                table: "NotasFiscais",
                newName: "IX_NotasFiscais_CarrinhoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "FaturamentosMensal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "CarrinhosAntecipacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosAntecipacao_Empresas_EmpresaId",
                table: "CarrinhosAntecipacao",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaturamentosMensal_Empresas_EmpresaId",
                table: "FaturamentosMensal",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_CarrinhosAntecipacao_CarrinhoId",
                table: "NotasFiscais",
                column: "CarrinhoId",
                principalTable: "CarrinhosAntecipacao",
                principalColumn: "Id");
        }
    }
}
