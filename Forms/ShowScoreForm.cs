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
    public partial class ShowScoreForm : Form
    {
        private List<String> courses;

   
        //private Dictionary<String, JTextField> jtextFieldHashMap;//管理文本域的集合
        private Dictionary<String, String> scores;	//学生所有成绩
        private string studentID;
        public ShowScoreForm(string studentID)
        {
            this.studentID = studentID;
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
                for (int i = 0; i < courses.Count(); i++)
                {
                    Label label = new Label();
                    label.Text = courses[i].ToString() + ":";
                    label.SetBounds(326, 48 + vgap, 240, 40);
                    TextBox field = new TextBox();
                    field.Text = scores[courses[i]];//给文本域添加成绩
                    field.SetBounds(626, 48 + vgap, 150, 40);
                    this.Controls.Add(label);
                    this.Controls.Add(field);

                    vgap += 60;
                }
                InitializeComponent();
            }
        }

        private void ShowScoreForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
