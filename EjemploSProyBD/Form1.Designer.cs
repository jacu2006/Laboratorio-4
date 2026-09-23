namespace EjemploSProyBD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            txtBuscar = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dgvProductos = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewImageColumn();
            imageList1 = new ImageList(components);
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnCargarImagen = new PictureBox();
            txtFolio = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            label6 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCargarImagen).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtBuscar);
            panel1.Location = new Point(46, 306);
            panel1.Name = "panel1";
            panel1.Size = new Size(710, 64);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLight;
            label5.Location = new Point(38, 21);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 2;
            label5.Text = "&Búsqueda:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(506, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(137, 18);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(352, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(46, 117);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 1;
            label1.Text = "Folio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(46, 166);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(46, 211);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 3;
            label3.Text = "Precio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(46, 257);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 4;
            label4.Text = "Cantidad:";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvProductos.Location = new Point(46, 387);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 80;
            dgvProductos.Size = new Size(710, 184);
            dgvProductos.TabIndex = 5;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Nombre";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Precio";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Cantidad";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Imagen";
            Column5.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Resizable = DataGridViewTriState.True;
            Column5.SortMode = DataGridViewColumnSortMode.Automatic;
            Column5.Width = 125;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "limpiar.png");
            imageList1.Images.SetKeyName(1, "agregar-imagen.png");
            imageList1.Images.SetKeyName(2, "borrar.png");
            imageList1.Images.SetKeyName(3, "buscar.png");
            imageList1.Images.SetKeyName(4, "lapices.png");
            imageList1.Images.SetKeyName(5, "guardar.png");
            imageList1.Images.SetKeyName(6, "boton-agregar.png");
            imageList1.Images.SetKeyName(7, "bolsa-de-la-compra.png");
            // 
            // btnGuardar
            // 
            btnGuardar.ImageKey = "boton-agregar.png";
            btnGuardar.ImageList = imageList1;
            btnGuardar.Location = new Point(46, 595);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(115, 59);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.ImageKey = "lapices.png";
            btnModificar.ImageList = imageList1;
            btnModificar.Location = new Point(183, 595);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(115, 59);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "&Modificar";
            btnModificar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.ImageKey = "borrar.png";
            btnEliminar.ImageList = imageList1;
            btnEliminar.Location = new Point(321, 595);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(115, 59);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "&Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.ImageKey = "limpiar.png";
            btnLimpiar.ImageList = imageList1;
            btnLimpiar.Location = new Point(464, 595);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(115, 59);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "&Limpiar";
            btnLimpiar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCargarImagen
            // 
            btnCargarImagen.Image = (Image)resources.GetObject("btnCargarImagen.Image");
            btnCargarImagen.Location = new Point(596, 121);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(160, 160);
            btnCargarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCargarImagen.TabIndex = 10;
            btnCargarImagen.TabStop = false;
            btnCargarImagen.Click += btnCargarImagen_Click;
            // 
            // txtFolio
            // 
            txtFolio.Location = new Point(164, 114);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(311, 27);
            txtFolio.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(164, 163);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(311, 27);
            txtNombre.TabIndex = 11;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(164, 208);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(311, 27);
            txtPrecio.TabIndex = 12;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(164, 254);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(311, 27);
            txtCantidad.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(513, 117);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 14;
            label6.Text = "Imagen:";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(label7);
            panel2.Location = new Point(3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(793, 94);
            panel2.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.ImageKey = "(ninguna)";
            label7.ImageList = imageList1;
            label7.Location = new Point(58, 24);
            label7.Name = "label7";
            label7.Size = new Size(333, 46);
            label7.TabIndex = 15;
            label7.Text = "CRUD de productos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 678);
            Controls.Add(panel2);
            Controls.Add(label6);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtFolio);
            Controls.Add(btnCargarImagen);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvProductos);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCargarImagen).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private TextBox txtBuscar;
        private Label label5;
        private DataGridView dgvProductos;
        private ImageList imageList1;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private PictureBox btnCargarImagen;
        private TextBox txtFolio;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Label label6;
        private Panel panel2;
        private Label label7;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewImageColumn Column5;
    }
}
