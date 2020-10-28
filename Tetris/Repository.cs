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

    class TetrisModel
    {
        public int[,] GameField { get; private set; }
        public int Score { get;  set; }
        public bool IsGameLost { get;  set; }
        public int FallingTetrominoX { get;  set; }
        public int FallingTetrominoY { get;  set; }
        public TetraminoModel FallingTetromino { get;  set; }
        public TetraminoModel NextTetromino { get;  set; }

        public TetrisModel() { }

        public TetrisModel(Tetris tetris)
        {
            GameField = tetris.GameField;
            Score = tetris.Score;
            IsGameLost = tetris.IsGameLost;
            FallingTetrominoX = tetris.FallingTetrominoX;
            FallingTetrominoY = tetris.FallingTetrominoY;
            FallingTetromino = new TetraminoModel();
            FallingTetromino.Condition = tetris.FallingTetromino.condition;
            FallingTetromino.Type = tetris.FallingTetromino.type;
            NextTetromino = new TetraminoModel();
            NextTetromino.Condition = tetris.NextTetromino.condition;
            NextTetromino.Type = tetris.NextTetromino.type;
        }
    }

    public class JsonRepo : IRepository
    {
        public async void Save(Tetris tetris)
        {
            using (FileStream save = new FileStream("save.json", FileMode.OpenOrCreate))
            {
                TetrisModel tetrisModel = new TetrisModel(tetris);
                await JsonSerializer.SerializeAsync<TetrisModel>(save, tetrisModel);
            }
        }

        public Tetris Load()
        {
            Tetris tetris = new Tetris();
            try
            {
                string tetrisJson = File.ReadAllText("save.json");
                TetrisModel tetrisModel = JsonSerializer.Deserialize<TetrisModel>(tetrisJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return tetris;
        }
    }
}