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

namespace KMiSOIB_lab
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

        private void Lb1_Button_Click(object sender, RoutedEventArgs e) { new Lab1().Show(); }
        private void Lb2_Button_Click(object sender, RoutedEventArgs e) { new Lab2().Show(); }
        
        private void Lb3_Button_Click(object sender, RoutedEventArgs e) { new Lab3().Show(); }
        private void Lb4_Button_Click(object sender, RoutedEventArgs e) { new Lab4().Show(); }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
