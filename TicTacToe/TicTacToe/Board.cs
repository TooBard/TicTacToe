using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum state { U, X, O };

    class Board
    {
        private state[,] board = new state[3, 3];
        private bool gameOver;
        private uint turn = 0; //if odd then p2, if even - p1

        public Board()
        {
            //new game
            Console.WriteLine($"Welcome to the Tic-Tac-Toe! The game is played using" +
                $"\n numpad, as seen below" +
                $"\n 7 | 8 | 9" +
                $"\n---+---+---" +
                $"\n 4 | 5 | 6" +
                $"\n---+---+---" +
                $"\n 1 | 2 | 3" +
                $"\n First player marks \"X\", second - \"O\"");        }
        /// <summary>
        /// Prints current state of the board
        /// </summary>
        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine($" {board[0, 0]} | {board[1, 0]} | {board[2, 0]}" +
                $"\n---+---+---" +
                $"\n {board[0, 1]} | {board[1, 1]} | {board[2, 1]}" +
                $"\n---+---+---" +
                $"\n {board[0, 2]} | {board[1, 2]} | {board[2, 2]}");
        }
        public void StartGame(byte input)
        {
            //Cheking input
            if (input > 9)
            {
                Console.WriteLine("Incorrect user input, try again");
                StartGame(CheckAndReturnCorrectInput(Console.ReadLine()));
                return;
            }
            //Registering input
            switch (input)
            {
                case 1:
                    FillCell(0, 2); break;
                case 2:
                    FillCell(1, 2); break;
                case 3:
                    FillCell(2, 2); break;
                case 4:
                    FillCell(0, 1); break;
                case 5:
                    FillCell(1, 1); break;
                case 6:
                    FillCell(2, 1); break;
                case 7:
                    FillCell(0, 0); break;
                case 8:
                    FillCell(1, 0); break;
                case 9:
                    FillCell(2, 0); break;
                default:
                    Console.WriteLine("This coder is a dumbass"); break;
            }

            turn++;

            PrintBoard();
            if (!gameOver)
            {
                string player = (turn % 2 == 0) ? "Player 1" : "Player 2";
                Console.WriteLine($"Next move, {player}");
                StartGame(CheckAndReturnCorrectInput(Console.ReadLine()));
            }
        }
        private void FillCell(byte col,byte str)
        {
            //Determining turn
            float whichPlayer = turn % 2;
            if(board[col,str] != state.U)
            {
                Console.WriteLine("This cell is already taken, try again");
                StartGame(CheckAndReturnCorrectInput(Console.ReadLine()));
                return;
            }
            board[col,str] = (whichPlayer == 0) ? state.X : state.O;
        }
        public byte CheckAndReturnCorrectInput(string input)
        {
            byte correctInput = 0;
            while (correctInput < 1 || correctInput > 9)
            {
                try
                {
                    correctInput = Convert.ToByte(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine("That is not a valid number. Try again.");
                    CheckAndReturnCorrectInput(Console.ReadLine());
                    break;
                }
            }
            return correctInput;
        }
        private void CheckGameState()
        {

        }


    }
}
