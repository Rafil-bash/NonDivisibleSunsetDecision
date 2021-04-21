using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faizov_R.R._NonDivizibleSunset
{
    public partial class NonDivisibleSunset : Form
    {
        public NonDivisibleSunset()
        {
            InitializeComponent();
        }
        /*
         * Создаем отдельный метод для обработки решения         * 
         * неделимое подмножество или non-divisible subset
        */
        static int NonDivisibleSunsetDecision(int[] InputData,
                                        int N, int K)
        {
            int[] f = new int[K];//   Создаем массив f размером K
            for (int i = 0; i < K; i++)
                f[i] = 0;        //   Обнуляем массив 

            for (int i = 0; i < N; i++)
                f[InputData[i] % K]++;
            /* Перебираем массив InputData и записываем в f таким образом:
             * От каждого элемента массива InputData находим остаток при делении на K
             * Например InputData[0]=7;7%6=1;
             * Далее В элемент массива f соотвествующий этому остатку добавляем +1;
             * т.е. 7%6=1;f[1]=1;если InputData[1]=7;7%6=1;f[1]=1+1 т.е.f[1]=2 ;
             */

            if (K % 2 == 0)
                f[K / 2] = Math.Min(f[K / 2], 1);
            /*
             * Далее проверяем на четность K,если K четное 
             * то перебираем элемент массив f[K/2] и присваиваеи ему минимальное
             * от f[K / 2] и 1
             */
            // 


            int res = Math.Min(f[0], 1);// создаем переменную int res и присваиваем минимальную из f[0] и 1
            
            
            for (int i = 1; i <= K / 2; i++)
                res += Math.Max(f[i], f[K - i]);
            /*   
             *   создаем цикл в диапазоне от i=1 и i <= K / 2
             *   Суммируем все максимальные значения в диапазоне f[i], f[K - i]
             *   Их сумма и будет нашим решением
            */
            return res;
        }



       

        private void bResult_Click_1(object sender, EventArgs e)
        {
            
                string q;
                string pathToFileInput, pathToFileOutput;

            /*
             * Условие, если выбирается rbChoiseInput00
             * то входные данные input 00 и должно сохранятся в output 00 ;
             * Если 2-ая кнопка  то входные данные input 16 
             * и должно сохранятся в output 16
              */

            if (rbChoiseInput00.Checked)
                {
                    pathToFileInput = "C:\\Faizov R.R. NonDivizibleSunset\\input\\input00.txt";
                    pathToFileOutput = "C:\\Faizov R.R. NonDivizibleSunset\\output\\output00.txt";
                }
                else
                {
                
                    pathToFileInput = "C:\\Faizov R.R. NonDivizibleSunset\\input\\input16.txt";
                    pathToFileOutput = "C:\\Faizov R.R. NonDivizibleSunset\\output\\output16.txt";
                }

            //  Если ничего не выбрано то выводится сообщение

            if (!rbChoiseInput00.Checked && !rbChoiseInput16.Checked)
            {
                
                MessageBox.Show("Ничего не выбрано");
                return;

            }

            //   Переходим к решению

           

            //     Работа с входными данными
                string readAllFile = File.ReadAllText(pathToFileInput);// считываем входные данные из input
                string[] readEveryLine = new string[pathToFileInput.Length];// получаем неупорядоченный массив данных
                string[] OrderedInputData = readAllFile.Split(new char[] { ' ', ',', '\n' });// переводим данные в упорядоченный вид
                string solution;

            //    Переменные для решения
                int N = Convert.ToInt32(OrderedInputData[0]);
                int K = Convert.ToInt32(OrderedInputData[1]); ;
                int[] InputData = new int[N];//  Создаем массив размером N




            //  Переводим Входные данные с типа String в тип Int
            for (int i = 2, j = 0; i < OrderedInputData.Length; i++, j++)
                {
                    InputData[j] = Convert.ToInt32(OrderedInputData[i]);

                }
                

                //   Решение

            Directory.CreateDirectory("C:\\Faizov R.R. NonDivizibleSunset\\output");//   Создаем папку в диске C для записи output
            solution = Convert.ToString(NonDivisibleSunsetDecision(InputData,
                                             N, K));//   Получаем само решение, вызвав метод NonDivisibleSunsetDecision
            File.WriteAllText(pathToFileOutput, solution);//   Записали решение как output **.txt в нами созданую папку output

            //   Оформление для проги

            //   Прописали команды для очистки lbAllSolution при каждом клике кнопки и записи новых операций
            q = null;
            for (int i = 2; i < OrderedInputData.Length; i++)
            {
                q = q + " " + OrderedInputData[i];
            }            
            lbAllSolution.Items.Clear();
            
            //   Оформление приложения

            //  ListBoxs
            lbAllSolution.Items.Add("N=" + OrderedInputData[0]);
            lbAllSolution.Items.Add("K=" + OrderedInputData[1]);
            lbAllSolution.Items.Add(q);
            lbAllSolution.Items.Add("k для S'= " + solution);

            //  Labels
            if (rbChoiseInput00.Checked)
            {
                label6.Text = solution;//  output 00
            }
            if (rbChoiseInput16.Checked)
            {
                label7.Text = solution;//  output 16
            }
            
        }

      
    }
    }

