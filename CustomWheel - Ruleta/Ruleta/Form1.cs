
using Objetos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ruleta
{
    public partial class Form1 : Form
    {
        public string CurrentWinner { get; private set; }
        public string Resultado = string.Empty;

        public Form1()
        {
            InitializeComponent();

            // Las secciones que mostraremos en la ruleta y el color que tendra cada una
            List<ObjRuleta> wheelSections = new List<ObjRuleta>
            {
                new ObjRuleta { Text = "Mathematics", Color = Color.FromArgb(128, 0, 128) },
                new ObjRuleta { Text = "Science", Color = Color.FromArgb(255, 69, 0) },
                new ObjRuleta { Text = "History", Color = Color.FromArgb(255, 0, 0) },
                new ObjRuleta { Text = "Geography", Color = Color.FromArgb(255, 165, 0) },
                new ObjRuleta { Text = "Literature", Color = Color.FromArgb(0, 128, 0) },
                new ObjRuleta { Text = "Computers", Color = Color.FromArgb(0, 0, 255) },
                new ObjRuleta { Text = "Sports", Color = Color.FromArgb(75, 0, 130) },
                new ObjRuleta { Text = "Music", Color = Color.FromArgb(139, 0, 0) },
                new ObjRuleta { Text = "Movies", Color = Color.FromArgb(255, 215, 0) },
                new ObjRuleta { Text = "Games", Color = Color.FromArgb(255, 20, 147) }
            };

            pbRuleta.InitializeWheel(wheelSections);
        }

        private void pbRuleta_OnWheelStopped(object sender, string winner)
        {
            CurrentWinner = winner;
            lblResult.Text = $"Winner: {CurrentWinner}";
            Resultado = CurrentWinner;
        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            pbRuleta.Spin();
        }
    }
}
