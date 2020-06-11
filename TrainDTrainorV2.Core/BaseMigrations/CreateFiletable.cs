using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.BaseMigrations
{
    public abstract class CreateFiletable : DbMigrationBase
    {
        protected abstract string TableName { get; }
        protected abstract string JoinTableName { get; }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Filetable_Up(migrationBuilder);
            Function_Up(migrationBuilder);
            View_Up(migrationBuilder);
            CreateDir_Up(migrationBuilder);
            CreateFile_Up(migrationBuilder);
            Find_ParentFolder(migrationBuilder);
            Rename_Up(migrationBuilder);
            Update_Up(migrationBuilder);
            Delete_Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            Filetable_Down(migrationBuilder);
            Function_Down(migrationBuilder);
            View_Down(migrationBuilder);
            CreateDir_Down(migrationBuilder);
            CreateFile_Down(migrationBuilder);
            Find_ParentFolder_Down(migrationBuilder);
            Rename_Down(migrationBuilder);
            Update_Down(migrationBuilder);
            Delete_Down(migrationBuilder);
        }


        public  void Filetable_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(
            @"CREATE TABLE [{0}] AS FileTable WITH (FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME = {0}_streamid_constraint)", TableName));
        }

        public  void Filetable_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(
            @"DROP TABLE [{0}]", TableName));
        }
        public void Function_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
                CREATE FUNCTION [dbo].[{0}_FullDirPullPath](@FileId uniqueidentifier)
                      RETURNS NVARCHAR(250)
                      AS
                      BEGIN
                      DECLARE @root nvarchar(100);
                      DECLARE @fullpath nvarchar(250);
            SELECT @root = FileTableRootPath();
            SELECT @fullpath = @root + file_stream.GetFileNamespacePath()
                               FROM dbo.{0}
                               WHERE stream_id = @FileId;
            RETURN @fullpath;
            END",TableName));
        }
       
        public  void Function_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP FUNCTION [{0}_FullDirPullPath]", TableName));
        }
        public  void View_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE VIEW {0}_View AS            
            SELECT 
	             a.stream_id
	            ,a.file_stream
	            ,a.name
	            ,a.file_type
	            ,a.cached_file_size
	            ,a.creation_time
	            ,a.last_write_time
	            ,a.last_access_time
	            ,a.is_directory
	            ,a.is_offline
	            ,a.is_hidden
	            ,a.is_readonly
	            ,a.is_archive
	            ,a.is_system
	            ,a.is_temporary
                ,a.parent_path_locator.ToString() as [parentpath]
                ,a.path_locator.ToString() as [path]
                ,[dbo].[{0}_FullDirPullPath](stream_id) as fullpath
                ,b.Id                
            FROM 
	            [{0}] AS a INNER JOIN 
                [{1}] AS b ON a.stream_id = b.FileId
            ", TableName,JoinTableName));
        }

        public  void View_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP VIEW [{0}_View]", TableName));
        }

        public void CreateDir_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE PROCEDURE [{0}_CreateDir] (@name AS NVARCHAR(255), @parentpath nvarchar(4000))
            AS
            BEGIN
	            INSERT INTO [{0}] (name, path_locator, is_directory, is_archive) 
                OUTPUT INSERTED.stream_id, INSERTED.path_locator.ToString() as [path]
	            VALUES (@name, dbo.GetNewPathLocator(@parentpath), 1, 0)
            END
            ", TableName));
        }

        public void CreateDir_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP PROCEDURE [{0}_CreateDir]", TableName));
        }

        public void CreateFile_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE PROCEDURE [{0}_CreateFile] (
	            @name nvarchar(255), 
	            @file_stream varbinary(max),
	            @parentpath nvarchar(4000),
	            @is_hidden bit = 0,
	            @is_readonly bit = 0,
	            @is_archive bit = 0,
	            @is_system bit = 0,
	            @is_temporary bit = 0
            )
            AS
            BEGIN
                INSERT INTO [{0}](
                   [name]
	              ,[file_stream]
                  ,[path_locator]
                  ,[is_hidden]
                  ,[is_readonly]
                  ,[is_archive]
                  ,[is_system]
                  ,[is_temporary]
	            ) 
	            OUTPUT INSERTED.stream_id, INSERTED.path_locator.ToString() as [path]
	            VALUES (@name, @file_stream, dbo.GetNewPathLocator(@parentpath), @is_hidden, @is_readonly, @is_archive, @is_system, @is_temporary)
            END
            ", TableName));
        }
       
        public void CreateFile_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP PROCEDURE [{0}_CreateFile]", TableName));
        }

        public void Find_ParentFolder(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE PROCEDURE [{0}_Folder] (
	            @name nvarchar(255)	           
            )
            AS
            BEGIN
                SELECT stream_id, path_locator.ToString() as [path] FROM [{0}]
                WHERE name = @name                 
            END
            ", TableName));
        }
        public void Find_ParentFolder_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP PROCEDURE [{0}_Folder]", TableName));
        }
        public void Rename_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE PROCEDURE [{0}_Rename] (
	             @stream_id uniqueidentifier
	            ,@name nvarchar(255)
            ) AS
            BEGIN
	            UPDATE [{0}] SET name = @name WHERE stream_id = @stream_id
            END
            ", TableName));
        }

        public void Rename_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP PROCEDURE [{0}_Rename]", TableName));
        }

        public void Update_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE PROCEDURE [{0}_Update] (
	             @stream_id uniqueidentifier
	            ,@file_stream varbinary(max)
            ) AS
            BEGIN
	            UPDATE [{0}] SET file_stream = @file_stream WHERE stream_id = @stream_id;
                SELECT u.stream_id, u.path_locator.ToString() as [path] FROM [{0}] as u WHERE u.stream_id = @stream_id;
            END
            ", TableName));
        }

        public void Update_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP PROCEDURE [{0}_Update]", TableName));
        }

        public void Delete_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
            CREATE PROCEDURE [{0}_Delete] (
	             @stream_id uniqueidentifier
            ) AS
            BEGIN
	            DELETE FROM [{0}] WHERE stream_id = @stream_id
            END
            ", TableName));
        }

        public void Delete_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP PROCEDURE [{0}_Delete]", TableName));
        }
    }
}
