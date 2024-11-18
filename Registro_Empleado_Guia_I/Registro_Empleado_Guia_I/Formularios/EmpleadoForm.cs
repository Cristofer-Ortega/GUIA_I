using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using Registro_Empleado_Guia_I.Datos;

namespace Registro_Empleado_Guia_I.Formularios
{
    public partial class EmpleadoForm : Form
    {
        public Empleado Empleado { get; private set; }
        public EmpleadoForm()
        {
            InitializeComponent();
        }
        public EmpleadoForm(Empleado empleado)
        {
            InitializeComponent();
            tbxIdEmpleado.Text = empleado.Id;
            tbxNombre.Text = empleado.Nombre;
            tbxApellido1.Text = empleado.Apellido;
            tbxApellido2.Text = empleado.Apellido2;
            tbxEdad.Text = empleado.Edad.ToString();
            tbxEmail.Text = empleado.Email;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool empleadoValidado = ValidarEmpleado(out string errorMsg);
            if (empleadoValidado)
            {
                Empleado = new Empleado(tbxIdEmpleado.Text, tbxNombre.Text, tbxApellido1.Text, tbxApellido2.Text, Convert.ToDouble(tbxEdad.Text), tbxEmail.Text);
                this.DialogResult = DialogResult.OK;
            }
            else 
            { 
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private bool ValidarEmpleado(out string errorMsg) 
        {
            errorMsg = string.Empty;
            if(string.IsNullOrEmpty(tbxIdEmpleado.Text)) 
            {
                errorMsg += "El ID del empleado no puede estar vacio." + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(tbxNombre.Text))
            {
                errorMsg += "El Nombre del empleado no puede estar vacio." + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(tbxApellido1.Text))
            {
                errorMsg += "El apellido1 del empleado no puede estar vacio." + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(tbxApellido2.Text))
            {
                errorMsg += "El Apellido2 del empleado no puede estar vacio." + Environment.NewLine;
            }
            bool edadOk = double.TryParse(tbxEdad.Text, out double edad);
            if (edadOk)
            {
                if(edad < 16)
                {
                    errorMsg += "La edad debe de ser mayor a 16" + Environment.NewLine;
                }
            }
            else 
            {
                errorMsg += "La edad del empleado debe de ser un numero valido" + Environment.NewLine;
            }
            try 
            {
                new MailAddress(tbxEmail.Text);
;
            }
            catch(Exception ex) 
            {
                errorMsg += "El e -mail debe tener un formato correcto" + Environment.NewLine;
            }
            return errorMsg == string.Empty;
            
        }
    }
}
