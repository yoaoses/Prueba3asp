using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoachimOsesPrueba3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<Student> currentStudents;
        DataManager dbmanager = new DataManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            currentStudents = dbmanager.getAll("alumno");
            loadStudents(currentStudents, "pageLoad");

        }
        private void loadStudents(List<Student> students, String caller)
        {
            if (!IsPostBack && students.Count != 0)
            {
                loadData(students);
            }
            else
            {
                if (caller == "pageLoad")
                {
                    lstStudents.Visible = false;
                    lblNoRecords.Visible = true;
                }
                else if (caller == "textRut")
                {
                    loadData(currentStudents);
                }
            }
        }

        private void loadData(List<Student> dataList)
        {
            lstStudents.Items.Clear();
            lstStudents.DataSource = dataList;
            lstStudents.DataTextField = "Nombre";
            lstStudents.DataValueField = "Id";
            lstStudents.DataBind();
            lstStudents.Visible = true;
            lblNoRecords.Visible = false;
        }
        protected void habilitateDelete_CheckedChanged(object sender, EventArgs e) => btnDelete.Enabled = habilitateDelete.Checked;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = studentId.Text != "" ? Convert.ToInt32(studentId.Text) : 0;
            Student userInput = new Student(id, txtRut.Text, txtStudentName.Text);
            List<Student> filteredStudents;
            // Usar el valor de elementExists según tus necesidades
            switch (btnSave.Text) {
                case "Verificar":
                    if (txtRut.Text != "")
                    {
                        filteredStudents = currentStudents.Where(student => student.Rut.Contains(userInput.Rut)).ToList();
                    }
                    else {
                        filteredStudents = currentStudents.Where(student => student.Nombre.Contains(userInput.Nombre)).ToList();
                    }
                    if (filteredStudents.Count > 0)
                    {
                        loadData(filteredStudents);
                        if (filteredStudents.Count == 1)
                        {
                            btnSave.Enabled = true;
                            txtRut.Text = filteredStudents[0].Rut;
                            txtStudentName.Text = filteredStudents[0].Nombre;
                            btnSave.Text = "Actualizar";
                        }
                        else
                        {
                            btnSave.Enabled = false;
                            lbldbManager.Text = "Seleccione 1 coincidencia para Modificar";
                        }
                    }
                    else {
                        btnSave.Text = "Guardar Nuevo";
                    }
                    break;
                case "Guardar Nuevo":
                        updateSave(userInput, "saveNew");
                    break;
                case "Actualizar Datos":
                       
                        Student selectedStudent = currentStudents.FirstOrDefault(student => student.Id == userInput.Id);
                        String rutErrortext = selectedStudent.Rut == txtRut.Text ? "nada" : "";
                        String nameErrortext = selectedStudent.Nombre == txtStudentName.Text ? "nada" : "";
                    if (rutErrortext == "" && nameErrortext=="") {
                       updateSave(userInput, "update");
                    }
                    else
                    {
                        lbldbManager.Text = "No hay cambios, nada que guardar";
                    }
                    break;
                
            }
        }
        private void updateSave(Student element,String wutToDo) {
            string response = "";
            switch (wutToDo) {
                case "saveNew":
                    string[] values = { element.Rut, element.Nombre };
                    response = dbmanager.insertIntoTable("alumno", values);
                    if (response == "success")
                    {
                        resetFields();
                        loadData(dbmanager.getAll("alumno"));
                        lbldbManager.Text = "Nuevo Usuario guardado";
                    }
                    else
                    {
                        lbldbManager.Text = response;
                    }
                    break;
                case "update":
                    response = dbmanager.updateStudent(element);
                    if (response == "success")
                    {
                        resetFields();
                        loadData(dbmanager.getAll("alumno"));
                        lbldbManager.Text = response;
                    }
                    else
                    {
                        lbldbManager.Text = response;
                    }
                    break;
            }
            
    }

        protected void reset_Click(object sender, EventArgs e)
        {
            resetFields();
        }
        private void resetFields() {
            habilitateDelete.Checked = false;
            habilitateDelete.Enabled = false;
            btnDelete.Enabled = false;
            txtStudentName.Text = "";
            txtRut.Text = "";
            loadData(dbmanager.getAll("alumno"));
            btnSave.Text = "Verificar";
            btnSave.Enabled = true;
            studentId.Text = "";
            lbldbManager.Text = "---";
                
        }

        protected void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(lstStudents.SelectedItem.Value);
            List<Student> filteredStudents = currentStudents.Where(student => student.Id == selectedId).ToList();
            txtRut.Text = filteredStudents[0].Rut;
            txtStudentName.Text = filteredStudents[0].Nombre;
            studentId.Text = Convert.ToString(filteredStudents[0].Id);
            loadData(currentStudents);
            lstStudents.SelectedValue = filteredStudents[0].Id.ToString();
            btnSave.Enabled = true;
            btnSave.Text = "Actualizar Datos";
            lbldbManager.Text = "";
            habilitateDelete.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (studentId.Text != "") { 
                lbldbManager.Text=dbmanager.deleteThisone("alumno",Convert.ToInt32(studentId.Text));
                resetFields();
            }
        }

       
    }
}