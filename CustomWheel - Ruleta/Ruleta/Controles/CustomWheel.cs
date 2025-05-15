using Objetos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ruleta.Controles
{
    public class CustomWheel : PictureBox
    {
        public string CurrentWinner { get; private set; }
        private bool isSpinning = false;
        private float currentAngle = 0;
        private float spinSpeed = 0;
        private List<ObjRuleta> sections;
        private Random random = new Random();
        private Timer spinTimer;

        public event EventHandler<string> OnWheelStopped;

        public CustomWheel()
        {
            this.DoubleBuffered = true;
            spinTimer = new Timer
            {
                Interval = 16
            };
            spinTimer.Tick += SpinTimer_Tick;
        }

        public void InitializeWheel(List<ObjRuleta> wheelSections)
        {
            sections = wheelSections;
            this.Invalidate();
        }
        
        public void Spin()
        {
            if (!isSpinning)
            {
                isSpinning = true;
                spinSpeed = random.Next(20, 30); // diferencia de 10 numeros, esto es lo que modifica la velocidad de giro
                spinTimer.Start();               // y esto permite que el resultado de la ruleta sea un tanto al azar
            }
        }

        private void SpinTimer_Tick(object sender, EventArgs e)
        {
            if (isSpinning)
            {
                currentAngle += spinSpeed;
                spinSpeed *= 0.98f;

                if (spinSpeed < 0.1f)
                {
                    isSpinning = false;
                    spinTimer.Stop();

                    float normalizedAngle = ((270 - currentAngle) % 360 + 360) % 360; // con 270 y la resta, queremos indicar que el valor del ganador sera obtenido en los 90 grados
                    float sectionAngle = 360f / sections.Count;
                    int winningIndex = (int)(normalizedAngle / sectionAngle);
                    CurrentWinner = sections[winningIndex].Text;
                    OnWheelStopped?.Invoke(this, CurrentWinner);
                }
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (sections == null || sections.Count == 0) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawWheel(e.Graphics, currentAngle);
        }

        private void DrawWheel(Graphics g, float angle)
        {
            g.Clear(this.BackColor);
            float sectionAngle = 360f / sections.Count;
            float startAngle = angle;

            // Dibujar círculo exterior
            using (Pen pen = new Pen(Color.FromArgb(57, 62, 70), 2))
            {
                g.DrawEllipse(pen, 1, 1, this.Width - 3, this.Height - 3);
            }

            // Dibujar secciones
            for (int i = 0; i < sections.Count; i++)
            {
                using (SolidBrush brush = new SolidBrush(sections[i].Color))
                {
                    g.FillPie(brush, 10, 10, this.Width - 21, this.Height - 21, startAngle, sectionAngle);
                }

                // Dibujar líneas divisorias
                double rad = startAngle * Math.PI / 180;
                Point center = new Point(this.Width / 2, this.Height / 2);
                Point edge = new Point(
                    (int)(center.X + Math.Cos(rad) * this.Width / 2),
                    (int)(center.Y + Math.Sin(rad) * this.Height / 2)
                );
                g.DrawLine(Pens.Black, center, edge);

                // Dibujar texto
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    float textAngle = startAngle + sectionAngle / 2;
                    float radius = (this.Width - 40) / 3;
                    PointF textPoint = new PointF(
                        center.X + (float)(radius * Math.Cos(textAngle * Math.PI / 180)),
                        center.Y + (float)(radius * Math.Sin(textAngle * Math.PI / 180))
                    );

                    using (Matrix rotationMatrix = new Matrix())
                    {
                        rotationMatrix.RotateAt(textAngle + 90, textPoint); // angulo del texto
                        g.Transform = rotationMatrix;
                        g.DrawString(sections[i].Text, new Font("Arial", 10, FontStyle.Bold), Brushes.White, textPoint, sf); // formato de texto de las secciones
                        g.ResetTransform();
                    }
                }

                startAngle += sectionAngle;
            }

            // Dibujar indicador-flecha
            Point[] arrow = {                 
                new Point(this.Width/2, 0),
                new Point(this.Width/2 - 10, 20),
                new Point(this.Width/2 + 10, 20)
            };
            g.FillPolygon(Brushes.Red, arrow);
        }
    }
}