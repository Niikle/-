using System;
using System.Collections.Generic;
using System.ComponentModel;
using SD = System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Приложение_для_файлов_1._1.Properties;
using System.Media;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

using System.Drawing.Drawing2D;
using File = System.IO.File;

namespace Приложение_для_файлов_1._1
{
    public partial class Form1 : Form
    {
        int create_rop = 0;
        int auto = 0;
        string sim;
        bool ciin_a = true, ciin_b = false,ciin_c = false, ciin_sim = false;
        double first_num = 0, second_num = 0, third_num = 0;
        char first_char, second_char;
        bool cin_first_num = true, cin_second_num = false, cin_third_num = false, cin_first_char = false, cin_second_char = false, proverka = false;
        int[,] array = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },//1
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },//2
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },//3
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } //4
        };
        string[] schita = new string[5];
        //List<double> lst = new List<double>();

        Timer timer;
        Timer timer2;
        Timer timer_budilnik;

        public Form1()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Clock;

            timer2 = new Timer();
            timer2.Interval = 990;
            timer2.Tick += RealClock;
            timer2.Start();

            timer_budilnik = new Timer();
            timer_budilnik.Interval = 900;
            timer_budilnik.Tick += budilnik;

            for (int i = 0; i < 3; i++)
            {
                dgv.Rows.Add(" ");
            }

            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    dgv.Rows[i].Cells[j].Value = "0";
                }
            }

            label16.Text = "0";
            label17.Text = "0";
            label18.Text = "0";
            label19.Text = "0";

            if(Properties.Settings.Default.Save_name_1 != "")
                textBoxF1.Text = Properties.Settings.Default.Save_name_1;
            if (Properties.Settings.Default.Save_name_2 != "")
                textBoxF2.Text = Properties.Settings.Default.Save_name_2;
            if (Properties.Settings.Default.Save_name_3 != "")
                textBoxF3.Text = Properties.Settings.Default.Save_name_3;
            if (Properties.Settings.Default.Save_name_4 != "")
                textBoxF4.Text = Properties.Settings.Default.Save_name_4;

            if (Properties.Settings.Default.Save_salary_1 != "")
                textBoxZP1.Text = Properties.Settings.Default.Save_salary_1;
            if (Properties.Settings.Default.Save_salary_2 != "")
                textBoxZP2.Text = Properties.Settings.Default.Save_salary_2;
            if (Properties.Settings.Default.Save_salary_3 != "")
                textBoxZP3.Text = Properties.Settings.Default.Save_salary_3;
            if (Properties.Settings.Default.Save_salary_4 != "")
                textBoxZP4.Text = Properties.Settings.Default.Save_salary_4;


            labelFG1.Text = textBoxF1.Text;
            labelFN1.Text = textBoxF1.Text;
            labelFG2.Text = textBoxF2.Text;
            labelFN2.Text = textBoxF2.Text;
            labelFG3.Text = textBoxF3.Text;
            labelFN3.Text = textBoxF3.Text;
            labelFG4.Text = textBoxF4.Text;
            labelFN4.Text = textBoxF4.Text;

            textBoxVoda1.Text = Properties.Settings.Default.Save_Voda_1;
            textBoxVoda2.Text = Properties.Settings.Default.Save_Voda_2;
            textBoxElektro1.Text = Properties.Settings.Default.Save_Elektro_1;
            textBoxElektro2.Text = Properties.Settings.Default.Save_Elektro_2;
            textBoxElektro3.Text = Properties.Settings.Default.Save_Elektro_3;

            //dataGridView2.Rows.Add("январь");
            //dataGridView2.Rows.Add("февраль");
            //dataGridView2.Rows.Add("март");
            //dataGridView2.Rows.Add("апрель");
            //dataGridView2.Rows.Add("май");
            //dataGridView2.Rows.Add("июнь");
            //dataGridView2.Rows.Add("июль");
            //dataGridView2.Rows.Add("август");
            //dataGridView2.Rows.Add("сентябрь");
            //dataGridView2.Rows.Add("октябрь");
            //dataGridView2.Rows.Add("ноябрь");
            //dataGridView2.Rows.Add("декабрь");

            //for(int i = 0; i < 12; i++)
            //{
            //    dataGridView2[4, i].Value = "удалить строчку " + Convert.ToString(i + 1);
            //}

            //int counterSavesI = 0;
            //int counterSavesJ = 0;
            //int counterSavesII = 0;
            //foreach (var line in File.ReadLines(@"C:\Для файлов\Сохранение тепловых показаний.txt"))
            //{
            //    var array = line.Split();
            //    //dataGridView2.Rows.Add(array);
            //    dataGridView2[counterSavesI + 1, counterSavesJ].Value = "1";
            //    counterSavesI++;
            //    counterSavesII++;
            //
            //    if (counterSavesII == 3)
            //    {
            //        counterSavesII = 0;
            //        counterSavesJ++;
            //    }
            //}

            //string[] arrauSaveDataCounters;
            int counterRowsData = 0;
            foreach (string line in File.ReadLines(Environment.CurrentDirectory + @"\Для файлов\Сохранение тепловых показаний.txt"))
                //@"C:\Для файлов\Сохранение тепловых показаний.txt"
            {
                string[] array = line.Split();
                string[] month1 = { "январь" };
                switch (counterRowsData)
                {
                    case 0:
                        month1[0] = "январь";
                        break;
                    case 1:
                        month1[0] = "февраль";
                        break;
                    case 2:
                        month1[0] = "март";
                        break;
                    case 3:
                        month1[0] = "апрель";
                        break;
                    case 4:
                        month1[0] = "май";
                        break;
                    case 5:
                        month1[0] = "июнь";
                        break;
                    case 6:
                        month1[0] = "июль";
                        break;
                    case 7:
                        month1[0] = "август";
                        break;
                    case 8:
                        month1[0] = "сентябрь";
                        break;
                    case 9:
                        month1[0] = "октябрь";
                        break;
                    case 10:
                        month1[0] = "ноябрь";
                        break;
                    case 11:
                        month1[0] = "декабрь";
                        break;
                }
                string[] arrayFinally = month1.Union(array).ToArray();//объдинение
                dataGridView2.Rows.Add(arrayFinally);
                counterRowsData++;
            }

            //var lines = File.ReadAllLines(@"C:\Для файлов\Сохранение тепловых показаний.txt");
            //var maxLine = lines.Max(f => f.Length);
            //string secondLine = File.ReadLines(@"C:\Для файлов\Сохранение тепловых показаний.txt").Skip(0).First();
            //for(int i = 0; i < secondLine.Length; i++)
            //{
            //
            //    //dataGridView2[i, 0].Value = Convert.ToString(secondLine[i]);
            //},

            for(int i = 0; i < 3; i++)
            {
                dvg1.Rows.Add();
            }

            //dvg1.RowHeadersDefaultCellStyle = new DataGridViewCellStyle();
            //dvg1.RowHeadersDefaultCellStyle{ Font = 7,7};
        }

        SoundPlayer budi = new SoundPlayer(Environment.CurrentDirectory + @"\Для файлов\Звук на будильник.wav");

        private void budilnik(object sender, EventArgs e)
        {
            if(textBox9.Text == textBox8.Text)
            {
                textBox9.Text = "БУДИЛЬНИК!";
                budi.Play();
                timer_budilnik.Stop();
            }
        }

        private void RealClock(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if((DateTime.Now.Hour < 10) && (DateTime.Now.Minute < 10) && (DateTime.Now.Second < 10))
            {
                textBox8.Text = "0" + DateTime.Now.Hour.ToString() + ":" + "0" + DateTime.Now.Minute.ToString() + ":" + "0" + DateTime.Now.Second.ToString();
            }
            else if((DateTime.Now.Hour < 10) && (DateTime.Now.Minute < 10) && (DateTime.Now.Second >= 10))
            {
                textBox8.Text = "0" + DateTime.Now.Hour.ToString() + ":" + "0" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            }
            else if ((DateTime.Now.Hour < 10) && (DateTime.Now.Minute >= 10) && (DateTime.Now.Second < 10))
            {
                textBox8.Text = "0" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + "0" + DateTime.Now.Second.ToString();
            }
            else if ((DateTime.Now.Hour < 10) && (DateTime.Now.Minute >= 10) && (DateTime.Now.Second >= 10))
            {
                textBox8.Text = "0" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            }
            else if ((DateTime.Now.Hour >= 10) && (DateTime.Now.Minute < 10) && (DateTime.Now.Second < 10))
            {
                textBox8.Text = DateTime.Now.Hour.ToString() + ":" + "0" + DateTime.Now.Minute.ToString() + ":" + "0" + DateTime.Now.Second.ToString();
            }
            else if ((DateTime.Now.Hour >= 10) && (DateTime.Now.Minute < 10) && (DateTime.Now.Second >= 10))
            {
                textBox8.Text = DateTime.Now.Hour.ToString() + ":" + "0" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            }
            else if ((DateTime.Now.Hour >= 10) && (DateTime.Now.Minute >= 10) && (DateTime.Now.Second < 10))
            {
                textBox8.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + "0" + DateTime.Now.Second.ToString();
            }
            else if ((DateTime.Now.Hour >= 10) && (DateTime.Now.Minute >= 10) && (DateTime.Now.Second >= 10))
            {
                textBox8.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            }
        }

        private void Clock(object sender, EventArgs e)
        {
            sec++;
            if(sec < 10)
            {
                textBox5.Text = "0" + Convert.ToString(sec);
            }
            else if(sec < 60)
            {
                textBox5.Text = Convert.ToString(sec);
            }
            else if(sec == 60)
            {
                sec = 0;
                min++;
            }
            if (min < 10)
            {
                textBox6.Text = "0" + Convert.ToString(min);
            }
            else if(min < 60)
            {
                textBox6.Text = Convert.ToString(min);
            }
            else if(min == 60)
            {
                min = 0;
                hour++;
            }
            if (hour < 10)
            {
                textBox7.Text = "0" + Convert.ToString(hour);
            }
            else if(hour < 24)
            {
                textBox7.Text = Convert.ToString(hour);
            }
            else
            {
                textBox5.Text = "00";
                textBox6.Text = "00";
                textBox7.Text = "00";
            }

        }

        int sec = 0, min = 0, hour = 0, count_1 = 0;

        private void button7_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                button7.Text = "Очистка таймера";
                button6.Text = "Возобновление таймера";
            }
            else
            {
                timer.Stop();
                button7.Text = "Остановка таймера";
                button6.Text = "Запуск таймера";
                textBox5.Text = "00";
                textBox6.Text = "00";
                textBox7.Text = "00";
                sec = 0;
                min = 0;
                hour = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            first_num = 0;
            second_num = 0;
            third_num = 0;
            first_char = ' ';
            second_char = ' ';
            cin_first_num = true;
            cin_second_num = false;
            cin_third_num = false;
            cin_first_char = false;
            cin_second_char = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.BackgroundImage = Resources.Вариант1;
                //tabPage1.BackgroundImage = Resources.Вариант1;
                //tabPage2.BackgroundImage = Resources.Вариант1;
                //tabPage3.BackgroundImage = Resources.Вариант1;
                //    pictureBox1.BackgroundImage = Resources.Вариант1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.BackgroundImage = Resources.Вариант2;
                //tabPage1.BackgroundImage = Resources.Вариант2;
                //tabPage2.BackgroundImage = Resources.Вариант2;
                //tabPage3.BackgroundImage = Resources.Вариант2;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.BackgroundImage = Resources.Вариант3;
                //tabPage1.BackgroundImage = Resources.Вариант3;
                //tabPage2.BackgroundImage = Resources.Вариант3;
                //tabPage3.BackgroundImage = Resources.Вариант3;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                this.BackgroundImage = null;
                tabPage1.BackgroundImage = null;
                tabPage2.BackgroundImage = null;
                tabPage3.BackgroundImage = null;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 2;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 2;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 2;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 3;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 3;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 3;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 4;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 4;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 4;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 5;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 5;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 5;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 6;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 6;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 6;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 7;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 7;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 7;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 8;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 8;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 8;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 9;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 9;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 9;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 0;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 0;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 0;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_num = false;
                proverka = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (cin_first_char == true)
            {
                first_char = '+';
                cin_first_char = false;
                cin_first_num = false;
                cin_second_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char);
            }
            else if (cin_second_char == true)
            {
                second_char = '+';
                cin_second_char = false;
                cin_second_num = false;
                cin_third_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (cin_first_char == true)
            {
                first_char = '-';
                cin_first_char = false;
                cin_first_num = false;
                cin_second_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char);
            }
            else if (cin_second_char == true)
            {
                second_char = '-';
                cin_second_char = false;
                cin_second_num = false;
                cin_third_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (cin_first_char == true)
            {
                first_char = '*';
                cin_first_char = false;
                cin_first_num = false;
                cin_second_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char);
            }
            else if (cin_second_char == true)
            {
                second_char = '*';
                cin_second_char = false;
                cin_second_num = false;
                cin_third_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (cin_first_char == true)
            {
                first_char = '/';
                cin_first_char = false;
                cin_first_num = false;
                cin_second_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char);
            }
            else if (cin_second_char == true)
            {
                second_char = '/';
                cin_second_char = false;
                cin_second_num = false;
                cin_third_num = true;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cin_first_num = true;
            cin_second_num = false;
            cin_third_num = false;
            cin_first_char = true;
            cin_second_char = false;

            if (proverka == true)
            {
                if (first_char == '+')
                {
                    textBox1.Text = Convert.ToString(first_num + second_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '-')
                {
                    textBox1.Text = Convert.ToString(first_num - second_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '*')
                {
                    textBox1.Text = Convert.ToString(first_num * second_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '/')
                {
                    textBox1.Text = Convert.ToString(first_num / second_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
            }
            else
            {
                if (first_char == '+' && second_char == '+')
                {
                    textBox1.Text = Convert.ToString(first_num + second_num + third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '+' && second_char == '-')
                {
                    textBox1.Text = Convert.ToString(first_num + second_num - third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '+' && second_char == '*')
                {
                    textBox1.Text = Convert.ToString(first_num + second_num * third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '+' && second_char == '/')
                {
                    textBox1.Text = Convert.ToString(first_num + second_num / third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '-' && second_char == '+')
                {
                    textBox1.Text = Convert.ToString(first_num - second_num + third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '-' && second_char == '-')
                {
                    textBox1.Text = Convert.ToString(first_num - second_num - third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '-' && second_char == '*')
                {
                    textBox1.Text = Convert.ToString(first_num - second_num * third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '-' && second_char == '/')
                {
                    textBox1.Text = Convert.ToString(first_num - second_num / third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '*' && second_char == '+')
                {
                    textBox1.Text = Convert.ToString(first_num * second_num + third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '*' && second_char == '-')
                {
                    textBox1.Text = Convert.ToString(first_num * second_num - third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '*' && second_char == '*')
                {
                    textBox1.Text = Convert.ToString(first_num * second_num * third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '*' && second_char == '/')
                {
                    textBox1.Text = Convert.ToString(first_num * second_num / third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '/' && second_char == '+')
                {
                    textBox1.Text = Convert.ToString(first_num / second_num + third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '/' && second_char == '-')
                {
                    textBox1.Text = Convert.ToString(first_num / second_num - third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '/' && second_char == '*')
                {
                    textBox1.Text = Convert.ToString(first_num / second_num * third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
                else if (first_char == '/' && second_char == '/')
                {
                    textBox1.Text = Convert.ToString(first_num / second_num / third_num);
                    first_num = Convert.ToDouble(textBox1.Text);
                }
            }
            second_num = 0;
            third_num = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer_budilnik.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (cin_first_num == true)
            {
                first_num = first_num * 10 + 1;
                textBox1.Text = Convert.ToString(first_num);
                cin_first_char = true;
            }
            else if (cin_second_num == true)
            {
                second_num = second_num * 10 + 1;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num);
                cin_first_char = false;
                cin_second_char = true;
                proverka = true;
            }
            else if (cin_third_num == true)
            {
                third_num = third_num * 10 + 1;
                textBox1.Text = Convert.ToString(first_num + " " + first_char + " " + second_num + " " + second_char + " " + third_num);
                cin_second_char = false;
                proverka = false;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer_budilnik.Stop();
            budi.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer.Start();
            button7.Text = "Остановка таймера";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx";//C:\\Для файлов\\Счётчики.xlsx
            if (File.Exists(path))
            {
                Microsoft.Office.Interop.Excel.Application xlworksheet =
                new Microsoft.Office.Interop.Excel.Application();

                xlworksheet.Application.Workbooks.Open(
                    Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx", Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                try
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (array[i, j] != 0)
                            {
                                xlworksheet.Cells[i + 10, j + 5] = Convert.ToString(array[i, j] - 1);
                            }
                            else
                            {
                                xlworksheet.Cells[i + 10, j + 5] = "";
                            }
                        }

                    }

                    xlworksheet.Cells[10, 2] = labelFG1.Text.ToString();
                    xlworksheet.Cells[11, 2] = labelFG2.Text.ToString();
                    xlworksheet.Cells[12, 2] = labelFG3.Text.ToString();
                    xlworksheet.Cells[13, 2] = labelFG4.Text.ToString();

                    xlworksheet.Cells[10, 4] = textBox3.Text.ToString();
                    xlworksheet.Cells[11, 4] = textBox4.Text.ToString();
                    xlworksheet.Cells[12, 4] = textBox10.Text.ToString();
                    xlworksheet.Cells[13, 4] = textBox11.Text.ToString();

                    xlworksheet.Cells[10, 36] = "= SUM(E10:AI10)";
                    xlworksheet.Cells[11, 36] = "= SUM(E11:AI11)";
                    xlworksheet.Cells[12, 36] = "= SUM(E12:AI12)";
                    xlworksheet.Cells[13, 36] = "= SUM(E13:AI13)";

                    xlworksheet.Cells[10, 37] = "= AJ10 - D10";
                    xlworksheet.Cells[11, 37] = "= AJ11 - D11";
                    xlworksheet.Cells[12, 37] = "= AJ12 - D12";
                    xlworksheet.Cells[13, 37] = "= AJ13 - D13";

                    //xlworksheet.Cells[10, 37] = raznisa_A;
                    //xlworksheet.Cells[11, 37] = raznisa_B;
                    //xlworksheet.Cells[12, 37] = raznisa_C;
                    //xlworksheet.Cells[13, 37] = raznisa_D;
                }
                catch
                {
                    xlworksheet.Application.Workbooks.Close();
                }
                finally
                {
                    xlworksheet.Application.Workbooks.Close();
                }

                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx");
                p.Start();
                TopMost = false;
                this.TopMost = false;

            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 31; i++)
            {
                dvg1[i, 0].Value = false;
                array[0, i] = 0;
            }
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            checkBox5.Checked = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 31; i++)
            {
                dvg1[i, 1].Value = false;
            }
            for (int j = 0; j < 31; j++)
            {
                array[1, j] = 0;
            }
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            checkBox5.Checked = false;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 31; i++)
            {
                dvg1[i, 2].Value = false;
            }
            for (int j = 0; j < 31; j++)
            {
                array[2, j] = 0;
            }
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            checkBox5.Checked = false;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 31; i++)
            {
                dvg1[i, 3].Value = false;
            }
            for (int j = 0; j < 31; j++)
            {
                array[3, j] = 0;
            }
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            checkBox5.Checked = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 31; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    dvg1[i, j].Value = false;
                }
            }
            //Зануление всего
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    array[i, j] = 0;
                }
            }
            //выбор авто
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            checkBox5.Checked = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx";//C:\\Для файлов\\Табель.xlsx
            if (File.Exists(path))
            {
                Microsoft.Office.Interop.Excel.Application xlworksheet =
                new Microsoft.Office.Interop.Excel.Application();

                xlworksheet.Application.Workbooks.Open(
                    Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx", Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                try
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (Convert.ToString(dgv.Rows[i].Cells[j].Value) != "0")
                            {
                                xlworksheet.Cells[i + 10, j + 5] = dgv.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                xlworksheet.Cells[i + 10, j + 5] = "";
                            }
                        }

                    }

                    xlworksheet.Cells[10, 2] = labelFG1.Text.ToString();
                    xlworksheet.Cells[11, 2] = labelFG2.Text.ToString();
                    xlworksheet.Cells[12, 2] = labelFG3.Text.ToString();
                    xlworksheet.Cells[13, 2] = labelFG4.Text.ToString();

                    xlworksheet.Cells[10, 4] = textBox3.Text.ToString();
                    xlworksheet.Cells[11, 4] = textBox4.Text.ToString();
                    xlworksheet.Cells[12, 4] = textBox10.Text.ToString();
                    xlworksheet.Cells[13, 4] = textBox11.Text.ToString();

                    xlworksheet.Cells[10, 36] = "= SUM(E10:AI10)";
                    xlworksheet.Cells[11, 36] = "= SUM(E11:AI11)";
                    xlworksheet.Cells[12, 36] = "= SUM(E12:AI12)";
                    xlworksheet.Cells[13, 36] = "= SUM(E13:AI13)";

                    xlworksheet.Cells[10, 37] = "= AJ10 - D10";
                    xlworksheet.Cells[11, 37] = "= AJ11 - D11";
                    xlworksheet.Cells[12, 37] = "= AJ12 - D12";
                    xlworksheet.Cells[13, 37] = "= AJ13 - D13";

                    //xlworksheet.Cells[10, 37] = raznisa_A;
                    //xlworksheet.Cells[11, 37] = raznisa_B;
                    //xlworksheet.Cells[12, 37] = raznisa_C;
                    //xlworksheet.Cells[13, 37] = raznisa_D;
                }
                catch
                {
                    xlworksheet.Application.Workbooks.Close();
                }
                finally
                {
                    xlworksheet.Application.Workbooks.Close();
                }

                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx");
                p.Start();
                TopMost = false;
                this.TopMost = false;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            labelFG1.Text = textBoxF1.Text;
            labelFN1.Text = textBoxF1.Text;
            labelFG2.Text = textBoxF2.Text;
            labelFN2.Text = textBoxF2.Text;
            labelFG3.Text = textBoxF3.Text;
            labelFN3.Text = textBoxF3.Text;
            labelFG4.Text = textBoxF4.Text;
            labelFN4.Text = textBoxF4.Text;

            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if(auto != 0)
                    {
                        if(auto == 1)
                        {
                            if((j - i  - 0) % 4 == 0)
                            {
                                dvg1[j, i].Value = true;
                            }
                            else
                            {
                                dvg1[j, i].Value = false;
                            }
                        }
                        else if(auto == 2)
                        {
                            if((j - i - 3) % 4 == 0)
                            {
                                dvg1[j, i].Value = true;
                            }
                            else
                            {
                                dvg1[j, i].Value = false;
                            }
                        }
                        else if(auto == 3)
                        {
                            if((j - i - 2) % 4 == 0)
                            {
                                dvg1[j, i].Value = true;
                            }
                            else
                            {
                                dvg1[j, i].Value = false;
                            }
                        }
                        else
                        {
                            if((j - i - 1) % 4 == 0)
                            {
                                dvg1[j, i].Value = true;
                            }
                            else
                            {
                                dvg1[j, i].Value = false;
                            }
                        }
                    }

                    if (Convert.ToBoolean(dvg1[j, i].Value))
                    {
                        array[i, j] = 2;
                    }
                    else
                    {
                        array[i, j] = 0;
                    }
                    if (j > 0 && j < 30)// Все столбики, кроме первого и последнего
                    {
                        if (array[i, j] == 2)
                        {
                            if (array[i, j - 1] == 2)
                            {
                                if (array[i, j - 1] == 2)
                                {
                                    dgv[j, i].Value = "24";
                                }
                                else
                                {
                                    dgv[j, i].Value = "16";
                                }
                                dgv[j + 1, i].Value = "8";
                            }
                            else
                            {
                                dgv[j, i].Value = "16";
                            }
                        }
                        else
                        {
                            if (array[i, j - 1] == 2)
                            {
                                dgv[j, i].Value = "8";
                            }
                            else
                            {
                                dgv[j, i].Value = "0";
                            }
                        }
                    }
                    else if (j == 0)// Первый столбик
                    {
                        if (array[i, j] == 2)
                        {
                            dgv[j, i].Value = "16";
                            dgv[j + 1, i].Value = "8";
                        }
                        else
                        {
                            dgv[j, i].Value = "0";
                        }
                    }
                    else if (j == 30)// Последний столбик
                    {
                        if (array[i, j] == 2)
                        {
                            if (array[i, j - 1] == 2)
                            {
                                dgv[j, i].Value = "24";
                            }
                            else
                            {
                                dgv[j, i].Value = "16";
                            }
                        }
                        else
                        {
                            if (array[i, j - 1] == 2)
                            {
                                dgv[j, i].Value = "8";
                            }
                            else
                            {
                                dgv[j, i].Value = "0";
                            }
                        }
                    }
                }
            }
            if (checkBox1.Checked)//Первая строчка
            {
                if (array[0, 0] == 2)
                {
                    dgv[0, 0].Value = "24";
                }
                else
                {
                    dgv[0, 0].Value = "8";
                }
            }
            if (checkBox2.Checked)//Вторая строчка
            {
                if (array[1, 0] == 2)
                {
                    dgv[0, 1].Value = "24";
                }
                else
                {
                    dgv[0, 1].Value = "8";
                }
            }
            if (checkBox3.Checked)//Третья строчка
            {
                if (array[2, 0] == 2)
                {
                    dgv[0, 2].Value = "24";
                }
                else
                {
                    dgv[0, 2].Value = "8";
                }
            }
            if (checkBox4.Checked)//Четвёртая строчка
            {
                if (array[3, 0] == 2)
                {
                    dgv[0, 3].Value = "24";
                }
                else
                {
                    dgv[0, 3].Value = "8";
                }
            }
            if (checkBox6.Checked)//Первая строчка
            {
                for (int i = 30; i >= 0; i--)
                {
                    if (Convert.ToInt32(dgv[i, 0].Value) == 8)
                    {
                        dgv[i, 0].Value = "0";
                        break;
                    }
                }
            }
            if (checkBox7.Checked)//Вторая строчка
            {
                for (int i = 30; i >= 0; i--)
                {
                    if (Convert.ToInt32(dgv[i, 1].Value) == 8)
                    {
                        dgv[i, 1].Value = "0";
                        break;
                    }
                }
            }
            if (checkBox8.Checked)//Третья строчка
            {
                for (int i = 30; i >= 0; i--)
                {
                    if (Convert.ToInt32(dgv[i, 2].Value) == 8)
                    {
                        dgv[i, 2].Value = "0";
                        break;
                    }
                }
            }
            if (checkBox9.Checked)//Четрёртая строчка
            {
                for (int i = 30; i >= 0; i--)
                {
                    if (Convert.ToInt32(dgv[i, 3].Value) == 8)
                    {
                        dgv[i, 3].Value = "0";
                        break;
                    }
                }
            }

            int sum_hours_A = 0, sum_hours_B = 0, sum_hours_C = 0, sum_hours_D = 0;
            int raznisa_A = 0, raznisa_B = 0, raznisa_C = 0, raznisa_D = 0;
            for (int i = 0; i < 31; i++)
            {
                sum_hours_A += Convert.ToInt32(dgv[i, 0].Value);
            }
            for (int i = 0; i < 31; i++)
            {
                sum_hours_B += Convert.ToInt32(dgv[i, 1].Value);
            }
            for (int i = 0; i < 31; i++)
            {
                sum_hours_C += Convert.ToInt32(dgv[i, 2].Value);
            }
            for (int i = 0; i < 31; i++)
            {
                sum_hours_D += Convert.ToInt32(dgv[i, 3].Value);
            }
            label16.Text = Convert.ToString(sum_hours_A);
            label17.Text = Convert.ToString(sum_hours_B);
            label18.Text = Convert.ToString(sum_hours_C);
            label19.Text = Convert.ToString(sum_hours_D);
            raznisa_A = sum_hours_A - Convert.ToInt32(textBox3.Text);//3 4 10 11
            raznisa_B = sum_hours_B - Convert.ToInt32(textBox4.Text);
            raznisa_C = sum_hours_C - Convert.ToInt32(textBox10.Text);
            raznisa_D = sum_hours_D - Convert.ToInt32(textBox11.Text);
            label20.Text = Convert.ToString(raznisa_A);
            label21.Text = Convert.ToString(raznisa_B);
            label22.Text = Convert.ToString(raznisa_C);
            label23.Text = Convert.ToString(raznisa_D);

            labelFG1.Text = textBoxF1.Text;
            labelFN1.Text = textBoxF1.Text;
            labelFG2.Text = textBoxF2.Text;
            labelFN2.Text = textBoxF2.Text;
            labelFG3.Text = textBoxF3.Text;
            labelFN3.Text = textBoxF3.Text;
            labelFG4.Text = textBoxF4.Text;
            labelFN4.Text = textBoxF4.Text;

            if (textBoxZP1.Text != "" &&
                textBoxZP2.Text != "" &&
                textBoxZP3.Text != "" &&
                textBoxZP4.Text != "")
            {
                labelZP1.Text = Convert.ToString((Convert.ToDouble(textBoxZP1.Text) / Convert.ToDouble(textBox3.Text)) * Convert.ToDouble(label16.Text));
                labelZP2.Text = Convert.ToString((Convert.ToDouble(textBoxZP2.Text) / Convert.ToDouble(textBox4.Text)) * Convert.ToDouble(label17.Text));
                labelZP3.Text = Convert.ToString((Convert.ToDouble(textBoxZP3.Text) / Convert.ToDouble(textBox10.Text)) * Convert.ToDouble(label18.Text));
                labelZP4.Text = Convert.ToString((Convert.ToDouble(textBoxZP4.Text) / Convert.ToDouble(textBox11.Text)) * Convert.ToDouble(label19.Text));
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                auto = 1;
            }
            else
            {
                auto = 0;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Сохрание
            Properties.Settings.Default.Save_name_1 = textBoxF1.Text;
            Properties.Settings.Default.Save_name_2 = textBoxF2.Text;
            Properties.Settings.Default.Save_name_3 = textBoxF3.Text;
            Properties.Settings.Default.Save_name_4 = textBoxF4.Text;
            Properties.Settings.Default.Save_salary_1 = textBoxZP1.Text;
            Properties.Settings.Default.Save_salary_2 = textBoxZP2.Text;
            Properties.Settings.Default.Save_salary_3 = textBoxZP3.Text;
            Properties.Settings.Default.Save_salary_4 = textBoxZP4.Text;

            Properties.Settings.Default.Save_Voda_1 = textBoxVoda1.Text;
            Properties.Settings.Default.Save_Voda_2 = textBoxVoda2.Text;
            Properties.Settings.Default.Save_Elektro_1 = textBoxElektro1.Text;
            Properties.Settings.Default.Save_Elektro_2 = textBoxElektro2.Text;
            Properties.Settings.Default.Save_Elektro_3 = textBoxElektro3.Text;

            Properties.Settings.Default.Save();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx";//C:\\Для файлов\\Счётчики.xlsx
            if (File.Exists(path))
            {
                if (checkBox10.Checked)
                {
                    Microsoft.Office.Interop.Excel.Application xlworksheet =
                    new Microsoft.Office.Interop.Excel.Application();

                    xlworksheet.Application.Workbooks.Open(
                        Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx", Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);

                    try
                    {
                        bool canWrite = false;
                        int counter = 0;
                        while (canWrite == false)
                        {
                            if (xlworksheet.Cells[6, counter + 3].Value == null)
                            {
                                canWrite = true;
                                break;
                            }
                            else
                            {
                                counter++;
                            }
                        }
                        if (canWrite)
                        {
                            xlworksheet.Cells[6, counter + 3].Value = textBoxVoda1.Text.ToString();
                            xlworksheet.Cells[7, counter + 3].Value = textBoxVoda2.Text.ToString();
                            xlworksheet.Cells[8, counter + 3].Value = textBoxElektro1.Text.ToString();
                            xlworksheet.Cells[9, counter + 3].Value = textBoxElektro2.Text.ToString();
                            xlworksheet.Cells[10, counter + 3].Value = textBoxElektro3.Text.ToString();
                        }
                    }
                    catch
                    {
                        xlworksheet.Application.Workbooks.Close();
                    }
                    finally
                    {
                        xlworksheet.Application.Workbooks.Close();
                    }
                    checkBox10.Checked = false;
                }
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(Environment.CurrentDirectory + @"\Для файлов\Табель.xlsx");
                p.Start();
                TopMost = false;
                this.TopMost = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxVoda1.Text = null;
            textBoxVoda2.Text = null;
            textBoxElektro1.Text = null;
            textBoxElektro2.Text = null;
            textBoxElektro3.Text = null;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(auto != 0)
            {
                auto = 1;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (auto != 0)
            {
                auto = 2;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (auto != 0)
            {
                auto = 3;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (auto != 0)
            {
                auto = 4;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if(textBoxHeatingAll.Text != "" && textBoxBuilding23HotWater.Text != "" && textBoxBuilding23СentralHeating.Text != "")
            {
                textBoxBuilding23All.Text = Convert.ToString(
                    Convert.ToDouble(textBoxBuilding23HotWater.Text) +
                    Convert.ToDouble(textBoxBuilding23СentralHeating.Text)
                );

                textBoxBuilding24.Text = Convert.ToString(
                    Convert.ToDouble(textBoxHeatingAll.Text) -
                    Convert.ToDouble(textBoxBuilding23All.Text)
                );
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBoxHeatingAll.Text = null;
            textBoxBuilding23HotWater.Text = null;
            textBoxBuilding23СentralHeating.Text = null;
            textBoxBuilding23All.Text = null;
            textBoxBuilding24.Text = null;
        }

        private void buttonExportData_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + @"\Для файлов\Тепловые показания счётчиков.xlsx";//C:\\Для файлов\\Счётчики.xlsx
            if (File.Exists(path))
            {
                Microsoft.Office.Interop.Excel.Application xlworksheet =
                new Microsoft.Office.Interop.Excel.Application();

                xlworksheet.Application.Workbooks.Open(
                    Environment.CurrentDirectory + @"\Для файлов\Тепловые показания счётчиков.xlsx", Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                try
                {
                    for(int i = 0; i < 12; i++)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            xlworksheet.Cells[6 + i, j + 4].Value = dataGridView2[j + 1, i].Value;
                        }
                        /*
                        if (xlworksheet.Cells[6 + i, 4].Value == null) счётчики
                        {
                            xlworksheet.Cells[6 + i, 4].Value = textBoxBuilding23All.Text;
                            xlworksheet.Cells[6 + i, 5].Value = textBoxBuilding24.Text;
                            xlworksheet.Cells[6 + i, 6].Value = textBoxHeatingAll.Text;
                            break;
                        }
                        */
                    }
                }
                catch
                {
                    xlworksheet.Application.Workbooks.Close();
                }
                finally
                {
                    xlworksheet.Application.Workbooks.Close();
                }

                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(Environment.CurrentDirectory + @"\Для файлов\Тепловые показания счётчиков.xlsx");
                p.Start();
                TopMost = false;
                this.TopMost = false;

            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                if (Convert.ToString(dataGridView2[1, i].Value) == null || Convert.ToString(dataGridView2[1, i].Value) == "")
                {
                    dataGridView2[1, i].Value = textBoxBuilding23All.Text;
                    dataGridView2[2, i].Value = textBoxBuilding24.Text;
                    dataGridView2[3, i].Value = textBoxHeatingAll.Text;
                    break;
                }
            }

            string[,] arrayInputData = new string[3, 12];
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    arrayInputData[i,j] = Convert.ToString(dataGridView2[i + 1, j].Value);
                }
            }

            for(int j = 0; j < 12; j++)
            {
                File.WriteAllText(Environment.CurrentDirectory + @"\Для файлов\Сохранение тепловых показаний.txt", 
                    arrayInputData[0, j]);
            }

            File.WriteAllText(Environment.CurrentDirectory + @"\Для файлов\Сохранение тепловых показаний.txt", "");

            for (int j = 0; j < 12; j++)
            {
                File.AppendAllText(Environment.CurrentDirectory + @"\Для файлов\Сохранение тепловых показаний.txt",
                    Convert.ToString(arrayInputData[0, j]) + " " +
                    Convert.ToString(arrayInputData[1, j]) + " " +
                    Convert.ToString(arrayInputData[2, j]) + "\n");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("row " + e.RowIndex + ", col " + e.ColumnIndex);
            if(e.RowIndex >= 0)
            {
                if (dataGridView2[4, e.RowIndex].Selected)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        dataGridView2[i, e.RowIndex].Value = null;
                    }
                }
            }
        }

        private void dvg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 31; j++)
                {
                    if (Convert.ToBoolean(dvg1[j, i].Value))
                    {
                        array[i, j] = 2;
                    }
                    else
                    {
                        array[i, j] = 0;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = comboBox1.Text + ":" + comboBox2.Text + ":" + comboBox3.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = comboBox1.Text + ":" + comboBox2.Text + ":" + comboBox3.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = comboBox1.Text + ":" + comboBox2.Text + ":" + comboBox3.Text;
        }

        private void buttonImportData_Click(object sender, EventArgs e)
        {
            //string path1 = disk + ":\\Для файлов\\Месячная ведомость учёта тепловой энергии и теплоносителя за Август 2024 Гостиница горячая вода.txt";
            //string path2 = disk + ":\\Для файлов\\Месячная ведомость учёта тепловой энергии и теплоносителя за Август 2024 Гостиница горячая вода.txt";
            //string path3 = disk + ":\\Для файлов\\Месячная ведомость учёта тепловой энергии и теплоносителя за Август 2024 Гостиница горячая вода.txt";

            //string[] building23All = File.ReadAllLines(path1);
            //char[,] bulding12AllValue = null;

            //bulding12AllValue = building23All[90];

            //char[] building23AValue1 = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

            //for (int i = 0; i < 8; i++)
            //{
                //building23AValue1[i] = bulding12AllValue[90, 10 + i];
            //}

            //richTextBox1.Text = building23AValue1.ToString();


            //File.ReadLines(path2);
            //File.ReadLines(path3);
            //textBox1
        }
    }
}
