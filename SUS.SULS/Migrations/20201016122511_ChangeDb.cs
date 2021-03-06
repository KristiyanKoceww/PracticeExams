﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SUS.SULS.Migrations
{
    public partial class ChangeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Problems_ProblemId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_ProblemId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Submissions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProblemId",
                table: "Submissions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProblemId1",
                table: "Submissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Submissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ProblemId1",
                table: "Submissions",
                column: "ProblemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId1",
                table: "Submissions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Problems_ProblemId1",
                table: "Submissions",
                column: "ProblemId1",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserId1",
                table: "Submissions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Problems_ProblemId1",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId1",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_ProblemId1",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_UserId1",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "ProblemId1",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Submissions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Submissions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ProblemId",
                table: "Submissions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ProblemId",
                table: "Submissions",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Problems_ProblemId",
                table: "Submissions",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
