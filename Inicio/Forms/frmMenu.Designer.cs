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
            this.pnlMenuBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBotones
            // 
            this.pnlMenuBotones.Controls.Add(this.btnMulta);
            this.pnlMenuBotones.Controls.Add(this.btnPrestamo);
            this.pnlMenuBotones.Controls.Add(this.btnUsuario);
            this.pnlMenuBotones.Controls.Add(this.btnLibro);
            this.pnlMenuBotones.Location = new System.Drawing.Point(12, 26);
            this.pnlMenuBotones.Name = "pnlMenuBotones";
            this.pnlMenuBotones.Size = new System.Drawing.Size(776, 412);
            this.pnlMenuBotones.TabIndex = 0;
            // 
            // btnMulta
            // 
            this.btnMulta.Location = new System.Drawing.Point(458, 262);
            this.btnMulta.Name = "btnMulta";
            this.btnMulta.Size = new System.Drawing.Size(271, 122);
            this.btnMulta.TabIndex = 3;
            this.btnMulta.Text = "MULTAS";
            this.btnMulta.UseVisualStyleBackColor = true;
            // 
            // btnPrestamo
            // 
            this.btnPrestamo.Location = new System.Drawing.Point(44, 262);
            this.btnPrestamo.Name = "btnPrestamo";
            this.btnPrestamo.Size = new System.Drawing.Size(271, 122);
            this.btnPrestamo.TabIndex = 2;
            this.btnPrestamo.Text = "PRESTAMO";
            this.btnPrestamo.UseVisualStyleBackColor = true;
            this.btnPrestamo.Click += new System.EventHandler(this.btnPrestamo_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(458, 111);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(271, 122);
            this.btnUsuario.TabIndex = 1;
            this.btnUsuario.Text = "USUARIOS";
            this.btnUsuario.UseVisualStyleBackColor = true;
            // 
            // btnLibro
            // 
            this.btnLibro.Location = new System.Drawing.Point(44, 111);
            this.btnLibro.Name = "btnLibro";
            this.btnLibro.Size = new System.Drawing.Size(271, 122);
            this.btnLibro.TabIndex = 0;
            this.btnLibro.Text = "LIBROS";
            this.btnLibro.UseVisualStyleBackColor = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMenuBotones);
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
    }
}