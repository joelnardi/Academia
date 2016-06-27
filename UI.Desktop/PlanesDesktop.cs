using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Negocio;


namespace UI.Desktop
{
    public partial class PlanesDesktop : ApplicationForm
    {

        #region Propiedades
        public Plan PlanActual
        {
            get; set;
        }
        #endregion
        #region Constructores
        public PlanesDesktop()
        {
            InitializeComponent();
            EspecialidadLogic el = new EspecialidadLogic();
            this.cmbEspecialidades.DataSource = el.GetAll();
        }

        public PlanesDesktop(ModoForm modo): this()
        {
            this.Modo = modo;
        }

        public PlanesDesktop(int ID, ModoForm modo): this()
        {
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            MapearDeDatos();
        }
        #endregion
        #region Metodos
        public override void MapearDeDatos()
        {
            txtID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion;            
            cmbEspecialidades.SelectedItem = PlanActual.especialidad;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
            }
            else
            {
                PlanActual.ID = int.Parse(txtID.Text);
            }
            PlanActual.Descripcion = txtDescripcion.Text;
            PlanActual.especialidad = (Especialidad)cmbEspecialidades.SelectedItem;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
                default:
                    break;
            }
        }

        public override void GuardarCambios()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                pl.Save(PlanActual);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public override bool Validar()
        {
            bool valido = true;
            if (this.txtDescripcion.Text.Length == 0 || this.cmbEspecialidades.SelectedItem == null)
            {
                valido = false;
            }
            return valido;
        }
        #endregion


        private void PlanesDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            else
            {
                MessageBox.Show("Dátos inválidos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
