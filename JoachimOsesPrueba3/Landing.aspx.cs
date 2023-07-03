using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoachimOsesPrueba3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private List<Student> currentStudents;
        private List<Asignatura> currentSubjects;
        private Inscripcion currentInscription;
        readonly DataManager dbmanager = new DataManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            currentSubjects = dbmanager.getAllSubjects("asignatura");
            currentStudents = dbmanager.getAll("alumno");
            if (!IsPostBack && currentStudents.Count != 0)
            {
                loadStudentData(currentStudents);
                lblLstData.Text = "Alumnos";
                loadSelectData(currentSubjects);
            }   
        }
        private void loadStudentData(List<Student> dataList)
        {
            if (dataList.Count > 0)
            {
                lstData.Items.Clear();
                lstData.DataSource = dataList;
                lstData.DataTextField = "Nombre";
                lstData.DataValueField = "Id";
                lstData.DataBind();
            }
            else {
                lblLstData.Text = "No hay Datos";
            }
        }
        private void loadSubjectData(List<Asignatura> dataList)
        {
            lstData.Items.Clear();
            lstData.DataSource = dataList;
            lstData.DataTextField = "Nombre";
            lstData.DataValueField = "Id";
            lstData.DataBind();
            lblLstData.Text = "Alumnos";
            loadSelectData(dataList);
        }
        private void loadSelectData(List<Asignatura> dataList) { 
            foreach (Asignatura asignatura in dataList)
            {
                ListItem item = new ListItem(asignatura.Nombre, asignatura.Id.ToString());
                DropDownList1.Items.Add(item);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            currentSubjects = dbmanager.getAllSubjects("asignatura");
            if (currentSubjects.Count != 0)
            {
                loadSubjectData(currentSubjects);
                lblLstData.Text = "Asignaturas";
            }
            else
            {
                lblLstData.Text = "No hay alumnos";
            }

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //lblLstData.Text = "button1 click";
            currentStudents = dbmanager.getAll("alumno");
            if (currentStudents.Count != 0)
            {
                loadStudentData(currentStudents);
                lblLstData.Text = "Alumnos";
            }
            else
            {
                lblLstData.Text = "No hay alumnos";
            }
        }
        private void getDataForGrid(String caller,String aditional) {
            List<Inscripcion> obtainedData=new List<Inscripcion>();
            switch (caller) {
                case "student":
                    obtainedData = dbmanager.SelectAllStudentRelated(aditional);
                    listStatus.Text = "Ramos Inscritos";
                    break;
                case "subject":
                    obtainedData = dbmanager.SelectAllSubjectRelated(aditional);
                    listStatus.Text = "Resgistros aisgnatura";
                    break;
                case "all":
                    obtainedData = dbmanager.SelectAllInscriptions();
                    break;
            }
            if (obtainedData.Count > 0) { 
                dataToGrid(obtainedData);
            }
            else
            {
                listStatus.Text = "Nada que mostrar";

            }

        }
        protected void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblLstData.Text == "Alumnos")
            {
                Student found = currentStudents.Find(student => student.Id == Convert.ToInt32(lstData.SelectedValue));
                txtNombre.Text = found.Nombre;
                txtRut.Text = found.Rut;
                getDataForGrid("student", found.Rut);
            }
            else {
                Asignatura found = currentSubjects.Find(subject => subject.Id == Convert.ToInt32(lstData.SelectedValue));
                DropDownList1.SelectedValue = found.Id.ToString();
                getDataForGrid("subject", found.Codigo);
            }
        }
        private void dataToGrid(List<Inscripcion> incommingData) {
            dgData.DataSource = incommingData;
            dgData.DataBind();
        } 
        protected void Button3_Click(object sender, EventArgs e)
        {
            getDataForGrid("all", "*");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtRut.Text == "")
            {
                Student result = currentStudents.Find(element => element.Nombre == txtNombre.Text);
                if (result == null)
                {
                    txtRut.Text = "";
                    txtNombre.Text = "";
                }
                else {
                    txtNombre.Text = result.Nombre;
                    txtRut.Text = result.Rut;
                }
            }
            else { 
                Student result = currentStudents.Find(element => element.Rut == txtRut.Text);
            }
        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            int errcount = 0;
            errcount = currentStudents.Any(element => element.Nombre == txtNombre.Text) ? errcount : errcount + 1;
            errcount = currentStudents.Any(element => element.Rut == txtRut.Text) ? errcount : errcount + 1;
            errcount = currentSubjects.Any(element => element.Id.ToString() == DropDownList1.SelectedValue) ? errcount : errcount + 1;
            if (errcount == 0) {
                Inscripcion newRecord = new Inscripcion();
                newRecord.Rut = txtRut.Text;
                Asignatura found = currentSubjects.Find(asignatura => asignatura.Id.ToString() == DropDownList1.SelectedValue);    
                newRecord.Codigo = found.Codigo; // Obtener el valor de Codigo del objeto encontrado
                newRecord.Fecha = DateTime.Now;
                string[] values = { newRecord.Rut, newRecord.Codigo, newRecord.Fecha.ToString("dd-MM-yyyy") };
                dbmanager.insertIntoTable("inscripcion", values);
                resetFields();
            }


        }
        private void resetFields() {
            lstData.Items.Clear();
            txtNombre.Text = "";
            txtRut.Text = "";
            DropDownList1.Items.Clear();
            chkHabilitarCancelar.Checked = false;
            btnEliminarInscripcion.Enabled = false;
            dgData.DataSource = null; // Clear the data source
            dgData.DataBind();
            currentStudents = dbmanager.getAll("alumno");
            currentSubjects = dbmanager.getAllSubjects("asignatura");
            loadStudentData(currentStudents);
            lblLstData.Text = "Alumnos";
            loadSelectData(currentSubjects);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        protected void chkHabilitarCancelar_CheckedChanged(object sender, EventArgs e)=> btnEliminarInscripcion.Enabled = chkHabilitarCancelar.Checked;

        protected void dgData_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* select all inscripciones no retorna valores*/

        }
    }
}