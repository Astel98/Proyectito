namespace Proyectito
{
    partial class UI
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
            this.glControlador = new OpenTK.GLControl();
            this.obj3D = new System.Windows.Forms.ComboBox();
            this.caras = new System.Windows.Forms.ComboBox();
            this.escBar = new System.Windows.Forms.TrackBar();
            this.eX = new System.Windows.Forms.CheckBox();
            this.eY = new System.Windows.Forms.CheckBox();
            this.eZ = new System.Windows.Forms.CheckBox();
            this.rZ = new System.Windows.Forms.CheckBox();
            this.rY = new System.Windows.Forms.CheckBox();
            this.rX = new System.Windows.Forms.CheckBox();
            this.rotBar = new System.Windows.Forms.TrackBar();
            this.tZ = new System.Windows.Forms.CheckBox();
            this.tY = new System.Windows.Forms.CheckBox();
            this.tX = new System.Windows.Forms.CheckBox();
            this.traBar = new System.Windows.Forms.TrackBar();
            this.bTransf = new System.Windows.Forms.Button();
            this.bAnim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.escBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traBar)).BeginInit();
            this.SuspendLayout();
            // 
            // glControlador
            // 
            this.glControlador.BackColor = System.Drawing.Color.Black;
            this.glControlador.Location = new System.Drawing.Point(13, 13);
            this.glControlador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControlador.Name = "glControlador";
            this.glControlador.Size = new System.Drawing.Size(424, 424);
            this.glControlador.TabIndex = 0;
            this.glControlador.VSync = false;
            this.glControlador.Load += new System.EventHandler(this.glLoad);
            this.glControlador.Paint += new System.Windows.Forms.PaintEventHandler(this.glDraw);
            this.glControlador.Resize += new System.EventHandler(this.glResize);
            // 
            // obj3D
            // 
            this.obj3D.FormattingEnabled = true;
            this.obj3D.Location = new System.Drawing.Point(465, 13);
            this.obj3D.Name = "obj3D";
            this.obj3D.Size = new System.Drawing.Size(344, 24);
            this.obj3D.TabIndex = 1;
            this.obj3D.SelectedIndexChanged += new System.EventHandler(this.obj3DCambio);
            // 
            // caras
            // 
            this.caras.FormattingEnabled = true;
            this.caras.Location = new System.Drawing.Point(465, 71);
            this.caras.Name = "caras";
            this.caras.Size = new System.Drawing.Size(344, 24);
            this.caras.TabIndex = 2;
            // 
            // escBar
            // 
            this.escBar.Location = new System.Drawing.Point(444, 154);
            this.escBar.Name = "escBar";
            this.escBar.Size = new System.Drawing.Size(254, 56);
            this.escBar.TabIndex = 3;
            this.escBar.Value = 5;
            this.escBar.Scroll += new System.EventHandler(this.EscalarStart);
            // 
            // eX
            // 
            this.eX.AutoSize = true;
            this.eX.Location = new System.Drawing.Point(704, 154);
            this.eX.Name = "eX";
            this.eX.Size = new System.Drawing.Size(37, 20);
            this.eX.TabIndex = 4;
            this.eX.Text = "X";
            this.eX.UseVisualStyleBackColor = true;
            // 
            // eY
            // 
            this.eY.AutoSize = true;
            this.eY.Location = new System.Drawing.Point(747, 154);
            this.eY.Name = "eY";
            this.eY.Size = new System.Drawing.Size(38, 20);
            this.eY.TabIndex = 5;
            this.eY.Text = "Y";
            this.eY.UseVisualStyleBackColor = true;
            // 
            // eZ
            // 
            this.eZ.AutoSize = true;
            this.eZ.Location = new System.Drawing.Point(791, 154);
            this.eZ.Name = "eZ";
            this.eZ.Size = new System.Drawing.Size(37, 20);
            this.eZ.TabIndex = 6;
            this.eZ.Text = "Z";
            this.eZ.UseVisualStyleBackColor = true;
            // 
            // rZ
            // 
            this.rZ.AutoSize = true;
            this.rZ.Location = new System.Drawing.Point(791, 216);
            this.rZ.Name = "rZ";
            this.rZ.Size = new System.Drawing.Size(37, 20);
            this.rZ.TabIndex = 10;
            this.rZ.Text = "Z";
            this.rZ.UseVisualStyleBackColor = true;
            // 
            // rY
            // 
            this.rY.AutoSize = true;
            this.rY.Location = new System.Drawing.Point(747, 216);
            this.rY.Name = "rY";
            this.rY.Size = new System.Drawing.Size(38, 20);
            this.rY.TabIndex = 9;
            this.rY.Text = "Y";
            this.rY.UseVisualStyleBackColor = true;
            // 
            // rX
            // 
            this.rX.AutoSize = true;
            this.rX.Location = new System.Drawing.Point(704, 216);
            this.rX.Name = "rX";
            this.rX.Size = new System.Drawing.Size(37, 20);
            this.rX.TabIndex = 8;
            this.rX.Text = "X";
            this.rX.UseVisualStyleBackColor = true;
            // 
            // rotBar
            // 
            this.rotBar.Location = new System.Drawing.Point(444, 216);
            this.rotBar.Name = "rotBar";
            this.rotBar.Size = new System.Drawing.Size(254, 56);
            this.rotBar.TabIndex = 7;
            this.rotBar.Value = 5;
            this.rotBar.Scroll += new System.EventHandler(this.RotarStart);
            // 
            // tZ
            // 
            this.tZ.AutoSize = true;
            this.tZ.Location = new System.Drawing.Point(791, 278);
            this.tZ.Name = "tZ";
            this.tZ.Size = new System.Drawing.Size(37, 20);
            this.tZ.TabIndex = 14;
            this.tZ.Text = "Z";
            this.tZ.UseVisualStyleBackColor = true;
            // 
            // tY
            // 
            this.tY.AutoSize = true;
            this.tY.Location = new System.Drawing.Point(747, 278);
            this.tY.Name = "tY";
            this.tY.Size = new System.Drawing.Size(38, 20);
            this.tY.TabIndex = 13;
            this.tY.Text = "Y";
            this.tY.UseVisualStyleBackColor = true;
            // 
            // tX
            // 
            this.tX.AutoSize = true;
            this.tX.Location = new System.Drawing.Point(704, 278);
            this.tX.Name = "tX";
            this.tX.Size = new System.Drawing.Size(37, 20);
            this.tX.TabIndex = 12;
            this.tX.Text = "X";
            this.tX.UseVisualStyleBackColor = true;
            // 
            // traBar
            // 
            this.traBar.Location = new System.Drawing.Point(444, 278);
            this.traBar.Name = "traBar";
            this.traBar.Size = new System.Drawing.Size(254, 56);
            this.traBar.TabIndex = 11;
            this.traBar.Value = 5;
            this.traBar.Scroll += new System.EventHandler(this.TrasladarStart);
            // 
            // bTransf
            // 
            this.bTransf.Location = new System.Drawing.Point(474, 394);
            this.bTransf.Name = "bTransf";
            this.bTransf.Size = new System.Drawing.Size(123, 43);
            this.bTransf.TabIndex = 15;
            this.bTransf.Text = "Normal";
            this.bTransf.UseVisualStyleBackColor = true;
            this.bTransf.Click += new System.EventHandler(this.bTransf_Click);
            // 
            // bAnim
            // 
            this.bAnim.Location = new System.Drawing.Point(686, 394);
            this.bAnim.Name = "bAnim";
            this.bAnim.Size = new System.Drawing.Size(123, 43);
            this.bAnim.TabIndex = 16;
            this.bAnim.Text = "Animacion";
            this.bAnim.UseVisualStyleBackColor = true;
            this.bAnim.Click += new System.EventHandler(this.bAnim_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(842, 450);
            this.Controls.Add(this.bAnim);
            this.Controls.Add(this.bTransf);
            this.Controls.Add(this.tZ);
            this.Controls.Add(this.tY);
            this.Controls.Add(this.tX);
            this.Controls.Add(this.traBar);
            this.Controls.Add(this.rZ);
            this.Controls.Add(this.rY);
            this.Controls.Add(this.rX);
            this.Controls.Add(this.rotBar);
            this.Controls.Add(this.eZ);
            this.Controls.Add(this.eY);
            this.Controls.Add(this.eX);
            this.Controls.Add(this.escBar);
            this.Controls.Add(this.caras);
            this.Controls.Add(this.obj3D);
            this.Controls.Add(this.glControlador);
            this.Name = "UI";
            this.Text = "Grafica Cosita";
            ((System.ComponentModel.ISupportInitialize)(this.escBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControlador;
        private System.Windows.Forms.ComboBox obj3D;
        private System.Windows.Forms.ComboBox caras;
        private System.Windows.Forms.TrackBar escBar;
        private System.Windows.Forms.CheckBox eX;
        private System.Windows.Forms.CheckBox eY;
        private System.Windows.Forms.CheckBox eZ;
        private System.Windows.Forms.CheckBox rZ;
        private System.Windows.Forms.CheckBox rY;
        private System.Windows.Forms.CheckBox rX;
        private System.Windows.Forms.TrackBar rotBar;
        private System.Windows.Forms.CheckBox tZ;
        private System.Windows.Forms.CheckBox tY;
        private System.Windows.Forms.CheckBox tX;
        private System.Windows.Forms.TrackBar traBar;
        private System.Windows.Forms.Button bTransf;
        private System.Windows.Forms.Button bAnim;
    }
}