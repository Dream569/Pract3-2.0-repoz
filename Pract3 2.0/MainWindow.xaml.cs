using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using test1;

namespace Pract3_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] matr;
        int RandMax;
        bool isLouaded = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Опрограмме_Click(object sender, RoutedEventArgs e) //Кнопка "О программе"
        {
            MessageBox.Show("Разработчик: Мелехин Дмитрий. Задание: Дана целочисленная матрица размера M × N. Найти номер первой из ее строк, содержащих равное количество положительных и отрицательных элементов (нулевые элементы матрицы не учитываются). Если таких строк нет, то вывести 0.");
        }

        private void Выход_Click(object sender, RoutedEventArgs e) //Кнопка "Выход"
        {
            this.Close();
        }

        private void Очистить_Click(object sender, RoutedEventArgs e) //Кнопка "Очистить"
        {
            Clerar();
        }
        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null) Func.Functions.Save(matr);
            else MessageBox.Show("Создайте таблицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void Открыть_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null) Func.Functions.Load(out matr, out isLouaded);
            else MessageBox.Show("Создайте таблицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Создать_Click(object sender, RoutedEventArgs e)
        {
            bool f1 = int.TryParse(Strok.Text, out int M);
            bool f2 = int.TryParse(Stolb.Text, out int N);
            bool f3 = int.TryParse(Diap.Text, out RandMax);

            if (f1 == true && f2 == true && f3 == true)
            {
                if (M > 0 && N > 0)
                {
                    Options.Options.Massiv(out matr, M, N, RandMax);
                    datagrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                }
                else
                    MessageBox.Show("Введите число больше 0");
            }
            else
                MessageBox.Show("Я люблю числа, а не буквы");

        }
        private void Вывести_Click(object sender, RoutedEventArgs e)
        {
            if (matr == null)
            {
                MessageBox.Show("Создайте массив");
                return;
            }
            int nom = Options.Options.Function(matr, matr.GetLength(0), matr.GetLength(1));
            Rezul.Text = nom.ToString();
        }

        private void Clerar()
        {
            Strok.Clear();
            Stolb.Clear();
            Rezul.Clear();
            Diap.Clear();
            datagrid.ItemsSource = null;
            matr = null;
        }
    }
}
