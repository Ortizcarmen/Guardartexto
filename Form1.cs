using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guardartexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Guardar(string fileName, string texto)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(stream);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            writer.WriteLine(texto);
            //Cerrar el archivo
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar("archivo.txt", textBox1.Text);
            MessageBox.Show("Texto Guardado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Directorio en donde se va a iniciar la busqueda
            openFileDialog1.InitialDirectory = "c:\\";
            //Tipos de archivos que se van a buscar, en este caso archivos de texto con extensión .txt
            openFileDialog1.Filter = "Archivos txt (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            //Muestra la ventana para abrir el archivo y verifica que si se pueda abrir
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //Guardamos en una variable el nombre del archivo que abrimos
                string fileName = openFileDialog1.FileName;

                //Abrimos el archivo, en este caso lo abrimos para lectura
                FileStream flujo = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader lector = new StreamReader(flujo);

                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leído se va guardando en un control richTextBox
                while (lector.Peek() > -1)
                //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
                //lo muestre en otro control por ejemplo un combobox
                {
                    string textoLeido =lector.ReadLine();
                    richTextBox1.AppendText(lector.ReadLine());
                }
                //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
                lector.Close();
            }
        }

        private void btnFijo_Click(object sender, EventArgs e)
        {
            //Guardamos en una variable el nombre del archivo que abrimos
            string nombreArchivo = @"C:\Users\50236\Desktop.text";

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream flujo = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader lector = new StreamReader(flujo);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (lector.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                string textoLeido = lector.ReadLine();
                richTextBox1.AppendText(lector.ReadLine());
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            lector.Close();
        }
    }
}
