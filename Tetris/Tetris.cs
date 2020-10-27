using System;

namespace Tetris.Core
{
    public class Tetris
    {
        private const int NewTetrominoStartX = 2;
        private const int NewTetrominoStartY = 0;
        private static readonly int[,] emptyField = new int[20, 10];

        private readonly Random random;

        public int[,] GameField { get; private set; }

        public int Score { get; private set; }
        public bool IsGameLost { get; private set; }
        public int FallingTetrominoX { get; private set; }
        public int FallingTetrominoY { get; private set; }
        public ITetromino FallingTetromino { get; private set; }
        public ITetromino NextTetromino { get; private set; }

        public Tetris(int[,] field = null)
        {
            GameField = field ?? emptyField;
            random = new Random();
            FallingTetrominoX = NewTetrominoStartX;
            FallingTetrominoY = NewTetrominoStartY;
            FallingTetromino = GetNewTetramino();
            NextTetromino = GetNewTetramino();
        }

        private ITetromino GetNewTetramino()
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

        private void ChangeTetromino()
        {
            FallingTetromino = NextTetromino;
            FallingTetrominoX = NewTetrominoStartX;
            FallingTetrominoY = NewTetrominoStartY;
            if (CheckCollisionInstalledTetrominoes())
                IsGameLost = true;
            NextTetromino = GetNewTetramino();
        }

        public void Rotate()
        {
            FallingTetromino.RotateRight();
            if (CheckCollisionBorder() || IsCollisionFloor() || CheckCollisionInstalledTetrominoes())
                FallingTetromino.RotateLeft();
        }

        public void MoveDown()
        {
            FallingTetrominoY++;
            if (IsCollisionFloor() || CheckCollisionInstalledTetrominoes())
            {
                FallingTetrominoY--;
                ConnectTetrominoToGameField();
            }
        }

        public void MoveRight()
        {
            FallingTetrominoX++;
            if (CheckCollisionBorder() || CheckCollisionInstalledTetrominoes()) FallingTetrominoX--;
        }

        public void MoveLeft()
        {
            FallingTetrominoX--;
            if (CheckCollisionBorder() || CheckCollisionInstalledTetrominoes()) FallingTetrominoX++;
        }

        public bool CheckCollisionBorder() =>
            FallingTetrominoX + FallingTetromino.GetTetromino().GetLength(1) > GameField.GetLength(1)
            || FallingTetrominoX < 0;


        public bool CheckCollisionInstalledTetrominoes()
        {
            for (var y = 0; y < FallingTetromino.GetTetromino().GetLength(0); y++)
            for (var x = 0; x < FallingTetromino.GetTetromino().GetLength(1); x++)
                if (FallingTetromino.GetTetromino()[y, x] != 0 &&
                    GameField[FallingTetrominoY + y, FallingTetrominoX + x] != 0)
                    return true;
            return false;
        }

        public bool IsCollisionFloor()
        {
            return FallingTetrominoY > GameField.GetLength(0) - FallingTetromino.GetTetromino().GetLength(0);
        }

        private void ConnectTetrominoToGameField()
        {
            for (var y = 0; y < FallingTetromino.GetTetromino().GetLength(0); y++)
            for (var x = 0; x < FallingTetromino.GetTetromino().GetLength(1); x++)
                if (FallingTetromino.GetTetromino()[y, x] != 0)
                    GameField[FallingTetrominoY + y, FallingTetrominoX + x] = 1;
            CheckStrip();
            ChangeTetromino();
        }

        public void CheckStrip()
        {
            for (var y = GameField.GetLength(0) - 1; y >= 0; y--)
            {
                var stripCounter = 0;
                for (var x = 0; x < GameField.GetLength(1); x++)
                    if (GameField[y, x] != 0)
                        stripCounter++;
                    else
                        break;
                if (stripCounter == GameField.GetLength(1))
                {
                    DeleteStrip(y);
                    y++;
                }
            }
        }

        private void DeleteStrip(int stripY)
        {
            Score++;
            for (var y = stripY; y > 1; y--)
            for (var x = 0; x < GameField.GetLength(1); x++)
                GameField[y, x] = GameField[y - 1, x];
        }
    }
}