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
    public partial class AddScoreForm : Form
    {
        private List<String> courses;
        private Dictionary<String, TextBox> textBoxHashMap;//管理文本域的集合
        private Dictionary<String, String> scores;  //学生所有成绩
        private string studentID;
        private string studentName;
        //private Student student;
        public AddScoreForm()
        {
            int vgap = 0;   //垂直间距

            studentID = CurStudentCommonData.curStudent.getStudent_ID();
            studentName = CurStudentCommonData.curStudent.getStudent_Name();
            courses = SqlHelper.getCourse(CurStudentCommonData.curStudent.getMajor_ID(), CurStudentCommonData.curStudent.getGrade());
            scores = SqlHelper.getStudentScore(studentID);//根据学号获得该学生的所有科目成绩

            if (scores.Count() > 0)
            {
                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.Text = "该学生已经有成绩了！";
                this.Controls.Add(label);
            }
            else
            {
                textBoxHashMap = new Dictionary<string, TextBox>();
                for (int i = 0; i < courses.Count(); i++)
                {
                    Label label = new Label();
                    label.Text = courses[i].ToString() + ":";
                    label.SetBounds(126, 48 + vgap, 240, 40);
                    TextBox field = new TextBox();
                    field.SetBounds(426, 48 + vgap, 150, 40);
                    textBoxHashMap.Add(courses[i], field);
                    this.Controls.Add(label);
                    this.Controls.Add(field);

                    vgap += 60;
                }
                InitializeComponent();

            }
        }

        private void AddScoreForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < courses.Count(); i++)
            {
                textBoxHashMap[courses[i]].Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < courses.Count(); i++)
            {
                //Console.WriteLine(courses[i]);
                TextBox field = textBoxHashMap[courses[i]];

                String score = field.Text;
                if (score.Equals(""))
                {
                    MessageBox.Show("成绩不能为空！");
                    return;
                }
                if (double.Parse(score) < 0 || double.Parse(score) > 100)
                {
                    MessageBox.Show("请输入0~100之间的成绩");
                    return;
                }
            }
            int j;
            for (j = 0; j < courses.Count(); j++)
            {
                TextBox field = textBoxHashMap[courses[j]];
                String score = field.Text.Trim();
                //MessageBox.Show(courses[j]);
                //MessageBox.Show(score);
                bool b = SqlHelper.addStudentScore(studentID, studentName, courses[j], score);
                if (!b)
                {
                    break;
                }
            }
            if (j < courses.Count())
            {
                MessageBox.Show("添加失败！");
            }
            else
            {
                MessageBox.Show("添加成功！");
                
            }
        }
    }
}
