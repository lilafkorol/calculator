using System;
using System.IO;
using System.Windows.Forms;

namespace gsdw
{
    public partial class Form1 : Form
    {
        private double result = 0;               // ���������� ��� �������� ����������
        private string operation = "";           // ������� ��������
        private bool isOperationPerformed = false; // �������� ������� ������ ��������

        public Form1()
        {
            InitializeComponent();
        }

        // ���������� ��� ������ ����
        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox_Result.Text += button.Text;
        }

        // ���������� ��� ������ ��������
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = Double.Parse(textBox_Result.Text);
            isOperationPerformed = true;
        }

        // ���������� ��� ������ "="
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
                        MessageBox.Show("������� �� ���� ����������!");
                    break;
            }
            result = Double.Parse(textBox_Result.Text);
            operation = "";
        }

        // ���������� ��� ������ "C" (�������)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            result = 0;
            operation = "";
        }

        // ���������� ��� ������ ���������� ����������
        private void buttonSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("result.txt", textBox_Result.Text);
            MessageBox.Show("��������� ��������!");
        }

        // ���������� ��� ������ �������� ����������
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("result.txt"))
                textBox_Result.Text = File.ReadAllText("result.txt");
            else
                MessageBox.Show("���� � ����������� �� ������!");
        }

        // ���������� ��� ������ ����� �������� �����
        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            // ����� �������� ����� ����� � ������
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