using System;
internal class Program
{
    private static void Main(string[] args)
    {
        int[,] board = new int[3, 3];

        Random rand = new();
        int userMark = rand.Next(1, 3);
        Console.WriteLine($"Twój znak to: {(userMark == 1 ? 'X' : 'O')}");
        PrintBoard(board, false);
        if (userMark == 2)
        {
            NextMove(board, 1, userMark);
            Console.WriteLine($"Twój znak to: {(userMark == 1 ? 'X' : 'O')}");
            while (!CheckWin(board))
            {
                NextMove(board, userMark, userMark);
                if (CheckWin(board))
                    break;
                NextMove(board, 1, userMark);
            }
        }
        else
        {
            NextMove(board, userMark, userMark);
            while (!CheckWin(board))
            {
                NextMove(board, 2, userMark);
                if (CheckWin(board))
                    break;
                NextMove(board, userMark, userMark);
            }
        }
            
    }

    private static void PrintBoard(int[,] board)
    {
        int position = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (board[i,j])
                {
                    case 1:
                        Console.Write(" X ");
                        break;
                    case 2:
                        Console.Write(" O ");
                        break;
                    default:
                        Console.Write($"({position})");
                        break;
                }
                if (j != 2)
                    Console.Write("|");
                position++;
            }
            if(i != 2)
                Console.WriteLine("\n--- --- ---");
        }

        Console.WriteLine("\nWybierz miejsce od 0 do 8");
    }
    private static void NextMove(int[,] board, int player, int userMark)
    {
        if (player == userMark)
            UserPlacement(board, player);
        else
            ComputerPlacement(board, player);
        PrintBoard(board, true);
    }
    private static void PrintBoard(int[,] board, bool clearConsole)
    {
        if (clearConsole)
            Console.Clear();
        PrintBoard(board);
    }
    private static void UserPlacement(int[,] board,int userMark)
    {
        while (!PlaceMark(board, GetUserInput(), userMark))
            Console.WriteLine("Miejsce zajęte, wybierz inne miejsce");
    }
    private static void ComputerPlacement(int[,] board, int compMark)
    {
        Random rand = new();

        while (!PlaceMark(board, rand.Next(0, 8), compMark))
            Console.WriteLine("Miejsce zajęte, wybierz inne miejsce");
    }
    private static int GetUserInput()
    {
        while (true)
            if (int.TryParse(Console.ReadLine(), out int input))
                if (input >= 0 && input <= 8)
                    return input;
                else
                    Console.WriteLine("Nieprawidłowy zakres. Wybierz liczbę od 0 do 8.");
            else
                Console.WriteLine("Nieprawidłowy znak. Wpisz liczbę od 0 do 8.");
    }
    private static bool PlaceMark(int[,] board, int position, int player)
    {
        int row = position / 3;
        int col = position % 3;
        if (board[row, col] == 0)
        {
            board[row, col] = player;
            return true;
        }
        else
        {
            return false;
        }
    }
    private static bool CheckWin(int[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                PrintBoard(board,true);
                Console.WriteLine($"Gracz {(board[i, 0] == 1 ? 'X' : 'O')} wygrał!");
                return true;
            }
            if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                PrintBoard(board,true);
                Console.WriteLine($"Gracz {(board[0, i] == 1 ? 'X' : 'O')} wygrał!");
                return true;
            }
        }
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            PrintBoard(board,true);
            Console.WriteLine($"Gracz {(board[0, 0] == 1 ? 'X' : 'O')} wygrał!");
            return true;
        }
        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            PrintBoard(board, true);
            Console.WriteLine($"Gracz {(board[0, 2] == 1 ? 'X' : 'O')} wygrał!");
            return true;
        }
        if(board[0,0] !=0 && board[0,1] !=0 && board[0,2] !=0 &&
           board[1,0] !=0 && board[1,1] !=0 && board[1,2] !=0 &&
           board[2,0] !=0 && board[2,1] !=0 && board[2,2] !=0)
        {
            PrintBoard(board, true);
            Console.WriteLine("Remis!");
            return true;
        }
        return false;
    }
}