using System;

namespace Tetris.Core
{
    public class TetraminoModel
    {
        public int Condition { get; set; }
        public char Type { get; set; }

        public TetraminoModel() { }
    }


    public class Tetramino
    {
        private readonly int[][,] tetromino;
        public int condition { get; private set; }
        public char type { get; }

        private static readonly Random random = new Random();

        public Tetramino(int[][,] _tetromino, char _type)
        {
            tetromino = _tetromino;
            type = _type;
        }

        public static Tetramino SetTetramino(TetraminoModel model)
        {
            var tetramino = GetTetramino(model.Type);
            tetramino.SetCondition(model.Condition);
            return tetramino;
        }

        public void SetCondition(int _condition) => condition = _condition;

        public int[,] Get()
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

        public static Tetramino GetRandom()
        {
            switch (random.Next(7))
            {
                case 0: return O();
                case 1: return I();
                case 2: return S();
                case 3: return Z();
                case 4: return L();
                case 5: return J();
                default: return T();
            }
        }

        public static Tetramino GetTetramino(char _type)
        {
            switch (_type)
            {
                case 'O': return O();
                case 'I': return I();
                case 'S': return S();
                case 'Z': return Z();
                case 'L': return L();
                case 'J': return J();
                default: return T();
            }
        }

        public static Tetramino O() => new Tetramino(
            new int[][,]
            {
                new int[,]
                {
                    {1, 1},
                    {1, 1}
                }
            }, 'O');

        public static Tetramino I() => new Tetramino(
            new int[][,]
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
            }, 'I');

        public static Tetramino S() => new Tetramino(
            new int[][,]
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
            }, 'S');

        public static Tetramino Z() => new Tetramino(
            new int[][,]
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
            }, 'Z');

        public static Tetramino L() => new Tetramino(
            new int[][,]
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
            }, 'L');

        public static Tetramino J() => new Tetramino(
            new int[][,]
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
            }, 'J');

        public static Tetramino T() => new Tetramino(
            new int[][,]
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
            }, 'T');
    }
}