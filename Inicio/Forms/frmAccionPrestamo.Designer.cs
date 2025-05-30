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
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(219, 25);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(147, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "HACER PRESTAMO";
            // 
            // lblIdUusario
            // 
            this.lblIdUusario.AutoSize = true;
            this.lblIdUusario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdUusario.Location = new System.Drawing.Point(245, 86);
            this.lblIdUusario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdUusario.Name = "lblIdUusario";
            this.lblIdUusario.Size = new System.Drawing.Size(94, 16);
            this.lblIdUusario.TabIndex = 1;
            this.lblIdUusario.Text = "ID USUARIO";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(155, 106);
            this.txtIdUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(288, 22);
            this.txtIdUsuario.TabIndex = 2;
            // 
            // txtIdLibro
            // 
            this.txtIdLibro.Location = new System.Drawing.Point(155, 187);
            this.txtIdLibro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdLibro.Name = "txtIdLibro";
            this.txtIdLibro.Size = new System.Drawing.Size(288, 22);
            this.txtIdLibro.TabIndex = 3;
            // 
            // lblIdLibro
            // 
            this.lblIdLibro.AutoSize = true;
            this.lblIdLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdLibro.Location = new System.Drawing.Point(245, 167);
            this.lblIdLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdLibro.Name = "lblIdLibro";
            this.lblIdLibro.Size = new System.Drawing.Size(70, 16);
            this.lblIdLibro.TabIndex = 5;
            this.lblIdLibro.Text = "ID LIBRO";
            // 
            // lblFechaEstipulada
            // 
            this.lblFechaEstipulada.AutoSize = true;
            this.lblFechaEstipulada.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEstipulada.Location = new System.Drawing.Point(212, 292);
            this.lblFechaEstipulada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaEstipulada.Name = "lblFechaEstipulada";
            this.lblFechaEstipulada.Size = new System.Drawing.Size(155, 16);
            this.lblFechaEstipulada.TabIndex = 7;
            this.lblFechaEstipulada.Text = "FECHA ESTIPULADA";
            // 
            // dtpkFechaEstipulada
            // 
            this.dtpkFechaEstipulada.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.dtpkFechaEstipulada.Location = new System.Drawing.Point(83, 330);
            this.dtpkFechaEstipulada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpkFechaEstipulada.Name = "dtpkFechaEstipulada";
            this.dtpkFechaEstipulada.Size = new System.Drawing.Size(368, 22);
            this.dtpkFechaEstipulada.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.Location = new System.Drawing.Point(249, 449);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmAccionPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(579, 690);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpkFechaEstipulada);
            this.Controls.Add(this.lblFechaEstipulada);
            this.Controls.Add(this.lblIdLibro);
            this.Controls.Add(this.txtIdLibro);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.lblIdUusario);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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