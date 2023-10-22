using System;

namespace Options
{
    public class Options
    {
        public static int Function(int[,] matr, int N, int M)
        {
            int Pol = 0;
            int Otr = 0;
            for (int j = 0; j < N; j++)
            {

                for (int i = 0; i < M; i++)
                {
                    if (matr[j, i] > 0)
                        Pol++;
                    else if (matr[j, i] < 0)
                        Otr++;                  
                }
                if (Pol == Otr)
                {
                    return j + 1;
                }
                Pol = 0;
                Otr = 0;

            }
            return -1;
        }
        public static void Massiv(out int[,] matr, int N, int M, int RandMax)
        {
            Random rnd = new Random();
            matr = new int[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    matr[i, j] = rnd.Next(-RandMax, RandMax);
            //datagrid.ItemsSource = VisialArray.ToDataTable(matr).DefaultView;
            //var res = new DataTable();
            //for (int i = 0; i < matr.GetLength(1); i++)
            //{
            //    res.Columns.Add("col" + (i + 1), typeof(T));
            //}

            //for (int i = 0; i < matr.GetLength(0); i++)
            //{
            //    var row = res.NewRow();

            //    for (int j = 0; j < matr.GetLength(1); j++)
            //    {
            //        row[j] = matr[i, j];
            //    }

            //    res.Rows.Add(row);
            //}

            //return res;
        }
    }
}
