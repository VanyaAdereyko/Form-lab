using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication19
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            // добавляем возможность выбора цвета шрифта
            fontDialog1.ShowColor = true;
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            richTextBox1.Multiline = true;
            // создаем элементы меню
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставить");
            // добавляем элементы в меню
            contextMenuStrip1.Items.AddRange(new[] { copyMenuItem, pasteMenuItem });
            // ассоциируем контекстное меню с текстовым полем
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            // устанавливаем обработчики событий для меню
            copyMenuItem.Click += copyMenuItem1_Click;
            pasteMenuItem.Click += pasteMenuItem1_Click;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            richTextBox1.Font = fontDialog1.Font;
            // установка цвета шрифта
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Font t = new Font(richTextBox1.Text, (float)numericUpDown1.Value);
            richTextBox1.Font = t;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Clipboard.SetText(richTextBox1.Text);



        }

        private void button5_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                richTextBox1.Text = (String)iData.GetData(DataFormats.Text);
            }
        }

        private void pasteMenuItem1_Click(object sender, EventArgs e)
        {

            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                richTextBox1.Text = (String)iData.GetData(DataFormats.Text);
            }
        }

        private void copyMenuItem1_Click(object sender, EventArgs e)
        {
            // если выделен текст в текстовом поле, то копируем его в буфер
            Clipboard.SetText(richTextBox1.Text);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold | richTextBox1.SelectionFont.Style);

            richTextBox1.Select();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic | richTextBox1.SelectionFont.Style);

            richTextBox1.Select();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline | richTextBox1.SelectionFont.Style);

            richTextBox1.Select();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

	richTextBox1.ZoomFactor = + 1.5f;
           
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1f;
        }
    }
}
