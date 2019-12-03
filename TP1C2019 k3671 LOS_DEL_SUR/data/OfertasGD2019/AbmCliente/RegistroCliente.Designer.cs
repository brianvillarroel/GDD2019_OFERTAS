namespace OfertasGD2019.AbmCliente
{
    partial class RegistroCliente
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.dateNac = new System.Windows.Forms.DateTimePicker();
            this.txtCP = new MiLibreria.NumericTextBox();
            this.txtDepto = new MiLibreria.ErrorTxtBox();
            this.numPiso = new MiLibreria.NumericTextBox();
            this.txtDir = new MiLibreria.ErrorTxtBox();
            this.txtCiudad = new MiLibreria.ErrorTxtBox();
            this.numTel = new MiLibreria.NumericTextBox();
            this.txtMail = new MiLibreria.TxtBoxMail();
            this.numDni = new MiLibreria.NumericTextBox();
            this.txtApellido = new MiLibreria.ErrorTxtBox();
            this.txtName = new MiLibreria.ErrorTxtBox();
            this.txtConfPass = new MiLibreria.ErrorTxtBox();
            this.txtPass = new MiLibreria.ErrorTxtBox();
            this.txtUser = new MiLibreria.ErrorTxtBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre*";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(215, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "DNI*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(209, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Telefono*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(179, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Codigo Postal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(116, 449);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Fecha  de Nacimiento*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(223, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ciudad*";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(205, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Direccion*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(248, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Piso";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(395, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Depto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(179, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 23;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Limpiar);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(441, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 34);
            this.button2.TabIndex = 24;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Guardar);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(109, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Confrirmar Contraseña*";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(190, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "Contraseña*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(217, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 30;
            this.label15.Text = "Usuario*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Stencil Std", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(754, 70);
            this.label16.TabIndex = 59;
            this.label16.Text = "Registro Clientes";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateNac
            // 
            this.dateNac.CustomFormat = "yyyy-MM-dd";
            this.dateNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNac.Location = new System.Drawing.Point(309, 449);
            this.dateNac.MaxDate = new System.DateTime(2001, 12, 31, 0, 0, 0, 0);
            this.dateNac.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateNac.Name = "dateNac";
            this.dateNac.Size = new System.Drawing.Size(241, 23);
            this.dateNac.TabIndex = 75;
            this.dateNac.Value = new System.DateTime(2001, 12, 31, 0, 0, 0, 0);
            // 
            // txtCP
            // 
            this.txtCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCP.Location = new System.Drawing.Point(309, 420);
            this.txtCP.MaxLength = 5;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(239, 23);
            this.txtCP.TabIndex = 74;
            this.txtCP.Validar = false;
            // 
            // txtDepto
            // 
            this.txtDepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepto.Location = new System.Drawing.Point(452, 389);
            this.txtDepto.MaxLength = 4;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(97, 23);
            this.txtDepto.TabIndex = 71;
            this.txtDepto.Validar = false;
            // 
            // numPiso
            // 
            this.numPiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPiso.Location = new System.Drawing.Point(308, 389);
            this.numPiso.MaxLength = 3;
            this.numPiso.Name = "numPiso";
            this.numPiso.Size = new System.Drawing.Size(81, 23);
            this.numPiso.TabIndex = 70;
            this.numPiso.Validar = false;
            // 
            // txtDir
            // 
            this.txtDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDir.Location = new System.Drawing.Point(309, 360);
            this.txtDir.MaxLength = 50;
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(240, 23);
            this.txtDir.TabIndex = 69;
            this.txtDir.Validar = true;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(309, 330);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(240, 23);
            this.txtCiudad.TabIndex = 68;
            this.txtCiudad.Validar = true;
            // 
            // numTel
            // 
            this.numTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTel.Location = new System.Drawing.Point(309, 300);
            this.numTel.MaxLength = 12;
            this.numTel.Name = "numTel";
            this.numTel.Size = new System.Drawing.Size(240, 23);
            this.numTel.TabIndex = 67;
            this.numTel.Validar = true;
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(309, 270);
            this.txtMail.MaxLength = 50;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(240, 23);
            this.txtMail.TabIndex = 66;
            // 
            // numDni
            // 
            this.numDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDni.Location = new System.Drawing.Point(309, 240);
            this.numDni.MaxLength = 10;
            this.numDni.Name = "numDni";
            this.numDni.Size = new System.Drawing.Size(240, 23);
            this.numDni.TabIndex = 65;
            this.numDni.Validar = true;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(309, 210);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(240, 23);
            this.txtApellido.TabIndex = 64;
            this.txtApellido.Validar = true;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(309, 180);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 23);
            this.txtName.TabIndex = 63;
            this.txtName.Validar = true;
            // 
            // txtConfPass
            // 
            this.txtConfPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfPass.Location = new System.Drawing.Point(309, 150);
            this.txtConfPass.MaxLength = 25;
            this.txtConfPass.Name = "txtConfPass";
            this.txtConfPass.PasswordChar = '*';
            this.txtConfPass.Size = new System.Drawing.Size(240, 23);
            this.txtConfPass.TabIndex = 62;
            this.txtConfPass.Validar = true;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(309, 119);
            this.txtPass.MaxLength = 25;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(240, 23);
            this.txtPass.TabIndex = 61;
            this.txtPass.Validar = true;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(309, 86);
            this.txtUser.MaxLength = 25;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(240, 23);
            this.txtUser.TabIndex = 60;
            this.txtUser.Validar = true;
            // 
            // RegistroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 614);
            this.Controls.Add(this.dateNac);
            this.Controls.Add(this.txtCP);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.numPiso);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.numTel);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.numDni);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtConfPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "RegistroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label16;
        private MiLibreria.ErrorTxtBox txtDepto;
        private MiLibreria.NumericTextBox numPiso;
        private MiLibreria.ErrorTxtBox txtDir;
        private MiLibreria.ErrorTxtBox txtCiudad;
        private MiLibreria.NumericTextBox numTel;
        private MiLibreria.TxtBoxMail txtMail;
        private MiLibreria.NumericTextBox numDni;
        private MiLibreria.ErrorTxtBox txtApellido;
        private MiLibreria.ErrorTxtBox txtName;
        private MiLibreria.ErrorTxtBox txtConfPass;
        private MiLibreria.ErrorTxtBox txtPass;
        private MiLibreria.ErrorTxtBox txtUser;
        private System.Windows.Forms.DateTimePicker dateNac;
        private MiLibreria.NumericTextBox txtCP;
    }
}