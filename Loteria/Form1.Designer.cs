
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Loteria
{
    partial class Form1
    {
        string[] archivos = new string[54];
        int[] carta = new int[16];
        int[] acertadas = new int[10];
        int intentos = 0;
        public Form1()
        {
            InitializeComponent();
            dgv.Visible = false;
            pictureBox1.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            //Lenamos un arreglo con el nombre de las imagenes que disponemos
            for (int i = 0; i < archivos.Length; i++)
                archivos[i] = "imagen" + (i + 1).ToString() + ".jpg";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Boton Empezar a Jugar
            dgv.RowCount = 3;

            int i, j, k = 0, n = 9;
            //Metodo nos devuelve un arreglo de numeros diferentes
            carta = AleatoriosDiferentes(n);
            //Mostramos las imagenes en el DataGridView
            for (i = 0; i < dgv.RowCount; i++)
                for (j = 0; j < dgv.ColumnCount; j++)
                {
                    dgv[j, i].Value = Image.FromFile("imagen" + carta[k] + ".jpg");
                    k++;

                }
            for (i = 0; i < dgv.RowCount; i++)
                dgv.Rows[i].Height = 100;

            dgv.Visible = true;
            pictureBox1.Visible = true;
            button2.Visible = true;
            label1.Visible = true;
            button1.Text = "Volver a jugar";
            intentos = 0;
            tbintentos.Text = "";
            //Ponemos en el arreglo acertadas 0 ya que es el que nos va ayudar
            //A Determinar si ya competo la carta
            for (int m = 0; m < acertadas.Length; m++)
                acertadas[m] = 0;
            pictureBox1.Image = Image.FromFile("imageninicio.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton Cantar
            intentos++;
            tbintentos.Text = intentos.ToString();

            Random r = new Random();
            int i, j, k, a;
            int bc = r.Next(1, 21);


            pictureBox1.Image = Image.FromFile(archivos[bc - 1]);
            k = 0;
            //Verificamos si la imagen del picturebox esta en el datagrid
            //Si es asi ponemos la imagen por default y al arreglo acertados ponemos 1
            for (i = 0; i < dgv.RowCount; i++)
            {
                for (j = 0; j < dgv.ColumnCount; j++)
                {
                    if (bc == carta[k])
                    {
                        acertadas[k] = 1;
                        dgv[j, i].Value = Image.FromFile("imagendefault.png");
                    }
                    k++;
                }
            }
            int suma = 0;
            //Sumamos los elementos de acertadas
            for (a = 0; a < acertadas.Length; a++)
                suma += acertadas[a];

            if (suma == acertadas.Length)
                MessageBox.Show("Carta completa");

        }



        private int[] AleatoriosDiferentes(int n)
        {
            int[] numeros = new int[n];
            Random r = new Random();
            for (int i = 0; i < numeros.Length; i++)
            {
                bool yaExiste = true;
                while (yaExiste)
                {
                    numeros[i] = r.Next(1, 21);
                    bool yaEsta = false;
                    for (int j = 0; j < i; j++)
                        if (numeros[i] == numeros[j])
                        {
                            yaEsta = true;
                            break;
                        }
                    yaExiste = yaEsta;
                }

            }
            return numeros;
        }

        private PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private Label label1;
        private System.Windows.Forms.Button button2;
        private DataGridView dgv;
        private TextBox tbintentos;
    }
}

