using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace Pcb.Database.Migrations
{
    public partial class AddDbUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                var sql = GetSqlToCreateUsers();
                migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

        private string GetSqlToCreateUsers()
        {
            StringBuilder sqlstring = new StringBuilder();
            sqlstring.Append("if (database_principal_id('exec_readonly_role') is null)");
            sqlstring.Append(" begin");
            sqlstring.Append("	create role exec_readonly_role;");
            sqlstring.Append(" end");

            sqlstring.Append(" if (database_principal_id('api_admin_role') is null)");
            sqlstring.Append(" begin");
            sqlstring.Append("	create role api_admin_role;");
            sqlstring.Append(" exec sys.sp_addrolemember 'db_datareader', 'api_admin_role';");
            sqlstring.Append(" exec sys.sp_addrolemember 'db_owner', 'api_admin_role';");
            sqlstring.Append(" end");

            sqlstring.Append(" if (database_principal_id('api_query_role') is null)");
            sqlstring.Append(" begin");
            sqlstring.Append("	create role api_query_role;");
            sqlstring.Append(" exec sys.sp_addrolemember 'db_datareader', 'api_query_role';");
            sqlstring.Append(" exec sys.sp_addrolemember 'exec_readonly_role', 'api_query_role';");
            sqlstring.Append(" end");

            sqlstring.Append(" if (database_principal_id('api_command_role') is null)");
            sqlstring.Append(" begin");
            sqlstring.Append("	create role api_command_role;");
            sqlstring.Append(" exec sys.sp_addrolemember 'db_datawriter', 'api_command_role';");
            sqlstring.Append(" exec sys.sp_addrolemember 'db_datareader', 'api_command_role';");
            sqlstring.Append(" grant execute to api_command_role;");
            sqlstring.Append(" end");

            sqlstring.Append(" if not exists(select loginname");
            sqlstring.Append(" from master.dbo.syslogins");
            sqlstring.Append(" where name = 'pcbappadmin')");
            sqlstring.Append("	create login pcbappadmin with password = '!9UxiF0kV0H1D8ZJ0b7E9p%^j!';");
            sqlstring.Append(" if (database_principal_id('pcbadmin_user') is null)");
            sqlstring.Append("	create user pcbadmin_user for login pcbappadmin;");
            sqlstring.Append(" if is_rolemember('api_admin_role', 'pcbadmin_user') = 0");
            sqlstring.Append("	exec sys.sp_addrolemember 'api_admin_role', 'pcbadmin_user';");

            sqlstring.Append(" if not exists(select loginname");
            sqlstring.Append(" from master.dbo.syslogins");
            sqlstring.Append(" where name = 'pcbappquery')");
            sqlstring.Append("	create login pcbappquery with password = '!5pgPPhejFrvyoZ&f&DI*cMRd!';");
            sqlstring.Append(" if (database_principal_id('pcbquery_user') is null)");
            sqlstring.Append("	create user pcbquery_user for login pcbappquery;");
            sqlstring.Append(" if is_rolemember('api_query_role', 'pcbquery_user') = 0");
            sqlstring.Append("	exec sys.sp_addrolemember 'api_query_role', 'pcbquery_user';");

            sqlstring.Append(" if not exists(select loginname");
            sqlstring.Append(" from master.dbo.syslogins");
            sqlstring.Append(" where name = 'pcbappcommand')");
            sqlstring.Append("	create login pcbappcommand with password = '!*Z8QQPk&BNPJxqPDqmbtjaH&!';");
            sqlstring.Append(" if (database_principal_id('pcbcommand_user') is null)");
            sqlstring.Append("	create user pcbcommand_user for login pcbappcommand;");
            sqlstring.Append(" if is_rolemember('api_command_role', 'pcbcommand_user') = 0");
            sqlstring.Append("	exec sys.sp_addrolemember 'api_command_role', 'pcbcommand_user';");


            return sqlstring.ToString();
        }
    }
}
