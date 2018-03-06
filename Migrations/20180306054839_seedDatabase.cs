using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace angular2.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 migrationBuilder.Sql("Insert Into Makes (Name) Values ('Make1')");
            migrationBuilder.Sql("Insert Into Makes (Name) Values ('Make2')");
            migrationBuilder.Sql("Insert Into Makes (Name) Values ('Make3')");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make1-ModelA',(select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make1-ModelB',(select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make1-ModelC',(select Id from Makes where Name='Make1'))");
           
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make2-ModelA',(select Id from Makes where Name='Make2'))");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make2-ModelB',(select Id from Makes where Name='Make2'))");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make2-ModelC',(select Id from Makes where Name='Make2'))");
           
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make3-ModelA',(select Id from Makes where Name='Make3'))");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make3-ModelB',(select Id from Makes where Name='Make3'))");
            migrationBuilder.Sql("Insert Into Models (Name,MakeId) Values ('Make3-ModelC',(select Id from Makes where Name='Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
