using StudentManageSystem.Entity;
using StudentManageSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageSystem.Utils
{
    internal class Tools
    {
        public static void setCurStudentInfo(string studentID)
        {
            var stuInfo = SqlHelper.searchStudent(studentID);
            CurStudentCommonData.curStudent.setStudent_ID(stuInfo.Rows[0][0].ToString());
            CurStudentCommonData.curStudent.setStudent_Name(stuInfo.Rows[0][1].ToString());
            CurStudentCommonData.curStudent.setSex(stuInfo.Rows[0][2].ToString());
            CurStudentCommonData.curStudent.setGrade(stuInfo.Rows[0][3].ToString());
            CurStudentCommonData.curStudent.setClasse(stuInfo.Rows[0][4].ToString());
            CurStudentCommonData.curStudent.setMajor_ID(stuInfo.Rows[0][5].ToString());
            CurStudentCommonData.curStudent.setMajor_Name(stuInfo.Rows[0][6].ToString());
            CurStudentCommonData.curStudent.setDepartment_ID(stuInfo.Rows[0][7].ToString());
            CurStudentCommonData.curStudent.setDepartment_Name(stuInfo.Rows[0][8].ToString());
            CurStudentCommonData.curStudent.setEvaluations(SqlHelper.getEvluations(CurStudentCommonData.curStudent.getStudent_ID()));
        }

        public static void showCurStudentInfo()
        {
            MessageBox.Show("StuID:" + CurStudentCommonData.curStudent.getStudent_ID() + "\n"
               + "Student_Name:" + CurStudentCommonData.curStudent.getStudent_Name() + "\n"
               + "sex:" + CurStudentCommonData.curStudent.getSex() + "\n"
               + "Grade:" + CurStudentCommonData.curStudent.getGrade() + "\n"
               + "classe:" + CurStudentCommonData.curStudent.getClasse() + "\n"
               + "Major_ID:" + CurStudentCommonData.curStudent.getMajor_ID() + "\n"
               + "Major_Name:" + CurStudentCommonData.curStudent.getMajor_Name() + "\n"
               + "departID:" + CurStudentCommonData.curStudent.getDepartment_ID() + "\n"
               + "departName:" + CurStudentCommonData.curStudent.getDepartment_Name() + "\n"
               );
        }

        public static void setCurTeacherInfo(string teacherID)
        {
            var teacherInfo = SqlHelper.searchTeacher(teacherID);
            CurTeacherCommonData.curTeacher.setTeacher_ID(teacherInfo.Rows[0][0].ToString());
            CurTeacherCommonData.curTeacher.setTeacher_Name(teacherInfo.Rows[0][1].ToString());
         
        }

        public static void showCurTeacherInfo()
        {
            MessageBox.Show("Teacher_ID:" + CurTeacherCommonData.curTeacher.getTeacher_ID() + "\n"
               + "Teacher_Name:" + CurTeacherCommonData.curTeacher.getTeacher_Name() + "\n"
               );
        }

        //获取年级
        public static List<String> CreateGrade()
        {
            List<String> List = new List<String>();
 
            int currentYear = DateTime.Now.Year;
            
            for (int i = 0; i < 4; i++)
            {
                List.Add((currentYear--).ToString());
            }
            return List;

        }


        //生成学生学号的方法(学号：department+major+grade+classe+num)
        public static String CreateID(String grade, String classe, String major, String department, String num)
        {
            String id = department + grade.Substring(2) + major + classe + num;
            return id;
        }
    }
}
