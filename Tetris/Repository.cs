using System;
using System.IO;
using System.Text.Json;

namespace Tetris.Core
{
    public interface IRepository
    {
        void Save(Tetris tetris);
        Tetris Load();
    }

    class TetrisDataForSerialazing
    {
        public int[,] GameField { get; private set; }
        public int Score { get; private set; }
        public bool IsGameLost { get; private set; }
        public int FallingTetrominoX { get; private set; }
        public int FallingTetrominoY { get; private set; }
        public Tetramino FallingTetromino { get; private set; }
        public Tetramino NextTetromino { get; private set; }

        public TetrisDataForSerialazing(Tetris tetris)
        {
            GameField = tetris.GameField;
            Score = tetris.Score;
            IsGameLost = tetris.IsGameLost;
            FallingTetrominoX = tetris.FallingTetrominoX;
            FallingTetrominoY = tetris.FallingTetrominoY;
            FallingTetromino = tetris.FallingTetromino;
            NextTetromino = tetris.NextTetromino;
        }
    }

    public class JsonRepo : IRepository
    {
        public async void Save(Tetris tetris)
        {
            using (FileStream save = new FileStream("save.json", FileMode.OpenOrCreate))
            {
                TetrisDataForSerialazing tetrisData = new TetrisDataForSerialazing(tetris);
                await JsonSerializer.SerializeAsync<TetrisDataForSerialazing>(save, tetrisData);
            }
        }

        public Tetris Load()
        {
            Tetris tetris = new Tetris();
            try
            {
                string tetrisJson = File.ReadAllText("save.json");
                tetris = new Tetris();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return tetris;
        }
    }
}