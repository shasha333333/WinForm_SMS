using Org.BouncyCastle.Asn1.Tsp;
using StudentManageSystem.Entity;
using StudentManageSystem.Helpers;
using StudentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageSystem.Forms
{
    public partial class EvaluateStudentForm : Form
    {
        string studentId = null;
        string teacherId = null;
        string evaluation = null;

        public EvaluateStudentForm()
        {
            InitializeComponent();
        }

        private void EvaluateStudentForm_Load(object sender, EventArgs e)
        {
            label_studentName.Text = CurStudentCommonData.curStudent.getStudent_Name();
            //richTextBox_evaluation.Text = stuInfo.Rows[0][0].ToString();
            studentId = CurStudentCommonData.curStudent.getStudent_ID();
            teacherId = CurTeacherCommonData.curTeacher.getTeacher_ID();
            if(CurStudentCommonData.curStudent.getEvaluations().ContainsKey(teacherId))
            evaluation = CurStudentCommonData.curStudent.getEvaluations()[teacherId];
            MessageBox.Show("当前评价内容:"+"\n"+evaluation);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox_evaluation_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_studentName_SizeChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentId = CurStudentCommonData.curStudent.getStudent_ID();
            teacherId = CurTeacherCommonData.curTeacher.getTeacher_ID();
            evaluation = richTextBox_evaluation.Text;
            MessageBox.Show("评价内容更新为:" + "\n" + evaluation);
            if (CurStudentCommonData.curStudent.getEvaluations().ContainsKey(teacherId) 
                ? SqlHelper.updateStudentEvaluation(studentId, teacherId, evaluation)
                :SqlHelper.insertStudentEvaluation(studentId, teacherId, evaluation))
            {
                MessageBox.Show("评价成功！");
                return;
            }
            else
            {
                MessageBox.Show("评价失败！");
                return;
            }
        }
    }
}
