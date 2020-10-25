using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris.WindowsForms
{
    public partial class GameForm : Form
    {
        private readonly Core.Tetris tetris = new Core.Tetris();

        public GameForm()
        {
            InitializeComponent();
            timer1.Interval = 400;
            timer1.Start();
        }

        public void DrawTetrominos(Graphics g)
        {
            for (var y = 0; y < tetris.FallingTetromino.GetTetromino().GetLength(0); y++)
            for (var x = 0; x < tetris.FallingTetromino.GetTetromino().GetLength(1); x++)
                if (tetris.FallingTetromino.GetTetromino()[y, x] == 1)
                    g.FillRectangle(Brushes.Red,
                        new Rectangle(50 + (tetris.FallingTetrominoX + x) * 25 - 1,
                            50 + (tetris.FallingTetrominoY + y) * 25 + 1, 25 - 1, 25 - 1));

            for (var y = 0; y < tetris.GameField.GetLength(0); y++)
            for (var x = 0; x < tetris.GameField.GetLength(1); x++)
                if (tetris.GameField[y, x] == 1)
                    g.FillRectangle(Brushes.Red, new Rectangle(50 + x * 25, 50 + y * 25, 25, 25));
        }

        public void DrawGameField(Graphics g)
        {
            for (var y = 0; y <= tetris.GameField.GetLength(0); y++)
                g.DrawLine(Pens.Black, new Point(50, 50 + y * 25),
                    new Point(50 + tetris.GameField.GetLength(1) * 25, 50 + y * 25));
            for (var x = 0; x <= tetris.GameField.GetLength(1); x++)
                g.DrawLine(Pens.Black, new Point(50 + x * 25, 50),
                    new Point(50 + x * 25, 50 + tetris.GameField.GetLength(0) * 25));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawTetrominos(e.Graphics);
            DrawGameField(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tetris.IsGameLost)
                timer1.Stop();
            lblScore.Text = tetris.Score.ToString();
            tetris.MoveDown();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
            }
        }
    }
}