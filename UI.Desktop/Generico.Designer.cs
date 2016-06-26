namespace UI.Desktop
{
    partial class Generico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generico));
            this.tcGenerico = new System.Windows.Forms.ToolStripContainer();
            this.tlGenerico = new System.Windows.Forms.TableLayoutPanel();
            this.dgvGenerico = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcGenerico.ContentPanel.SuspendLayout();
            this.tcGenerico.TopToolStripPanel.SuspendLayout();
            this.tcGenerico.SuspendLayout();
            this.tlGenerico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerico)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcGenerico
            // 
            // 
            // tcGenerico.ContentPanel
            // 
            this.tcGenerico.ContentPanel.Controls.Add(this.tlGenerico);
            this.tcGenerico.ContentPanel.Size = new System.Drawing.Size(284, 236);
            this.tcGenerico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcGenerico.Location = new System.Drawing.Point(0, 0);
            this.tcGenerico.Name = "tcGenerico";
            this.tcGenerico.Size = new System.Drawing.Size(284, 261);
            this.tcGenerico.TabIndex = 0;
            this.tcGenerico.Text = "toolStripContainer1";
            // 
            // tcGenerico.TopToolStripPanel
            // 
            this.tcGenerico.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlGenerico
            // 
            this.tlGenerico.ColumnCount = 2;
            this.tlGenerico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlGenerico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlGenerico.Controls.Add(this.dgvGenerico, 0, 0);
            this.tlGenerico.Controls.Add(this.btnActualizar, 0, 1);
            this.tlGenerico.Controls.Add(this.btnSalir, 1, 1);
            this.tlGenerico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlGenerico.Location = new System.Drawing.Point(0, 0);
            this.tlGenerico.Name = "tlGenerico";
            this.tlGenerico.RowCount = 2;
            this.tlGenerico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlGenerico.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlGenerico.Size = new System.Drawing.Size(284, 236);
            this.tlGenerico.TabIndex = 0;
            // 
            // dgvGenerico
            // 
            this.dgvGenerico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlGenerico.SetColumnSpan(this.dgvGenerico, 2);
            this.dgvGenerico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGenerico.Location = new System.Drawing.Point(3, 3);
            this.dgvGenerico.Name = "dgvGenerico";
            this.dgvGenerico.Size = new System.Drawing.Size(278, 201);
            this.dgvGenerico.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.Location = new System.Drawing.Point(125, 210);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(206, 210);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNuevo,
            this.tsEditar,
            this.tsEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(112, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsNuevo
            // 
            this.tsNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevo.Image")));
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsNuevo.Text = "Nuevo";
            // 
            // tsEditar
            // 
            this.tsEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsEditar.Image")));
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(23, 22);
            this.tsEditar.Text = "Editar";
            // 
            // tsEliminar
            // 
            this.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsEliminar.Text = "Eliminar";
            // 
            // Generico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tcGenerico);
            this.Name = "Generico";
            this.Text = "Generico";
            this.tcGenerico.ContentPanel.ResumeLayout(false);
            this.tcGenerico.TopToolStripPanel.ResumeLayout(false);
            this.tcGenerico.TopToolStripPanel.PerformLayout();
            this.tcGenerico.ResumeLayout(false);
            this.tcGenerico.PerformLayout();
            this.tlGenerico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerico)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcGenerico;
        private System.Windows.Forms.TableLayoutPanel tlGenerico;
        private System.Windows.Forms.DataGridView dgvGenerico;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNuevo;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private System.Windows.Forms.ToolStripButton tsEliminar;
    }
}