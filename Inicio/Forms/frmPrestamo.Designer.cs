namespace LoginV1.Forms
{
    partial class frmPrestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgPrestamos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pnlAccionPrestamo = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnExtender = new System.Windows.Forms.Button();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrestamos)).BeginInit();
            this.pnlAccionPrestamo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgPrestamos
            // 
            this.dtgPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrestamos.Location = new System.Drawing.Point(16, 80);
            this.dtgPrestamos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgPrestamos.Name = "dtgPrestamos";
            this.dtgPrestamos.RowHeadersWidth = 51;
            this.dtgPrestamos.Size = new System.Drawing.Size(984, 362);
            this.dtgPrestamos.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(33, 41);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(173, 106);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlAccionPrestamo
            // 
            this.pnlAccionPrestamo.Controls.Add(this.btnEditar);
            this.pnlAccionPrestamo.Controls.Add(this.btnEliminar);
            this.pnlAccionPrestamo.Controls.Add(this.btnExtender);
            this.pnlAccionPrestamo.Controls.Add(this.btnDevolucion);
            this.pnlAccionPrestamo.Controls.Add(this.btnAgregar);
            this.pnlAccionPrestamo.Location = new System.Drawing.Point(16, 449);
            this.pnlAccionPrestamo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAccionPrestamo.Name = "pnlAccionPrestamo";
            this.pnlAccionPrestamo.Size = new System.Drawing.Size(1224, 174);
            this.pnlAccionPrestamo.TabIndex = 3;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEditar.Location = new System.Drawing.Point(708, 41);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(192, 106);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(944, 41);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(192, 106);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnExtender
            // 
            this.btnExtender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExtender.Location = new System.Drawing.Point(465, 41);
            this.btnExtender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExtender.Name = "btnExtender";
            this.btnExtender.Size = new System.Drawing.Size(205, 106);
            this.btnExtender.TabIndex = 4;
            this.btnExtender.Text = "EXTENDER";
            this.btnExtender.UseVisualStyleBackColor = true;
            this.btnExtender.Click += new System.EventHandler(this.btnExtender_Click);
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDevolucion.Location = new System.Drawing.Point(243, 41);
            this.btnDevolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(196, 106);
            this.btnDevolucion.TabIndex = 3;
            this.btnDevolucion.Text = "DEVOLUCION";
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.Location = new System.Drawing.Point(869, 48);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(131, 30);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.CargarPrestamos);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAtras.Location = new System.Drawing.Point(3, 1);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(97, 34);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(16, 48);
            this.txtConsulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(844, 22);
            this.txtConsulta.TabIndex = 6;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(643, 1);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 28);
            this.btnExportar.TabIndex = 11;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.ExportarPrestamos);
            // 
            // btnImportar
            // 
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnImportar.Location = new System.Drawing.Point(520, 1);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(100, 28);
            this.btnImportar.TabIndex = 10;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.ImportarPrestamos_Click);
            // 
            // frmPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1285, 628);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.txtConsulta);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.pnlAccionPrestamo);
            this.Controls.Add(this.dtgPrestamos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPrestamo";
            this.Text = "Prestamo";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrestamos)).EndInit();
            this.pnlAccionPrestamo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgPrestamos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel pnlAccionPrestamo;
        private System.Windows.Forms.Button btnExtender;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnImportar;
    }
}