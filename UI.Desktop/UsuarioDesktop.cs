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
    public partial class UsuarioDesktop : ApplicationForm
    {

        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get
            {
                return _usuarioActual;
            }

            set
            {
                _usuarioActual = value;
            }
        }

        public UsuarioDesktop() : base()
        {
            InitializeComponent();

        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usrL = new UsuarioLogic();
            UsuarioActual = usrL.GetOne(ID);
            MapearDeDatos();
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = UsuarioActual.ID.ToString();
            this.txtNombre.Text = UsuarioActual.Nombre;
            this.txtApellido.Text = UsuarioActual.Apellido;
            this.txtEmail.Text = UsuarioActual.EMail;
            this.txtUsuario.Text = UsuarioActual.NombreUsuario;
            this.txtClave.Text = UsuarioActual.Clave;
            this.txtConfirmarClave.Text = UsuarioActual.Clave;
            this.chkHabilitado.Checked = UsuarioActual.Habilitado;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }
            else
            {

                UsuarioActual.ID = int.Parse(txtID.Text);
            }

            if (txtClave.Text == txtConfirmarClave.Text)
            {
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.EMail = txtEmail.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Habilitado = chkHabilitado.Checked;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
                default:
                    break;
            }


        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic usrL = new UsuarioLogic();
            try
            {
                usrL.Save(UsuarioActual);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public override bool Validar()
        {
            bool valido = true;
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                valido = false;
                return false;
            }
            if (txtClave.Text.Length < 8)
            {
                valido = false;
                return false;
            }

            if (txtClave.Text.Length==0 || txtApellido.Text.Length == 0 || txtNombre.Text.Length == 0 || txtEmail.Text.Length == 0 || txtUsuario.Text.Length == 0)
            {
                valido = false;
                return false;
            }

            if (this.Modo == ModoForm.Modificacion && txtID.Text.Length == 0)
            {
                valido = false;
                return false;
            }
            if (!Util.Validacion.mailValido(txtEmail.Text))
            {
                valido = false;
                return false;
            }

            return valido;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
