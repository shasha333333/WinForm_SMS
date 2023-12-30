using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Collections;
using StudentManageSystem.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace StudentManageSystem.Helpers
{
    internal class SqlHelper
    {
   
        public static string server = "127.0.0.1";
        public static string database = "studentsystem1";
        public static string uid = "root";
        public static string pwd = "admin";
        public static string conStr = String.Format("server={0};database={1};uid={2};pwd={3};charset=utf8", server, database, uid, pwd);


        /// <summary>
        /// 测试连接
        /// </summary>

        public static void Test()
        {
            using (MySqlConnection connect = new MySqlConnection(conStr))
            {
                string sql = "select * from student;";
                MySqlCommand cmd = new MySqlCommand(sql, connect);
                connect.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Console.WriteLine(dr[0].ToString() + " "
                                    + dr[1].ToString() + " "
                                    + dr[2].ToString());
                }
            }
            Console.WriteLine("111");

        }


        /// <summary>
        /// 查询函数,传入sql语句,返回存储着结果的DataTable
        /// </summary>
        /// <exception cref="Exception">查询出错就会抛出该异常</exception>
        public static DataTable Query(string sql)
        {
            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 增删改函数,传入sql语句,返回变更的数据库条数
        /// </summary>
        /// <exception cref="Exception">更改出错就会抛出该异常</exception>
        public static bool Update(string sql)
        {
            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        int result = cmd.ExecuteNonQuery();
                        return result>0;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static Dictionary<String, String> getEvluations(String studentID, String teacherID)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            string sql = String.Format("select Evaluations,Teacher_Id from evaluation where Student_Id='{0}'AND Teacher_Id='{1}'", studentID,teacherID);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            map.Add(reader[1].ToString(), reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return map;
        }

        public static Dictionary<String, String> getEvluations(String studentID)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            string sql = String.Format("select Evaluations,Teacher_Id from evaluation where Student_Id='{0}'", studentID);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            map.Add(reader[1].ToString(), reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return map;
        }

        public static Dictionary<String, String> getAllDepartment()
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
           
            string sql = "select * from department order by Department_ID";
            
            using(var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                { 
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            map.Add(reader[1].ToString(), reader[0].ToString());
                        }
                    }catch (Exception ex) 
                    {
                        throw ex;
                    }
                }
               
            }
           
            return map;
        }

        public static Dictionary<String, String> getAllMajor()
        {
            Dictionary<String, String> map = new Dictionary<String, String>();

            string sql = "select * from major order by Major_ID";

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            map.Add(reader[1].ToString(), reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return map;
        }

        public static Dictionary<String, String> getStudentScore(String student_Id)
        {        
            Dictionary<String, String> map = new Dictionary<String, String>();

            string sql = String.Format("select Course_Name, Score from score where Student_Id ='{0}' order by Student_Id asc", student_Id);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            map.Add(reader[0].ToString(), reader[1].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return map;

        }

        public static List<String> getCourse(String major_Id, String grade)
        {      
            List<String> list = new List<String>();

            string sql = String.Format(" select Course_Name from course where Major_ID ='{0}' and Grade ='{1}'", major_Id, grade);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return list;
        }

        public static List<String> getDepartment(String studentID)
        {
            List<String> list = new List<String>();
            
            string sql = String.Format("select Department_ID from student where Student_Id='{0}'", studentID);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader[1].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return list;
        }

        public static List<String> getMajor(String department_ID)
        {
            List<String> list = new List<String>();      

            string sql = String.Format("select * from major where Department_ID='{0}' order by Major_ID", department_ID);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader[1].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return list;
        }

        public static List<String> getClasse(String grade, String major_ID)
        {
            List<String> list = new List<String>();

            string sql = String.Format("select Classe from classe where Grade='{0}' and Major_ID='{1}'", grade, major_ID);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return list;
        }

        public static DataTable searchStudent(String studentID)
        {
            string sql = String.Format("select * from student where Student_Id='{0}'", studentID);
            return Query(sql);
        }

        public static DataTable searchTeacher(String teacherID)
        {
            string sql = String.Format("select * from teacher where Teacher_Id='{0}'", teacherID);
            return Query(sql);
        }


        public static bool addStudent(Student student)
        {
            string sql = String.Format("insert into student values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                 student.getStudent_ID(),student.getStudent_Name(), student.getSex(),
                 student.getGrade(),student.getClasse(),student.getMajor_ID(), 
                 student.getMajor_Name(), student.getDepartment_ID(), student.getDepartment_Name());

            //MessageBox.Show(sql);
            return Update(sql);
        }

        public static bool deleteStudent(String studentID)
        {  
            string sql = String.Format("delete from student where Student_Id='{0}'",studentID);
            return Update(sql);
        }

        public static bool insertStudentEvaluation(String studentID,String teacherID,String evaluation)
        {
            string sql = String.Format("insert into evaluation values('{0}','{1}','{2}')", studentID,teacherID,evaluation);
            return Update(sql);
        }

        public static bool updateStudentEvaluation(String studentID, String teacherID, String evaluation)
        {
            string sql = String.Format("UPDATE evaluation SET Evaluations='{0}' WHERE Student_Id='{1}' AND Teacher_Id='{2}'", evaluation, studentID, teacherID);
            return Update(sql);
        }

        public static bool updateStudentScore(String studentID, String course_Name, String score)
        {
            string sql = String.Format("update score set Score = '{0}' where Course_Name ='{1}' and Student_Id ='{2}' ", score, course_Name, studentID );
            return Update(sql);
        }

        public static bool addStudentScore(String studentID, String studentName, String course, String score)
        {
            string sql = String.Format("insert into score values('{0}','{1}','{2}','{3}')", studentID, studentName, course, score);
            //MessageBox.Show(sql);
            return Update(sql);
        }

        public static string getCourseAvg(String course, String major, String classe, String grade)
        {
            string sql = String.Format("select  AVG(Score) from score  where Course_Name='{0}' and  Student_Id in (select Student_Id from student where Grade='{1}'and Classe='{2}' and Major_Name='{3}')", course, grade,classe, major);
            return getAnalyzResult(sql);
        }

        public static string getCourseHighestScore(String course, String major, String classe, String grade)
        {
            string sql = String.Format("select MAX(Score) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' ", grade, classe, major, course);
            return getAnalyzResult(sql);
        }

        public static string getCourseLowestScore(String course, String major, String classe, String grade)
        {
            string sql = String.Format("select MIN(Score) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' ", grade, classe, major, course);
            return getAnalyzResult(sql);
        }

        //根据学生专业，年级，班级，科目，考试成绩类型(优，良，中，及格，不及格)返回该类型的学生人数
        public static String getCount_ScoreType(String grade, String classe, String major, String type, String course_Name)
        {
            String count = null;
            String sql = null;
            if (type.Equals("优"))
            {
                sql = String.Format("select  Count(*) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' and Score>=90 and Score<=100"
                    ,grade,classe,major,course_Name);
            }
            else if (type.Equals("良"))
            {
                sql = String.Format("select  Count(*) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' and Score>=80 and Score<90"
                    , grade, classe, major, course_Name);
            }
            else if (type.Equals("中"))
            {
                sql = String.Format("select  Count(*) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' and Score>=70 and Score<80"
                    , grade, classe, major, course_Name);
            }
            else if (type.Equals("及格"))
            {
                sql = String.Format("select  Count(*) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' and Score>=60 and Score<70"
                    , grade, classe, major, course_Name);
            }
            else if (type.Equals("不及格"))
            {
                sql = String.Format("select  Count(*) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') and Course_Name='{3}' and Score>=0 and Score<60"
                    , grade, classe, major, course_Name);
            }
            count = getAnalyzResult(sql) ;

            return count + "人";
        }

        public static String getHaveScoreCount(String major, String classe, String grade)
        {
            String sql = String.Format("select Count(*) from score where Student_Id in(select Student_Id from student where Grade='{0}' and Classe='{1}' and Major_Name='{2}') GROUP BY  Course_Name", grade, classe, major);
            return getAnalyzResult(sql);
        }

        public static String getClasse_SumScore(String classe, String grade, String major)
        {
            String sql = String.Format("select SUM(Score) from score where Student_Id in(Select Student_Id from student where Classe='{0}' and Grade='{1}' and Major_Name='{2}')",classe,grade,major);
            return getAnalyzResult(sql);
        }

        public static String getClasseAvg(String major, String classe, String grade)
        {
            string count = getHaveScoreCount(major, classe, grade);
            string sum = getClasse_SumScore (classe, grade, major);
            if (sum != null && count != null)
            {
                return (double.Parse(sum)/double.Parse(count)).ToString();
            }
            return " ";
        }

        private static string getAnalyzResult(string sql)
        {
            string result = null;
            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                           result = reader[0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return result;
        }

        //根据学生(年级和编号)返回对应的班级
        public static List<String> getAllClasse(String grade, String major_ID)
        {
            List<String> list = new List<String>();

            string sql = String.Format("select Classe from classe where Grade='{0}' and Major_ID='{1}'", grade, major_ID);

            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return list;
        }
    }
}
