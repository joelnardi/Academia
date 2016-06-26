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


        public Plan PlanActual
        {
            get; set;
        }

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

        private void PlanesDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
