using Org.BouncyCastle.Pqc.Crypto.Lms;
using StudentManageSystem.Helpers;
using StudentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace StudentManageSystem.Forms
{
   
    public partial class TeacherForm : Form
    {
        private static List<String> query_Option;
        private DataTable datasource = null;

        public TeacherForm()
        {
            //Tools.setCurTeacherInfo("111333222");
            InitializeComponent();
        }

        public void refreshDatagridView3()
        {
            string sql = string.Format("SELECT "
                            + "Student_Name, Student_ID, Score, Course_Name,"
                            + "RANK() OVER (PARTITION BY Course_Name ORDER BY Score DESC) "
                        + "FROM  "
                            + " score"
                           + " WHERE Course_Name = '{0}'", CurSearchData.course);
            datasource = SqlHelper.Query(sql);
            dataGridView3.DataSource = datasource;
            dataGridView3.RowHeadersWidth = 20;
            dataGridView3.Columns[0].HeaderText = "姓名";
            dataGridView3.Columns[1].HeaderText = "学号";
            dataGridView3.Columns[2].HeaderText = "得分";
            dataGridView3.Columns[3].HeaderText = "课程";
            dataGridView3.Columns[4].HeaderText = "排名";
        }

        public void refreshDatagridView2()
        {
            string sql = CreateSql.getStudent_Sql(null, "全部");
            dataGridView2.DataSource = SqlHelper.Query(sql);
            dataGridView2.RowHeadersWidth = 20;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.Columns[0].HeaderText = "学号";
            dataGridView2.Columns[1].HeaderText = "姓名";
            dataGridView2.Columns[2].HeaderText = "性别";
            dataGridView2.Columns[3].HeaderText = "年级";
            dataGridView2.Columns[4].HeaderText = "班级";
            dataGridView2.Columns[6].HeaderText = "专业";
            dataGridView2.Columns[8].HeaderText = "院系";
        }

        public void refreshDatagridView1()
        {
            string sql = CreateSql.getStudent_Sql(null, "全部");
            datasource = SqlHelper.Query(sql);
            dataGridView1.DataSource = datasource;
            dataGridView1.RowHeadersWidth = 20;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "性别";
            dataGridView1.Columns[3].HeaderText = "年级";
            dataGridView1.Columns[4].HeaderText = "班级";
            dataGridView1.Columns[6].HeaderText = "专业";
            dataGridView1.Columns[8].HeaderText = "院系";
            //dataGridView1.Rows[dataGridView1.RowCount - 1].Visible = false;
        }

        private void 学生成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 学生成绩统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 获取选中行的数据  
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; // 获取选中第一行


                // 获取选中行中每个单元格的值  
                object[] rowData = new object[dataGridView1.Columns.Count];
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    rowData[i] = selectedRow.Cells[i].Value;
                }


                string studendID = rowData[0].ToString();
                MessageBox.Show(studendID);
                SqlHelper.deleteStudent(studendID);
            }
            else
            {
                // 处理没有选中行的情况，例如弹出消息提示用户需要选择一个行  
                MessageBox.Show("请选中一行学生信息");
            }

            //SqlHelper.deleteStudent(studendID);
            //dataGridView1.Refresh();
            refreshDatagridView1();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new AddStudentForm().ShowDialog();
            //MessageBox.Show(id);
            refreshDatagridView1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 获取选中行的数据  
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; // 获取选中第一行


                // 获取选中行中每个单元格的值  
                object[] rowData = new object[dataGridView1.Columns.Count];
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    rowData[i] = selectedRow.Cells[i].Value;
                }


                string studendID = rowData[0].ToString();
                //MessageBox.Show(studendID);

                Thread th;
                th = new Thread(delegate () { new ShowStudentInfoForm(studendID).ShowDialog(); });

                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                // 处理没有选中行的情况，例如弹出消息提示用户需要选择一个行  
                MessageBox.Show("请选中一行学生信息");
            }

            //SqlHelper.deleteStudent(studendID);
            //dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 获取选中行的数据  
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; // 获取选中第一行


                // 获取选中行中每个单元格的值  
                object[] rowData = new object[dataGridView1.Columns.Count];
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    rowData[i] = selectedRow.Cells[i].Value;
                }
                //更新当前学生信息
                Tools.setCurStudentInfo(rowData[0].ToString());
                //MessageBox.Show(studendID);

                new EvaluateStudentForm().ShowDialog();

            }
            else
            {
                // 处理没有选中行的情况，例如弹出消息提示用户需要选择一个行  
                MessageBox.Show("请选中一行学生信息");
            }

            //SqlHelper.deleteStudent(studendID);
            //dataGridView1.Refresh();
            refreshDatagridView1();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            query_Option = new List<String>
            {
                "全部",
                "学号",
                "姓名",
                "性别",
                "班级",
                "年级",
                "专业",
                "院系",
                "课程"
            };
            refreshDatagridView1();
            refreshDatagridView2();
            //comboBox_grade.Items.Add(Tools.CreateGrade());
            //comboBox_grade.Items.Add(query_Option);

            CurSearchData.departments = SqlHelper.getAllDepartment();
            CurSearchData.all_Major = SqlHelper.getAllMajor();

            foreach (KeyValuePair<string, string> item in CurSearchData.departments)
            {
                comboBox_department.Items.Add(item.Key);
                //MessageBox.Show("Key: " + item.Key + ", Value: " + item.Value);
            }
            foreach (string item in Tools.CreateGrade())
            {
                comboBox_grade.Items.Add(item);
            }

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
   

        private void button5_Click(object sender, EventArgs e)
        {
             if (dataGridView2.SelectedRows.Count > 0)
            {
                // 获取选中行的数据  
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // 获取选中第一行


                // 获取选中行中每个单元格的值  
                object[] rowData = new object[dataGridView2.Columns.Count];
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    rowData[i] = selectedRow.Cells[i].Value;
                }


                string studentID = rowData[0].ToString();
                //MessageBox.Show(studentID);


                //courses = SqlHelper.getCourse(SqlHelper.)
                Tools.setCurStudentInfo(studentID);
                //Tools.showCurStudentInfo();



                new AddScoreForm().ShowDialog();

           
            }
            else
            {
                // 处理没有选中行的情况，例如弹出消息提示用户需要选择一个行  
                MessageBox.Show("请选中一行学生信息");
            }

            //SqlHelper.deleteStudent(studendID);
            //dataGridView2.Refresh();
            refreshDatagridView2();
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // 获取选中行的数据  
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // 获取选中第一行


                // 获取选中行中每个单元格的值  
                object[] rowData = new object[dataGridView2.Columns.Count];
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    rowData[i] = selectedRow.Cells[i].Value;
                }


                CurStudentCommonData.curStudent.setStudent_ID( rowData[0].ToString());
                //MessageBox.Show(studendID);

                new UpdateScoreForm().ShowDialog(); 

                
            }
            else
            {
                // 处理没有选中行的情况，例如弹出消息提示用户需要选择一个行  
                MessageBox.Show("请选中一行学生信息");
            }

            //SqlHelper.deleteStudent(studendID);
            //dataGridView2.Refresh();
            refreshDatagridView2();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // 获取选中行的数据  
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // 获取选中第一行


                // 获取选中行中每个单元格的值  
                object[] rowData = new object[dataGridView2.Columns.Count];
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    rowData[i] = selectedRow.Cells[i].Value;
                }


                string studendID = rowData[0].ToString();
                //MessageBox.Show(studendID);

                Thread th;
                th = new Thread(delegate () { new ShowScoreForm(studendID).ShowDialog(); });

                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                // 处理没有选中行的情况，例如弹出消息提示用户需要选择一个行  
                MessageBox.Show("请选中一行学生信息");
            }

            //SqlHelper.deleteStudent(studendID);
            //refreshDatagridView2();
        }

        private void button13_Click(object sender, EventArgs e)
        {
                
            initializeGroupBox1();
        }

        private void initializeGroupBox1()
        {

            //数据校验部分
            if (CurSearchData.grade == null)
            {
                MessageBox.Show("年级不能为空！");
                return;
            }
            if (CurSearchData.departments == null)
            {   //先检查再用
                MessageBox.Show("院系不能为空！");
                return;
            }
            if (CurSearchData.majors == null)
            {   //先检查再用
                MessageBox.Show("专业不能为空！");
                return;
            }
            if (CurSearchData.major_ID == null)
            {
                MessageBox.Show("专业不能为空！");
                return;
            }
            if (CurSearchData.classe == null)
            {
                MessageBox.Show("班级不能为空！");
                return;
            }
            this.groupBox1.Controls.Clear();

            Label average_Scores = new System.Windows.Forms.Label();  //平均成绩标签
            TextBox average_ScoresText = new System.Windows.Forms.TextBox();  //平均成绩文本域
            Label total_Score = new System.Windows.Forms.Label(); //总成绩标签
            TextBox total_ScoreText = new System.Windows.Forms.TextBox(); //总成绩文本域
            Button scores_Ranking = new System.Windows.Forms.Button(); //成绩排名按钮

            CurSearchData.courses = SqlHelper.getCourse(CurSearchData.major_ID, CurSearchData.grade);//获得所有课程


            average_Scores.Text = ("班级平均成绩:");
            average_Scores.SetBounds(200, 15, 90, 20);//班级平均成绩文本域
            this.groupBox1.Controls.Add(average_Scores);

            //设置班级的平均成绩
            average_ScoresText.Text = SqlHelper.getClasseAvg( CurSearchData.major_Name, CurSearchData.classe, CurSearchData.grade);
            average_ScoresText.SetBounds(295, 15, 60, 20);
            this.groupBox1.Controls.Add(average_ScoresText);

            total_Score.Text = "班级总成绩:";
            total_Score.SetBounds(435, 15, 80, 20);
            this.groupBox1.Controls.Add(total_Score);

            //设置班级总成绩
            total_ScoreText.Text = SqlHelper.getClasse_SumScore(CurSearchData.classe, CurSearchData.grade, CurSearchData.major_Name);
            total_ScoreText.SetBounds(520, 15, 60, 20);
            this.groupBox1.Controls.Add(total_ScoreText);


            int vgap = 0;   //垂直间距
            for (int i = 0; i < CurSearchData.courses.Count(); i++)
            {
                Label label_course = new System.Windows.Forms.Label
                {
                    Text = (CurSearchData.courses[i] + ":")   //科目标签
                };
                label_course.SetBounds(26, 48 + vgap, 120, 20);
                this.groupBox1.Controls.Add(label_course);
                Label highestScore = new System.Windows.Forms.Label
                {
                    Text = ("最高成绩:")        //最高成绩标签
                };
                highestScore.SetBounds(156, 48 + vgap, 60, 20);
                this.groupBox1.Controls.Add(highestScore);

                TextBox highestScoreText = new TextBox();//最高成绩文本域
                highestScoreText.SetBounds(221, 48 + vgap, 30, 20);
                //设置最高成绩
                highestScoreText.Text = SqlHelper.getCourseHighestScore(CurSearchData.courses[i], CurSearchData.major_Name, CurSearchData.classe, CurSearchData.grade);
                this.groupBox1.Controls.Add(highestScoreText);

                Label lowest_Score = new System.Windows.Forms.Label
                {
                    Text = ("最低成绩:")  //最低成绩标签
                };
                lowest_Score.SetBounds(261, 48 + vgap, 60, 20);
                this.groupBox1.Controls.Add(lowest_Score);

                TextBox lowest_ScoreText = new TextBox();//最低成绩文本域
                lowest_ScoreText.SetBounds(326, 48 + vgap, 30, 20);
                //设置最低成绩
                lowest_ScoreText.Text = SqlHelper.getCourseLowestScore(CurSearchData.courses[i], CurSearchData.major_Name, CurSearchData.classe, CurSearchData.grade);
                this.groupBox1.Controls.Add(lowest_ScoreText);


                Label avg_Score = new System.Windows.Forms.Label
                {
                    Text = ("平均成绩:") //平均成绩标签
                };
                avg_Score.SetBounds(366, 48 + vgap, 60, 20);
                this.groupBox1.Controls.Add(avg_Score);

                TextBox avg_ScoreText = new TextBox();    //平均成绩文本域
                avg_ScoreText.SetBounds(431, 48 + vgap, 30, 20);
                //计算平均成绩
                String score = SqlHelper.getCourseAvg(CurSearchData.courses[i], CurSearchData.major_Name, CurSearchData.classe, CurSearchData.grade);
                if (score != null && !score.Equals(""))
                {
                    avg_ScoreText.Text = (score[0] + "" + score[1] + "" + score[2] + "" + score[3]);
                }
                this.groupBox1.Controls.Add(avg_ScoreText);


                Label j1 = new System.Windows.Forms.Label
                {
                    Text = ("优:")   //优人数标签
                };
                j1.SetBounds(476, 48 + vgap, 20, 20);
                this.groupBox1.Controls.Add(j1);

                TextBox t1 = new TextBox();//优文本域
                t1.SetBounds(498, 48 + vgap, 40, 20);
                //计算优秀人数
                t1.Text = SqlHelper.getCount_ScoreType(CurSearchData.grade, CurSearchData.classe, CurSearchData.major_Name, "优", CurSearchData.courses[i]);
                this.groupBox1.Controls.Add(t1);

                Label j2 = new System.Windows.Forms.Label
                {
                    Text = ("良:")   //良人数标签
                };
                j2.SetBounds(548, 48 + vgap, 20, 20);
                this.groupBox1.Controls.Add(j2);

                TextBox t2 = new TextBox();//良文本域
                t2.SetBounds(570, 48 + vgap, 40, 20);
                //计算良好人数
                t2.Text = SqlHelper.getCount_ScoreType(CurSearchData.grade, CurSearchData.classe, CurSearchData.major_Name, "良", CurSearchData.courses[i]);
                this.groupBox1.Controls.Add(t2);

                Label j3 = new System.Windows.Forms.Label
                {
                    Text = ("中:")  //中人数标签
                };
                j3.SetBounds(620, 48 + vgap, 20, 20);
                this.groupBox1.Controls.Add(j3);

                TextBox t3 = new TextBox();//中文本域
                //计算中人数
                t3.Text = SqlHelper.getCount_ScoreType(CurSearchData.grade, CurSearchData.classe, CurSearchData.major_Name, "中", CurSearchData.courses[i]);
                t3.SetBounds(642, 48 + vgap, 40, 20);
                this.groupBox1.Controls.Add(t3);


                Label j4 = new System.Windows.Forms.Label
                {
                    Text = ("及格:")  //及格人数标签
                };
                j4.SetBounds(692, 48 + vgap, 30, 20);
                this.groupBox1.Controls.Add(j4);

                TextBox t4 = new TextBox();//及格文本域
                //计算及格人数
                t4.Text = SqlHelper.getCount_ScoreType(CurSearchData.grade, CurSearchData.classe, CurSearchData.major_Name, "及格", CurSearchData.courses[i]);
                t4.SetBounds(724, 48 + vgap, 40, 20);
                this.groupBox1.Controls.Add(t4);


                Label j5 = new System.Windows.Forms.Label
                {
                    Text = ("不及格:") //不及格人数标签
                };
                j5.SetBounds(774, 48 + vgap, 50, 20);
                this.groupBox1.Controls.Add(j5);

                TextBox t5 = new TextBox();//不及格文本域
                t5.SetBounds(825, 48 + vgap, 40, 20);
                //计算不及格人数
                t5.Text = SqlHelper.getCount_ScoreType(CurSearchData.grade, CurSearchData.classe, CurSearchData.major_Name, "不及格", CurSearchData.courses[i]);
                this.groupBox1.Controls.Add(t5);

                vgap += 30;
            }
        }

        private void comboBox_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurSearchData.all_Major = SqlHelper.getAllMajor();
            comboBox_classe.Items.Clear();
            comboBox_course.Items.Clear();
            if (comboBox_grade.SelectedIndex >= 0)
            {
                CurSearchData.grade = comboBox_grade.SelectedItem.ToString();//获得年级
                if (comboBox_major.SelectedIndex >= 0)
                {
                    string option = comboBox_major.SelectedItem.ToString();
                    CurSearchData.major_ID = CurSearchData.all_Major[option];   //获得专业编号
                                                    //MessageBox.Show("major_ID: "+major_ID);
                                                    //MessageBox.Show("grade: "+grade);

                    if (CurSearchData.grade != null && CurSearchData.major_ID != null)
                    {
                        CurSearchData.courses = SqlHelper.getCourse(CurSearchData.major_ID, CurSearchData.grade);//获得所有课程
                        foreach (string item in CurSearchData.courses)
                        {
                            //MessageBox.Show($"{item}, {item}");
                            comboBox_course.Items.Add(item);
                        }
                        CurSearchData.classes = SqlHelper.getClasse(CurSearchData.grade, CurSearchData.major_ID);
                        foreach (string item in CurSearchData.classes)
                        {
                            //MessageBox.Show($"{item}, {item}");
                            comboBox_classe.Items.Add(item);
                        }
                    }
                }
            }
         
        }

        private void comboBox_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_course.Items.Clear();
            comboBox_major.Items.Clear();
            comboBox_classe.Items.Clear();
            if (comboBox_department.SelectedIndex >= 0)
            {
                string option = comboBox_department.SelectedItem.ToString();

                CurSearchData.department_ID = CurSearchData.departments[option];	//获得院系编号
                //MessageBox.Show(option);
                //MessageBox.Show("department_ID: " + department_ID);
                CurSearchData.majors = SqlHelper.getMajor(CurSearchData.department_ID);

                foreach (string item in CurSearchData.majors)
                {
                    comboBox_major.Items.Add(item);
                }
            }
        }

        private void comboBox_major_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_course.Items.Clear();
            comboBox_classe.Items.Clear();//移除"班级选项"的内容
            if (comboBox_major.SelectedItem != null)
            {   //防止空指针 
                if (!comboBox_major.SelectedItem.ToString().Equals(""))
                {
                    if (comboBox_major.SelectedItem.ToString().Equals("") || comboBox_grade.SelectedItem == null || comboBox_grade.SelectedItem.ToString().Equals(""))
                    {
                        MessageBox.Show("年级不能为空");
                        return;
                    }
                    String option = comboBox_major.SelectedItem.ToString();
                    CurSearchData.major_Name = option;
                    CurSearchData.major_ID = CurSearchData.all_Major[option];    //专业编号
                    CurSearchData.grade = comboBox_grade.SelectedItem.ToString();
                    if (CurSearchData.grade!=null&&CurSearchData.major_ID!=null)
                    {
                        CurSearchData.courses = SqlHelper.getCourse(CurSearchData.major_ID, CurSearchData.grade);//获得所有课程
                        foreach (string item in CurSearchData.courses)
                        {
                            //MessageBox.Show($"{item}, {item}");
                            comboBox_course.Items.Add(item);
                        }
                        CurSearchData.classes = SqlHelper.getAllClasse(CurSearchData.grade, CurSearchData.major_ID); //获得班级
                        foreach (string item in CurSearchData.classes)
                        {
                            comboBox_classe.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_classe.SelectedIndex >= 0)
            {
                CurSearchData.classe = comboBox_classe.SelectedItem.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //数据校验部分
            if (CurSearchData.grade == null)
            {
                MessageBox.Show("年级不能为空！");
                return;
            }
            if (CurSearchData.departments == null)
            {   //先检查再用
                MessageBox.Show("院系不能为空！");
                return;
            }
            if (CurSearchData.majors == null)
            {   //先检查再用
                MessageBox.Show("专业不能为空！");
                return;
            }
            if (CurSearchData.major_ID == null)
            {
                MessageBox.Show("专业不能为空！");
                return;
            }
            if (CurSearchData.classe == null)
            {
                MessageBox.Show("班级不能为空！");
                return;
            }
            if (CurSearchData.course == null)
            {
                MessageBox.Show("课程不能为空！");
                return;
            }
            refreshDatagridView3();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_course.SelectedIndex >= 0)
            {
                CurSearchData.course = comboBox_course.SelectedItem.ToString();
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_search_conditions_Click(object sender, EventArgs e)
        {
            String id = textBox_studentID.Text.Trim();
            String name = textBox_studentName.Text.Trim();
            String sex = textBox_sex.Text.Trim();
            String grade = textBox_grade.Text.Trim();
            String department = textBox_department.Text.Trim();
            String major = textBox_major.Text.Trim();
            String classe = textBox_classe.Text.Trim();
            if (id.Equals("") && name.Equals("") && sex.Equals("") && grade.Equals("") && department.Equals("") && major.Equals("") && classe.Equals(""))
            {
                MessageBox.Show("条件不能为空！");
                return;
            }
            else
            {
                String sql = CreateSql.getConditions_Sql(id, name, sex, grade, department, major, classe);
                dataGridView1.DataSource = SqlHelper.Query(sql);
            }
        }

        private void button_search_option_Click(object sender, EventArgs e)
        {
            String str = textBox_option_search.Text.Trim();   //查询内容
            String option = comboBox_option.SelectedItem.ToString();    //查询选项
            String sql = CreateSql.getStudent_Sql(str, option);	//获得sql语句
            dataGridView1 .DataSource = SqlHelper.Query(sql);
        }

        private void textBox_option_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_search_option2_Click(object sender, EventArgs e)
        {
            String str = textBox_option_search2.Text.Trim();   //查询内容
            String option = comboBox_option2.SelectedItem.ToString();    //查询选项
            String sql = CreateSql.getStudent_Sql(str, option);	//获得sql语句
            dataGridView2.DataSource = SqlHelper.Query(sql);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
