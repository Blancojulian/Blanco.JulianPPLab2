namespace PPLab2Form.Forms
{
    partial class FrmEstadoAlumno
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
            this.lbl_datos = new System.Windows.Forms.Label();
            this.cbx_estado = new System.Windows.Forms.ComboBox();
            this.btn_confimar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_datos
            // 
            this.lbl_datos.AutoSize = true;
            this.lbl_datos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_datos.Location = new System.Drawing.Point(36, 42);
            this.lbl_datos.Name = "lbl_datos";
            this.lbl_datos.Size = new System.Drawing.Size(45, 19);
            this.lbl_datos.TabIndex = 0;
            this.lbl_datos.Text = "label1";
            // 
            // cbx_estado
            // 
            this.cbx_estado.FormattingEnabled = true;
            this.cbx_estado.Location = new System.Drawing.Point(274, 42);
            this.cbx_estado.Name = "cbx_estado";
            this.cbx_estado.Size = new System.Drawing.Size(121, 23);
            this.cbx_estado.TabIndex = 1;
            // 
            // btn_confimar
            // 
            this.btn_confimar.Location = new System.Drawing.Point(54, 315);
            this.btn_confimar.Name = "btn_confimar";
            this.btn_confimar.Size = new System.Drawing.Size(99, 30);
            this.btn_confimar.TabIndex = 2;
            this.btn_confimar.Text = "Confirmar";
            this.btn_confimar.UseVisualStyleBackColor = true;
            this.btn_confimar.Click += new System.EventHandler(this.btn_confimar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(274, 315);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(99, 30);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // FrmEstadoAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_confimar);
            this.Controls.Add(this.cbx_estado);
            this.Controls.Add(this.lbl_datos);
            this.Name = "FrmEstadoAlumno";
            this.Text = "Cambiar estado de alumno";
            this.Load += new System.EventHandler(this.FrmEstadoAlumno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_datos;
        private ComboBox cbx_estado;
        private Button btn_confimar;
        private Button btn_cancelar;
    }
}