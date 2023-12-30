using StudentManageSystem.Entity;
using StudentManageSystem.Forms;
using StudentManageSystem.Helpers;
using StudentManageSystem.Utils;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace StudentManageSystem
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            gp.Dispose();
            region.Dispose();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox_user.Text == "")
            {
                textBox_user.Text = "请输入用户名";
                textBox_user.ForeColor = Color.Gray;
            }
            else
            {
                textBox_pwd.ForeColor = Color.Black;
            }
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBox_user.Text == "请输入用户名")
            {
                textBox_user.Text = "";
                textBox_user.ForeColor = Color.Black;
            }

        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (textBox_pwd.Text == "")
            {
                textBox_pwd.Text = "请输入密码";
                textBox_pwd.ForeColor = Color.Gray;
            }
            else
            {
                textBox_pwd.ForeColor = Color.Black;
            }
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            if (textBox_pwd.Text == "请输入密码")
            {
                textBox_pwd.Text = "";
                textBox_pwd.ForeColor = Color.Black;
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.radioButton_student = new System.Windows.Forms.RadioButton();
            this.radioButton_teacher = new System.Windows.Forms.RadioButton();
            this.button_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentManageSystem.Properties.Resources.QQ头像;
            this.pictureBox1.Location = new System.Drawing.Point(260, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_user
            // 
            this.textBox_user.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_user.ForeColor = System.Drawing.Color.Gray;
            this.textBox_user.Location = new System.Drawing.Point(190, 455);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(425, 26);
            this.textBox_user.TabIndex = 1;
            this.textBox_user.Text = "请输入用户名";
            this.textBox_user.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.textBox_user.GotFocus += new System.EventHandler(this.textBox1_GotFocus);
            this.textBox_user.LostFocus += new System.EventHandler(this.textBox1_LostFocus);
            // 
            // radioButton_student
            // 
            this.radioButton_student.AutoSize = true;
            this.radioButton_student.Checked = true;
            this.radioButton_student.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_student.Location = new System.Drawing.Point(190, 633);
            this.radioButton_student.Name = "radioButton_student";
            this.radioButton_student.Size = new System.Drawing.Size(57, 20);
            this.radioButton_student.TabIndex = 0;
            this.radioButton_student.TabStop = true;
            this.radioButton_student.Text = "学生";
            this.radioButton_student.UseVisualStyleBackColor = true;
            this.radioButton_student.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_teacher
            // 
            this.radioButton_teacher.AutoSize = true;
            this.radioButton_teacher.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_teacher.Location = new System.Drawing.Point(565, 633);
            this.radioButton_teacher.Name = "radioButton_teacher";
            this.radioButton_teacher.Size = new System.Drawing.Size(57, 20);
            this.radioButton_teacher.TabIndex = 3;
            this.radioButton_teacher.Text = "老师";
            this.radioButton_teacher.UseVisualStyleBackColor = true;
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_login.Location = new System.Drawing.Point(190, 720);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(182, 62);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "————————————Login————————————";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_pwd.ForeColor = System.Drawing.Color.Gray;
            this.textBox_pwd.Location = new System.Drawing.Point(190, 542);
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.Size = new System.Drawing.Size(425, 26);
            this.textBox_pwd.TabIndex = 2;
            this.textBox_pwd.Text = "请输入密码";
            this.textBox_pwd.GotFocus += new System.EventHandler(this.textBox2_GotFocus);
            this.textBox_pwd.LostFocus += new System.EventHandler(this.textBox2_LostFocus);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(433, 720);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(182, 62);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(792, 811);
            this.Controls.Add(this.textBox_pwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.radioButton_teacher);
            this.Controls.Add(this.radioButton_student);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
    
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            textBox_user.Text = null;
            textBox_pwd.Text = null;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_login_Click_1(object sender, EventArgs e)
        {
            bool isS = radioButton_student.Checked;
            string sqlStr = String.Format("select * from {0} where User_name = '{1}' and Password = '{2}'",
                isS?"user_student":"user_teacher",textBox_user.Text,textBox_pwd.Text);


            using(var dt = SqlHelper.Query(sqlStr))
            {
                try
                {
                    if(dt.Rows.Count < 0 || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("账号或密码错误");
                        textBox_pwd.Focus();
                        return;
                    }
                    else
                    {
                        if (isS)
                        {
                            MessageBox.Show(dt.Rows[0][3].ToString());
                            Tools.setCurStudentInfo(dt.Rows[0][3].ToString());
                        }
                        else
                        {
                            MessageBox.Show(dt.Rows[0][3].ToString());
                            Tools.setCurTeacherInfo(dt.Rows[0][3].ToString());
                        }
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            Thread th;
            if (isS)
            {
                th = new Thread(delegate () { new StudentForm().ShowDialog(); });
            }
            else
            {
                th = new Thread(delegate () { new TeacherForm().ShowDialog(); });
            }
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
    }
}
