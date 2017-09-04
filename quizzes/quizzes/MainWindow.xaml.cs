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

namespace quizzes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuestionManager manager = new QuestionManager();
        public MainWindow()
        {
            manager.Load();
            DataContext = manager;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                manager.Remove((Question)ListOfQuestions.SelectedItem);
                manager.Save();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionWithSelection dialog = new AddQuestionWithSelection(manager);
            dialog.ShowDialog();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                manager.UpdateQuestion((Question)ListOfQuestions.SelectedItem, Question.Text, OptionA.Text, OptionB.Text,
                    OptionC.Text, OptionD.Text, correct.SelectedIndex);
                manager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
