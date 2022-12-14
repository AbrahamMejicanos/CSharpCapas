using Entidades.Usuario;
using LogicaNegocio.Usuario;
using System;
using System.Windows.Forms;

namespace ProyectoPrueba.Principal
{
    public partial class FrmUsuario : Form
    {
        private ClsUsuario objUsuario = null;
        private readonly ClsUsuarioLn objUsuarioLn = new ClsUsuarioLn();

        public FrmUsuario()
        {
            InitializeComponent();
            CargarListaUsuarios();
        }

        private void CargarListaUsuarios() { 
            
            objUsuario = new ClsUsuario();
            objUsuarioLn.Index(ref objUsuario);
            if (objUsuario.MensajeError == null) {

                dgvUsuarios.DataSource = objUsuario.DtResultado;

            }
            else {

                MessageBox.Show(objUsuario.MensajeError, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            objUsuario = new ClsUsuario() {

                NUTUX = tbN.Text,
                PATUX = tbPA.Text,
                SATUX = tbSA.Text,
                NTUXX = tbNi.Text
            
            };

            objUsuarioLn.Create(ref objUsuario);

            if (objUsuario.MensajeError == null)
            {

                MessageBox.Show("El ID: " + objUsuario.ValorScalar + ", fue agregado correctamente");
                CargarListaUsuarios();

            }
            else {

                MessageBox.Show(objUsuario.MensajeError, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {

            objUsuario = new ClsUsuario()
            {
                IDTUX = Convert.ToByte(lblIUTUX.Text),
                NUTUX = tbN.Text,
                PATUX = tbPA.Text,
                SATUX = tbSA.Text,
                NTUXX = tbNi.Text

            };

            objUsuarioLn.Update(ref objUsuario);
            if (objUsuario.MensajeError == null)
            {

                MessageBox.Show("El usuario fue actualizado correctamente");
                CargarListaUsuarios();

            }
            else
            {

                MessageBox.Show(objUsuario.MensajeError, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try {

                if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Editar") {

                    objUsuario = new ClsUsuario() {

                        IDTUX = Convert.ToByte(dgvUsuarios.Rows[e.RowIndex].Cells["IDTUX"].Value.ToString())

                    };

                    lblIUTUX.Text = objUsuario.IDTUX.ToString();
                    objUsuarioLn.Read(ref objUsuario);
                    tbN.Text = objUsuario.NUTUX;
                    tbPA.Text = objUsuario.PATUX;
                    tbSA.Text = objUsuario.SATUX;
                    tbNi.Text = objUsuario.NTUXX;

                }

            } catch (Exception ex) {

                throw;

             }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objUsuario = new ClsUsuario() {

                IDTUX = Convert.ToByte(lblIUTUX.Text)

            };

            objUsuarioLn.Delete(ref objUsuario);
            CargarListaUsuarios();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
