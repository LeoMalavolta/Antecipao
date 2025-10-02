using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antecipacao.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCamposEntidades : Migration
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
                name: "FK_NotasFiscais_CarrinhosAntecipacao_CarrinhoAntecipacaoId",
                table: "NotasFiscais");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_Empresas_EmpresaId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_CarrinhoAntecipacaoId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_EmpresaId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_FaturamentosMensal_EmpresaId",
                table: "FaturamentosMensal");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhosAntecipacao_EmpresaId",
                table: "CarrinhosAntecipacao");

            migrationBuilder.DropColumn(
                name: "CarrinhoAntecipacaoId",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "FaturamentosMensal");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "CarrinhosAntecipacao");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresas",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_IdCarrinho",
                table: "NotasFiscais",
                column: "IdCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_IdEmpresa",
                table: "NotasFiscais",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FaturamentosMensal_IdEmpresa",
                table: "FaturamentosMensal",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Cnpj",
                table: "Empresas",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhosAntecipacao_IdEmpresa",
                table: "CarrinhosAntecipacao",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosAntecipacao_Empresas_IdEmpresa",
                table: "CarrinhosAntecipacao",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaturamentosMensal_Empresas_IdEmpresa",
                table: "FaturamentosMensal",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_CarrinhosAntecipacao_IdCarrinho",
                table: "NotasFiscais",
                column: "IdCarrinho",
                principalTable: "CarrinhosAntecipacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_Empresas_IdEmpresa",
                table: "NotasFiscais",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosAntecipacao_Empresas_IdEmpresa",
                table: "CarrinhosAntecipacao");

            migrationBuilder.DropForeignKey(
                name: "FK_FaturamentosMensal_Empresas_IdEmpresa",
                table: "FaturamentosMensal");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_CarrinhosAntecipacao_IdCarrinho",
                table: "NotasFiscais");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_Empresas_IdEmpresa",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_IdCarrinho",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_IdEmpresa",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_FaturamentosMensal_IdEmpresa",
                table: "FaturamentosMensal");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_Cnpj",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhosAntecipacao_IdEmpresa",
                table: "CarrinhosAntecipacao");

            migrationBuilder.AddColumn<Guid>(
                name: "CarrinhoAntecipacaoId",
                table: "NotasFiscais",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "NotasFiscais",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "FaturamentosMensal",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "CarrinhosAntecipacao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_CarrinhoAntecipacaoId",
                table: "NotasFiscais",
                column: "CarrinhoAntecipacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_EmpresaId",
                table: "NotasFiscais",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturamentosMensal_EmpresaId",
                table: "FaturamentosMensal",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhosAntecipacao_EmpresaId",
                table: "CarrinhosAntecipacao",
                column: "EmpresaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_Empresas_EmpresaId",
                table: "NotasFiscais",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }
    }
}
