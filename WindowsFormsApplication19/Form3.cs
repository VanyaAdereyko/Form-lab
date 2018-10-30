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
    public partial class Form3 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public Form3()
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
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer2_Tick;
            timer2.Start();
        }



        private void вырезатьToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
        }

        private void копироватьToolStripButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void вставкаToolStripButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void печатьToolStripButton_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
                printDocument1.Print();

        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            richTextBox1.Font = fontDialog1.Font;
            // установка цвета шрифта
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripProgressBar1.Value == 100)
            {
                toolStripProgressBar1.Value = 0;
                timer1.Stop();
                pictureBox1.Visible = true;
                button1.Visible = true;
                richTextBox1.Visible = true;
                MessageBox.Show("Все компоненты загружены");

            }
            else
            {
                toolStripProgressBar1.Value = toolStripProgressBar1.Value + 2;

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
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

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
    }
}