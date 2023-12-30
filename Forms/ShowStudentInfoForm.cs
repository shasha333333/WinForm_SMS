using StudentManageSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageSystem.Forms
{
    public partial class ShowStudentInfoForm : Form
    {
        string studentId = null;
        public ShowStudentInfoForm(string student_ID)
        {
            InitializeComponent();
            studentId = student_ID;
        }

       
        private void ShowStudentInfoForm_Load(object sender, EventArgs e)
        {
            var stuInfo = SqlHelper.searchStudent(studentId);
            label_id_content.Text = stuInfo.Rows[0][0].ToString();
            label_name_content.Text = stuInfo.Rows[0][1].ToString();
            label_sex_content.Text = stuInfo.Rows[0][2].ToString();
            label_grade_content.Text = stuInfo.Rows[0][3].ToString();
            label_classe_content.Text = stuInfo.Rows[0][4].ToString();
            label_major_content.Text = stuInfo.Rows[0][6].ToString();
            label_department_content.Text = stuInfo.Rows[0][8].ToString();
        }
    }
}
