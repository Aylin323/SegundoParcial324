using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;

namespace WindowsFormsApplication7
{

    public partial class Form1 : Form
    {
        int cR, cG, cB;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "archivos jpg|*.jpg"; 
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            con.ConnectionString = "DSN=odbcimagenes";

            cmd.CommandText = "insert into texturas(descripcion,cR,cG,cB,colorpintar) ";
            cmd.CommandText = cmd.CommandText + " values('"+textBox4.Text+"',"+textBox1.Text+","+textBox2.Text+","+textBox3.Text+",'"+textBox5.Text+"')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            mostrar();
        }


        

        private void button5_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int r, g, b;
            bool coloru;
            String mensaje_color="";

            for (int k = 0; k < dataGridView1.RowCount - 1; k++)
            {
                r = 0; g = 0; b = 0;
                coloru = false;
                r = Int32.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString());
                g = Int32.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString());
                b = Int32.Parse(dataGridView1.Rows[k].Cells[4].Value.ToString());

                String data = dataGridView1.Rows[k].Cells[5].Value.ToString();

                int red = 0, green = 0, blue = 0;

                Color colort = new Color();
                String patron = "#";

                if (data.StartsWith(patron))
                {
                    data = data.Substring(1);
                    red = int.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    green = int.Parse(data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    blue = int.Parse(data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                }
                else
                {
                    colort = Color.FromName(data);
                    red = colort.R;
                    green = colort.G;
                    blue = colort.B;
                    
                }



                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        c = bmp.GetPixel(i, j);
                       
                         if ((c.R == r) && (c.G == g) && (c.B == b))
                         {
                            coloru = true;
                            
                            bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                         }
                         else
                         {
                             bmp.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                         }
                    }
                }

              
                if (coloru)
                {
                    mensaje_color = "Color: " + data + ", " + mensaje_color;
                }
                
                
            }
            
            pictureBox1.Image = bmp;
            MessageBox.Show(mensaje_color);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void mostrar()
        {
            OdbcConnection con = new OdbcConnection();
            OdbcDataAdapter ada = new OdbcDataAdapter();
            con.ConnectionString = "DSN=odbcimagenes";
            ada.SelectCommand = new OdbcCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from texturas";
            DataSet ds = new DataSet();
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
