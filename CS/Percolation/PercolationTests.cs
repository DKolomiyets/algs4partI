using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Percolation
{
    [TestClass]
    public class PercolationTests
    {
        [TestMethod]
        public void TestThat1DimensionalMatrixPercolatesAfterOneOpen()
        {
            Percolation target = new Percolation( 1 );

            target.Open( 1, 1 );

            Assert.IsTrue( target.Percolates() );
        }

        [TestMethod]
        public void TestDoesNotPercolate2DimensionalMatrixAfterCreation()
        {
            Percolation target = new Percolation( 2 );

            Assert.IsFalse( target.Percolates() );
        }

        [TestMethod]
        public void TestIsNotOpenAfterCreation()
        {
            Percolation target = new Percolation( 2 );

            Assert.IsFalse( target.IsOpen( 1, 1 ) );
        }

        [TestMethod]
        public void TestIsNotFullClosedSite()
        {
            Percolation target = new Percolation( 2 );

            Assert.IsFalse( target.IsFull( 1, 1 ) );
        }

        [TestMethod]
        public void TestIsNotFull()
        {
            Percolation target = new Percolation( 2 );

            target.Open( 2, 2 );

            Assert.IsFalse( target.IsFull( 2, 2 ) );
        }

        [TestMethod]
        public void TestIsFull()
        {
            Percolation target = new Percolation( 2 );

            target.Open( 1, 1 );

            Assert.IsTrue( target.IsFull( 1, 1 ) );
        }

		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TestThatIsFullThrowsExceptionOnInvalidFirstIndex()
		{
			Percolation target = new Percolation( 2 );

			target.IsFull( -1, 1 );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TestThatIsFullThrowsExceptionOnTooBigSecondIndex()
		{
			Percolation target = new Percolation( 2 );

			target.IsFull( 1, 5 );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TestThatIsFullThrowsExceptionOnTooLowSecondIndex()
		{
			Percolation target = new Percolation( 2 );

			target.IsFull( 1, -5 );
		}

        [TestMethod]
        public void TestIsOpenAfterOpen()
        {
            Percolation target = new Percolation( 2 );

            target.Open( 1, 1 );

            Assert.IsTrue( target.IsOpen( 1, 1 ) );
        }

        [TestMethod]
        public void TestPercolates2DimensionalMatrix()
        {
            Percolation target = new Percolation( 2 );

            target.Open( 1, 1 );
            target.Open( 2, 1 );

            Assert.IsTrue( target.Percolates() );
        }

        [TestMethod]
        public void TestDoesNotPercolate2DimensionalMatrix()
        {
            Percolation target = new Percolation( 2 );

            target.Open( 1, 1 );
            target.Open( 2, 2 );

            Assert.IsFalse( target.Percolates() );
        }

        [TestMethod]
        public void TestPercolates3DimensionalMatrix()
        {
            Percolation target = new Percolation( 3 );

            target.Open( 1, 1 );
            target.Open( 2, 1 );
            target.Open( 3, 1 );

            Assert.IsTrue( target.Percolates() );
        }

        [TestMethod]
        public void TestDoesNotPercolate3DimensionalMatrix()
        {
            Percolation target = new Percolation( 3 );

            target.Open( 1, 1 );
            target.Open( 2, 2 );
            target.Open( 3, 3 );

            Assert.IsFalse( target.Percolates() );
        }

        [TestMethod]
        public void TestPercolates4DimensionalMatrix()
        {
            Percolation target = new Percolation( 4 );

            target.Open( 1, 1 );
            target.Open( 2, 1 );
            target.Open( 3, 1 );
            target.Open( 4, 1 );

            Assert.IsTrue( target.Percolates() );
        }

        [TestMethod]
        public void TestDoesNotPercolate4DimensionalMatrix()
        {
            Percolation target = new Percolation( 4 );

            target.Open( 1, 1 );
            target.Open( 2, 2 );
            target.Open( 3, 3 );
            target.Open( 4, 4 );

            Assert.IsFalse( target.Percolates() );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatOpenShouldThrowExceptionOnZeroIndexes()
        {
            Percolation target = new Percolation( 4 );

            target.Open( 0, 0 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatOpenShouldThrowExceptionOnGreaterThenSizeIndexSpecified()
        {
            Percolation target = new Percolation( 4 );

            target.Open( 5, 1 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatIsOpenShouldThrowExceptionOnGreaterThenSizeIndexSpecified()
        {
            Percolation target = new Percolation( 4 );
            
            target.IsOpen( 5, 1 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatIsOpenShouldThrowExceptionOnZeroIndexSpecified()
        {
            Percolation target = new Percolation( 4 );

            target.IsOpen( 0, 0 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatIsFullShouldThrowExceptionOnGreaterThenSizeIndexSpecified()
        {
            Percolation target = new Percolation( 4 );

            target.IsFull( 5, 1 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatIsFullShouldThrowExceptionOnZeroIndexSpecified()
        {
            Percolation target = new Percolation( 4 );

            target.IsFull( 0, 0 );
        }

        [TestMethod]
        public void TestIsNotFullEvenIfSiteIsOpenAndSystemPercolates()
        {
            Percolation target = new Percolation( 3 );

            target.Open( 3, 1 );

            target.Open( 1, 3 );
            target.Open( 2, 3 );
            target.Open( 3, 3 );

            Assert.IsFalse( target.IsFull( 3, 1 ) );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfIllegalArgumentExceptionThrownOnZeroSize()
        {
            new Percolation( 0 );
        }
    }
}
