using Microsoft.Win32;
using System;
using System.IO;

namespace Func
{
    public class Functions
    {
        public static void Save(int[,] matr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.* | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine($"{matr.GetLength(0)}\n{matr.GetLength(1)}");
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        file.WriteLine(matr[i, j]);
                    }
                }
                file.Close();
            }
        }
        /// <summary>
        /// Чтение матрицы из файла
        /// </summary>
        /// <param name="matr">Матрица</param>
        /// <param name="isLoaded">Загружена ли матрица</param>
        public static void Load(out int[,] matr, out bool isLoaded)
        {
            // Создаём и настраиваем элемент OpenFileDialog
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* |Текстовые файлы (*.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие матрицы";

            if (open.ShowDialog() == true) // Открываем диалоговое окно и при успехе работаем с файлом
            {
                StreamReader file = new StreamReader(open.FileName); // Создаем поток для работы с файлом и указываем ему имя файла

                int rowCount = Convert.ToInt32(file.ReadLine()),
                    columnCount = Convert.ToInt32(file.ReadLine());

                matr = new int[rowCount, columnCount]; // Создаём матрицу
                for (int i = 0; i < matr.GetLength(0); i++)
                    for (int j = 0; j < matr.GetLength(1); j++)
                        matr[i, j] = Convert.ToInt32(file.ReadLine()); // Считываем матрицу из файла

                file.Close();

                isLoaded = true;
            }
            else
            {
                matr = null;
                isLoaded = false;
            }
        }
    }
}
