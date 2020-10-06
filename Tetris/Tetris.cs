using System;

namespace Tetris
{
    public class Tetris
    {
        public int[,] gameField { get; private set; } = new int[20, 10];
        public int Score { get; private set; } = 0;
        static int newTetrominoStartX = 3;
        static int newTetrominoStartY = 20;
        int faillingTetrominoX = newTetrominoStartX;
        int faillingTetrominoY = newTetrominoStartY;
        public ITetromino FaillingTetromino { get; private set; }
        public ITetromino NextTetromino { get; private set; }
        Random random = new Random();

        public Tetris()
        {
            FaillingTetromino = GetNewTetramino();
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
            FaillingTetromino.RotateLeft();
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                FaillingTetromino.RotateRight();
            }
        }

        public void TetrominoRotateRight()
        {
            FaillingTetromino.RotateRight();
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                FaillingTetromino.RotateLeft();
            }
        }

        public void TetrominoMoveDown()
        {
            faillingTetrominoY++;
            if (IsCollisionBorder() || IsCollisionInstalledTetrominoes())
            {
                faillingTetrominoY--;
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

        bool IsCollisionBorder()
        {
            return (
                ((faillingTetrominoX + FaillingTetromino.GetTetromino().GetLength(0)) >= gameField.GetLength(0)) ||
                (faillingTetrominoX <= 0) ||
                ((faillingTetrominoY - FaillingTetromino.GetTetromino().Rank) <= 0)
                );
        }

        bool IsCollisionInstalledTetrominoes()
        {
            for (var y = 0; y < FaillingTetromino.GetTetromino().GetLength(0); y++)
                for (var x = 0; x < FaillingTetromino.GetTetromino().GetLength(1); x++)
                {
                    if (gameField[faillingTetrominoY + y, faillingTetrominoX + x] != 0)
                        return true;
                }
            return false;
        }
    }
}
