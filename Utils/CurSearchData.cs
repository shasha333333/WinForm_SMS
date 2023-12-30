using StudentManageSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManageSystem.Utils
{
    internal class CurSearchData
    {
        public static Dictionary<String, String> departments;    //所有院系集合
        public static Dictionary<String, String> all_Major;  //所有专业集合
        public static List<string> majors;  //专业名称集合
        public static List<string> classes;  //班级集合
        public static List<string> courses;  //课程集合
        public static Student student = new Student();
        public static string department_ID = null;
        public static string major_ID = null;
        public static string grade = null;
        public static string department_Name = null;
        public static string major_Name = null;
        public static string sid = null;
        public static string name = null;
        public static string sex = null;
        public static string classe = null;
        public static string course = null;
    }
}
