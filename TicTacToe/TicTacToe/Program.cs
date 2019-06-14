using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.StartGame(board.CheckAndReturnCorrectInput(Console.ReadLine()));

            Console.ReadKey();            
        }
    }
}
