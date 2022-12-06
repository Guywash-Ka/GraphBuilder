using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilding
{
    public partial class Form1 : Form
    {
        public Graphics gr;
        public double delta_x = 1;
        public double delta_y = 1;
        int PIXELS_IN_DELTA = 18;
        public int w ,h;
        


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Ручной")
            {
                textBox9.Visible = true;
                label11.Visible = true;
            }
            else
            {
                textBox9.Visible = false;
                label11.Visible = false;
            }
        }

       private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            w = pictureBox1.ClientSize.Width / 2;
            h = pictureBox1.ClientSize.Height / 2;
            e.Graphics.TranslateTransform(w, h);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }

        public Form1()
        {
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
            w = pictureBox1.ClientSize.Width;
            h = pictureBox1.ClientSize.Height;
            gr.TranslateTransform(w / 2, h / 2);

        }

        private void DrawAxis() //435, 320
        {
            Pen pen_axis = new Pen(Color.Black);
            gr.DrawLine(pen_axis, new Point(w, 0), new Point(-w, 0));
            for (int i = PIXELS_IN_DELTA; i < w; i += PIXELS_IN_DELTA)
            {
                gr.DrawLine(Pens.Black, i, -5, i, 5);
                gr.DrawString($"{i / PIXELS_IN_DELTA * delta_x}", SystemFonts.DefaultFont, Brushes.Black, new PointF(i-5, 15));
            }
            for (int i = -PIXELS_IN_DELTA; i > -w; i -= PIXELS_IN_DELTA)
            {
                gr.DrawLine(Pens.Black, i, -5, i, 5);
                gr.DrawString($"{i / PIXELS_IN_DELTA * delta_x}", SystemFonts.DefaultFont, Brushes.Black, new PointF(i-5, 15));
            }
            gr.DrawLine(pen_axis, new Point(0, h), new Point(0, -h));
            for (int i = -PIXELS_IN_DELTA; i < h; i += PIXELS_IN_DELTA)
            {
                gr.DrawLine(Pens.Black, -5, i, 5, i);
                gr.DrawString($"{Math.Round(-i / PIXELS_IN_DELTA * delta_y)}", SystemFonts.DefaultFont, Brushes.Black, new PointF(10, i-5));
            }
            for (int i = PIXELS_IN_DELTA; i > -h; i -= PIXELS_IN_DELTA)
            {
                gr.DrawLine(Pens.Black, -5, i, 5, i);
                gr.DrawString($"{Math.Round(-i / PIXELS_IN_DELTA * delta_y)}", SystemFonts.DefaultFont, Brushes.Black, new PointF(10, i-5));
            }
        }
        
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal val = numericUpDown1.Value;
            switch (val)
            {
                case 5:
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    break;
                case 4:
                    textBox2.Visible = false;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label2.Visible = false;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    break;
                case 3:
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    break;
                case 2:
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = true;
                    label6.Visible = true;
                    break;
                case 1:
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = true;
                    break;
                case 0:
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = textBox1.Text;
            //PIXELS_IN_DELTA = w / Convert.ToInt32(textBox1.Text) * (int)delta;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox8.Text;
            //PIXELS_IN_DELTA = w / Convert.ToInt32(textBox1.Text) * (int)delta;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            delta_x = textBox9.Text == ""? 1: Convert.ToDouble(textBox9.Text);
            PIXELS_IN_DELTA = w / Convert.ToInt32(textBox1.Text) * (int)delta_x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.AliceBlue);
            Func<float, float> y = i => -(float)(Convert.ToDouble(textBox2.Text) * i * i * i * i * i + Convert.ToDouble(textBox3.Text) * i * i * i * i + Convert.ToDouble(textBox4.Text) * i * i * i + Convert.ToDouble(textBox5.Text) * i * i + Convert.ToDouble(textBox6.Text) * i + Convert.ToDouble(textBox7.Text));
            Pen pen_graph = new Pen(Color.Purple, 2f);
            double max_y = Enumerable.Range(-Convert.ToInt32(textBox1.Text), 2 * Convert.ToInt32(textBox1.Text) + 1).Max(x => Math.Abs(y(x)));
            PIXELS_IN_DELTA = w / Convert.ToInt32(textBox1.Text) * (int)delta_x;
            delta_y = max_y / Convert.ToInt32(textBox1.Text) * delta_x;
            DrawAxis();
            float y1, y2, coords;
            PointF[] arr = {};
            for (int i = -w; i < w; i++)
            {
                coords = (float)i / PIXELS_IN_DELTA * (float)delta_x;
                arr = arr.Append(new PointF(i, y(coords) * PIXELS_IN_DELTA  / (float)delta_y)).ToArray();

            }   
            gr.DrawLines(pen_graph, arr);
        }
    }
}
