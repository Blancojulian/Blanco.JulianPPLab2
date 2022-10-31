namespace PPLab2Form.Forms
{
    partial class FrmElegirProfesor
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
            this.cbx_profesores = new System.Windows.Forms.ComboBox();
            this.dgvw_profesores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvw_profesores)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_profesores
            // 
            this.cbx_profesores.FormattingEnabled = true;
            this.cbx_profesores.Location = new System.Drawing.Point(141, 82);
            this.cbx_profesores.Name = "cbx_profesores";
            this.cbx_profesores.Size = new System.Drawing.Size(121, 23);
            this.cbx_profesores.TabIndex = 0;
            // 
            // dgvw_profesores
            // 
            this.dgvw_profesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvw_profesores.Location = new System.Drawing.Point(77, 175);
            this.dgvw_profesores.Name = "dgvw_profesores";
            this.dgvw_profesores.RowTemplate.Height = 25;
            this.dgvw_profesores.Size = new System.Drawing.Size(564, 150);
            this.dgvw_profesores.TabIndex = 1;
            this.dgvw_profesores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvw_profesores_CellContentClick);
            // 
            // FrmElegirProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvw_profesores);
            this.Controls.Add(this.cbx_profesores);
            this.Name = "FrmElegirProfesor";
            this.Text = "Elegir profesor";
            this.Load += new System.EventHandler(this.FrmElegirProfesor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvw_profesores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbx_profesores;
        private DataGridView dgvw_profesores;
    }
}