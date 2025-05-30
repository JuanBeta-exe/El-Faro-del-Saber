namespace LoginV1.Forms
{
    partial class frmMulta
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvMultas = new System.Windows.Forms.DataGridView();
            this.pnlMultaDetalle = new System.Windows.Forms.Panel();
            this.btnAbonar = new System.Windows.Forms.Button();
            this.txtIdMulta = new System.Windows.Forms.TextBox();
            this.lblIdMulta = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.gbxPagarMulta = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).BeginInit();
            this.gbxPagarMulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAtras.Location = new System.Drawing.Point(0, 1);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(139, 30);
            this.btnAtras.TabIndex = 21;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.Location = new System.Drawing.Point(691, 46);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(139, 28);
            this.btnConsultar.TabIndex = 22;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvMultas
            // 
            this.dgvMultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMultas.Location = new System.Drawing.Point(0, 80);
            this.dgvMultas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMultas.Name = "dgvMultas";
            this.dgvMultas.RowHeadersWidth = 51;
            this.dgvMultas.Size = new System.Drawing.Size(829, 532);
            this.dgvMultas.TabIndex = 23;
            // 
            // pnlMultaDetalle
            // 
            this.pnlMultaDetalle.BackColor = System.Drawing.Color.Azure;
            this.pnlMultaDetalle.Location = new System.Drawing.Point(839, 80);
            this.pnlMultaDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMultaDetalle.Name = "pnlMultaDetalle";
            this.pnlMultaDetalle.Size = new System.Drawing.Size(655, 697);
            this.pnlMultaDetalle.TabIndex = 24;
            // 
            // btnAbonar
            // 
            this.btnAbonar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAbonar.Location = new System.Drawing.Point(139, 108);
            this.btnAbonar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbonar.Name = "btnAbonar";
            this.btnAbonar.Size = new System.Drawing.Size(153, 28);
            this.btnAbonar.TabIndex = 26;
            this.btnAbonar.Text = "ABONAR";
            this.btnAbonar.UseVisualStyleBackColor = true;
            // 
            // txtIdMulta
            // 
            this.txtIdMulta.Location = new System.Drawing.Point(40, 39);
            this.txtIdMulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdMulta.Name = "txtIdMulta";
            this.txtIdMulta.Size = new System.Drawing.Size(132, 22);
            this.txtIdMulta.TabIndex = 27;
            // 
            // lblIdMulta
            // 
            this.lblIdMulta.AutoSize = true;
            this.lblIdMulta.Location = new System.Drawing.Point(76, 20);
            this.lblIdMulta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdMulta.Name = "lblIdMulta";
            this.lblIdMulta.Size = new System.Drawing.Size(55, 16);
            this.lblIdMulta.TabIndex = 28;
            this.lblIdMulta.Text = "ID Multa";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(271, 39);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(132, 22);
            this.txtMonto.TabIndex = 31;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(285, 20);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(94, 16);
            this.lblMonto.TabIndex = 32;
            this.lblMonto.Text = "Monto a pagar";
            // 
            // gbxPagarMulta
            // 
            this.gbxPagarMulta.Controls.Add(this.lblMonto);
            this.gbxPagarMulta.Controls.Add(this.lblIdMulta);
            this.gbxPagarMulta.Controls.Add(this.txtMonto);
            this.gbxPagarMulta.Controls.Add(this.btnAbonar);
            this.gbxPagarMulta.Controls.Add(this.txtIdMulta);
            this.gbxPagarMulta.Location = new System.Drawing.Point(0, 619);
            this.gbxPagarMulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxPagarMulta.Name = "gbxPagarMulta";
            this.gbxPagarMulta.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxPagarMulta.Size = new System.Drawing.Size(484, 158);
            this.gbxPagarMulta.TabIndex = 26;
            this.gbxPagarMulta.TabStop = false;
            this.gbxPagarMulta.Text = "Pagar Multa";
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEditar.Location = new System.Drawing.Point(593, 633);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(164, 28);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Text = "Editar Multa";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(593, 727);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(164, 28);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.Text = "Eliminar Multa";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(0, 48);
            this.txtConsulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(669, 22);
            this.txtConsulta.TabIndex = 29;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(753, 1);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 28);
            this.btnExportar.TabIndex = 31;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmMulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1444, 791);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtConsulta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.gbxPagarMulta);
            this.Controls.Add(this.pnlMultaDetalle);
            this.Controls.Add(this.dgvMultas);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnAtras);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMulta";
            this.Text = "frmMulta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).EndInit();
            this.gbxPagarMulta.ResumeLayout(false);
            this.gbxPagarMulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvMultas;
        private System.Windows.Forms.Panel pnlMultaDetalle;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblIdMulta;
        private System.Windows.Forms.TextBox txtIdMulta;
        private System.Windows.Forms.Button btnAbonar;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.GroupBox gbxPagarMulta;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Button btnExportar;
    }
}