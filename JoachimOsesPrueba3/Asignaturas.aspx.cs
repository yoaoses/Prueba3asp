using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoachimOsesPrueba3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private List<Asignatura> subjects;
        DataManager dbmanager = new DataManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            subjects = dbmanager.getAllSubjects("asignatura");
            if (!IsPostBack && subjects.Count != 0)
            {
                resetFields();
                loadSubjects(subjects);
                lblcardHeader.Text = "Asignaturas almacenadas";
            }
            else {
                if (subjects.Count == 0) {
                    lblcardHeader.Text = "No hay datos";
                }
            }

        }
        private void loadSubjects(List<Asignatura>dataList) {
            lstAsignaturas.Items.Clear();
            if (dataList.Count > 0)
            {
                foreach(var asignatura in dataList)
                {
                    ListItem item = new ListItem(asignatura.Nombre, asignatura.Id.ToString());
                    lstAsignaturas.Items.Add(item);
                }
            }
            else {
                lblcardHeader.Text = "No hay datos";
            }
        }
        /**
         *  Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Horas = horas;
            Semestre = semestre;
        */

        protected void lstAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {       
            int selectedId = Convert.ToInt32(value: lstAsignaturas.SelectedItem.Value);
            List<Asignatura> filteredSubs = subjects.Where(sub => sub.Id == selectedId).ToList();
            txtCodigo.Text = filteredSubs[0].Codigo;
            txtNombre.Text = filteredSubs[0].Nombre;
            txtHoras.Text = filteredSubs[0].Horas.ToString();
            txtSemestre.Text = filteredSubs[0].Semestre.ToString();
            lblrecordId.Text = Convert.ToString(filteredSubs[0].Id);
            lstAsignaturas.SelectedValue = filteredSubs[0].Id.ToString();
            btnGuardar.Enabled = true;
            btnGuardar.Text = "Actualizar Datos";
            habilitateDelete.Enabled = true;
            lblDataHeader.Text = "Detalle";
            lblcardHeader.Text = "Asiganturas almacenadas";
            
        }

        protected void habilitateDelete_CheckedChanged(object sender, EventArgs e) => btnDelete.Enabled = habilitateDelete.Checked;
        protected void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (lblrecordId.Text != "")
            {
                lblDataHeader.Text = dbmanager.deleteThisone("asignatura", Convert.ToInt32(lblrecordId.Text));
            }
            resetFields();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetFields();
        }
        private void resetFields() {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtHoras.Text = "";
            txtSemestre.Text = "";
            lblDataHeader.Text = "";
            lblrecordId.Text = "";
            btnGuardar.Text = "Guardar Nuevo";
            loadSubjects(dbmanager.getAllSubjects("asignatura"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            int horas = 0;
            int.TryParse(txtHoras.Text, out horas);
            int semestre = 0;
            int.TryParse(txtSemestre.Text, out semestre);
            int recordId = 0;
            int.TryParse(lblrecordId.Text, out recordId);

            // Realizar cualquier procesamiento adicional con los datos capturados
            // ...

            // Ejemplo de cómo utilizar los datos capturados:
            Asignatura userInput = new Asignatura(
                recordId,
                codigo,
                nombre,
                horas,
                semestre
            );
            lblDataHeader.Text = userInput.Codigo + ", " + userInput.Nombre + ", " + userInput.Id + ", " + userInput.Horas + ", " + userInput.Semestre;
            switch (btnGuardar.Text) {
                case "Guardar Nuevo":
                        String[] value = { userInput.Codigo, userInput.Nombre, userInput.Horas.ToString(), userInput.Semestre.ToString() };
                        lblDataHeader.Text = dbmanager.insertIntoTable("asignatura", value);
                    break;
                case "Actualizar Datos":
                        lblDataHeader.Text = dbmanager.UpdateAsignatura(userInput);
                    break;
                default:
                    resetFields();
                    break;
            }
            
            
        }
    }
        
}