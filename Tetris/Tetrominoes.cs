using System;

namespace Tetris.Core
{
    public class TetraminoModel
    {
        public int Condition { get; set; }
        public char Type { get; set; }
    }


    public class Tetramino
    {
        private static readonly Random random = new Random();
        private readonly int[][,] tetromino;

        public Tetramino(int[][,] _tetromino, char _type)
        {
            tetromino = _tetromino;
            type = _type;
        }

        public int condition { get; private set; }
        public char type { get; }

        public static Tetramino SetTetramino(TetraminoModel model)
        {
            var tetramino = GetTetramino(model.Type);
            tetramino.SetCondition(model.Condition);
            return tetramino;
        }

        public void SetCondition(int _condition)
        {
            condition = _condition;
        }

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

        public static Tetramino O()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {1, 1},
                        {1, 1}
                    }
                }, 'O');
        }

        public static Tetramino I()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {1, 1, 1, 1}
                    },
                    new[,]
                    {
                        {1},
                        {1},
                        {1},
                        {1}
                    }
                }, 'I');
        }

        public static Tetramino S()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {0, 1, 1},
                        {1, 1, 0}
                    },
                    new[,]
                    {
                        {1, 0},
                        {1, 1},
                        {0, 1}
                    }
                }, 'S');
        }

        public static Tetramino Z()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {1, 1, 0},
                        {0, 1, 1}
                    },
                    new[,]
                    {
                        {0, 1},
                        {1, 1},
                        {1, 0}
                    }
                }, 'Z');
        }

        public static Tetramino L()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {1, 1, 1},
                        {1, 0, 0}
                    },
                    new[,]
                    {
                        {1, 0},
                        {1, 0},
                        {1, 1}
                    },
                    new[,]
                    {
                        {0, 0, 1},
                        {1, 1, 1}
                    },
                    new[,]
                    {
                        {1, 1},
                        {0, 1},
                        {0, 1}
                    }
                }, 'L');
        }

        public static Tetramino J()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {1, 1, 1},
                        {0, 0, 1}
                    },
                    new[,]
                    {
                        {1, 1},
                        {1, 0},
                        {1, 0}
                    },
                    new[,]
                    {
                        {1, 0, 0},
                        {1, 1, 1}
                    },
                    new[,]
                    {
                        {0, 1},
                        {0, 1},
                        {1, 1}
                    }
                }, 'J');
        }

        public static Tetramino T()
        {
            return new Tetramino(
                new[]
                {
                    new[,]
                    {
                        {1, 1, 1},
                        {0, 1, 0}
                    },
                    new[,]
                    {
                        {1, 0},
                        {1, 1},
                        {1, 0}
                    },
                    new[,]
                    {
                        {0, 1, 0},
                        {1, 1, 1}
                    },
                    new[,]
                    {
                        {0, 1},
                        {1, 1},
                        {0, 1}
                    }
                }, 'T');
        }
    }
}