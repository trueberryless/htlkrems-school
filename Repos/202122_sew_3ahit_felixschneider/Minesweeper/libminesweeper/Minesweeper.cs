using System;

namespace libminesweeper
{
    public enum EField { BOMB, ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, 
        BOMBFLAG, ZEROFLAG, ONEFLAG, TWOFLAG, THREEFLAG, FOURFLAG, FIVEFLAG, SIXFLAG, SEVENFLAG, EIGHTFLAG,
        BOMBACTIVATED, ZEROACTIVATED, ONEACTIVATED, TWOACTIVATED, THREEACTIVATED, FOURACTIVATED, FIVEACTIVATED, SIXACTIVATED, SEVENACTIVATED, EIGHTACTIVATED }

    public enum EPlayStatus { CONTINUE, WIN, LOSE }

    public enum EAction { OPEN, FLAG }
    public interface IMinesweeper
    {
        public EField[,] GetField { get; }

        public EPlayStatus Play(int x, int y, EAction action);

        IMinesweeper Reset();
    }

    public class Minesweeper : IMinesweeper
    {
        private EField[,] field;
        private EPlayStatus status;
        private int xsize, ysize, bomb_amount;

        public Minesweeper():this(4, 4, 2) { }

        public Minesweeper(int xsize, int ysize, int bomb_amount)
        {
            this.xsize = xsize;
            this.ysize = ysize;
            this.bomb_amount = bomb_amount;
        }

        public EField[,] GetField
        {
            get
            {
                //if (field == null)
                //    throw new Exception("No field available.");
                return field;
            }
        }

