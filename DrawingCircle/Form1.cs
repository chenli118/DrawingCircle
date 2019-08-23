using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingCircle
{
    public partial class Form1 : Form
    {
        private Font _font = new Font("Arial", 12);
        private Brush _brush = new SolidBrush(Color.Black);
        private Pen _pen = new Pen(Color.Black, 1f);
        private string _text = "角度字";

        int wX = 600;
        int wY = 600;


        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint; 
            this.ClientSize = new Size(wX, wY);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {           
            Point center = new Point(wX/2, wY/2);
            Point edge = new Point(
              (int)(center.X + wX/5 * Math.Cos(Math.PI * 30 / 180.0)),
              (int)(center.Y + wY/6 * Math.Sin(Math.PI * 120 / 180.0)));
            e.Graphics.DrawLine(Pens.Black, center, edge);
            e.Graphics.DrawEllipse(Pens.Black, new Rectangle(new Point(10, 10), new Size(450, 450)));
            e.Graphics.DrawEllipse(Pens.Black, new Rectangle(new Point(85, 85), new Size(300, 300)));

            GraphicsText graphicsText = new GraphicsText();
            graphicsText.Graphics = e.Graphics;
            
            // 绘制围绕点旋转的文本
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            graphicsText.DrawString(_text, _font, _brush, new PointF(300, 80), format, 160f);
            graphicsText.DrawString(_text, _font, _brush, new PointF(300, 160), format, 30f);
        }
        bool isShow = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            AnimateWinForm af = new AnimateWinForm();
            isShow = !isShow;
            if (isShow)
                af.Show();
            else
            {
                af.WindowClose(); af.WindowClose(); af.WindowClose();
            }
            }
    }
}
