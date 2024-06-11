using System;

namespace Minesweeper
{
    public enum EField
    {
        BOMB, ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT,
        BOMBFLAG, ZEROFLAG, ONEFLAG, TWOFLAG, THREEFLAG, FOURFLAG, FIVEFLAG, SIXFLAG, SEVENFLAG, EIGHTFLAG,
        BOMBACTIVATED, ZEROACTIVATED, ONEACTIVATED, TWOACTIVATED,
        THREEACTIVATED, FOURACTIVATED, FIVEACTIVATED, SIXACTIVATED,
        SEVENACTIVATED, EIGHTACTIVATED
    };

    public enum EPlayStatus { CONTINUE, WIN, LOSE };

    public enum EAction { OPEN, FLAG }

    public interface IMinesweeper
    {
        public EField[,] Field { get; } // in der Klasse auf get set ausimplementieren
                                        // durch Instanz auf das Field zugreifen
                                        // Fixe Spielgr��e 18x18
                                        // 35 Bomben

        EPlayStatus Play(int x, int y, EAction action);
        /*
         * EField[,] CreateField() --> Feld neu generieren 
         * PlayTurn() 
         * Win()
         * 
         */

        IMinesweeper Reset();
        /*          
         * Es wird eine neue Instanz von Minesweeper returned.
         */
    }
}
