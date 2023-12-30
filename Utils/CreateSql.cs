using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManageSystem.Utils
{
    internal class CreateSql
    {
        //根据查询内容、选项从学生表里返回特定的sql语句
        public static String getStudent_Sql(String str, String option)
        {
            String sql = null;
            if ("全部".Equals(option))
            {
                sql = "select * from student";
            }
            else if ("学号".Equals(option))
            {
                sql = "select * from student where Student_Id like '%" + str + "%'";
            }
            else if ("姓名".Equals(option))
            {
                sql = "select * from student where Student_Name like '%" + str + "%'";
            }
            else if ("性别".Equals(option))
            {
                sql = "select * from student where Student_Sex like '%" + str + "%'";
            }
            else if ("年级".Equals(option))
            {
                sql = "select * from student where Grade like '%" + str + "%'";
            }
            else if ("班级".Equals(option))
            {
                sql = "select * from student where Classe like '%" + str + "%'";
            }
            else if ("专业".Equals(option))
            {
                sql = "select * from student where Major_Name  like '%" + str + "%'";
            }
            else if ("院系".Equals(option))
            {
                sql = "select * from student where Department_Name like '%" + str + "%'";
            }

            else if ("课程".Equals(option))
            {
                sql = "SELECT * " +
                        "FROM Course " +
                        "JOIN Student ON Course.Grade = Student.Grade AND Course.Major_ID = Student.Major_ID " +
                        "WHERE Course_Name LIKE '%" + str + "%'";
            }


            return sql;
        }

        //多条件查询的sql语句创建
        public static String getConditions_Sql(String id, String name, String sex, String grade, String department, String major, String classe)
        {
            StringBuilder sql = new StringBuilder("select * from student where 1=1");
            if (!id.Equals(""))
            {
                sql.Append(" and Student_Id like '%" + id + "%'  ");
            }
            if (!name.Equals(""))
            {
                sql.Append(" and Student_Name like '%" + name + "%'  ");
            }
            if (!sex.Equals(""))
            {
                sql.Append(" and Student_Sex like '%" + sex + "%'  ");
            }
            if (!grade.Equals(""))
            {
                sql.Append(" and Grade like '%" + grade + "%'  ");
            }
            if (!department.Equals(""))
            {
                sql.Append(" and Department_Name like '%" + department + "%'  ");
            }
            if (!major.Equals(""))
            {
                sql.Append(" and Major_Name like '%" + major + "%'  ");
            }
            if (!classe.Equals(""))
            {
                sql.Append(" and Classe like '%" + classe + "%'  ");
            }

            return sql.ToString();
        }

        //根据查询内容、选项从学生表里返回特定的sql语句
        public static String getStudent_Sql(String grade, String major, String str, String option)
        {
            String sql = null;
            if ("全部".Equals(option))
            {
                sql = "select * from student where Grade='" + grade + "' and Major_Name='" + major + "'";
            }
            else if ("学号".Equals(option))
            {
                sql = "select * from student where Student_Id like '%" + str + "%' and Grade='" + grade + "' and Major_Name='" + major + "'";
            }
            else if ("姓名".Equals(option))
            {
                sql = "select * from student where Student_Name like '%" + str + "%' and Grade='" + grade + "' and Major_Name='" + major + "'";
            }
            else if ("性别".Equals(option))
            {
                sql = "select * from student where Student_Sex like '%" + str + "%' and Grade='" + grade + "' and Major_Name='" + major + "'";
            }
            else if ("年级".Equals(option))
            {
                sql = "select * from student where Grade like '%" + str + "%' and Grade='" + grade + "' and Major_Name='" + major + "'";
            }
            else if ("班级".Equals(option))
            {
                sql = "select * from student where Classe like '%" + str + "%' and Grade='" + grade + "' and Major_Name='" + major + "'";
            }
            return sql;
        }
    }
}
