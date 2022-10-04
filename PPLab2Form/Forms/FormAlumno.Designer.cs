namespace PPLab2Form.Forms
{
    partial class FormAlumno
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
            this.lbl_bienvenida = new System.Windows.Forms.Label();
            this.btn_mostrarMaterias = new System.Windows.Forms.Button();
            this.btn_mostrarExamenes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_bienvenida
            // 
            this.lbl_bienvenida.AutoSize = true;
            this.lbl_bienvenida.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_bienvenida.Location = new System.Drawing.Point(54, 19);
            this.lbl_bienvenida.Name = "lbl_bienvenida";
            this.lbl_bienvenida.Size = new System.Drawing.Size(306, 46);
            this.lbl_bienvenida.TabIndex = 0;
            this.lbl_bienvenida.Text = "Bienvenido alumno";
            this.lbl_bienvenida.Click += new System.EventHandler(this.alumno_lbl_inicio_Click);
            // 
            // btn_mostrarMaterias
            // 
            this.btn_mostrarMaterias.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_mostrarMaterias.Location = new System.Drawing.Point(67, 101);
            this.btn_mostrarMaterias.Name = "btn_mostrarMaterias";
            this.btn_mostrarMaterias.Size = new System.Drawing.Size(134, 39);
            this.btn_mostrarMaterias.TabIndex = 1;
            this.btn_mostrarMaterias.Text = "Materias cursadas";
            this.btn_mostrarMaterias.UseVisualStyleBackColor = true;
            // 
            // btn_mostrarExamenes
            // 
            this.btn_mostrarExamenes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_mostrarExamenes.Location = new System.Drawing.Point(67, 157);
            this.btn_mostrarExamenes.Name = "btn_mostrarExamenes";
            this.btn_mostrarExamenes.Size = new System.Drawing.Size(134, 39);
            this.btn_mostrarExamenes.TabIndex = 2;
            this.btn_mostrarExamenes.Text = "Examenes rendidos";
            this.btn_mostrarExamenes.UseVisualStyleBackColor = true;
            // 
            // FormAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_mostrarExamenes);
            this.Controls.Add(this.btn_mostrarMaterias);
            this.Controls.Add(this.lbl_bienvenida);
            this.Name = "FormAlumno";
            this.Text = "FormAlumno";
            this.Load += new System.EventHandler(this.FormAlumno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_bienvenida;
        private Button btn_mostrarMaterias;
        private Button btn_mostrarExamenes;
    }
}