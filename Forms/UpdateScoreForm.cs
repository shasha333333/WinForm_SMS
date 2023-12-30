using Org.BouncyCastle.Utilities;
using StudentManageSystem.Helpers;
using StudentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace StudentManageSystem.Forms
{
    public partial class UpdateScoreForm : Form { 
    
        private List<String> courses;
        private Dictionary<String, TextBox> textBoxHashMap;//管理文本域的集合
        private Dictionary<String, String> scores;	//学生所有成绩
        private string studentID;
        public UpdateScoreForm()
        {
            this.studentID = CurStudentCommonData.curStudent.getStudent_ID();
            int vgap = 0;	//垂直间距
            scores = SqlHelper.getStudentScore(studentID);//根据学号获得该学生的所有科目成绩
            courses = scores.Keys.ToList();
            if (scores.Count() <= 0)
            {
                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.Text = "该学生还没有成绩！";
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
                    field.Text = scores[courses[i]];//给文本域添加成绩
                    field.SetBounds(426, 48 + vgap, 150, 40);
                    textBoxHashMap.Add(courses[i], field);
                    this.Controls.Add(label);
                    this.Controls.Add(field);

                    vgap += 60;
                }
                InitializeComponent();
            }
        }

        private void UpdateScoreFormcs_Load(object sender, EventArgs e)
        {
            
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
                bool b = SqlHelper.updateStudentScore(studentID, courses[j], score);
                if (!b)
                {
                    break;
                }
            }
            if (j < courses.Count())
            {
                MessageBox.Show("修改失败！");
            }
            else
            {
                MessageBox.Show("修改成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < courses.Count(); i++)
            {
                textBoxHashMap[courses[i]].Text = scores[courses[i]];
            }
        }
    }
}
