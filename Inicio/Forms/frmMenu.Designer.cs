namespace LoginV1.Forms
{
    partial class frmMenu
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
            this.pnlMenuBotones = new System.Windows.Forms.Panel();
            this.btnMulta = new System.Windows.Forms.Button();
            this.btnPrestamo = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnLibro = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlMenuBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBotones
            // 
            this.pnlMenuBotones.Controls.Add(this.btnMulta);
            this.pnlMenuBotones.Controls.Add(this.btnPrestamo);
            this.pnlMenuBotones.Controls.Add(this.btnUsuario);
            this.pnlMenuBotones.Controls.Add(this.btnLibro);
            this.pnlMenuBotones.Location = new System.Drawing.Point(16, 102);
            this.pnlMenuBotones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMenuBotones.Name = "pnlMenuBotones";
            this.pnlMenuBotones.Size = new System.Drawing.Size(1035, 480);
            this.pnlMenuBotones.TabIndex = 0;
            // 
            // btnMulta
            // 
            this.btnMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnMulta.Location = new System.Drawing.Point(611, 322);
            this.btnMulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMulta.Name = "btnMulta";
            this.btnMulta.Size = new System.Drawing.Size(361, 150);
            this.btnMulta.TabIndex = 3;
            this.btnMulta.Text = "MULTAS";
            this.btnMulta.UseVisualStyleBackColor = true;
            this.btnMulta.Click += new System.EventHandler(this.btnMulta_Click);
            // 
            // btnPrestamo
            // 
            this.btnPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPrestamo.Location = new System.Drawing.Point(59, 322);
            this.btnPrestamo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrestamo.Name = "btnPrestamo";
            this.btnPrestamo.Size = new System.Drawing.Size(361, 150);
            this.btnPrestamo.TabIndex = 2;
            this.btnPrestamo.Text = "PRESTAMO";
            this.btnPrestamo.UseVisualStyleBackColor = true;
            this.btnPrestamo.Click += new System.EventHandler(this.btnPrestamo_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUsuario.Location = new System.Drawing.Point(611, 137);
            this.btnUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(361, 150);
            this.btnUsuario.TabIndex = 1;
            this.btnUsuario.Text = "USUARIOS";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnLibro
            // 
            this.btnLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLibro.Location = new System.Drawing.Point(59, 137);
            this.btnLibro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLibro.Name = "btnLibro";
            this.btnLibro.Size = new System.Drawing.Size(361, 150);
            this.btnLibro.TabIndex = 0;
            this.btnLibro.Text = "LIBROS";
            this.btnLibro.UseVisualStyleBackColor = true;
            this.btnLibro.Click += new System.EventHandler(this.btnLibro_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(3, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Cerrar Sesion";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1067, 597);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlMenuBotones);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.pnlMenuBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotones;
        private System.Windows.Forms.Button btnMulta;
        private System.Windows.Forms.Button btnPrestamo;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnLibro;
        private System.Windows.Forms.Button btnSalir;
    }
}