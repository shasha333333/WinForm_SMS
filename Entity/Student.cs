using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManageSystem.Entity
{
    internal class Student
    {
        private String student_Name;    //姓名
        private String student_ID;    //学号
        private String sex;    //性别
        private String classe;    //班级
        private String grade;    //年级
        private String Major_ID;    //学生所属专业编号
        private String Department_ID;    //学生所属院系编号
        private String Major_Name;    //学生所属专业名称
        private String Department_Name;//学生所属院系名称
        private Dictionary<string, string> scores;    //成绩
        private Dictionary<string, string> evaluations;    //评价 

        public Dictionary<string,string> getScores()
        {
            return scores;
        }

        public Dictionary<string, string> getEvaluations()
        {
            return evaluations;
        }

        public void setScores(Dictionary<string, string> scores)
        {
            this.scores = scores;
        }

        public void setEvaluations(Dictionary<string, string> evaluations)
        {
            this.evaluations = evaluations;
        }

        public String getMajor_Name()
        {
            return Major_Name;
        }

        public void setMajor_Name(String major_Name)
        {
            Major_Name = major_Name;
        }

        public String getDepartment_Name()
        {
            return Department_Name;
        }

        public void setDepartment_Name(String department_Name)
        {
            Department_Name = department_Name;
        }

        public String getStudent_Name()
        {
            return student_Name;
        }

        public void setStudent_Name(String student_Name)
        {
            this.student_Name = student_Name;
        }

        public String getStudent_ID()
        {
            return student_ID;
        }

        public void setStudent_ID(String student_ID)
        {
            this.student_ID = student_ID;
        }

        public String getSex()
        {
            return sex;
        }

        public void setSex(String sex)
        {
            this.sex = sex;
        }

        public String getClasse()
        {
            return classe;
        }

        public void setClasse(String classe)
        {
            this.classe = classe;
        }

        public String getGrade()
        {
            return grade;
        }

        public void setGrade(String grade)
        {
            this.grade = grade;
        }

        public String getMajor_ID()
        {
            return Major_ID;
        }

        public void setMajor_ID(String major_ID)
        {
            Major_ID = major_ID;
        }

        public String getDepartment_ID()
        {
            return Department_ID;
        }

        public void setDepartment_ID(String department_ID)
        {
            Department_ID = department_ID;
        }

    }
}
