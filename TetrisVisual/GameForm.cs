using System;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Core;

namespace Tetris.WindowsForms
{
    public partial class GameForm : Form
    {
        private readonly int blockSize = 25;
        private readonly int gameFieldX= 50;
        private readonly int gameFieldY= 50;

        private Core.Tetris tetris;
        private IRepository repo;

        public GameForm()
        {
            tetris = new Core.Tetris();
            repo = new JsonRepo();
            InitializeComponent();
            gameTimer.Interval = 400;
            gameTimer.Start();
        }

        public void DrawTetrominos(Graphics g)
        {
            for (var y = 0; y < tetris.FallingTetromino.Get().GetLength(0); y++)
            for (var x = 0; x < tetris.FallingTetromino.Get().GetLength(1); x++)
                if (tetris.FallingTetromino.Get()[y, x] == 1)
                    g.FillRectangle(Brushes.Red,
                        new Rectangle(gameFieldX + (tetris.FallingTetrominoX + x) * blockSize ,
                            gameFieldY + (tetris.FallingTetrominoY + y) * blockSize, blockSize, blockSize));

            for (var y = 0; y < tetris.GameField.GetLength(0); y++)
            for (var x = 0; x < tetris.GameField.GetLength(1); x++)
                if (tetris.GameField[y, x] == 1)
                    g.FillRectangle(Brushes.Red, new Rectangle(gameFieldX + x * blockSize, gameFieldY + y * blockSize, blockSize, blockSize));
        }

        public void DrawGameField(Graphics g)
        {
            for (var y = 0; y <= tetris.GameField.GetLength(0); y++)
                g.DrawLine(Pens.Black, new Point(gameFieldX, gameFieldY + y * blockSize),
                    new Point(gameFieldX + tetris.GameField.GetLength(1) * blockSize, gameFieldY + y * blockSize));
            for (var x = 0; x <= tetris.GameField.GetLength(1); x++)
                g.DrawLine(Pens.Black, new Point(gameFieldX + x * blockSize, gameFieldY),
                    new Point(gameFieldX + x * blockSize, gameFieldY + tetris.GameField.GetLength(0) * blockSize));
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            DrawTetrominos(e.Graphics);
            DrawGameField(e.Graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (tetris.IsGameLost)
                gameTimer.Stop();
            lblScore.Text = tetris.Score.ToString();
            tetris.MoveDown();
            Invalidate();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    tetris.Rotate();
                    Invalidate();
                    break;
                case Keys.Right:
                    tetris.MoveRight();
                    Invalidate();
                    break;
                case Keys.Left:
                    tetris.MoveLeft();
                    Invalidate();
                    break;
                case Keys.Down:
                    tetris.MoveDown();
                    Invalidate();
                    break;
                case Keys.P:
                    if (gameTimer.Enabled)
                    {
                        gameTimer.Stop();
                        btnLoad.Enabled = true;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        gameTimer.Start();
                        btnLoad.Enabled = false;
                        btnSave.Enabled = false;
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) => repo.Save(tetris);

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tetris = repo.Load();
            Invalidate();
        }
    }
}