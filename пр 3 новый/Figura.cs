using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пр_3_новый
{
    public class Figura
    {
        int x;
        int y;
        int h;
        PictureBox pb;
        int dx = 10;

        public Figura(int nx, int ny, int nh, PictureBox npb)
        {
            x = nx;
            y = ny;
            h = nh;
            pb = npb;
            Draw();
        }
        public void Draw()
        {
            
                Graphics gr = Graphics.FromImage(pb.Image);
                SolidBrush solidBrush = new SolidBrush(Color.LightBlue);
                gr.FillRectangle(solidBrush, x, y, h, h);

                Point[] triangle1Points = { new Point(x, y), new Point(x + h / 2, y + h / 2), new Point(x, y + h) };
                Point[] triangle2Points = { new Point(x + h, y), new Point(x + h / 2, y + h / 2), new Point(x + h, y + h) };
                Point[] triangle3Points = { new Point(x, y), new Point(x + h / 2, y + h / 2), new Point(x + h, y) };
                Point[] triangle4Points = { new Point(x, y + h), new Point(x + h / 2, y + h / 2), new Point(x + h, y + h) };



                Pen redPen = new Pen(Color.Red, 2);
                gr.DrawPolygon(redPen, triangle1Points);
                gr.DrawPolygon(redPen, triangle2Points);
                gr.DrawPolygon(redPen, triangle3Points);
                gr.DrawPolygon(redPen, triangle4Points);


                SolidBrush greenBrush = new SolidBrush(Color.Green);

                int circleDiameter = h / 6;
                Point circleCenter = new Point(x + h / 3 + circleDiameter, y + h / 4);
                gr.FillEllipse(greenBrush, circleCenter.X - circleDiameter / 2, circleCenter.Y - circleDiameter / 2, circleDiameter, circleDiameter);
                Point circleCenter2 = new Point(x + h / 3 + circleDiameter, y + 3 * h / 4);
                gr.FillEllipse(greenBrush, circleCenter2.X - circleDiameter / 2, circleCenter2.Y - circleDiameter / 2, circleDiameter, circleDiameter);

                pb.Refresh();

            

        }

        public void Move()
        {
            Clear();
            if (x + dx < 0 || x + dx > pb.Width - h)
            {
                dx = -dx;
            }
            x = x + dx;
            Draw();
        }
        public void Clear()
        {
            Graphics gr = Graphics.FromImage(pb.Image);
            SolidBrush solidBrush = new SolidBrush(Color.Purple);
            gr.FillRectangle(solidBrush, x, y, h, h);
            pb.Refresh();

        }

        internal void SetPosition(int newX, int newY)
        {
            x = newX;
            y = newY;
            Draw();
        }

        internal void SetHeight(int newHeight)
        {
            h = newHeight;
            Draw();
        }
    }
}

     