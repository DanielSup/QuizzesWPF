using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace quizzes
{
    public class QuestionManager : INotifyPropertyChanged
    {
        ObservableCollection<Question> questions = new ObservableCollection<Question>();
        public string QuestionCount { get { return questions.Count + ""; } }
        private string path = "questions.xml";

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Question> Questions { get { return questions; } }
        public void AddQuestion(string question, string optionA, string optionB, string optionC, string
            optionD, int? correctAnswer)
        {
            if (question.Length < 1)
            {
                throw new ArgumentNullException("Musí být zadán text otázky.");
            }
            if (optionA.Length < 1 || optionB.Length < 1 || optionC.Length < 1 || optionD.Length < 1)
            {
                throw new ArgumentNullException("Musí být zadány všechny možnosti.");
            }
            if (correctAnswer == null)
            {
                throw new ArgumentNullException("Musí být zvolena správná odpověď.");
            }
            questions.Add(new Question(question, optionA, optionB, optionC, optionD, (Choice)correctAnswer.Value));
            MakeChange("QuestionCount");
        }
        public void UpdateQuestion(Question questionObject, string question, string optionA, string optionB, string optionC, string
            optionD, int? correctAnswer)
        {
            foreach(Question quest in questions)
            {
                if(questionObject == quest)
                {
                    questionObject.Text = question;
                    questionObject.OptionA = optionA;
                    questionObject.OptionB = optionB;
                    questionObject.OptionC = optionC;
                    questionObject.OptionD = optionD;
                    questionObject.CorrectAnswer = (Choice)(correctAnswer.Value);
                    break;
                }
                MakeChange("Questions");
                questionObject.MakeChange("Text");
            }
        }
        public void Remove(Question question)
        {
            questions.Remove(question);
            MakeChange("QuestionCount");
        }

        protected void MakeChange(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(questions.GetType());
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    questions = (ObservableCollection<Question>) serializer.Deserialize(sr);
                }
            } else
            {
                questions = new ObservableCollection<Question>();
            }
        }
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(questions.GetType());
            using (StreamWriter sr = new StreamWriter(path))
            {
                serializer.Serialize(sr, questions);
            }
        }
    }
}
