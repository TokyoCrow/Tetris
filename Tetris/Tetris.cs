using System;

namespace Tetris
{
    public class Tetris
    {
        public int[,] GameField { get; set; } = new int[20, 10];
        public int Score { get; private set; } = 0;
        public bool IsGameLost { get; private set; } = false;
        static int newTetrominoStartX = 2;
        static int newTetrominoStartY = 0;
        public int FallingTetrominoX { get; private set; } = newTetrominoStartX;
        public int FallingTetrominoY { get; private set; } = newTetrominoStartY;
        public ITetromino FallingTetromino { get; private set; }
        public ITetromino NextTetromino { get; private set; }
        Random random = new Random();

        public Tetris()
        {
            FallingTetromino = GetNewTetramino();
            NextTetromino = GetNewTetramino();
        }

        ITetromino GetNewTetramino()
        {
            switch (random.Next(7))
            {
                case 0: return new TetrominoO();
                case 1: return new TetrominoI();
                case 2: return new TetrominoS();
                case 3: return new TetrominoZ();
                case 4: return new TetrominoL();
                case 5: return new TetrominoJ();
                default: return new TetrominoT();
            }
        }

        void ChangeTetromino()
        {
            FallingTetromino = NextTetromino;
            FallingTetrominoX = newTetrominoStartX;
            FallingTetrominoY = newTetrominoStartY;
            if (IsCollisionInstalledTetrominoes())
                IsGameLost = true;
            NextTetromino = GetNewTetramino();
        }

        public void TetrominoRotate()
        {
            FallingTetromino.RotateRight();
            if (IsCollisionBorder() || IsCollisionFloor() || IsCollisionInstalledTetrominoes())
            {
                FallingTetromino.RotateLeft();
            }
        }

        public void TetrominoMoveDown()
        {
            FallingTetrominoY++;
            if (IsCollisionFloor() || IsCollisionInstalledTetrominoes())
            {
                FallingTetrominoY--;
                ConnectTetrominoToGameField();
            }
        }

        public void TetrominoMoveRight()
        {
            FallingTetrominoX++;
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                FallingTetrominoX--;
            }
        }

        public void TetrominoMoveLeft()
        {
            FallingTetrominoX--;
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                FallingTetrominoX++;
            }
        }

        public bool IsCollisionBorder()
        {
            return (
                ((FallingTetrominoX + FallingTetromino.GetTetromino().GetLength(1)) > GameField.GetLength(1)) ||
                (FallingTetrominoX < 0)
                );
        }

        public bool IsCollisionInstalledTetrominoes()
        {
            for (var y = 0; y < FallingTetromino.GetTetromino().GetLength(0); y++)
                for (var x = 0; x < FallingTetromino.GetTetromino().GetLength(1); x++)
                {
                    if ((FallingTetromino.GetTetromino()[y, x] != 0) &&
                        (GameField[FallingTetrominoY + y, FallingTetrominoX + x] != 0))
                        return true;
                }
            return false;
        }

        public bool IsCollisionFloor()
        {
            return (FallingTetrominoY > GameField.GetLength(0) - FallingTetromino.GetTetromino().GetLength(0));
        }

        void ConnectTetrominoToGameField()
        {
            for (var y = 0; y < FallingTetromino.GetTetromino().GetLength(0); y++)
                for (var x = 0; x < FallingTetromino.GetTetromino().GetLength(1); x++)
                {
                    if (FallingTetromino.GetTetromino()[y, x] != 0)
                        GameField[FallingTetrominoY + y, FallingTetrominoX + x] = 1;
                }
            CheckStrip();
            ChangeTetromino();
        }

        public void CheckStrip()
        {
            for (var y = GameField.GetLength(0)-1; y >= 0 ; y--)
            {
                var stripCounter = 0;
                for (var x = 0; x < GameField.GetLength(1); x++)
                {
                    if (GameField[y, x] != 0)
                        stripCounter++;
                    else
                        break;
                }
                if (stripCounter == GameField.GetLength(1))
                {
                    DeleteStrip(y);
                    y++;
                }
            }
        }

        void DeleteStrip(int stripY)
        {
            Score++;
            for (var y = stripY; y > 1; y--)
            {
                for (var x = 0; x < GameField.GetLength(1); x++)
                {
                    GameField[y, x] = GameField[y - 1, x];
                }
            }
        }
    }
}