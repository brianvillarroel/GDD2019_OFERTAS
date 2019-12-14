namespace OfertasGD2019.AbmProveedor
{
    partial class ListadoProveedor
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
            this.txtRSocial = new System.Windows.Forms.Label();
            this.Mail = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.Label();
            this.txtRSoc = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.numCuit = new System.Windows.Forms.TextBox();
            this.dataGridViewProv = new System.Windows.Forms.DataGridView();
            this.txtMail = new MiLibreria.TxtBoxMail();
            this.CUIT = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRSocial
            // 
            this.txtRSocial.AutoSize = true;
            this.txtRSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRSocial.Location = new System.Drawing.Point(12, 72);
            this.txtRSocial.Name = "txtRSocial";
            this.txtRSocial.Size = new System.Drawing.Size(103, 17);
            this.txtRSocial.TabIndex = 0;
            this.txtRSocial.Text = "Razon Social";
            this.txtRSocial.Click += new System.EventHandler(this.Nombre_Click);
            // 
            // Mail
            // 
            this.Mail.AutoSize = true;
            this.Mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mail.Location = new System.Drawing.Point(663, 72);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(37, 17);
            this.Mail.TabIndex = 2;
            this.Mail.Text = "Mail";
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(0, 0);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(100, 23);
            this.DNI.TabIndex = 38;
            // 
            // txtRSoc
            // 
            this.txtRSoc.Location = new System.Drawing.Point(121, 72);
            this.txtRSoc.Name = "txtRSoc";
            this.txtRSoc.Size = new System.Drawing.Size(202, 20);
            this.txtRSoc.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(1092, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 29);
            this.btnBuscar.TabIndex = 35;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(1213, 71);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(93, 29);
            this.btnLimpiar.TabIndex = 36;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // numCuit
            // 
            this.numCuit.Location = new System.Drawing.Point(418, 71);
            this.numCuit.Name = "numCuit";
            this.numCuit.Size = new System.Drawing.Size(202, 20);
            this.numCuit.TabIndex = 37;
            // 
            // dataGridViewProv
            // 
            this.dataGridViewProv.AllowUserToAddRows = false;
            this.dataGridViewProv.AllowUserToDeleteRows = false;
            this.dataGridViewProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProv.Location = new System.Drawing.Point(12, 110);
            this.dataGridViewProv.MultiSelect = false;
            this.dataGridViewProv.Name = "dataGridViewProv";
            this.dataGridViewProv.ReadOnly = true;
            this.dataGridViewProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProv.Size = new System.Drawing.Size(1294, 463);
            this.dataGridViewProv.TabIndex = 9;
            this.dataGridViewProv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(719, 72);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(203, 20);
            this.txtMail.TabIndex = 7;
            // 
            // CUIT
            // 
            this.CUIT.AutoSize = true;
            this.CUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CUIT.Location = new System.Drawing.Point(351, 72);
            this.CUIT.Name = "CUIT";
            this.CUIT.Size = new System.Drawing.Size(43, 17);
            this.CUIT.TabIndex = 39;
            this.CUIT.Text = "CUIT";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.AutoSize = true;
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(475, 303);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(369, 26);
            this.txtBusqueda.TabIndex = 40;
            this.txtBusqueda.Text = "No se han encontrado resultados.";
            this.txtBusqueda.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(12, 594);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 40);
            this.btnVolver.TabIndex = 41;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Stencil Std", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1318, 56);
            this.label16.TabIndex = 61;
            this.label16.Text = "Listado proveedores";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListadoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 687);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.CUIT);
            this.Controls.Add(this.dataGridViewProv);
            this.Controls.Add(this.numCuit);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtRSoc);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.Mail);
            this.Controls.Add(this.txtRSocial);
            this.Name = "ListadoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Proveedores";
            this.Load += new System.EventHandler(this.ListadoProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtRSocial;
        private System.Windows.Forms.Label Mail;
        private System.Windows.Forms.Label DNI;
        public System.Windows.Forms.TextBox txtRSoc;
        public MiLibreria.TxtBoxMail txtMail;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.TextBox numCuit;
        private System.Windows.Forms.DataGridView dataGridViewProv;
        private System.Windows.Forms.Label CUIT;
        private System.Windows.Forms.Label txtBusqueda;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label16;
    }
}