using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizzes
{
    public enum Choice { A, B, C, D }
    public class Question : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Question()
        {
        }
        public void MakeChange(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public Question(string text, string optionA, string optionB, string optionC, string optionD, Choice correctAnswer)
        {
            Text = text;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
            OptionD = optionD;
            CorrectAnswer = correctAnswer;
        }

        public string Text { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public Choice CorrectAnswer { get; set; }
        public int Answer { get { return (int)CorrectAnswer; } set { CorrectAnswer = (Choice)value; } }
        public override string ToString()
        {
            return this.Text;
        }
    }
}
