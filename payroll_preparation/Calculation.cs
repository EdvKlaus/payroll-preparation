using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace payroll_preparation
{
    public partial class Calculation : Form
    {
        public Calculation()
        {
            InitializeComponent();
        }

        private void Calculation_Click(object sender, EventArgs e)
        {
            try
            {
                int number_of_days_worked = Convert.ToInt32(textBox1.Text);
                int number_of_hours_worked = Convert.ToInt32(textBox2.Text);
                int hourly_bonus_amount = Convert.ToInt32(textBox3.Text);

                if (number_of_days_worked >= 1 && number_of_hours_worked >= 1 && hourly_bonus_amount >= 1) {
                    if (number_of_days_worked < 8) {
                        double weekly_salary = (245 + hourly_bonus_amount) * number_of_hours_worked * number_of_days_worked;
                        double two_weeks_salary = (245 + hourly_bonus_amount) * number_of_hours_worked * (number_of_days_worked * 2);
                        double mounthly_salary = (245 + hourly_bonus_amount) * number_of_hours_worked * number_of_days_worked * 4;

                        textBox6.Text = weekly_salary.ToString();
                        textBox5.Text = two_weeks_salary.ToString();
                        textBox4.Text = mounthly_salary.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Число рабочих дней (в неделю) должно быть в диапозоне от 1 до 7", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Все числа должны быть целыми и положительными", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Все поля для расчётов должны быть заполнениы целыми числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Generation_File_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;


            string fileStr = "Текущая дата: " + dateTime.ToString() + "\n" + "Заработная плата за неделю: " + textBox6.Text.ToString() + "\n" + "Заработная плата за 2 неделе: " + textBox5.Text.ToString() + "\n" + "Заработная плата за месяц: " + textBox4.Text.ToString();

            saveFileDialog1.FileName = @"calculation.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var writer = new StreamWriter(
                    saveFileDialog1.FileName, false, Encoding.GetEncoding(1251));

                    writer.Write(fileStr);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
