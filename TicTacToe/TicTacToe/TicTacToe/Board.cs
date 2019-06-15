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
                $"\n First player marks \"X\", second - \"O\"");
        }
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
            CheckGameState();
            if (gameOver)
                return;
                string player = (turn % 2 == 0) ? "Player 1" : "Player 2";
                Console.WriteLine($"Next move, {player}");
                StartGame(CheckAndReturnCorrectInput(Console.ReadLine()));
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
                catch (Exception)
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
            //Cheking each column for wincondition
            int draw = 0;
            for (int column = 0; column <= 2; column++)
            {
                int p1Wins = 0;
                int p2Wins = 0;
                for (int line = 0; line <= 2; line++)
                {
                    if (board[column, line] == state.X)
                    {
                        p1Wins++;
                        draw++;
                    }

                    else if (board[column, line] == state.O)
                    {
                        p2Wins++;
                        draw++;
                    }
                    
                }
                CheckWinCondition(p1Wins, p2Wins, draw);
                p1Wins = 0;
                p2Wins = 0;
                //swapping column and line, checking lines
                for (int line = 0; line <= 2; line++)
                {
                    if (board[line, column] == state.X)
                        p1Wins++;
                    else if (board[line, column] == state.O)
                        p2Wins++;

                }
                CheckWinCondition(p1Wins, p2Wins);
            }
            //Also checking diagonal wincondition
            int dP1Wins = 0;
            int dP2Wins = 0;
            for (int diagInd = 0; diagInd <= 2; diagInd++)
            {
                if (board[diagInd, diagInd] == state.X)
                    dP1Wins++;
                else if (board[diagInd, diagInd] == state.O)
                    dP2Wins++;
            }
            CheckWinCondition(dP1Wins, dP2Wins);
            dP1Wins = 0;
            dP2Wins = 0;

            int reverseind = 2;
            for (int ind = 0; ind <=2; ind++)
            {
                if (board[ind, reverseind] == state.X)
                    dP1Wins++;
                else if (board[ind, reverseind] == state.O)
                    dP2Wins++;
                reverseind--;
            }
            CheckWinCondition(dP1Wins, dP2Wins);
        }
        private void CheckWinCondition(int p1Wins, int p2Wins, int draw = 0)
        {
            if (p1Wins == 3 || p2Wins == 3)
            {
                Console.WriteLine($"Player {((p1Wins == 3) ? 1 : 2)} have won");
                gameOver = true;
                return;
            }
            if (draw == 9)
            {
                Console.WriteLine($"draw");
                gameOver = true;
                return;
            }
        }
    }
}
