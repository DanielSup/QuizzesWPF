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
using System.Windows.Shapes;

namespace quizzes
{
    /// <summary>
    /// Interaction logic for AddQuestionWithSelection.xaml
    /// </summary>
    public partial class AddQuestionWithSelection : Window
    {
        private QuestionManager manager;
        public AddQuestionWithSelection(QuestionManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                manager.AddQuestion(Question.Text, OptionA.Text, OptionB.Text,
                    OptionC.Text, OptionD.Text, correct.SelectedIndex);
                manager.Save();
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
