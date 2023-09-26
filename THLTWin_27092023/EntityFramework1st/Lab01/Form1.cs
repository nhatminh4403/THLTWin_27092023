using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> listStudent;
        List<Faculty> listFaculty;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB contextDB = new StudentContextDB();
                listFaculty = contextDB.Faculties.ToList();//lấy khoa
                listStudent = contextDB.Students.ToList();//lấy sv
                FillcmbFaculty(listFaculty);
                BindDataToGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to access into db", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FillcmbFaculty(List<Faculty> listFaculty)
        {
            this.cmbFaculty.DataSource = listFaculty;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void BindDataToGrid(List<Student> students)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in students)
            {
                Int32 index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentId;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }
        private void Refresh()
        {
            txtIDStudent.Clear();
            txtName.Clear();
            txtScore.Clear();
            cmbFaculty.SelectedValue = 1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB contextDB = new StudentContextDB();
                var student = new Student()
                {
                    StudentId = txtIDStudent.Text,
                    FullName = txtName.Text,
                    AverageScore = float.Parse(txtScore.Text),
                    FacultyID = int.Parse(cmbFaculty.SelectedValue.ToString())
                };
                contextDB.Students.Add(student);
                contextDB.SaveChanges();
                MessageBox.Show("Thêm mới dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
