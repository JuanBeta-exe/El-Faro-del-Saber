namespace Inicio
{
    partial class frmRegistro
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
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btn_Registrar = new System.Windows.Forms.Button();
            this.Lbl_Registro = new System.Windows.Forms.Label();
            this.plRegistroCampos = new System.Windows.Forms.Panel();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDirrecion = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDocumentoIdentidad = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.plRegistroCampos.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(70, 26);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(200, 20);
            this.txt_Nombre.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(70, 211);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // btn_Registrar
            // 
            this.btn_Registrar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Registrar.Location = new System.Drawing.Point(117, 369);
            this.btn_Registrar.Name = "btn_Registrar";
            this.btn_Registrar.Size = new System.Drawing.Size(100, 30);
            this.btn_Registrar.TabIndex = 2;
            this.btn_Registrar.Text = "REGISTRAR";
            this.btn_Registrar.UseVisualStyleBackColor = true;
            this.btn_Registrar.Click += new System.EventHandler(this.Btn_Registrar_Click);
            // 
            // Lbl_Registro
            // 
            this.Lbl_Registro.AutoSize = true;
            this.Lbl_Registro.Location = new System.Drawing.Point(151, 9);
            this.Lbl_Registro.Name = "Lbl_Registro";
            this.Lbl_Registro.Size = new System.Drawing.Size(79, 13);
            this.Lbl_Registro.TabIndex = 3;
            this.Lbl_Registro.Text = "REGISTRATE!";
            // 
            // plRegistroCampos
            // 
            this.plRegistroCampos.Controls.Add(this.txtDireccion);
            this.plRegistroCampos.Controls.Add(this.lblDirrecion);
            this.plRegistroCampos.Controls.Add(this.txtCorreo);
            this.plRegistroCampos.Controls.Add(this.lblCorreo);
            this.plRegistroCampos.Controls.Add(this.txtDocumento);
            this.plRegistroCampos.Controls.Add(this.lblDocumentoIdentidad);
            this.plRegistroCampos.Controls.Add(this.lblPassword);
            this.plRegistroCampos.Controls.Add(this.lblTelefono);
            this.plRegistroCampos.Controls.Add(this.lblFullName);
            this.plRegistroCampos.Controls.Add(this.txtPassword);
            this.plRegistroCampos.Controls.Add(this.btn_Registrar);
            this.plRegistroCampos.Controls.Add(this.txt_Nombre);
            this.plRegistroCampos.Controls.Add(this.txtEmail);
            this.plRegistroCampos.Location = new System.Drawing.Point(25, 36);
            this.plRegistroCampos.Name = "plRegistroCampos";
            this.plRegistroCampos.Size = new System.Drawing.Size(334, 413);
            this.plRegistroCampos.TabIndex = 4;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(70, 271);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);
            this.txtDireccion.TabIndex = 12;
            // 
            // lblDirrecion
            // 
            this.lblDirrecion.AutoSize = true;
            this.lblDirrecion.Location = new System.Drawing.Point(147, 255);
            this.lblDirrecion.Name = "lblDirrecion";
            this.lblDirrecion.Size = new System.Drawing.Size(52, 13);
            this.lblDirrecion.TabIndex = 11;
            this.lblDirrecion.Text = "Direccion";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(70, 153);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 20);
            this.txtCorreo.TabIndex = 10;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(123, 137);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(94, 13);
            this.lblCorreo.TabIndex = 9;
            this.lblCorreo.Text = "Correo Electronico";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(70, 86);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtDocumento.TabIndex = 8;
            // 
            // lblDocumentoIdentidad
            // 
            this.lblDocumentoIdentidad.AutoSize = true;
            this.lblDocumentoIdentidad.Location = new System.Drawing.Point(114, 70);
            this.lblDocumentoIdentidad.Name = "lblDocumentoIdentidad";
            this.lblDocumentoIdentidad.Size = new System.Drawing.Size(124, 13);
            this.lblDocumentoIdentidad.TabIndex = 7;
            this.lblDocumentoIdentidad.Text = "Documento de Identidad";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(138, 313);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(147, 195);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(122, 10);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(91, 13);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "Nombre Completo";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 329);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // frmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.plRegistroCampos);
            this.Controls.Add(this.Lbl_Registro);
            this.Name = "frmRegistro";
            this.Text = "Registro";
            this.plRegistroCampos.ResumeLayout(false);
            this.plRegistroCampos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btn_Registrar;
        private System.Windows.Forms.Label Lbl_Registro;
        private System.Windows.Forms.Panel plRegistroCampos;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDocumentoIdentidad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDirrecion;
    }
}