using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;

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
            try
            {
                var tetrisJson = JsonSerializer.Serialize<Tetris>(tetris);
                File.WriteAllText("save.json", tetrisJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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