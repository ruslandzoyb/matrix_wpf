using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace Matrix_name
{
    class Operations
    {
       public static Matrix Addition(Matrix first,Matrix second)
        {
           
            if (first.Row==second.Row && first.Column==second.Column)
            {
                Matrix matrix = new Matrix(first.Row, first.Column);
                for (ushort i = 0; i < first.Row; i++)
                {
                    for (ushort j = 0; j < first.Column; j++)
                    {
                        matrix[i, j] = first[i, j] + second[i, j];
                    }
                }
                return matrix;
            }
            else
            {
                throw new Exception("Не равные матрицы ");
            }
        }
       public static Matrix Substraction (Matrix first,Matrix second)
        {
            if (first.Row == second.Row && first.Column == second.Column)
            {
                Matrix matrix = new Matrix(first.Row, first.Column);
                for (ushort i = 0; i < first.Row; i++)
                {
                    for (ushort j = 0; j < first.Column; j++)
                    {
                        matrix[i, j] = first[i, j] - second[i, j];
                    }
                }
                return matrix;
            }
            else
            {
                throw new Exception("Не равные матрицы ");
            }
        }
        public static Matrix Multiplication(Matrix first,Matrix second)
        {
           
            if (first.Column == second.Row)
            {
                Matrix matrix = new Matrix(first.Row, second.Column);
                for (ushort i = 0; i < first.Row; i++)
                {
                    for (ushort j = 0; j < second.Column; j++)
                    {
                        matrix[i, j] = 0;

                        for (ushort k = 0; k < first.Column; k++)
                        {
                            matrix[i, j] += first[i, k] * second[k, j];
                        }
                    }
                    
                }
                return matrix;
            }
            else
            {
                throw new Exception("");
            }
        }
        public static void Serialize (Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            string directory = @"D:\.NET\Matrix\Matrix\Saved";
            string path;
            Console.WriteLine("Введите название файла для сохранения ");
             string path_enter = Console.ReadLine();
            path = Path.Combine(directory, path_enter+".dat");
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                Console.WriteLine("Такое имя уже существует ");
                Serialize(matrix);
            }
            else
            {
                              
                using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    
                    formatter.Serialize(fs, matrix);
                }
            }
            

        }
        public static Matrix Deserilize()
        {
            string directory = @"D:\.NET\Matrix\Matrix\Saved";
            string path;
            Console.WriteLine("Введите имя файла");
            path = Console.ReadLine();
            string total_path = Path.Combine(directory, path+".dat");
            FileInfo file = new FileInfo(total_path);
            if (file.Exists)
            {
                using (FileStream stream = new FileStream(total_path,FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Matrix matrix = (Matrix)formatter.Deserialize(stream);
                    return matrix;
                }
            }
            else
            {
                return Deserilize();
            }

        }



    }
}
