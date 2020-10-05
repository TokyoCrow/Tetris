namespace Tetris
{
    public class Tetris
    {
        int[,] gameField = new int[20, 10];
        int faillingTetrominoX = 3;
        int faillingTetrominoY = 20;
        ITetromino faillingTetromino;

        void TetrominoMoveDown()
        {
            faillingTetrominoY++;
        }

        void TetrominoMoveRight()
        {
            faillingTetrominoX++;
        }

        void TetrominoMoveLeft()
        {
            faillingTetrominoX--;
        }

        bool IsCollisionBorder()
        {
            return (
                ((faillingTetrominoX + faillingTetromino.GetTetromino().GetLength(0)) >= gameField.GetLength(0)) ||
                (faillingTetrominoX <= 0) ||
                ((faillingTetrominoY - faillingTetromino.GetTetromino().Rank) <= 0) ||
                IsCollisionInstalledTetrominoes()
                );
        }

        bool IsCollisionInstalledTetrominoes()
        {
            for (var y = 0; y < faillingTetromino.GetTetromino().GetLength(0); y++)
                for (var x = 0; x < faillingTetromino.GetTetromino().GetLength(1); x++)
                {
                    if (gameField[faillingTetrominoY + y, faillingTetrominoX + x] == 1)
                        return true;
                }
            return false;
        }
    }
}
