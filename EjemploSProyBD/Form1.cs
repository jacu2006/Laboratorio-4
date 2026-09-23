using System.Globalization;

namespace EjemploSProyBD
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();
        private Image imagenPorDefecto;
        private int idSeleccionado = 0;

        public Form1()
        {
            InitializeComponent();
            listaProductos = new List<Producto>();
            imagenPorDefecto = btnCargarImagen.Image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos("");
        }

        private void cargarProductos(string filtro = "")
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Refresh();

            listaProductos = Conexion.GetProductos(filtro);

            foreach (var prod in listaProductos)
            {
                // Uso de la librería externa para convertir bytes a Image
                Image img = ImagenHelper.ByteArrayToImage(prod.Imagen);

                string precioFormateado = prod.Precio.ToString("F2", CultureInfo.InvariantCulture);

                dgvProductos.Rows.Add(prod.Id, prod.Nombre, precioFormateado, prod.Cantidad, img);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarProductos(txtBuscar.Text.Trim());
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    btnCargarImagen.Image = Image.FromFile(openFileDialog.FileName);
                    btnCargarImagen.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            if (ExisteProductoDuplicado(myProducto["nombre"].ToString(), 0))
            {
                MessageBox.Show($"El producto '{myProducto["nombre"]}' ya se encuentra registrado en el sistema.",
                                "Producto Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (Conexion.InsertSeguro("productos", myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro");
                cargarProductos();
                LimpiarCampos();
            }
        }

        private void CargarDatosProductos()
        {
            myProducto.Clear();

            string nombreNormalizado = txtNombre.Text.Trim().ToUpper();
            myProducto["nombre"] = nombreNormalizado;

            decimal precio = decimal.Parse(txtPrecio.Text.Trim(), CultureInfo.InvariantCulture);
            myProducto["precio"] = Math.Round(precio, 2);

            myProducto["cantidad"] = int.Parse(txtCantidad.Text.Trim());

            // Uso de la librería externa para convertir Image a bytes
            myProducto["imagen"] = ImagenHelper.ImageToByteArray(btnCargarImagen.Image);
        }

        private bool ExisteProductoDuplicado(string nombreNormalizado, int idIgnorar)
        {
            return listaProductos.Any(p => p.Nombre.Equals(nombreNormalizado, StringComparison.OrdinalIgnoreCase)
                                        && p.Id != idIgnorar);
        }

        private bool datosCorrectos()
        {
            var camposAValidar = new List<(TextBox txt, IValidadorCampo validador, string nombreCampo)>
            {
                (txtFolio, new ValidadorEntero(), "Folio"),
                (txtNombre, new ValidadorTexto(), "Nombre"),
                (txtPrecio, new ValidadorDecimal(), "Precio"),
                (txtCantidad, new ValidadorEntero(), "Cantidad")
            };

            foreach (var item in camposAValidar)
            {
                if (!item.validador.EsValido(item.txt.Text.Trim()))
                {
                    MessageBox.Show($"Error en '{item.nombreCampo}': {item.validador.MensajeError}",
                                    "Validación de Campos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    item.txt.Focus();
                    return false;
                }
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtFolio.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            btnCargarImagen.Image = imagenPorDefecto;
            idSeleccionado = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);

                txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";

                if (decimal.TryParse(fila.Cells[2].Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
                {
                    txtPrecio.Text = precio.ToString("F2", CultureInfo.InvariantCulture);
                }
                else
                {
                    txtPrecio.Text = fila.Cells[2].Value?.ToString() ?? "";
                }

                txtCantidad.Text = fila.Cells[3].Value?.ToString() ?? "";

                var imgVal = fila.Cells[4].Value;
                if (imgVal != null && imgVal is Image)
                    btnCargarImagen.Image = (Image)imgVal;
                else
                    btnCargarImagen.Image = imagenPorDefecto;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla dando clic sobre él.");
                return;
            }

            if (!datosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            if (ExisteProductoDuplicado(myProducto["nombre"].ToString(), idSeleccionado))
            {
                MessageBox.Show($"Ya existe otro producto registrado con el nombre '{myProducto["nombre"]}'.",
                                "Producto Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (Conexion.UpdateSeguro("productos", myProducto, idSeleccionado))
            {
                MessageBox.Show("Registro modificado exitosamente.");
                cargarProductos();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla dando clic sobre él.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este producto de forma permanente?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                if (Conexion.Delete("productos", idSeleccionado))
                {
                    MessageBox.Show("Registro eliminado exitosamente.");
                    cargarProductos();
                    LimpiarCampos();
                }
            }
        }
    }
}