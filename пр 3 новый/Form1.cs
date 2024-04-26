using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace пр_3_новый
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap br = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = br;
            Graphics gr = Graphics.FromImage(br);
            SolidBrush solidBrush = new SolidBrush(Color.Purple);
            gr.FillRectangle(solidBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Refresh();

        }

        public void DrawFigures()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            SolidBrush solidBrush = new SolidBrush(Color.Purple);
            gr.FillRectangle(solidBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Refresh();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Figura fg1 = listBox1.Items[i] as Figura;
                fg1.Draw();
            }
            pictureBox1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                int x = Convert.ToInt32(f.textBox1.Text);
                int y = Convert.ToInt32(f.textBox2.Text);
                int h = Convert.ToInt32(f.textBox3.Text);
                Figura fg = new Figura(x, y, h, pictureBox1);
                listBox1.Items.Add(fg);
                DrawFigures();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Объект для удаления не выбран");
            }
            else
            {
                Figura selectedFigura = (Figura)listBox1.SelectedItem;
                listBox1.Items.Remove(selectedFigura);
                pictureBox1.Refresh();
            }



        }
        private void UpdateButtonStates()
        {
            button1.Enabled = listBox1.Items.Count > 0;
            button2.Enabled = listBox1.SelectedIndex != -1;
            button3.Enabled = listBox1.SelectedIndex != -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Figura fg1 = listBox1.Items[i] as Figura;
                fg1.Move();
            }
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                int index = listBox1.SelectedIndex;
                if (index != -1)
                {
                    int x = Convert.ToInt32(f.textBox1.Text);
                    int y = Convert.ToInt32(f.textBox2.Text);
                    int h = Convert.ToInt32(f.textBox3.Text);
                    Figura selectedFigure = (Figura)listBox1.Items[index];
                    selectedFigure.SetPosition(x, y);
                    selectedFigure.SetHeight(h);
                    DrawFigures();
                }
                else
                {
                    MessageBox.Show("Выберите фигуру для редактирования.");
                }


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}




        
                    
  




