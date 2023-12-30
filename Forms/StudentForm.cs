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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageSystem.Forms
{
    public partial class StudentForm : Form
    {
        private DataTable datasource = null;
        public StudentForm()
        {
            //Tools.setCurStudentInfo("222100215");
            InitializeComponent();
        }
        public void refreshDatagridView1()
        {
            string sql = string.Format("SELECT "
                            + " Student_ID, Student_Name, Course_Name, Score,"
                            + " RANK() OVER (PARTITION BY Student_ID ORDER BY Score DESC) "
                        + "FROM  "
                            + " score"
                            + " WHERE Student_ID = '{0}'", CurStudentCommonData.curStudent.getStudent_ID());
            datasource = SqlHelper.Query(sql);
            dataGridView1.DataSource = datasource;
            dataGridView1.RowHeadersWidth = 20;
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "课程";
            dataGridView1.Columns[3].HeaderText = "得分";
            dataGridView1.Columns[4].HeaderText = "排名";
        }

/*
        public void refreshDatagridView2()
        {
            string sql = string.Format("SELECT "
                           + " Evaluations, Teacher_Name"
                        + " FROM  "
                            + " evaluation"
                            + " JOIN teacher ON evaluation.Teacher_Id = teacher.Teacher_Id"
                            + " WHERE evaluation.Student_Id = '{0}'", CurStudentCommonData.curStudent.getStudent_ID());
            datasource = SqlHelper.Query(sql);
    
          
            dataGridView2.DataSource = datasource;
            dataGridView2.RowHeadersWidth = 20;
          
            dataGridView2.Columns[0].HeaderText = "评价";
            dataGridView2.Columns[1].HeaderText = "老师";
        
        }*/


        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            refreshDatagridView1();
            //refreshDatagridView2();
            Tools.showCurStudentInfo();

                
            foreach (KeyValuePair<string,string> item in CurStudentCommonData.curStudent.getEvaluations())
            {
                //MessageBox.Show($"{item}, {item}");
                comboBox_evaluation_teacher.Items.Add(item.Key);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_evalution_teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_evaluation_teacher.SelectedIndex >= 0)
            {
                richTextBox1.Text = CurStudentCommonData.curStudent.getEvaluations()[comboBox_evaluation_teacher.SelectedItem.ToString()];
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
