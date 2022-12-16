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

namespace Директория_Ф
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("c:\\temp");
            Directory.CreateDirectory("c:\\temp\\K1");
            Directory.CreateDirectory("c:\\temp\\K2");

            StreamWriter sw = new StreamWriter("c:\\temp\\K1\\t1.txt");
            sw.Write("Щербаков Захар Михайлович, 15.07.2004, Россия г.Владимир");
            sw.Close();
            sw = new StreamWriter("c:\\temp\\K1\\t2.txt");
            sw.Write("Лапшин Олег, ?7.??.200?, Казахстан г.Караганда");
            sw.Close();

            sw = new StreamWriter("c:\\temp\\K2\\t3.txt");
            StreamReader sr = new StreamReader("c:\\temp\\K1\\t1.txt");
            var read = sr.ReadToEnd();
            sw.WriteLine(read);
            sr.Close();

            sr = new StreamReader("c:\\temp\\K1\\t2.txt");
            read = sr.ReadToEnd();
            sw.WriteLine(read);
            sr.Close();
            sw.Close();

            DirectoryInfo d = new DirectoryInfo("c:\\temp\\K1\\");
            DirectoryInfo d3 = new DirectoryInfo("c:\\temp\\K2\\");
            FileInfo[] f = d.GetFiles();
            FileInfo[] f3 = d3.GetFiles();
            foreach (FileInfo i in f)
            {
                richTextBox1.Text += "\nИмя: " + i.Name.ToString() + "\n"
                                                    + " Путь: " + i.FullName.ToString() + "\n"
                                                    + " Атрибут: " + i.Attributes.ToString() + "\n"
                                                    + "Расширение: " + i.Extension.ToString() + "\n"
                                                    + "Размер: " + i.Length.ToString() + "\n"
                                                    + "Только для чтения: " + i.IsReadOnly.ToString() + "\n"
                                                    + "Время создания" + i.CreationTime.ToString() + "\n";
            }

            foreach (FileInfo i in f3)
            {
                richTextBox1.Text += "\nИмя: " + i.Name.ToString() + "\n"
                                                    + " Путь: " + i.FullName.ToString() + "\n"
                                                    + " Атрибут: " + i.Attributes.ToString() + "\n"
                                                    + "Расширение: " + i.Extension.ToString() + "\n"
                                                    + "Размер: " + i.Length.ToString() + "\n"
                                                    + "Только для чтения: " + i.IsReadOnly.ToString() + "\n"
                                                    + "Время создания" + i.CreationTime.ToString() + "\n";
            }


            File.Move("c:\\temp\\K1\\t2.txt", "c:\\temp\\K2\\t2.txt");
            File.Copy("c:\\temp\\K1\\t1.txt", "c:\\temp\\K2\\t1.txt");
            Directory.Move("c:\\temp\\K2", "c:\\temp\\ALL");
            Directory.Delete("c:\\temp\\K1", true);

            DirectoryInfo h = new DirectoryInfo("c:\\temp\\ALL\\");
            FileInfo[] j = h.GetFiles();
            richTextBox1.Text += "All:\n";
            foreach (FileInfo i in j)
            {
                richTextBox1.Text += "\nИмя: " + i.Name.ToString() + "\n"
                                    + " Путь: " + i.FullName.ToString() + "\n"
                                    + " Атрибут: " + i.Attributes.ToString() + "\n"
                                    + "Расширение: " + i.Extension.ToString() + "\n"
                                    + "Размер: " + i.Length.ToString() + "\n"
                                    + "Только для чтения: " + i.IsReadOnly.ToString() + "\n"
                                    + "Время создания" + i.CreationTime.ToString() + "\n";
            }

        }
    }
}
