using System;
using System.IO;
using Newtonsoft.Json;

namespace Tetris.Core
{
    public interface IRepository
    {
        void Save(Tetris tetris);
        Tetris Load();
    }

    public class TetrisModel
    {
        public int[,] GameField { get; set; }
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
        public void Save(Tetris tetris)
        {
            using (StreamWriter sw = new StreamWriter(@"save.json"))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();
                TetrisModel tetrisModel = new TetrisModel(tetris);
                serializer.Serialize(jw,tetrisModel);
            }
        }

        public Tetris Load()
        {
            Tetris tetris;
            using (StreamReader save = File.OpenText(@"save.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                TetrisModel tetrisModel = (TetrisModel)serializer.Deserialize(save, typeof(TetrisModel));
                tetris = new Tetris(tetrisModel);
                Console.WriteLine(tetris.Score);
            }
            return tetris;
        }
    }
}