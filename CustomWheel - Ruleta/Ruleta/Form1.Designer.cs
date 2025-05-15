namespace Ruleta
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.pbRuleta = new Ruleta.Controles.CustomWheel();
            this.btnSpin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRuleta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(137, 456);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(404, 25);
            this.lblResult.TabIndex = 7;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbRuleta
            // 
            this.pbRuleta.Location = new System.Drawing.Point(139, 37);
            this.pbRuleta.Name = "pbRuleta";
            this.pbRuleta.Size = new System.Drawing.Size(400, 400);
            this.pbRuleta.TabIndex = 0;
            this.pbRuleta.TabStop = false;
            this.pbRuleta.OnWheelStopped += new System.EventHandler<string>(this.pbRuleta_OnWheelStopped);
            // 
            // btnSpin
            // 
            this.btnSpin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnSpin.FlatAppearance.BorderSize = 0;
            this.btnSpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSpin.ForeColor = System.Drawing.Color.White;
            this.btnSpin.Location = new System.Drawing.Point(271, 504);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(131, 30);
            this.btnSpin.TabIndex = 0;
            this.btnSpin.Text = "Play";
            this.btnSpin.UseVisualStyleBackColor = false;
            this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.pbRuleta);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbRuleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CustomWheel pbRuleta;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnSpin;
    }
}

