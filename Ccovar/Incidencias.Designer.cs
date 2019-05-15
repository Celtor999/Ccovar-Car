namespace Ccovar
{
    partial class Incidencias
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
            this.dataGridIncidencias = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autos_relacionados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIncidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridIncidencias
            // 
            this.dataGridIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIncidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.marca,
            this.nacionalidad,
            this.autos_relacionados});
            this.dataGridIncidencias.Location = new System.Drawing.Point(12, 229);
            this.dataGridIncidencias.Name = "dataGridIncidencias";
            this.dataGridIncidencias.Size = new System.Drawing.Size(776, 210);
            this.dataGridIncidencias.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            // 
            // nacionalidad
            // 
            this.nacionalidad.HeaderText = "Nacionalidad";
            this.nacionalidad.Name = "nacionalidad";
            this.nacionalidad.ReadOnly = true;
            // 
            // autos_relacionados
            // 
            this.autos_relacionados.HeaderText = "Autos Relacionados";
            this.autos_relacionados.Name = "autos_relacionados";
            this.autos_relacionados.ReadOnly = true;
            // 
            // Incidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridIncidencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Incidencias";
            this.Text = "Incidencias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIncidencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridIncidencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn autos_relacionados;
    }
}