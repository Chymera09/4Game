using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4Game
{    
    class GameLogic
    {
        private byte[,] fieldValue;
        private Brush[,] fieldColor;

        public GameLogic(byte rowNumber, byte columnNumber)
        {
            fieldValue = new byte[rowNumber, columnNumber];
            fieldColor = new Brush[rowNumber, columnNumber];
            for (int i = 0; i < rowNumber; i++)
                for (int j = 0; j < columnNumber; j++)
                    fieldColor[i, j] = Brushes.White;                          
        }

        //Érték lekérése
        public byte getValue(byte rowNumber, byte columnNumber)
        {
            return fieldValue[rowNumber, columnNumber];
        }

        //Érték megadása
        public void setValue(byte rowNumber, byte columnNumber, byte value)
        {
            fieldValue[rowNumber, columnNumber] = value;
        }

        //Szín lekérése
        public Brush getColor(byte rowNumber, byte columnNumber)
        {
            return fieldColor[rowNumber, columnNumber];
        }

        //Szín megadása
        public void setColor (byte rowNumber,byte columnNumber, Brush value)
        {
            fieldColor[rowNumber, columnNumber] = value;
        }

        //Érték beállítása mezőre kattintás után
        public void setFieldValues(byte rowNumber, byte columnNumber, Player player)
        {
            //eredeti rész: pl 2;2
            setFieldElement(rowNumber, columnNumber, player);
            //1;2
            try
            {                
                setFieldElement((byte)(rowNumber - 1), columnNumber, player);
            }
            catch (Exception e) { };

            //3;2
            try
            {
                setFieldElement((byte)(rowNumber + 1), columnNumber, player);
            }
            catch (Exception e) { };

            //2;1
            try
            {
                setFieldElement(rowNumber, (byte)(columnNumber - 1), player);
            }
            catch (Exception e) { };

            //2;3
            try
            {
                setFieldElement(rowNumber, (byte)(columnNumber + 1), player);
            }
            catch (Exception e) { };

            if(Settings.Diagonal)
            {
                //1;1
                try
                {
                    setFieldElement((byte)(rowNumber - 1), (byte)(columnNumber - 1), player);
                }
                catch (Exception e) { };

                //3;1
                try
                {
                    setFieldElement((byte)(rowNumber + 1), (byte)(columnNumber - 1), player);
                }
                catch (Exception e) { };

                //1;3
                try
                {
                    setFieldElement((byte)(rowNumber - 1), (byte)(columnNumber + 1), player);
                }
                catch (Exception e) { };

                //3;3
                try
                {
                    setFieldElement((byte)(rowNumber + 1), (byte)(columnNumber + 1), player);
                }
                catch (Exception e) { };
            }
        }

        private void setFieldElement(byte rowNumber, byte columnNumber, Player player)
        {
            if(fieldValue[rowNumber, columnNumber] < Constants.MAXFIELDVALUE)
            {
                fieldValue[rowNumber, columnNumber]++;
                if(fieldValue[rowNumber, columnNumber] == Constants.MAXFIELDVALUE)
                {
                    fieldColor[rowNumber, columnNumber] = player.Color;
                    player.addScore();
                }
            }
        }
    }
}
