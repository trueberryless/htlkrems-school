using System;

namespace Minesweeper
{
    public enum EField { BOMB, ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT,
        BOMBFLAG, ZEROFLAG, ONEFLAG, TWOFLAG, THREEFLAG, FOURFLAG, FIVEFLAG, SIXFLAG, SEVENFLAG, EIGHTFLAG,
        BOMBACTIVATED, ZEROACTIVATED, ONEACTIVATED, TWOACTIVATED,
        THREEACTIVATED, FOURACTIVATED, FIVEACTIVATED, SIXACTIVATED,
        SEVENACTIVATED, EIGHTACTIVATED };

    public enum EPlayStatus { CONTINUE, WIN, LOSE }; //PAUSED

    public interface IMinesweeper
    {
        public EField[,] Field { get; } // in der Klasse auf get set ausimplementieren
                                        // durch Instanz auf das Field zugreifen
                                        // Fixe Spielgröße 18x18
                                        // 35 Bomben

        EPlayStatus Play(int x, int y);
        /*
         * EField[,] CreateField() --> Feld neu generieren 
         * PlayTurn() 
         * Win()
         * 
         */
        void Reset();
        /*          
         * 
         */
    }
}
