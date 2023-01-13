using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Round : Ellipse
    {
        public static new int count = 0;
        public int diameter;
        public Round(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            diameter = radius*2;
            try
            {
                if (!(x < 0 || y < 0 || x + diameter > pictureBox.Width || y + diameter > pictureBox.Height))
                {
                    FiguresContainer.RoundsList.Add(this);
                    FiguresContainer.figureList.Add(this);
                    number = count;
                    count++;
                }
                else
                {
                    throw new Exception("Фигура должна помещаться на холст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}", "Ашипка");
            }
        }

        public override void Draw()
        {
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawEllipse(pen, x, y, diameter, diameter);
                pictureBox.Image = bitmap;
                DrawText("Ro", number);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}", "Ашипка");
            }
        }

        public override void MoveTo(int x, int y)
        {
            try
            {
                if (!(x < 0 || y < 0 || x + diameter > pictureBox.Width || y + diameter > pictureBox.Height))
                {
                    this.x = x; this.y = y;
                    DeleteF(this, false);
                    Draw();
                }
                else
                {
                    throw new Exception("Фигура должна помещаться на холст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}", "Ашипка");
            }
        }

        public void ResizeRound(int radius)
        {
            try
            {
                if (!(x < 0 || y < 0 || x + radius * 2 > pictureBox.Width || y + radius * 2 > pictureBox.Height))
                {
                    diameter = radius * 2;
                    DeleteF(this, false);
                    Draw();
                }
                else
                {
                    throw new Exception("Фигура должна помещаться на холст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}", "Ашипка");
            }
        }
    }
}
