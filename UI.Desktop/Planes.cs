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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tscNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop formPlan = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop formPlan = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
            }
            this.Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop formPlan = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
            }
            this.Listar();
        }
    }
}
