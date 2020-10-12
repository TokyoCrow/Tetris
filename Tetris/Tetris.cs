using System;

namespace Tetris
{
    public class Tetris
    {
        public int[,] GameField { get; private set; } = new int[20, 10];
        public int Score { get; private set; } = 0;
        static int newTetrominoStartX = 3;
        static int newTetrominoStartY = 20;
        int faillingTetrominoX = newTetrominoStartX;
        int faillingTetrominoY = newTetrominoStartY;
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
                case 6: return new TetrominoT();
            }
            return new TetrominoO();
        }

        public void TetrominoRotateLeft()
        {
            FallingTetromino.RotateLeft();
            if (IsCollisionBorder() || IsCollisionFloor() || IsCollisionInstalledTetrominoes())
            {
                FallingTetromino.RotateRight();
            }
        }

        public void TetrominoRotateRight()
        {
            FallingTetromino.RotateRight();
            if (IsCollisionBorder() || IsCollisionFloor() || IsCollisionInstalledTetrominoes())
            {
                FallingTetromino.RotateLeft();
            }
        }

        public void TetrominoMoveDown()
        {
            faillingTetrominoY++;
            if (IsCollisionFloor() || IsCollisionInstalledTetrominoes())
            {
                faillingTetrominoY--;
                ConnectTetrominoToGameField();
            }
        }

        public void TetrominoMoveRight()
        {
            faillingTetrominoX++;
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                faillingTetrominoX--;
            }
        }

        public void TetrominoMoveLeft()
        {
            faillingTetrominoX--;
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                faillingTetrominoX++;
            }
        }

        public bool IsCollisionBorder()
        {
            return (
                ((faillingTetrominoX + FallingTetromino.GetTetromino().GetLength(0)) >= GameField.GetLength(0)) ||
                (faillingTetrominoX <= 0)
                );
        }

        public bool IsCollisionInstalledTetrominoes()
        {
            for (var y = 0; y < FallingTetromino.GetTetromino().GetLength(0); y++)
                for (var x = 0; x < FallingTetromino.GetTetromino().GetLength(1); x++)
                {
                    if (GameField[faillingTetrominoY + y, faillingTetrominoX + x] != 0)
                        return true;
                }
            return false;
        }

        public bool IsCollisionFloor()
        {
            if ((faillingTetrominoY + FallingTetromino.GetTetromino().Rank) > GameField.Rank)
                return false;
            return true;
        }

        void ConnectTetrominoToGameField()
        {
            for (var y = 0; y < FallingTetromino.GetTetromino().GetLength(0); y++)
                for (var x = 0; x < FallingTetromino.GetTetromino().GetLength(1); x++)
                {
                    if (FallingTetromino.GetTetromino()[y,x] != 0)
                        GameField[faillingTetrominoY + y, faillingTetrominoX + x] = 1;
                }
        }
    }
}