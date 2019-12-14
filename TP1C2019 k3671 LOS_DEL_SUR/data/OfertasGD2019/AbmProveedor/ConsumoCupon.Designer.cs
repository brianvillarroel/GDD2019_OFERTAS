namespace OfertasGD2019.Abm_Proveedor
{
    partial class ConsumoCupon
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGVCupones = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCupones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de cupones disponibles para entregar";
            // 
            // dataGVCupones
            // 
            this.dataGVCupones.AllowUserToAddRows = false;
            this.dataGVCupones.AllowUserToDeleteRows = false;
            this.dataGVCupones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGVCupones.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGVCupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVCupones.Location = new System.Drawing.Point(49, 131);
            this.dataGVCupones.MultiSelect = false;
            this.dataGVCupones.Name = "dataGVCupones";
            this.dataGVCupones.ReadOnly = true;
            this.dataGVCupones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVCupones.ShowEditingIcon = false;
            this.dataGVCupones.Size = new System.Drawing.Size(770, 374);
            this.dataGVCupones.TabIndex = 2;
            this.dataGVCupones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVCupones_CellClick);
            // 
            // btnVolver
            // 
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(49, 533);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 40);
            this.btnVolver.TabIndex = 38;
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
            this.label16.Size = new System.Drawing.Size(871, 70);
            this.label16.TabIndex = 60;
            this.label16.Text = "Consumo Cupon";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.AutoSize = true;
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(251, 282);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(369, 26);
            this.txtBusqueda.TabIndex = 61;
            this.txtBusqueda.Text = "No se han encontrado resultados.";
            this.txtBusqueda.Visible = false;
            // 
            // ConsumoCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 591);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGVCupones);
            this.Controls.Add(this.label1);
            this.Name = "ConsumoCupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsumoCupon";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCupones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGVCupones;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label txtBusqueda;
    }
}