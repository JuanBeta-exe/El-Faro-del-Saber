namespace LoginV1.Forms
{
    partial class frmAccionPrestamo
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIdUusario = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtIdLibro = new System.Windows.Forms.TextBox();
            this.lblIdLibro = new System.Windows.Forms.Label();
            this.lblFechaEstipulada = new System.Windows.Forms.Label();
            this.dtpkFechaEstipulada = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(164, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(107, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "HACER PRESTAMO";
            // 
            // lblIdUusario
            // 
            this.lblIdUusario.AutoSize = true;
            this.lblIdUusario.Location = new System.Drawing.Point(184, 70);
            this.lblIdUusario.Name = "lblIdUusario";
            this.lblIdUusario.Size = new System.Drawing.Size(70, 13);
            this.lblIdUusario.TabIndex = 1;
            this.lblIdUusario.Text = "ID USUARIO";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(116, 86);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(217, 20);
            this.txtIdUsuario.TabIndex = 2;
            // 
            // txtIdLibro
            // 
            this.txtIdLibro.Location = new System.Drawing.Point(116, 152);
            this.txtIdLibro.Name = "txtIdLibro";
            this.txtIdLibro.Size = new System.Drawing.Size(217, 20);
            this.txtIdLibro.TabIndex = 3;
            // 
            // lblIdLibro
            // 
            this.lblIdLibro.AutoSize = true;
            this.lblIdLibro.Location = new System.Drawing.Point(184, 136);
            this.lblIdLibro.Name = "lblIdLibro";
            this.lblIdLibro.Size = new System.Drawing.Size(53, 13);
            this.lblIdLibro.TabIndex = 5;
            this.lblIdLibro.Text = "ID LIBRO";
            // 
            // lblFechaEstipulada
            // 
            this.lblFechaEstipulada.AutoSize = true;
            this.lblFechaEstipulada.Location = new System.Drawing.Point(159, 237);
            this.lblFechaEstipulada.Name = "lblFechaEstipulada";
            this.lblFechaEstipulada.Size = new System.Drawing.Size(112, 13);
            this.lblFechaEstipulada.TabIndex = 7;
            this.lblFechaEstipulada.Text = "FECHA ESTIPULADA";
            // 
            // dtpkFechaEstipulada
            // 
            this.dtpkFechaEstipulada.Location = new System.Drawing.Point(62, 268);
            this.dtpkFechaEstipulada.Name = "dtpkFechaEstipulada";
            this.dtpkFechaEstipulada.Size = new System.Drawing.Size(277, 20);
            this.dtpkFechaEstipulada.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(187, 365);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmAccionPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 561);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpkFechaEstipulada);
            this.Controls.Add(this.lblFechaEstipulada);
            this.Controls.Add(this.lblIdLibro);
            this.Controls.Add(this.txtIdLibro);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.lblIdUusario);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmAccionPrestamo";
            this.Text = "AccionPrestamo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdUusario;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.TextBox txtIdLibro;
        private System.Windows.Forms.Label lblIdLibro;
        private System.Windows.Forms.Label lblFechaEstipulada;
        private System.Windows.Forms.DateTimePicker dtpkFechaEstipulada;
        private System.Windows.Forms.Button btnAceptar;
    }
}