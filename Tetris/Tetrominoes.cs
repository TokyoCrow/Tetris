namespace Tetris.Core
{
    public interface ITetromino
    {
        int[,] GetTetromino();
        void RotateRight();
        void RotateLeft();
    }

    public class TetrominoO : ITetromino
    {
        private static readonly int[,] tetromino = 
        {
            {1, 1},
            {1, 1}
        };

        public int[,] GetTetromino()
        {
            return tetromino;
        }

        public void RotateRight()
        {
        }

        public void RotateLeft()
        {
        }
    }

    public class TetrominoI : ITetromino
    {
        private static readonly int[][,] tetromino = 
        {
            new int[,] 
            {
                {1, 1, 1, 1}
            },
            new int[,] 
            {
                {1},
                {1},
                {1},
                {1}
            }
        };

        private int condition;

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
        private static readonly int[][,] tetromino =
        {
            new int[,]
            {
                {0, 1, 1},
                {1, 1, 0}
            },
            new int[,]
            {
                {1, 0},
                {1, 1},
                {0, 1}
            }
        };

        private int condition;

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
        private static readonly int[][,] tetromino = 
        {
            new int[,]
            {
                {1, 1, 0},
                {0, 1, 1}
            },
            new int[,]
            {
                {0, 1},
                {1, 1},
                {1, 0}
            }
        };

        private int condition;

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
        private static readonly int[][,] tetromino = 
        {
            new int[,]
            {
                {1, 1, 1},
                {1, 0, 0}
            },
            new int[,]
            {
                {1, 0},
                {1, 0},
                {1, 1}
            },
            new int[,]
            {
                {0, 0, 1},
                {1, 1, 1}
            },
            new int[,]
            {
                {1, 1},
                {0, 1},
                {0, 1}
            }
        };

        private int condition;

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
        private static readonly int[][,] tetromino = 
        {
            new int[,]
            {
                {1, 1, 1},
                {0, 0, 1}
            },
            new int[,]
            {
                {1, 1},
                {1, 0},
                {1, 0}
            },
            new int[,]
            {
                {1, 0, 0},
                {1, 1, 1}
            },
            new int[,]
            {
                {0, 1},
                {0, 1},
                {1, 1}
            }
        };

        private int condition;

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
        private static readonly int[][,] tetromino = 
        {
            new int[,]
            {
                {1, 1, 1},
                {0, 1, 0}
            },
            new int[,]
            {
                {1, 0},
                {1, 1},
                {1, 0}
            },
            new int[,]
            {
                {0, 1, 0},
                {1, 1, 1}
            },
            new int[,]
            {
                {0, 1},
                {1, 1},
                {0, 1}
            }
        };

        private int condition;

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
}