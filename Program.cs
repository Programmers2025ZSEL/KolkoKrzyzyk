using System;
internal class Program
{
    private static void Main(string[] args)
    {
        int[,] board = new int[3, 3];
        PrintBoard(board);
    }

    private static void PrintBoard(int[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (board[i,j])
                {
                    case 1:
                        Console.Write("X");
                        break;
                    case 2:
                        Console.Write("O");
                        break;
                    default:
                        Console.Write(" ");
                        break;
                }
                if (j != 2)
                    Console.Write("|");
            }
            if(i != 2)
                Console.WriteLine("\n- - -");
        }
    }
}