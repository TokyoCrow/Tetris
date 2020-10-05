using System;

namespace Tetris
{
    interface ITetromino
    {
        int[,] GetFigure();
        void Rotate();
    }

    public class TetrominoO : ITetromino
    {
        int condition = 0;
        static int[,] tetromino = new int[2,2]
        {
            { 1,1 },
            { 1,1 }
        };

        public int[,] GetTetromino()
        {
            return figure;
        }

        public void Rotate()
        {
            if (condition == figure.Length)
                condition = 0;
            else
                condition++;
        }
    }

    public class FigureI : IFigure
    {
        int condition = 0;
        static int[][,] figure = new int[2][,]
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

    public class FigureS : IFigure
    {
        int condition = 0;
        static int[][,] figure = new int[2][,]
        {
            new int[2, 3]
            {
                { 0,1,1 },
                { 1,1,0 }
            },
            new int[3, 2]
            {
                { 1,0 },
                { 1,1 },
                { 0,1 }
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

    public class FigureZ : IFigure
    {
        int condition = 0;
        static int[][,] figure = new int[2][,]
        {
            new int[2, 3]
            {
                { 1,1,0 },
                { 0,1,1 }
            },
            new int[3, 2]
            {
                { 0,1 },
                { 1,1 },
                { 1,0 }
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

    public class FigureL : IFigure
    {
        int condition = 0;
        static int[][,] figure = new int[4][,]
        {
            new int[2, 3]
            {
                { 1,1,1 },
                { 1,0,0 }
            },
            new int[3, 2]
            {
                { 1,0 },
                { 1,0 },
                { 1,1 }
            },
            new int[2, 3]
            {
                { 0,0,1 },
                { 1,1,1 }
            },
            new int[3, 2]
            {
                { 1,1 },
                { 0,1 },
                { 0,1 }
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

    public class FigureJ : IFigure
    {
        int condition = 0;
        static int[][,] figure = new int[4][,]
        {
            new int[2, 3]
            {
                { 1,1,1 },
                { 0,0,1 }
            },
            new int[3, 2]
            {
                { 1,1 },
                { 1,0 },
                { 1,0 }
            },
            new int[2, 3]
            {
                { 1,0,0 },
                { 1,1,1 }
            },
            new int[3, 2]
            {
                { 0,1 },
                { 0,1 },
                { 1,1 }
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

    public class FigureT : IFigure
    {
        int condition = 0;
        static int[][,] figure = new int[4][,]
        {
            new int[2, 3]
            {
                { 1,1,1 },
                { 0,1,0 }
            },
            new int[3, 2]
            {
                { 1,0 },
                { 1,1 },
                { 1,0 }
            },
            new int[2, 3]
            {
                { 0,1,0 },
                { 1,1,1 }
            },
            new int[3, 2]
            {
                { 0,1 },
                { 1,1 },
                { 0,1 }
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
