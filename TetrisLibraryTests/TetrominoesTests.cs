using Tetris;
using Xunit;

namespace TetrisLibraryTests
{
    public class TetrominoesTests
    {
        TetrominoO tetrominoO = new TetrominoO();
        TetrominoI tetrominoI = new TetrominoI();
        TetrominoS tetrominoS = new TetrominoS();
        TetrominoZ tetrominoZ = new TetrominoZ();
        TetrominoL tetrominoL = new TetrominoL();
        TetrominoJ tetrominoJ = new TetrominoJ();
        TetrominoT tetrominoT = new TetrominoT();

        [Fact]
        public void TetrominoORotateTest()
        {
            Equals(new int[2, 2] { { 1, 1 },{ 1, 1 } }, tetrominoO.GetTetromino());
            tetrominoO.Rotate();
            Equals(new int[2, 2] { { 1, 1 }, { 1, 1 } }, tetrominoO.GetTetromino());
        }

        [Fact]
        public void TetrominoIRotateTest()
        {
            Equals(new int[1, 4] { { 1,1,1,1 } }, tetrominoI.GetTetromino());
            tetrominoI.Rotate();
            Equals(new int[4, 1] { { 1 },{ 1 },{ 1 },{ 1 } }, tetrominoI.GetTetromino());
        }

        [Fact]
        public void TetrominoSRotateTest()
        {
            TetrominoS tetromino = new TetrominoS();
            Equals(new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } }, tetrominoS.GetTetromino());
            tetrominoS.Rotate();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 1 }, { 0, 1 } }, tetrominoS.GetTetromino());
        }

        [Fact]
        public void TetrominoZRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } }, tetrominoZ.GetTetromino());
            tetrominoZ.Rotate();
            Equals(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 } }, tetrominoZ.GetTetromino());
        }

        [Fact]
        public void TetrominoLRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 1, 0, 0 } }, tetrominoL.GetTetromino());
            tetrominoL.Rotate();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 0 }, { 1, 1 } }, tetrominoL.GetTetromino());
            tetrominoL.Rotate();
            Equals(new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } }, tetrominoL.GetTetromino());
            tetrominoL.Rotate();
            Equals(new int[3, 2] { { 1, 1 }, { 0, 1 }, { 0, 1 } }, tetrominoL.GetTetromino());
        }

        [Fact]
        public void TetrominoJRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 0, 1 } }, tetrominoJ.GetTetromino());
            tetrominoJ.Rotate();
            Equals(new int[3, 2] { { 1, 1 }, { 1, 0 }, { 1, 0 } }, tetrominoJ.GetTetromino());
            tetrominoJ.Rotate();
            Equals(new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } }, tetrominoJ.GetTetromino());
            tetrominoJ.Rotate();
            Equals(new int[3, 2] { { 0, 1 }, { 0, 1 }, { 1, 1 } }, tetrominoJ.GetTetromino());
        }

        [Fact]
        public void TetrominoTRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 1, 0 } }, tetrominoT.GetTetromino());
            tetrominoT.Rotate();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 1 }, { 1, 0 } }, tetrominoT.GetTetromino());
            tetrominoT.Rotate();
            Equals(new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } }, tetrominoT.GetTetromino());
            tetrominoT.Rotate();
            Equals(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 0, 1 } }, tetrominoT.GetTetromino());
        }

    }
}
