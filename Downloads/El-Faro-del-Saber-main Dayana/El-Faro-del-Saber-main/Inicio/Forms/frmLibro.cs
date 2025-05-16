using LoginV1.Controller;
using LoginV1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginV1.Forms
{
    public partial class frmLibro : Form
    {
        private LibroController _libroController = new LibroController();

        public frmLibro()
        {
            InitializeComponent();
            CargarLibros();
            
            txtConsulta.KeyPress += SoloNumeros_KeyPress;
            txtAutor.KeyPress += SoloLetras_KeyPress;
            txtISBN.KeyPress += SoloNumeros_KeyPress;    
            txtAño.KeyPress += SoloNumeros_KeyPress;
            txtCategoria.KeyPress += SoloNumeros_KeyPress;
            txtCantidad.KeyPress += SoloNumeros_KeyPress;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConsulta.Text))
            {
                CargarLibros();
            }
            else
            {
                var libros = _libroController.ObtenerLibroPorId(int.Parse(txtConsulta.Text));
                dgvLibros.DataSource = null;
                dgvLibros.DataSource = libros;
            }
            txtConsulta.Clear(); // Limpiar el TextBox después de la consulta

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposAgregar())
                return;

            // Crear un nuevo Libro con los datos ingresados
            var libro = new Libro
            {
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                Editorial = txtEditorial.Text,
                ISBN = txtISBN.Text,
                AñoPublicacion = int.Parse(txtAño.Text),
                Categoria = int.Parse(txtCategoria.Text),
                Cantidad = int.Parse(txtCantidad.Text),
                EjemplaresDisponibles = int.Parse(txtCantidad.Text),
                Estado = "Disponible"
            };
            _libroController.AgregarLibro(libro);

            // Limpiar los TextBox después de agregar el libro
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditorial.Clear();
            txtISBN.Clear();
            txtAño.Clear();
            txtCategoria.Clear();
            txtCantidad.Clear();

            // Actualizar la lista de libros en el DataGridView
            CargarLibros();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                // Obtener el ID del libro seleccionado
                int id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells[0].Value);

                // Crear un objeto Libro con los datos editados
                var libroEditado = new Libro
                {
                    Id = id,
                    Titulo = dgvLibros.SelectedRows[0].Cells[1].Value.ToString(),
                    Autor = dgvLibros.SelectedRows[0].Cells[2].Value.ToString(),    
                    Editorial = dgvLibros.SelectedRows[0].Cells[3].Value.ToString(),    
                    ISBN = dgvLibros.SelectedRows[0].Cells[4].Value.ToString(),
                    AñoPublicacion = int.Parse(dgvLibros.SelectedRows[0].Cells[5].Value.ToString()),
                    Categoria = int.Parse(dgvLibros.SelectedRows[0].Cells[6].Value.ToString()),
                    Cantidad = int.Parse(dgvLibros.SelectedRows[0].Cells[7].Value.ToString()),
                    EjemplaresDisponibles = int.Parse(dgvLibros.SelectedRows[0].Cells[8].Value.ToString()),
                    Estado = "Disponible"
                };

                // Llamar al método EditarLibro del controlador
                if (_libroController.EditarLibro(libroEditado))
                {
                    MessageBox.Show("Libro editado con éxito.");
                    CargarLibros();
                }
                else
                {
                    MessageBox.Show("Error al editar el libro.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el valor de la primera columna (por ejemplo, "Id") de la fila seleccionada y almacenarlo como entero
            if (dgvLibros.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells[0].Value);
                // Llamar al método EliminarLibro del controlador
                if (_libroController.EliminarLibro(id))
                {
                    MessageBox.Show("Libro eliminado con éxito.");
                    CargarLibros();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el libro.");
                }
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }

        private void CargarLibros()
        {
            var libros = _libroController.ObtenerLibros();
            dgvLibros.DataSource = null; // Limpiar el DataGridView
            dgvLibros.DataSource = libros; // Asignar la lista de libros como fuente de datos
        }
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras, espacio y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private bool ValidarCamposAgregar()
        {
            // Lista de campos y sus nombres amigables
            var campos = new List<(TextBox, string)>
            {
                (txtTitulo, "Título"),
                (txtAutor, "Autor"),
                (txtEditorial, "Editorial"),
                (txtISBN, "ISBN"),
                (txtAño, "Año de Publicación"),
                (txtCategoria, "Categoría"),
                (txtCantidad, "Cantidad")
            };

            var camposFaltantes = new List<string>();

            // Restablece el color de fondo de todos los TextBox
            foreach (var campo in campos)
                campo.Item1.BackColor = Color.White;

            // Verifica cuáles están vacíos
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Item1.Text))
                {
                    camposFaltantes.Add(campo.Item2);
                    campo.Item1.BackColor = Color.Crimson; // Resalta el campo faltante
                }
            }

            if (camposFaltantes.Count > 0)
            {
                MessageBox.Show(
                    "Debe completar los siguientes campos:\n- " + string.Join("\n- ", camposFaltantes),
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        
    }
}
