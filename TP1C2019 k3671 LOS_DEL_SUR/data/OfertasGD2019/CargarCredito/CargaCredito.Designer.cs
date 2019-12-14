namespace OfertasGD2019.CargarCredito
{
    partial class CargaCredito
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
            this.usuario = new System.Windows.Forms.Label();
            this.Monto = new System.Windows.Forms.Label();
            this.TipoPago = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboPago = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateVenc = new MiLibreria.DateTxtBox();
            this.numTarjeta = new MiLibreria.NumericTextBox();
            this.txtNombTarj = new MiLibreria.ErrorTxtBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numId = new MiLibreria.NumericTextBox();
            this.txtUsuario = new MiLibreria.ErrorTxtBox();
            this.numMonto = new MiLibreria.NumericTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(25, 44);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(64, 17);
            this.usuario.TabIndex = 1;
            this.usuario.Text = "Usuario";
            this.usuario.Click += new System.EventHandler(this.label2_Click);
            // 
            // Monto
            // 
            this.Monto.AutoSize = true;
            this.Monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Monto.Location = new System.Drawing.Point(25, 87);
            this.Monto.Name = "Monto";
            this.Monto.Size = new System.Drawing.Size(52, 17);
            this.Monto.TabIndex = 2;
            this.Monto.Text = "Monto";
            // 
            // TipoPago
            // 
            this.TipoPago.AutoSize = true;
            this.TipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoPago.Location = new System.Drawing.Point(25, 43);
            this.TipoPago.Name = "TipoPago";
            this.TipoPago.Size = new System.Drawing.Size(105, 17);
            this.TipoPago.TabIndex = 3;
            this.TipoPago.Text = "Tipo de Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Numero";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nombre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Vencimiento";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // comboPago
            // 
            this.comboPago.AllowDrop = true;
            this.comboPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPago.FormattingEnabled = true;
            this.comboPago.Items.AddRange(new object[] {
            "Debito",
            "Credito"});
            this.comboPago.Location = new System.Drawing.Point(136, 40);
            this.comboPago.Name = "comboPago";
            this.comboPago.Size = new System.Drawing.Size(184, 24);
            this.comboPago.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateVenc);
            this.groupBox1.Controls.Add(this.TipoPago);
            this.groupBox1.Controls.Add(this.comboPago);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numTarjeta);
            this.groupBox1.Controls.Add(this.txtNombTarj);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(74, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 207);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Tarjeta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dateVenc
            // 
            this.dateVenc.Location = new System.Drawing.Point(136, 156);
            this.dateVenc.MaxLength = 7;
            this.dateVenc.Name = "dateVenc";
            this.dateVenc.Size = new System.Drawing.Size(184, 26);
            this.dateVenc.TabIndex = 13;
            this.dateVenc.Validar = false;
            // 
            // numTarjeta
            // 
            this.numTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTarjeta.Location = new System.Drawing.Point(136, 77);
            this.numTarjeta.MaxLength = 16;
            this.numTarjeta.Name = "numTarjeta";
            this.numTarjeta.Size = new System.Drawing.Size(184, 23);
            this.numTarjeta.TabIndex = 8;
            this.numTarjeta.Validar = true;
            // 
            // txtNombTarj
            // 
            this.txtNombTarj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombTarj.Location = new System.Drawing.Point(136, 120);
            this.txtNombTarj.MaxLength = 50;
            this.txtNombTarj.Name = "txtNombTarj";
            this.txtNombTarj.Size = new System.Drawing.Size(184, 23);
            this.txtNombTarj.TabIndex = 7;
            this.txtNombTarj.Validar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numId);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.Monto);
            this.groupBox2.Controls.Add(this.numMonto);
            this.groupBox2.Controls.Add(this.usuario);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(74, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 129);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(388, 41);
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(126, 26);
            this.numId.TabIndex = 12;
            this.numId.Validar = false;
            this.numId.Visible = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(136, 41);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(184, 23);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.Validar = false;
            this.txtUsuario.TextChanged += new System.EventHandler(this.errorTxtBox1_TextChanged);
            // 
            // numMonto
            // 
            this.numMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonto.Location = new System.Drawing.Point(136, 84);
            this.numMonto.MaxLength = 8;
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(184, 23);
            this.numMonto.TabIndex = 10;
            this.numMonto.Validar = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(319, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 36;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(588, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 37;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(74, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 40);
            this.button3.TabIndex = 38;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Stencil Std", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(796, 56);
            this.label1.TabIndex = 62;
            this.label1.Text = "Cargar Credito";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CargaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CargaCredito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label Monto;
        private System.Windows.Forms.Label TipoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MiLibreria.ErrorTxtBox txtNombTarj;
        private MiLibreria.NumericTextBox numTarjeta;
        private System.Windows.Forms.ComboBox comboPago;
        private MiLibreria.NumericTextBox numMonto;
        private MiLibreria.ErrorTxtBox txtUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MiLibreria.NumericTextBox numId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MiLibreria.DateTxtBox dateVenc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}