using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManageSystem.Entity
{
    internal class Teacher
    {
         private String teacher_Name;    //姓名
        private String teacher_ID;    //工号
   

        public String getTeacher_Name()
        {
            return teacher_Name;
        }

        public void setTeacher_Name(String teacher_Name)
        {
            this.teacher_Name = teacher_Name;
        }

        public String getTeacher_ID()
        {
            return teacher_ID;
        }

        public void setTeacher_ID(String teacher_ID)
        {
            this.teacher_ID = teacher_ID;
        }

    }

}
