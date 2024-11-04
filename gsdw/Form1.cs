using System;
using System.IO;
using System.Windows.Forms;

namespace gsdw
{
    public partial class Form1 : Form
    {
        private double result = 0;               // Переменная для хранения результата
        private string operation = "";           // Текущая операция
        private bool isOperationPerformed = false; // Проверка нажатия кнопки операции

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик для кнопок цифр
        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox_Result.Text += button.Text;
        }

        // Обработчик для кнопок операций
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = Double.Parse(textBox_Result.Text);
            isOperationPerformed = true;
        }

        // Обработчик для кнопки "="
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(textBox_Result.Text) != 0)
                        textBox_Result.Text = (result / Double.Parse(textBox_Result.Text)).ToString();
                    else
                        MessageBox.Show("Деление на ноль невозможно!");
                    break;
            }
            result = Double.Parse(textBox_Result.Text);
            operation = "";
        }

        // Обработчик для кнопки "C" (очистка)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            result = 0;
            operation = "";
        }

        // Обработчик для кнопки сохранения результата
        private void buttonSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("result.txt", textBox_Result.Text);
            MessageBox.Show("Результат сохранен!");
        }

        // Обработчик для кнопки загрузки результата
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("result.txt"))
                textBox_Result.Text = File.ReadAllText("result.txt");
            else
                MessageBox.Show("Файл с результатом не найден!");
        }

        // Обработчик для кнопки смены цветовой схемы
        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            // Смена цветовой схемы формы и кнопок
            this.BackColor = this.BackColor == System.Drawing.Color.LightGray ? System.Drawing.Color.White : System.Drawing.Color.LightGray;
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = control.BackColor == System.Drawing.Color.LightGray ? System.Drawing.Color.White : System.Drawing.Color.LightGray;
                }
            }
        }
    }
}