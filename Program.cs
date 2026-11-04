

namespace Examanation_System_Console_App
{

    class Mode { 
        private static List<Question> questions = new List<Question>();
        private static List<TrueFalseQuestion> trueFalseQuestions = new List<TrueFalseQuestion>();
        private static  List<ChooseOneQuestion> chooseOneQuestions = new List<ChooseOneQuestion>();
        private static  List<MultipleChoiceQuestion> multipleChoiceQuestions = new List<MultipleChoiceQuestion>();

        public static void DoctorMode()
        {
            Console.WriteLine("How many questions do you want to add?");
            int numQuestions = Convert.ToInt32(Console.ReadLine());
            
            for(int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"Adding question {i+1}:");
                Console.WriteLine("Select question type: 1 - True/False, 2 - Choose One, 3- Multiple Choice");
                int questionType = Convert.ToInt32(Console.ReadLine());
                switch(questionType)
                {
                    case 1:

                        
                        Console.Write("Enter Question Level (Easy/Medium/Hard):");
                        string levelInput = Console.ReadLine();
                        QuestionLevel level;

                        switch(levelInput.ToLower())
                        {
                            case "easy":
                                level = QuestionLevel.Easy;
                                break;
                            case "medium":
                                level = QuestionLevel.Medium;
                                break;
                            case "hard":
                                level = QuestionLevel.Hard;
                                break;
                            default:
                                Console.WriteLine("Invalid level. Defaulting to Easy.");
                                level = QuestionLevel.Easy;
                                break;
                        }

                        Console.Write("Enter the question header:");
                        string headerTF = Console.ReadLine();

                        Console.Write("Enter Question marks:");
                         int marksTF = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter the correct answer (true/false):");
                        string answerTF = Console.ReadLine();

                        TrueFalseQuestion tfQuestion = new TrueFalseQuestion(headerTF, marksTF, level, answerTF);
                        trueFalseQuestions.Add(tfQuestion);
                        questions.Add(tfQuestion);

                        break;
                    case 2:


                        Console.Write("Enter Question Level (Easy/Medium/Hard):");
                        string levelInput2 = Console.ReadLine();
                        QuestionLevel level2;

                        switch (levelInput2.ToLower())
                        {
                            case "easy":
                                level2 = QuestionLevel.Easy;
                                break;
                            case "medium":
                                level2  = QuestionLevel.Medium;
                                break;
                            case "hard":
                                level2 = QuestionLevel.Hard;
                                break;
                            default:
                                Console.WriteLine("Invalid level. Defaulting to Easy.");
                                level2 = QuestionLevel.Easy;
                                break;
                        }

                        Console.Write("Enter the question header:");
                        string headerchooseone = Console.ReadLine();

                        Console.Write("Enter Question marks:");
                        int markschooseone = Convert.ToInt32(Console.ReadLine());

                        List<string> choices = new List<string>();
                        for(int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter choice {j + 1}:");
                            string choice = Console.ReadLine();
                            choices.Add(choice);
                        }

                        Console.Write("Enter the correct choice number (1-4):");

                        string  correctChoiceNumber = Console.ReadLine();

                        ChooseOneQuestion chooseOneQuestion = new ChooseOneQuestion(headerchooseone, markschooseone, level2, choices.ToArray(), correctChoiceNumber);
                        chooseOneQuestions.Add(chooseOneQuestion);
                        questions.Add(chooseOneQuestion);







                        break;
                    case 3:

                        Console.Write("Enter Question Level (Easy/Medium/Hard):");
                        string levelInput3 = Console.ReadLine();
                        QuestionLevel level3;

                        switch (levelInput3.ToLower())
                        {
                            case "easy":
                                level3 = QuestionLevel.Easy;
                                break;
                            case "medium":
                                level3 = QuestionLevel.Medium;
                                break;
                            case "hard":
                                level3  = QuestionLevel.Hard;
                                break;
                            default:
                                Console.WriteLine("Invalid level. Defaulting to Easy.");
                                level3 = QuestionLevel.Easy;
                                break;
                        }

                        Console.Write("Enter the question header:");
                        string headermultiplechoice= Console.ReadLine();

                        Console.Write("Enter Question marks:");
                        int marksmultiplechoice = Convert.ToInt32(Console.ReadLine());


                        List<string> multiplechoices = new List<string>();
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter choice {j + 1}:");
                            string choice = Console.ReadLine();
                            multiplechoices.Add(choice);
                        }

                        Console.Write("Enter correct answers (comma-separated, e.g., 1,3):");
                        string correctAnswersInput = Console.ReadLine();
                        string[] correctAnswersArray = correctAnswersInput.Split(',');
                       
                        for (int k = 0; k < correctAnswersArray.Length; k++)
                        {
                            correctAnswersArray[k] = correctAnswersArray[k].Trim();
                        }

                        MultipleChoiceQuestion multipleChoiceQuestion = new MultipleChoiceQuestion(headermultiplechoice, marksmultiplechoice, level3, multiplechoices.ToArray(),correctAnswersArray );
                        multipleChoiceQuestions.Add(multipleChoiceQuestion);
                        questions.Add(multipleChoiceQuestion);

                        break;
                    default:
                        Console.WriteLine("Invalid question type. Please try again.");
                        i--; 
                        break;
                }
            }
        }

        public static void StudentMode()
        {

            int counter = 0;

            int totalscore=0;


            Console.WriteLine("Choose Exam Type: 1- Practical Exam 2- Final Exam");
            int examType = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Question Level (Easy/Medium/Hard):");
            string levelInput = Console.ReadLine();

            QuestionLevel level;

            switch (levelInput.ToLower())
            {
                case "easy":
                    level = QuestionLevel.Easy;
                    break;
                case "medium":
                    level = QuestionLevel.Medium;
                    break;
                case "hard":
                    level = QuestionLevel.Hard;
                    break;
                default:
                    Console.WriteLine("Invalid level. Defaulting to Easy.");
                    level = QuestionLevel.Easy;
                    break;
            }

            Console.WriteLine("--- Exam Started ---");

            switch (examType)
            {

                case 1:

                  

                    for (int i = 0; i < questions.Count/2; i++)
                    {
                        if (questions[i].Level == level)
                        {
                            questions[i].Display();
                            Console.Write("Your Answer:");

                            string answer = Console.ReadLine();
                            if (questions[i].CheckAnswer(answer))
                            {
                                counter += questions[i].Marks;
                            }

                            totalscore+= questions[i].Marks;
                        }
                    }

                    break;
                case 2:

                    for (int i = 0; i < questions.Count; i++)
                    {
                        if (questions[i].Level == level)
                        {
                            questions[i].Display();
                            Console.Write("Your Answer:");

                            string answer = Console.ReadLine();

                            if (questions[i].CheckAnswer(answer))
                            {
                                counter += questions[i].Marks;
                            }

                            totalscore += questions[i].Marks;
                        }
                    }
                    break;
            }

            Console.WriteLine($"Your score: {counter}/{totalscore}");

        }

    }
    public enum QuestionLevel
    {
        Easy,
        Medium,
        Hard
    }

    class Question
    {
        public string Header { get; set; }
        public int Marks { get; set; }
        public QuestionLevel Level { get; set; }

        public Question(string header, int marks, QuestionLevel level)
        {
            Header = header;        
            Marks = marks;
            Level = level;
        }

        public virtual void Display()
        {
            Console.Write($"{Header} ");
        }

        public virtual bool CheckAnswer(string userAnswer)
        {
            return false;
        }
     
       
    }

    class TrueFalseQuestion : Question
    {
        public string Answer { get; set; }
        public TrueFalseQuestion(string header, int marks, QuestionLevel level, string answer)
            : base(header, marks, level)
        {
            Answer = answer;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"(True/False) - Marks: {Marks}");
        }

        public override bool CheckAnswer(string userAnswer)
        {
            if (userAnswer == null)
            {
                return false;
            }

            return Answer.ToLower() == userAnswer.ToLower();
        }

    }

    class ChooseOneQuestion : Question
    {
        public List<string> Choices { get; set; }
        public string CorrectChoiceNumber { get; set; }
        public ChooseOneQuestion(string header, int marks, QuestionLevel level, string[] choices, string correctChoiceNumber)
            : base(header, marks, level)
        {
            Choices = new List<string>(choices);
            CorrectChoiceNumber = correctChoiceNumber;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"(Choose One) - Marks: {Marks}");
            Console.WriteLine("Choices:");
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswer(string userAnswer)
        {
            if (userAnswer == null)
            {
                return false;
            }

            return CorrectChoiceNumber == userAnswer;
        }
    }

    class MultipleChoiceQuestion : Question
    {
        public List<string> Choices { get; set; }
        public string[] CorrectChoiceIndices { get; set; }
        public MultipleChoiceQuestion(string header, int marks, QuestionLevel level, string[] choices, string[] correctChoiceIndices)
            : base(header, marks, level)
        {
            Choices = new List<string>(choices);
            CorrectChoiceIndices = correctChoiceIndices;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"(Multiple Choice) - Marks: {Marks}");
            Console.WriteLine("Choices:");
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswer(string userAnswer)
        {
            if (userAnswer == null)
            {
                return false;
            }

            string[] studentAnswers = userAnswer.Split(',');

            if (studentAnswers.Length != CorrectChoiceIndices.Length)
            {
                return false;
            }

            for (int i = 0; i < CorrectChoiceIndices.Length; i++)
            {
                bool answerFound = false;

                for (int j = 0; j < studentAnswers.Length; j++)
                {
                    if (CorrectChoiceIndices[i].Trim() == studentAnswers[j].Trim())
                    {
                        answerFound = true;
                        break;
                    }
                }

                if (!answerFound)
                {
                    return false;
                }
            }

            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int choice;
            do
            {
                Console.WriteLine ();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Doctor ");
                Console.WriteLine("2. Student ");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
    
                 choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        Mode.DoctorMode();
                        break;
                    case 2:
                        Mode.StudentMode();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }

                
               } while (choice != 3);
            }
            
    }
}
