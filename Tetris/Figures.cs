using System;

namespace Tetris
{
    interface IFigure
    {
        int[,] GetFigure();
        void Rotate();
    }

    public class FigureI : IFigure
    {
        int condition = 0;
        int[][,] figure = new int[2][,]
        {
            new int[1, 4]
            {
                { 1,1,1,1 }
            },
            new int[4, 1]
            {
                { 1 },
                { 1 },
                { 1 },
                { 1 }
            }
        };

        public int[,] GetFigure()
        {
            return figure[condition];
        }

        public void Rotate()
        {
            if (condition == figure.Length)
                condition = 0;
            else
                condition++;
        }
    }
}
