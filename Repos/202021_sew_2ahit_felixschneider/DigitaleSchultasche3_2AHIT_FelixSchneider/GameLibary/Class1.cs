using System;

namespace GameLibary
{
    interface ITicTacToe
    {
        /// <summary>
        /// Set Element
        /// </summary>
        /// <param name="nr">from 1 (lower left) to 9 (upper right)</param>
        /// <return>1 or 2 for concrete Player</return>
        char SetElement(int nr); //1...9

        /// <summary>
        /// Get Winner
        /// </summary>
        /// <returns>0 if no Winner, 1 or 2 for concrete player</returns>
        char GetWinner();
        
    }
    public class TicTacToe : ITicTacToe
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">Symbol for Player 1</param>
        /// <param name="b">Symbol for Player 2</param>
        /// <returns></returns>
        /// 

        char[] ttt = new char[9];
        bool firstelement = true;
        public char A { get; private set; }
        public char B { get; private set; }
        public char GetWinner()
        {
            if(GewinnerWaagrecht() || GewinnerSenkrecht() || GewinnerDiagonal())
            {
                if (firstelement)
                    return B;
                return A;
            }
            return ' ';
        }

        public char SetElement(int nr)
        {
            if(ttt[nr-1] == ' ' && GetWinner() == ' ')
            {
                if (firstelement)
                {
                    ttt[nr-1] = A;
                    firstelement = false;
                    return A;
                }
                else
                {
                    ttt[nr-1] = B;
                    firstelement = true;
                    return B;
                }
            }
            return ' ';
        }
        public TicTacToe(char a, char b)
        {
            A = a;
            B = b;
            for (int i = 0; i < ttt.Length; i++)
            {
                ttt[i] = ' ';
            }
        }
        public TicTacToe():this('X', 'O') { }

        public bool GewinnerWaagrecht()
        {
            for (int i = 0; i < 8; i+=3)
            {
                if(ttt[i] != ' ')
                    if(ttt[i] == ttt[i+1] && ttt[i+1] == ttt[i + 2])
                    {
                        return true;
                    }
            }
            return false;
        }
        public bool GewinnerSenkrecht()
        {
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i] != ' ')
                    if (ttt[i] == ttt[i + 3] && ttt[i + 3] == ttt[i + 6])
                    {
                        return true;
                    }
            }
            return false;
        }
        public bool GewinnerDiagonal()
        {
            if(ttt[0]==ttt[4] && ttt[4]== ttt[8] && ttt[0] != ' ' || ttt[2] == ttt[4] && ttt[4] == ttt[6] && ttt[2] != ' ')
            {
                return true;
            }
            return false;
        }
    }

    public class Example
    {
        public string Hallo()
        {
            return "hallo";
        }
    }   
}
