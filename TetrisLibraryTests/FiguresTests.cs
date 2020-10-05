using Tetris;
using Xunit;

namespace TetrisLibraryTests
{
    public class FiguresTests
    {
        FigureO figureO = new FigureO();
        FigureI figureI = new FigureI();
        FigureS figureS = new FigureS();
        FigureZ figureZ = new FigureZ();
        FigureL figureL = new FigureL();
        FigureJ figureJ = new FigureJ();
        FigureT figureT = new FigureT();

        [Fact]
        public void FigureORotateTest()
        {
            Equals(new int[2, 2] { { 1, 1 },{ 1, 1 } }, figureO.GetFigure());
            figureO.Rotate();
            Equals(new int[2, 2] { { 1, 1 }, { 1, 1 } }, figureO.GetFigure());
        }

        [Fact]
        public void FigureIRotateTest()
        {
            Equals(new int[1, 4] { { 1,1,1,1 } }, figureI.GetFigure());
            figureI.Rotate();
            Equals(new int[4, 1] { { 1 },{ 1 },{ 1 },{ 1 } }, figureI.GetFigure());
        }

        [Fact]
        public void FigureSRotateTest()
        {
            FigureS figure = new FigureS();
            Equals(new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } }, figureS.GetFigure());
            figureS.Rotate();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 1 }, { 0, 1 } }, figureS.GetFigure());
        }

        [Fact]
        public void FigureZRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } }, figureZ.GetFigure());
            figureZ.Rotate();
            Equals(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 } }, figureZ.GetFigure());
        }

        [Fact]
        public void FigureLRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 1, 0, 0 } }, figureL.GetFigure());
            figureL.Rotate();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 0 }, { 1, 1 } }, figureL.GetFigure());
            figureL.Rotate();
            Equals(new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } }, figureL.GetFigure());
            figureL.Rotate();
            Equals(new int[3, 2] { { 1, 1 }, { 0, 1 }, { 0, 1 } }, figureL.GetFigure());
        }

        [Fact]
        public void FigureJRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 0, 1 } }, figureJ.GetFigure());
            figureJ.Rotate();
            Equals(new int[3, 2] { { 1, 1 }, { 1, 0 }, { 1, 0 } }, figureJ.GetFigure());
            figureJ.Rotate();
            Equals(new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } }, figureJ.GetFigure());
            figureJ.Rotate();
            Equals(new int[3, 2] { { 0, 1 }, { 0, 1 }, { 1, 1 } }, figureJ.GetFigure());
        }

        [Fact]
        public void FigureTRotateTest()
        {
            Equals(new int[2, 3] { { 1, 1, 1 }, { 0, 1, 0 } }, figureT.GetFigure());
            figureT.Rotate();
            Equals(new int[3, 2] { { 1, 0 }, { 1, 1 }, { 1, 0 } }, figureT.GetFigure());
            figureT.Rotate();
            Equals(new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } }, figureT.GetFigure());
            figureT.Rotate();
            Equals(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 0, 1 } }, figureT.GetFigure());
        }

    }
}
