﻿namespace Gestion_Usuarioo
{
    partial class FrmUsuario
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAgregarUsuario = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.cbxTipoUsuario = new System.Windows.Forms.ComboBox();
            this.pnlAgregarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAgregarUsuario
            // 
            this.pnlAgregarUsuario.Controls.Add(this.cbxTipoUsuario);
            this.pnlAgregarUsuario.Controls.Add(this.btnAgregar);
            this.pnlAgregarUsuario.Controls.Add(this.txtPassword);
            this.pnlAgregarUsuario.Controls.Add(this.txtUsername);
            this.pnlAgregarUsuario.Controls.Add(this.txtDireccion);
            this.pnlAgregarUsuario.Controls.Add(this.txtTelefono);
            this.pnlAgregarUsuario.Controls.Add(this.txtCorreo);
            this.pnlAgregarUsuario.Controls.Add(this.txtDocumento);
            this.pnlAgregarUsuario.Controls.Add(this.txtNombre);
            this.pnlAgregarUsuario.Controls.Add(this.lblPassword);
            this.pnlAgregarUsuario.Controls.Add(this.lblUsername);
            this.pnlAgregarUsuario.Controls.Add(this.lblTipoUsuario);
            this.pnlAgregarUsuario.Controls.Add(this.lblDireccion);
            this.pnlAgregarUsuario.Controls.Add(this.lblTelefono);
            this.pnlAgregarUsuario.Controls.Add(this.lblcorreo);
            this.pnlAgregarUsuario.Controls.Add(this.lblDocumento);
            this.pnlAgregarUsuario.Controls.Add(this.lblNombre);
            this.pnlAgregarUsuario.Location = new System.Drawing.Point(13, 333);
            this.pnlAgregarUsuario.Name = "pnlAgregarUsuario";
            this.pnlAgregarUsuario.Size = new System.Drawing.Size(983, 161);
            this.pnlAgregarUsuario.TabIndex = 0;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(902, 251);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(94, 32);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(809, 66);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(155, 32);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(479, 112);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(134, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(479, 73);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(134, 20);
            this.txtUsername.TabIndex = 16;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(322, 112);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(134, 20);
            this.txtDireccion.TabIndex = 14;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(322, 73);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(134, 20);
            this.txtTelefono.TabIndex = 13;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(322, 32);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(134, 20);
            this.txtCorreo.TabIndex = 12;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(157, 112);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(134, 20);
            this.txtDocumento.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(145, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(134, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(476, 94);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 15);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(476, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 15);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Username";
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoUsuario.Location = new System.Drawing.Point(476, 14);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(87, 15);
            this.lblTipoUsuario.TabIndex = 6;
            this.lblTipoUsuario.Text = "Tipo usuario";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.Location = new System.Drawing.Point(319, 94);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(68, 15);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(319, 55);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(63, 15);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblcorreo
            // 
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblcorreo.Location = new System.Drawing.Point(319, 14);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(50, 15);
            this.lblcorreo.TabIndex = 3;
            this.lblcorreo.Text = "Correo";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDocumento.Location = new System.Drawing.Point(154, 94);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(144, 15);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "Documento identidad";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(142, 14);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(123, 15);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(13, 72);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(883, 255);
            this.dgvUsuarios.TabIndex = 1;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.Location = new System.Drawing.Point(782, 42);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(114, 24);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(902, 172);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(94, 30);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(13, 46);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(763, 20);
            this.txtConsulta.TabIndex = 4;
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAtras.Location = new System.Drawing.Point(1, 0);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(104, 24);
            this.btnAtras.TabIndex = 20;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // cbxTipoUsuario
            // 
            this.cbxTipoUsuario.FormattingEnabled = true;
            this.cbxTipoUsuario.Items.AddRange(new object[] {
            "SELECCIONAR",
            "Administrador",
            "Trabajador",
            "Cliente"});
            this.cbxTipoUsuario.Location = new System.Drawing.Point(479, 30);
            this.cbxTipoUsuario.Name = "cbxTipoUsuario";
            this.cbxTipoUsuario.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoUsuario.TabIndex = 19;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 506);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtConsulta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.pnlAgregarUsuario);
            this.Name = "FrmUsuario";
            this.Text = "Gestion_Usuario";
            this.TopMost = true;
            this.pnlAgregarUsuario.ResumeLayout(false);
            this.pnlAgregarUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAgregarUsuario;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.ComboBox cbxTipoUsuario;
    }
}

