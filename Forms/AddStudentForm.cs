using Org.BouncyCastle.Utilities.Encoders;
using StudentManageSystem.Entity;
using StudentManageSystem.Helpers;
using StudentManageSystem.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManageSystem.Forms
{
    public partial class AddStudentForm : Form
    {
        private Dictionary<String, String> departments;    //所有院系集合
        private Dictionary<String, String> all_Major;  //所有专业集合
        private List<string> majors;  //专业名称集合
        private List<string> classes;  //专业名称集合
        private Student student = new Student();
        private string department_ID = null;
        private string major_ID = null;
        private string grade = null;
        private string department_Name = null;
        private string major_Name = null;
        private string sid = null;
        private string name = null;
        private string sex = null;
        private string classe = null;
   
        public AddStudentForm()
        {
            try
            {
                departments = SqlHelper.getAllDepartment();
                all_Major = SqlHelper.getAllMajor();
                /*    foreach (KeyValuePair<string, string> item in departments)
                    {
                        MessageBox.Show("Key: " + item.Key + ", Value: " + item.Value);
                    }
                    MessageBox.Show(departments.Count.ToString());*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //Console.WriteLine(departments.Count);
            //MessageBox.Show(departments.Count.ToString());

            InitializeComponent();
         



        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            comboBox_sex.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_classe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_grade.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_major.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_departement.DropDownStyle = ComboBoxStyle.DropDownList;

            //comboBox_departement.Items.Clear();
            //专业选项
            foreach (KeyValuePair<string, string> item in departments)
            {
                comboBox_departement.Items.Add(item.Key);
                //MessageBox.Show("Key: " + item.Key + ", Value: " + item.Value);
            }

            //年级选项
            foreach (string item in Tools.CreateGrade())
            {
                comboBox_grade.Items.Add(item);
 
            }

            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_num.Clear();
            textBox_name.Clear();
            comboBox_sex.SelectedIndex = -1;
            comboBox_classe.SelectedIndex = -1;
            comboBox_grade.SelectedIndex = -1;
            comboBox_major.SelectedIndex = -1;
            comboBox_departement.SelectedIndex = -1;
            department_ID = null;
            major_ID = null;
            grade = null;
            department_Name = null;
            major_Name = null;
            sid = null;
            name = null;
            sex = null;
            classe = null;
         }

        private void button1_Click(object sender, EventArgs e)
        {
            student = new Student();
            sid = textBox_num.Text;
            name = textBox_name.Text;
            sex = comboBox_sex.Text;
            classe = comboBox_classe.Text;
            grade = comboBox_grade.Text;
            major_Name = comboBox_major.Text;
            department_Name = comboBox_departement.Text;

            MessageBox.Show("1111");
            if (sid.Equals(""))
            {
                MessageBox.Show("班号不能为空！");
                return;
            }
            if (textBox_num.Text.Length != 2)
            {
                MessageBox.Show("班号必须是两位数！");
                textBox_num.Clear();
                return;
            }
            if (name.Equals(""))
            {
                MessageBox.Show("姓名不能为空！");
                return;
            }
            if (sex.Equals(""))
            {
                MessageBox.Show("性别不能为空！");
                return;
            }
            if (grade.Equals(""))
            {
                MessageBox.Show("年级不能为空！");
                return;
            }
            if (classe.Equals(""))
            {
                MessageBox.Show("班级不能为空！");
                return;
            }

            if (department_ID.Equals(""))
            {
                MessageBox.Show("院系不能为空！");
                return;
            }

            if (major_ID.Equals(""))
            {
                MessageBox.Show("专业不能为空！");
                return;
            }
            String id = Tools.CreateID(grade, classe, major_ID, department_ID, sid);//生成学号

            MessageBox.Show("该学生的id为:" + id);
            student.setStudent_ID(id);
            student.setStudent_Name(name);
            student.setSex(sex);
            student.setGrade(grade);
            student.setClasse(classe);
            student.setMajor_Name(major_Name);
            student.setDepartment_Name(department_Name);
            student.setMajor_ID(major_ID);
            student.setDepartment_ID(department_ID);

            MessageBox.Show("StuID:"+student.getStudent_ID()+"\n"
                + "Student_Name:" + student.getStudent_Name() + "\n"
                + "sex:" + student.getSex() + "\n"
                + "Grade:" + student.getGrade() + "\n"
                + "classe:"+student.getClasse()+"\n"
                + "Major_ID:" + student.getMajor_ID() + "\n"
                + "Major_Name:" + student.getMajor_Name() + "\n"
                + "departID:"+student.getDepartment_ID() + "\n"
                + "departName:" + student.getDepartment_Name() + "\n"
               
               
                
                );

            if (SqlHelper.addStudent(student))
            {
                MessageBox.Show("添加成功！");
                return;
            }
            else
            {
                MessageBox.Show("添加失败！");

                return;
            }
        }

        private void comboBox_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_classe.SelectedIndex >= 0)
            {
                classe = comboBox_classe.SelectedItem.ToString();  
            }      
        }

        private void comboBox_departement_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_major.Items.Clear();
            comboBox_classe.Items.Clear();
            if (comboBox_departement.SelectedIndex >= 0)
            {
                string option = comboBox_departement.SelectedItem.ToString();

                department_ID = departments[option];	//获得院系编号
                //MessageBox.Show(option);
                //MessageBox.Show("department_ID: " + department_ID);
                majors = SqlHelper.getMajor(department_ID);

                foreach (string item in majors)
                {
                    comboBox_major.Items.Add(item);
                }
            }
                
        }

        private void comboBox_major_SelectedIndexChanged(object sender, EventArgs e)
        {
             comboBox_classe.Items.Clear();

            if(comboBox_major.SelectedIndex >= 0 )
            {
                string option = comboBox_major.SelectedItem.ToString();
                major_ID = all_Major[option];	//获得专业编号
                //MessageBox.Show("major_ID: "+major_ID);
                //MessageBox.Show("grade: "+grade);
                if (grade != null && major_ID != null)
                {
                
                    classes = SqlHelper.getClasse(grade, major_ID);
                    foreach (string item in classes)
                    {
                        //MessageBox.Show($"{item}, {item}");
                        comboBox_classe.Items.Add(item);
                    }
                }
            }
           
            
        }

        private void comboBox_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_classe.Items.Clear();
            if(comboBox_grade.SelectedIndex >= 0)
            {
                grade = comboBox_grade.SelectedItem.ToString();//获得年级

                if (comboBox_major.SelectedIndex >= 0)
                {
                    string option = comboBox_major.SelectedItem.ToString();
                    major_ID = all_Major[option];   //获得专业编号
                                                    //MessageBox.Show("major_ID: "+major_ID);
                                                    //MessageBox.Show("grade: "+grade);
                    if (grade != null && major_ID != null)
                    {

                        classes = SqlHelper.getClasse(grade, major_ID);
                        foreach (string item in classes)
                        {
                            //MessageBox.Show($"{item}, {item}");
                            comboBox_classe.Items.Add(item);
                        }
                    }
                }
            }
            

            

            //MessageBox.Show("grade: " + grade);
        }

        private void comboBox_sex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_sex.SelectedIndex >=0 )
            sex = comboBox_sex.SelectedItem.ToString();//获得性别
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_num_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
