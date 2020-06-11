using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrainDTrainorV2.Core.BaseMigrations
{
    public abstract class InitDb : DbMigrationBase
    {
        public abstract string RootPath { get; }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CreateDbDir_Up(migrationBuilder);
            FilestreamFilegroup_Up(migrationBuilder);
            FileStreamProperties_Up(migrationBuilder);
            GetNewID_Up(migrationBuilder);
            GetNewPathLocator_Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FilestreamFilegroup_Down(migrationBuilder);
            GetNewID_Down(migrationBuilder);
            GetNewPathLocator_Down(migrationBuilder);           
        }

        private void CreateDbDir_Up(MigrationBuilder migrationBuilder)
        {
            var dirName = string.Format(@"{0}\{1}", RootPath, DbName);
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);
        }

        public void FilestreamFilegroup_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"ALTER DATABASE {0} ADD FILEGROUP {0}Group CONTAINS FILESTREAM", DbName), true);
            migrationBuilder.Sql(string.Format(@"ALTER DATABASE {0}
                ADD FILE (
	                NAME = '{0}Filestream',
	                FILENAME = '{1}\{0}\Filestream'
                ) TO FILEGROUP {0}Group
                ", DbName, RootPath), true);
        }

        public void FilestreamFilegroup_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"ALTER DATABASE {0} REMOVE FILE {0}Filestream", DbName), true);
            migrationBuilder.Sql(string.Format(@"ALTER DATABASE {0} REMOVE FILEGROUP {0}Group", DbName), true);
        }

        private void FileStreamProperties_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"ALTER DATABASE {0} SET READ_COMMITTED_SNAPSHOT OFF", DbName), true);
            migrationBuilder.Sql(string.Format(@"ALTER DATABASE {0} SET FILESTREAM ( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = '{0}' )", DbName), true);
        }

        private void GetNewID_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.GetNewID AS SELECT newid() AS new_id");
        }

        private void GetNewID_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW dbo.GetNewID");
        }

        private void GetNewPathLocator_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION dbo.GetNewPathLocator (@parent hierarchyid = null) RETURNS varchar(max) AS
            BEGIN       
                DECLARE @result varchar(max), @newid uniqueidentifier  -- declare new path locator, newid placeholder       
                SELECT @newid = new_id FROM dbo.getNewID; -- retrieve new GUID      
                SELECT @result = ISNULL(@parent.ToString(), '/') + -- append parent if present, otherwise assume root
                                 convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 1, 6))) + '.' +
                                 convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 7, 6))) + '.' +
                                 convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 13, 4))) + '/'     
                RETURN @result -- return new path locator     
            END
            ");
        }

        private void GetNewPathLocator_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.GetNewPathLocator");
        }
    }
}
