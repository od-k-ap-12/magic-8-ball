using System;
using System.Collections.Generic;
using System.IO;
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

namespace magic_8_ball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textboxQuestion.Text == "") return;
            List<string> Answers = GetPossibleAnswers();
            textboxAnswer.Text = Answers[new Random().Next(0,Answers.Count)];
        }

        private List<string> GetPossibleAnswers()
        {
            List<string> Answers = new List<string>();
            StreamReader sr = new StreamReader("Answers.txt", Encoding.UTF8);
            if (sr != null)
            {
                while (!sr.EndOfStream)
                {
                    Answers.Add(sr.ReadLine() + '\n');
                }
            }
            sr.Close();
            return Answers;
        }
    }
}
