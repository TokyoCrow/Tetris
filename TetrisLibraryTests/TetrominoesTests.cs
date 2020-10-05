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
        public void TetrominoORotateRightTest()
        {
            Equals(new int[2, 2] { { 1, 1 }, { 1, 1 } }, tetrominoO.GetTetromino());
            tetrominoO.RotateRight();
            Equals(new int[2, 2] { { 1, 1 }, { 1, 1 } }, tetrominoO.GetTetromino());
            tetrominoO.RotateRight();
            Equals(new int[2, 2] { { 1, 1 }, { 1, 1 } }, tetrominoO.GetTetromino());
        }

        [Fact]
        public void TetrominoIRotateRightTest()
        {
            Equals(new int[1, 4] { { 1, 1, 1, 1 } }, tetrominoI.GetTetromino());
            tetrominoI.RotateRight();
            Equals(new int[4, 1] { { 1 },{ 1 },{ 1 },{ 1 } }, tetrominoI.GetTetromino());
            tetrominoI.RotateRight();
            Equals(new int[1, 4] { { 1, 1, 1, 1 } }, tetrominoI.GetTetromino());
        }

        [Fact]
        public void TetrominoSRotateRightTest()
        {
            TetrominoS tetromino = new TetrominoS();
            Equals(new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } }, tetrominoS.GetTetromino());
            tetrominoS.RotateRight();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 1 }, { 0, 1 } }, tetrominoS.GetTetromino());
        }

        [Fact]
        public void TetrominoZRotateRightTest()
        {
            Equals(new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } }, tetrominoZ.GetTetromino());
            tetrominoZ.RotateRight();
            Equals(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 } }, tetrominoZ.GetTetromino());
            tetrominoZ.RotateRight();
            Equals(new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } }, tetrominoZ.GetTetromino());
        }

        [Fact]
        public void TetrominoLRotateRightTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 1, 0, 0 } }, tetrominoL.GetTetromino());
            tetrominoL.RotateRight();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 0 }, { 1, 1 } }, tetrominoL.GetTetromino());
            tetrominoL.RotateRight();
            Equals(new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } }, tetrominoL.GetTetromino());
            tetrominoL.RotateRight();
            Equals(new int[3, 2] { { 1, 1 }, { 0, 1 }, { 0, 1 } }, tetrominoL.GetTetromino());
            tetrominoL.RotateRight();
            Equals(new int[2, 3] { { 1, 1, 1 }, { 1, 0, 0 } }, tetrominoL.GetTetromino());
        }

        [Fact]
        public void TetrominoJRotateRightTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 0, 1 } }, tetrominoJ.GetTetromino());
            tetrominoJ.RotateRight();
            Equals(new int[3, 2] { { 1, 1 }, { 1, 0 }, { 1, 0 } }, tetrominoJ.GetTetromino());
            tetrominoJ.RotateRight();
            Equals(new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } }, tetrominoJ.GetTetromino());
            tetrominoJ.RotateRight();
            Equals(new int[3, 2] { { 0, 1 }, { 0, 1 }, { 1, 1 } }, tetrominoJ.GetTetromino());
            tetrominoJ.RotateRight();
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 0, 1 } }, tetrominoJ.GetTetromino());
        }

        [Fact]
        public void TetrominoTRotateRightTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 1, 0 } }, tetrominoT.GetTetromino());
            tetrominoT.RotateRight();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 1 }, { 1, 0 } }, tetrominoT.GetTetromino());
            tetrominoT.RotateRight();
            Equals(new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } }, tetrominoT.GetTetromino());
            tetrominoT.RotateRight();
            Equals(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 0, 1 } }, tetrominoT.GetTetromino());
            tetrominoT.RotateRight();
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 1, 0 } }, tetrominoT.GetTetromino());
        }

    }
}
