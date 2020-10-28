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

    public class JsonRepo : IRepository
    {
        public void Save(Tetris tetris)
        {
            using (var sw = new StreamWriter(@"save.json"))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                var serializer = new JsonSerializer();
                var tetrisModel = new TetrisModel(tetris);
                serializer.Serialize(jw, tetrisModel);
            }
        }

        public Tetris Load()
        {
            Tetris tetris;
            using (var save = File.OpenText(@"save.json"))
            {
                var serializer = new JsonSerializer();
                var tetrisModel = (TetrisModel) serializer.Deserialize(save, typeof(TetrisModel));
                tetris = new Tetris(tetrisModel);
                Console.WriteLine(tetris.Score);
            }

            return tetris;
        }
    }
}