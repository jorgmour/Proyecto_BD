using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;


namespace MVC_VISTA_
{
    public partial class btncancelar : Form
    {
        ClsContacto objContacto = null; //inicializar la instancia 
        ClsContactoMgr objContactoMgr = null; //inicializar la instancia 
        DataTable Dtt;

        public btncancelar()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            objContacto = new ClsContacto(); //completo la instancia
            objContacto.opc = 1;
            objContactoMgr = new ClsContactoMgr(objContacto);//completo la instancia

            Dtt = new DataTable();
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
            {
                dtregistros.DataSource = Dtt;
            }
        }

        private void Guardar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 2;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Datos ingresados correctamente", "Mensaje");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
            btnguardarcambio.Enabled = false;
            txtcodigo.Focus();
            btnelminar.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtcodigo.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txtcodigo.Focus();
        }

        private void GuardarCambios()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 3;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Cambios guardados correctamente", "Mensaje");

        }

        private void dtregistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txttelefono.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();
            btnguardar.Enabled = false;
            btnguardarcambio.Enabled = true;
            txtcodigo.Enabled = false;
            btnelminar.Enabled = true;

        }

        private void btnguardarcambio_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambio.Enabled = false;
            txtcodigo.Enabled = true;
            btnelminar.Enabled = false;
            LimpiarCampos();
            
        }

        public void Eliminar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 4;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContactoMgr = new ClsContactoMgr(objContacto);

            objContactoMgr.EliminarDatos();
            MessageBox.Show("Registro eliminado exitosamente", "Mensaje");




        }

        private void btnelminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambio.Enabled = false;
            txtcodigo.Enabled = true;
            btnelminar.Enabled = false;
            LimpiarCampos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtcodigo.Enabled = true;
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambio.Enabled = false;
            btnelminar.Enabled = false;
            LimpiarCampos();

        }
    }
}


