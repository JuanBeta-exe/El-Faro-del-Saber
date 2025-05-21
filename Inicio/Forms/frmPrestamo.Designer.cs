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
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnExtender = new System.Windows.Forms.Button();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrestamos)).BeginInit();
            this.pnlAccionPrestamo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgPrestamos
            // 
            this.dtgPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrestamos.Location = new System.Drawing.Point(2, 50);
            this.dtgPrestamos.Name = "dtgPrestamos";
            this.dtgPrestamos.Size = new System.Drawing.Size(745, 294);
            this.dtgPrestamos.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(135, 33);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(142, 86);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlAccionPrestamo
            // 
            this.pnlAccionPrestamo.Controls.Add(this.btnActualizar);
            this.pnlAccionPrestamo.Controls.Add(this.btnExtender);
            this.pnlAccionPrestamo.Controls.Add(this.btnDevolucion);
            this.pnlAccionPrestamo.Controls.Add(this.btnAgregar);
            this.pnlAccionPrestamo.Location = new System.Drawing.Point(215, 365);
            this.pnlAccionPrestamo.Name = "pnlAccionPrestamo";
            this.pnlAccionPrestamo.Size = new System.Drawing.Size(745, 141);
            this.pnlAccionPrestamo.TabIndex = 3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(28, 65);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExtender
            // 
            this.btnExtender.Location = new System.Drawing.Point(568, 33);
            this.btnExtender.Name = "btnExtender";
            this.btnExtender.Size = new System.Drawing.Size(142, 86);
            this.btnExtender.TabIndex = 4;
            this.btnExtender.Text = "EXTENDER";
            this.btnExtender.UseVisualStyleBackColor = true;
            this.btnExtender.Click += new System.EventHandler(this.btnExtender_Click);
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Location = new System.Drawing.Point(355, 33);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(142, 86);
            this.btnDevolucion.TabIndex = 3;
            this.btnDevolucion.Text = "DEVOLUCION";
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(2, 1);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(73, 28);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 510);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.pnlAccionPrestamo);
            this.Controls.Add(this.dtgPrestamos);
            this.Name = "frmPrestamo";
            this.Text = "Prestamo";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrestamos)).EndInit();
            this.pnlAccionPrestamo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgPrestamos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel pnlAccionPrestamo;
        private System.Windows.Forms.Button btnExtender;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnActualizar;
    }
}