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
using mztrix.Controller;



namespace mztrix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        ushort row,column,row2,column2;
        MatrixController controller;
        double[,] array;
        double[,] array2;
        TextBox[,] textBoxes;

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox3.SelectedIndex > 0)
            {
                column2 = (ushort)comboBox3.SelectedIndex;
            }
            if (comboBox2.SelectedIndex>0)
            {
                array2 = new double[row2, column2];
                textBoxes = new TextBox[row2, column2];
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox2.SelectedIndex > 0)
            {
                row2 = (ushort)comboBox2.SelectedIndex;
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
               column = (ushort)comboBox1.SelectedIndex;
            }
            if (comboBox.SelectedIndex>0)
            {
                textBoxes = new TextBox[row, column];
                DrawTextBox(row, column, textBoxes);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex>0)
            {
                row =(ushort)comboBox.SelectedIndex;
            }
        }

        private void DrawTextBox(ushort row,ushort column,TextBox[,] textBoxes)
        {
            double x, y;
            const int height = 30;
            const int width = 50;
            Thickness margin;
            y = 80;
            x = 10;
            for (int i = 0; i < row; i++)
            {
               
                for (int j = 0; j < column; j++)
                {
                    textBoxes[i, j] = new TextBox();
                    textBoxes[i, j].Width = width;
                    textBoxes[i, j].Height = height;
                    margin = new Thickness();
                    margin.Top = y;
                    margin.Left = x;
                    textBoxes[i, j].Margin = margin;
                    x += 80;

                }
                x = 10;
                y += 50;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    grid.Children.Add(textBoxes[i, j]);
                }
            }
        }
    }
}
