using System.Diagnostics;
using System.Timers;

List<string> history = new List<string>();
List<double> time_history = new List<double>();
Random rnd = new Random();
int selection, level_diff, rand_diff, n, first_number, second_number, solution, total_points;
int number_of_games = 5; // default number of games
int correct_questions = 0;
Stopwatch stopwatch= new Stopwatch();
void menu()
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
}
int diff_adjuster(int level)
{
    if (level == 1) { rand_diff = 10; }
    else if (level == 2) { rand_diff = 20; }
    else rand_diff = 30; 
    return rand_diff;
}
int level()
{
    int difficulty = 1;
    Console.WriteLine("What difficuty do You want? Provide numbers.");
    while(true)
    {
        try
        {
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Medium");
            Console.WriteLine("3 - Hard");
            difficulty = Convert.ToInt32(Console.ReadLine());
            if(difficulty >= 1 && difficulty <= 3)  break;
        }
        catch (FormatException)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("PROVIDE INT FROM 1 TO 3");
        }
    }
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    return difficulty;
}

int games_number()
{
    int games;
    while (true)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("How many questions do you want?");
            Console.WriteLine("Default - 5 questions, maxiumum 20");
            Console.WriteLine("Type any number: ");
            games = Convert.ToInt32(Console.ReadLine());
            if (games > 0 && games <= 20) break;
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Provide number from 1 to 20");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
    }
    return games;
}
while (true)
{
    menu();
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("You have provided wrong input!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Provide numbers as shown below:");
            menu();
        }
    }
    Console.Clear();
    if (selection == 7) { break; }
    switch (selection)
    {
        case 1:
            Console.Clear();
            level_diff = level();
            n = diff_adjuster(level_diff);
            number_of_games = games_number();
            total_points = number_of_games; // later change to for? rn fast alternative 
            stopwatch.Start();
            while (number_of_games > 0)
            {
                first_number = rnd.Next(1, n);
                second_number = rnd.Next(1, n-5);
                Console.Clear();
                Console.WriteLine("{0} + {1} \t\tYour points: {2}/{3}", first_number, second_number, correct_questions, total_points);
                solution = Convert.ToInt32(Console.ReadLine()); //try catch here?
                if (solution == (first_number + second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            stopwatch.Stop();
            time_history.Add(Math.Round(stopwatch.Elapsed.TotalSeconds, 2));
            history.Add(correct_questions + "/" + total_points + "points");
            correct_questions = 0;
            stopwatch.Reset();
            break;
        case 2:
            Console.Clear();
            level_diff = level();
            n = diff_adjuster(level_diff);
            number_of_games = games_number();
            total_points = number_of_games;
            stopwatch.Start();
            while (number_of_games > 0)
            {
                first_number = rnd.Next(1, n);
                second_number = rnd.Next(1, n-5);
                if (second_number == 0) second_number++;
                Console.Clear();
                Console.WriteLine("{0} - {1} \t\tYour points: {2}/{3}", first_number, second_number, correct_questions,total_points);
                solution = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (solution == (first_number - second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            stopwatch.Stop();
            time_history.Add(Math.Round(stopwatch.Elapsed.TotalSeconds, 2));
            history.Add(correct_questions + "/" + total_points + "points");
            correct_questions = 0;
            stopwatch.Reset();
            break;
        case 3:
            Console.Clear();
            level_diff = level();
            n = diff_adjuster(level_diff);
            number_of_games = games_number();
            total_points = number_of_games;
            stopwatch.Start();
            while (number_of_games > 0)
            {
                first_number = rnd.Next(1, n);
                second_number = rnd.Next(1, n-5);
                Console.Clear();
                Console.WriteLine("{0} * {1} \t\tYour points: {2}/{3}", first_number, second_number, correct_questions, total_points); ;
                solution = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (solution == (first_number * second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            stopwatch.Stop();
            time_history.Add(Math.Round(stopwatch.Elapsed.TotalSeconds, 2));
            history.Add(correct_questions + "/" + total_points + "points");
            correct_questions = 0;
            stopwatch.Reset();
            break;
        case 4:
            Console.Clear();
            level_diff = level();
            n = diff_adjuster(level_diff);
            number_of_games = games_number();
            total_points = number_of_games;
            stopwatch.Start();
            while (number_of_games > 0)
            {
                bool flag = false;
                flag = rnd.NextDouble() >= 0.5;
                if (flag == true) { first_number = rnd.Next(2, n)*2; second_number = 2; }
                else { first_number = rnd.Next(2, n)*3; second_number = 3; }
                Console.Clear();
                Console.WriteLine("{0} / {1} \t\tYour points: {2}/{3}", first_number, second_number, correct_questions, total_points);
                solution = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (solution == (first_number / second_number))
                {
                    correct_questions++;
                }
                number_of_games--;
            }
            stopwatch.Stop();
            time_history.Add(Math.Round(stopwatch.Elapsed.TotalSeconds, 2));
            history.Add(correct_questions + "/" + total_points + "points");
            correct_questions = 0;
            stopwatch.Reset();
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
                int game_num = 1;
                for (int i = 0; i < history.Count; i++)
                {
                    //Console.WriteLine("Total time spent on this game: " + Math.Round(stopwatch.Elapsed.TotalSeconds, 2) + "s");

                    Console.WriteLine("Game {0}:\t{1}  Time spent: {2}s", game_num, history[i], time_history[i]);
                    ++game_num;
                }
                System.Threading.Thread.Sleep(10000);
            }
            break;
        //case 6:
            //random!
        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Type number from 1 to 5.");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            break;
    }

    Console.Clear();
}