        private EField[,] CreateField(int x, int y)
        {
            field = new EField[xsize, ysize];
            for (int i = 0; i < ysize; i++)
            {
                for (int j = 0; j < xsize; j++)
                {
                    field[i, j] = EField.ONE;
                }
            }
            for (int i = 0; i < bomb_amount; i++)
            {
                (int, int) xy = GetRandomXY(x, y);
                field[xy.Item1, xy.Item2] = EField.BOMB;
            }
            for (int i = 0; i < ysize; i++)
            {
                for (int j = 0; j < xsize; j++)
                {
                    if(field[i, j] != EField.BOMB)
                    {
                        field[i, j] = EField.ZERO;
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                if (k == 0 && l == 0 || l + j >= xsize || l + j <= -1)
                                    continue;
                                if (k + i >= ysize || k + i <= -1)
                                    break;
                                if (field[k + i, l + j] == EField.BOMB)
                                    field[i, j]++;
                            }
                        }
                    }
                }
            }
            return field;
        } //Feld generieren

        private (int, int) GetRandomXY(int x, int y)
        {
            (int, int) xy;
            Random randy = new Random();
            xy.Item1 = randy.Next(0, xsize);
            xy.Item2 = randy.Next(0, ysize);
            if (field[xy.Item1, xy.Item2] == EField.BOMB) //  || (xy.Item1 == x && xy.Item2 == y)
                return GetRandomXY(x, y);
            return xy;
        } //zufällig setzen

        public EPlayStatus Play(int y, int x, EAction action)
        {
            if (field == null)
                CreateField(x, y);
            if(action == EAction.OPEN)
            {
                OpenField(x, y);
            }
            else if (action == EAction.FLAG)
            {
                switch (field[x, y])
                {
                    case EField.BOMB: field[x, y] = EField.BOMBFLAG; break;
                    case EField.ZERO: field[x, y] = EField.ZEROFLAG; break;
                    case EField.ONE: field[x, y] = EField.ONEFLAG; break;
                    case EField.TWO: field[x, y] = EField.TWOFLAG; break;
                    case EField.THREE: field[x, y] = EField.THREEFLAG; break;
                    case EField.FOUR: field[x, y] = EField.FOURFLAG; break;
                    case EField.FIVE: field[x, y] = EField.FIVEFLAG; break;
                    case EField.SIX: field[x, y] = EField.SIXFLAG; break;
                    case EField.SEVEN: field[x, y] = EField.SEVENFLAG; break;
                    case EField.EIGHT: field[x, y] = EField.EIGHTFLAG; break;

                    case EField.BOMBFLAG: field[x, y] = EField.BOMB; break;
                    case EField.ZEROFLAG: field[x, y] = EField.ZERO; break;
                    case EField.ONEFLAG: field[x, y] = EField.ONE; break;
                    case EField.TWOFLAG: field[x, y] = EField.TWO; break;
                    case EField.THREEFLAG: field[x, y] = EField.THREE; break;
                    case EField.FOURFLAG: field[x, y] = EField.FOUR; break;
                    case EField.FIVEFLAG: field[x, y] = EField.FIVE; break;
                    case EField.SIXFLAG: field[x, y] = EField.SIX; break;
                    case EField.SEVENFLAG: field[x, y] = EField.SEVEN; break;
                    case EField.EIGHTFLAG: field[x, y] = EField.EIGHT; break;

                    default: break;
                }
            }
            EPlayStatus winner = GetWinner(x, y);
            if(winner == EPlayStatus.LOSE)
            {
                OpenAllBombFields();
            }
            return winner;
        } //ein Spielzug

        private void OpenField(int x, int y)
        {
            switch (field[x, y])
            {
                case EField.BOMB: field[x, y] = EField.BOMBACTIVATED; break;
                case EField.ZERO: OpenAllZeroFields(x, y); break;
                case EField.ONE: field[x, y] = EField.ONEACTIVATED; break;
                case EField.TWO: field[x, y] = EField.TWOACTIVATED; break;
                case EField.THREE: field[x, y] = EField.THREEACTIVATED; break;
                case EField.FOUR: field[x, y] = EField.FOURACTIVATED; break;
                case EField.FIVE: field[x, y] = EField.FIVEACTIVATED; break;
                case EField.SIX: field[x, y] = EField.SIXACTIVATED; break;
                case EField.SEVEN: field[x, y] = EField.SEVENACTIVATED; break;
                case EField.EIGHT: field[x, y] = EField.EIGHTACTIVATED; break;
                default: break;
            }
        } //ein Feld öffnen

        private bool OpenAllZeroFields(int x, int y)
        {
            field[x, y] = EField.ZEROACTIVATED;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0 || y + j >= xsize || y + j <= -1)
                        continue;
                    if (x + i >= ysize || x + i <= -1)
                        break;
                    OpenField(x + i, y + j);
                }
            }
            return true;
        } //alle Felder, die an 0er angrenzen, öffnen

        private bool OpenAllBombFields()
        {
            for (int i = 0; i < ysize; i++)
            {
                for (int j = 0; j < xsize; j++)
                {
                    switch(field[i, j]) {
                        case EField.BOMBFLAG:
                        case EField.BOMB: field[i, j] = EField.BOMBACTIVATED; break;
                        default: break;
                    }
                }
            }
            return true;
        } //bei LOSE alle Bomben zeigen

        private EPlayStatus GetWinner(int x, int y)
        {
            if (field[x, y] == EField.BOMBACTIVATED)
                return EPlayStatus.LOSE;
            bool won = true;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    switch(field[i, j])
                    {
                        case EField.ZEROACTIVATED:
                        case EField.ONEACTIVATED:
                        case EField.TWOACTIVATED:
                        case EField.THREEACTIVATED:
                        case EField.FOURACTIVATED:
                        case EField.FIVEACTIVATED:
                        case EField.SIXACTIVATED:
                        case EField.SEVENACTIVATED:
                        case EField.EIGHTACTIVATED:
                        case EField.BOMBFLAG: break;
                        default: won = false; break;
                    }
                }
            }
            if (won == true)
                return EPlayStatus.WIN;
            return EPlayStatus.CONTINUE;
        } //returnt Gewinner

        public IMinesweeper Reset()
        {
            field = null;
            return (IMinesweeper)new Minesweeper(xsize, ysize, bomb_amount);
        } //setzt field auf null zurück
    }
}
