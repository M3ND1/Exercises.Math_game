// See https://aka.ms/new-console-template for more information
//change history points to string
//declare
//class Points
//{
//    public int Points_Achieved { get; set; }
//    public int Points_Total { get; set; }

//    public Points(int points_achieved, int points_total)
//    {
//        Points_Achieved = points_achieved;
//        Points_Total= points_total;
//    }
//    public override string ToString()
//    {
//        return Points_Achieved + "/" + Points_Total;
//    }
//}

List<int> history = new List<int>();
//history.Add(new Points(1, 2));
Random rnd = new Random();
int first_number, second_number;
int solution;
int number_of_games = 5;
int correct_questions = 0;
while (true)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("Choose your game by entering number of game: \n");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.BackgroundColor = ConsoleColor.Black;
    //time stop 1.500ms
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("1: Adding");
    Console.WriteLine("2: Subtraction");
    Console.WriteLine("3: Multiplication");
    Console.WriteLine("4: Division");
    Console.WriteLine("5: Check Your history");
    Console.WriteLine("6: All random");
    Console.WriteLine("7: Exit from program");
    //input3
    int selection;
    while (true)
    {
        try
        {
            selection = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            break;
        }
        catch(FormatException) 
        {
            //change body color to red for sec and then ot black again 
            //user will know that he make smth wrong
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("Please, provide proper number. Not string! \n\n");
            Console.WriteLine("1: Adding");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Multiplication");
            Console.WriteLine("4: Division");
            Console.WriteLine("5: Check Your history");
            Console.WriteLine("6: All random");
            Console.WriteLine("7: Exit from program");
        }
    }
    Console.Clear();
    if (selection == 7) { break; }
    number_of_games = 5;
    switch (selection)
    {
        case 1:
            Console.Clear();
            while (number_of_games > 0)
            {
                first_number = rnd.Next(10);
                second_number = rnd.Next(10);
                Console.Clear();
                Console.WriteLine("{0} + {1} \t\tYour points: {2}", first_number, second_number, correct_questions + "/5");
                solution = Convert.ToInt32(Console.ReadLine()); //try catch here?
                if (solution == (first_number + second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            history.Add(correct_questions);
            correct_questions = 0;
            break;
        case 2:
            Console.Clear();
            while (number_of_games > 0)
            {
                first_number = rnd.Next(10);
                second_number = rnd.Next(5);
                if (second_number == 0) second_number++;
                Console.WriteLine("{0} - {1} \t\tYour points: {2}", first_number, second_number, correct_questions + "/5");
                solution = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (solution == (first_number - second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            history.Add(correct_questions);
            correct_questions = 0;
            break;
        case 3:
            Console.Clear();
            while (number_of_games > 0)
            {
                first_number = rnd.Next(1, 11);
                second_number = rnd.Next(1, 11);
                Console.WriteLine("{0} * {1} \t\tYour points: {2}", first_number, second_number, correct_questions + "/5"); ;
                solution = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (solution == (first_number * second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            history.Add(correct_questions);
            correct_questions = 0;
            break;
        case 4:
            while (number_of_games > 0)
            {
                first_number = rnd.Next(10, 21);
                second_number = rnd.Next(1, 10);
                Console.WriteLine("{0} / {1} \t\tYour points: {2}", first_number, second_number, correct_questions + "/5");
                solution = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (solution == (first_number / second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            history.Add(correct_questions);
            correct_questions = 0;
            break;
        case 5:
            if (history.Count == 0)
            {
                Console.WriteLine("Your game history is empty.");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                break;
            }
            else
            {
                int i = 1;
                foreach (int m in history)
                {
                    Console.WriteLine("Game " + i + ":\t" + m + "/5 points");
                    ++i;
                }
                System.Threading.Thread.Sleep(10000);
            }
            break;
        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Type number from 1 to 5.");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            break;
    }

    Console.Clear();
}
