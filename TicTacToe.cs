using System;

namespace TicTacToe
{
    class PlayGame
    {
        // refactor
        static public char PLAYER1 = 'X';
        static public char PLAYER2 = 'O';
        static public char[,] marksArray = new char[3,3] { {' ',' ',' '}, {' ',' ',' '}, {' ',' ',' '} };
        static public int[] playerMove = {-1, -1};

        static public void drawLines(char[,] marks)
        {
            Console.WriteLine(" " + marks[0, 0] + " | " + marks[0, 1] + " | " + marks[0, 2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + marks[1, 0] + " | " + marks[1, 1] + " | " + marks[1, 2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + marks[2, 0] + " | " + marks[2, 1] + " | " + marks[2, 2] + "\n");
        }

        static public char selectplayer(int gameRound)
        {
            if (Convert.ToBoolean(gameRound % 2))
            {
                return PLAYER1;
            }
            else
            {
                return PLAYER2;
            }
        }

        static public bool isValidMove(int[] move, char[,] m)
        {
            if (m[move[0],move[1]] == ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public void userInput(int[] move, char[,] marks, char currentPlayer)
        {
            do
            {
                move = new int[] {-1,-1};
                Console.WriteLine("Player " + currentPlayer + ", please select your move (row, 1-3):");
                move[0] = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Player " + currentPlayer + ", please select your move (column, 1-3):");
                move[1] = Convert.ToInt32(Console.ReadLine()) - 1;
                if (!isValidMove(move, marks))
                {
                    Console.WriteLine("Invalid move! Select a different move.");
                }
            } while (!isValidMove(move, marks));
            marks[move[0],move[1]] = currentPlayer;
        }

        static public bool determineWinner(char[,] m, char c)
        {
            // can this be shrunk?
            if ((m[0,0] == c && m[0,1] == c && m[0,2] == c) ||
                (m[1,0] == c && m[1,1] == c && m[1,2] == c) ||
                (m[2,0] == c && m[2,1] == c && m[2,2] == c) ||
                (m[0,0] == c && m[1,0] == c && m[2,0] == c) ||
                (m[0,1] == c && m[1,1] == c && m[2,1] == c) ||
                (m[0,2] == c && m[1,2] == c && m[2,2] == c) ||
                (m[0,0] == c && m[1,1] == c && m[2,2] == c) ||
                (m[2,0] == c && m[1,1] == c && m[0,2] == c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            for (int gameRound = 1; gameRound <= 9; gameRound++)
            {
                //Console.Clear();
                Console.WriteLine("ROUND " + gameRound + "\n");
                userInput(playerMove, marksArray, selectplayer(gameRound));
                drawLines(marksArray);
                if (determineWinner(marksArray, selectplayer(gameRound)))
                {
                    Console.WriteLine("Player " + selectplayer(gameRound) + " WINS!!");
                    break;
                }

                if (gameRound == 9)
                {
                    Console.WriteLine("Game ends in a tie.");
                }
            }

            Console.ReadKey();
        }
    }
}
