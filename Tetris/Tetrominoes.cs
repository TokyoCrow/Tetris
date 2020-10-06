using System;

namespace Tetris
{
    public interface ITetromino
    {
        int[,] GetTetromino();
        void RotateRight();
        void RotateLeft();
    }

    public class TetrominoO : ITetromino
    {
        static int[,] tetromino = new int[2, 2]
        {
            { 1,1 },
            { 1,1 }
        };

        public int[,] GetTetromino()
        {
            return tetromino;
        }

        public void RotateRight() { }
        public void RotateLeft() { }
    }

    public class TetrominoI : ITetromino
    {
        int condition = 0;
        static int[][,] tetromino = new int[2][,]
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

        public int[,] GetTetromino()
        {
            return tetromino[condition];
        }

        public void RotateRight()
        {
            if (condition == tetromino.Length - 1)
                condition = 0;
            else
                condition++;
        }

        public void RotateLeft()
        {
            if (condition == 0)
                condition = tetromino.Length - 1;
            else
                condition--;
        }
    }

    public class TetrominoS : ITetromino
    {
        int condition = 0;
        static int[][,] tetromino = new int[2][,]
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

        public int[,] GetTetromino()
        {
            return tetromino[condition];
        }

        public void RotateRight()
        {
            if (condition == tetromino.Length - 1)
                condition = 0;
            else
                condition++;
        }

        public void RotateLeft()
        {
            if (condition == 0)
                condition = tetromino.Length - 1;
            else
                condition--;
        }
    }

    public class TetrominoZ : ITetromino
    {
        int condition = 0;
        static int[][,] tetromino = new int[2][,]
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

        public int[,] GetTetromino()
        {
            return tetromino[condition];
        }

        public void RotateRight()
        {
            if (condition == tetromino.Length - 1)
                condition = 0;
            else
                condition++;
        }

        public void RotateLeft()
        {
            if (condition == 0)
                condition = tetromino.Length - 1;
            else
                condition--;
        }
    }

    public class TetrominoL : ITetromino
    {
        int condition = 0;
        static int[][,] tetromino = new int[4][,]
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

        public int[,] GetTetromino()
        {
            return tetromino[condition];
        }

        public void RotateRight()
        {
            if (condition == tetromino.Length - 1)
                condition = 0;
            else
                condition++;
        }

        public void RotateLeft()
        {
            if (condition == 0)
                condition = tetromino.Length - 1;
            else
                condition--;
        }
    }

    public class TetrominoJ : ITetromino
    {
        int condition = 0;
        static int[][,] tetromino = new int[4][,]
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

        public int[,] GetTetromino()
        {
            return tetromino[condition];
        }

        public void RotateRight()
        {
            if (condition == tetromino.Length - 1)
                condition = 0;
            else
                condition++;
        }

        public void RotateLeft()
        {
            if (condition == 0)
                condition = tetromino.Length - 1;
            else
                condition--;
        }
    }

    public class TetrominoT : ITetromino
    {
        int condition = 0;
        static int[][,] tetromino = new int[4][,]
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

        public int[,] GetTetromino()
        {
            return tetromino[condition];
        }

        public void RotateRight()
        {
            if (condition == tetromino.Length - 1 - 1)
                condition = 0;
            else
                condition++;
        }

        public void RotateLeft()
        {
            if (condition == 0)
                condition = tetromino.Length - 1 - 1;
            else
                condition--;
        }
    }
}
