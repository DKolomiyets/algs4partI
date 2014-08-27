import junit.framework.TestCase;

/**
 * Created by D.Kolomiyets on 2/2/14.
 */

public class PercolationTests extends TestCase {
    public void testThat1DimensionalMatrixPercolatesAfterOneOpen() {
        Percolation target = new Percolation(1);

        target.open(1, 1);

        assertTrue(target.percolates());
    }

    public void testDoesNotPercolate2DimensionalMatrixAfterCreation() {
        Percolation target = new Percolation(2);

        assertFalse(target.percolates());
    }

    public void testIsNotOpenAfterCreation() {
        Percolation target = new Percolation(2);

        assertFalse(target.isOpen(1, 1));
    }

    public void testIsNotFullClosedSite() {
        Percolation target = new Percolation(2);

        assertFalse(target.isFull(1, 1));
    }

    public void testIsNotFull() {
        Percolation target = new Percolation(2);

        target.open(2, 2);

        assertFalse(target.isFull(2, 2));
    }

    public void testIsFull() {
        Percolation target = new Percolation(2);

        target.open(1, 1);

        assertTrue(target.isFull(1, 1));
    }

    public void testIsOpenAfterOpen() {
        Percolation target = new Percolation(2);

        target.open(1, 1);

        assertTrue(target.isOpen(1, 1));
    }

    public void testPercolates2DimensionalMatrix() {
        Percolation target = new Percolation(2);

        target.open(1, 1);
        target.open(2, 1);

        assertTrue(target.percolates());
    }

    public void testDoesNotPercolate2DimensionalMatrix() {
        Percolation target = new Percolation(2);

        target.open(1, 1);
        target.open(2, 2);

        assertFalse(target.percolates());
    }

    public void testPercolates3DimensionalMatrix() {
        Percolation target = new Percolation(3);

        target.open(1, 1);
        target.open(2, 1);
        target.open(3, 1);

        assertTrue(target.percolates());
    }

    public void testDoesNotPercolate3DimensionalMatrix() {
        Percolation target = new Percolation(3);

        target.open(1, 1);
        target.open(2, 2);
        target.open(3, 3);

        assertFalse(target.percolates());
    }

    public void testPercolates4DimensionalMatrix() {
        Percolation target = new Percolation(4);

        target.open(1, 1);
        target.open(2, 1);
        target.open(3, 1);
        target.open(4, 1);

        assertTrue(target.percolates());
    }

    public void testDoesNotPercolate4DimensionalMatrix() {
        Percolation target = new Percolation(4);

        target.open(1, 1);
        target.open(2, 2);
        target.open(3, 3);
        target.open(4, 4);

        assertFalse(target.percolates());
    }

    public void testThatOpenShouldThrowExceptionOnZeroIndexes() {
        boolean thrown = false;
        Percolation target = new Percolation(4);

        try {
            target.open(0, 0);
        } catch (Exception e) {
            thrown = e.getClass() == IndexOutOfBoundsException.class;
        }

        assertTrue(thrown);
    }

    public void testThatOpenShouldThrowExceptionOnGreaterThenSizeIndexSpecified() {
        boolean thrown = false;
        Percolation target = new Percolation(4);

        try {
            target.open(5, 1);
        } catch (Exception e) {
            thrown = e.getClass() == IndexOutOfBoundsException.class;
        }

        assertTrue(thrown);
    }

    public void testThatIsOpenShouldThrowExceptionOnGreaterThenSizeIndexSpecified() {
        boolean thrown = false;
        Percolation target = new Percolation(4);

        try {
            target.isOpen(5, 1);
        } catch (Exception e) {
            thrown = e.getClass() == IndexOutOfBoundsException.class;
        }

        assertTrue(thrown);
    }

    public void testThatIsOpenShouldThrowExceptionOnZeroIndexSpecified() {
        boolean thrown = false;
        Percolation target = new Percolation(4);

        try {
            target.isOpen(0, 0);
        } catch (Exception e) {
            thrown = e.getClass() == IndexOutOfBoundsException.class;
        }

        assertTrue(thrown);
    }

    public void testThatIsFullShouldThrowExceptionOnGreaterThenSizeIndexSpecified() {
        boolean thrown = false;
        Percolation target = new Percolation(4);

        try {
            target.isFull(5, 1);
        } catch (Exception e) {
            thrown = e.getClass() == IndexOutOfBoundsException.class;
        }

        assertTrue(thrown);
    }

    public void testThatIsFullShouldThrowExceptionOnZeroIndexSpecified() {
        boolean thrown = false;
        Percolation target = new Percolation(4);

        try {
            target.isFull(0, 0);
        } catch (Exception e) {
            thrown = e.getClass() == IndexOutOfBoundsException.class;
        }

        assertTrue(thrown);
    }

    public void testIsNotFullEvenIfSiteIsOpenAndSystemPercolates() {
        Percolation target = new Percolation(3);

        target.open(3, 1);

        target.open(1, 3);
        target.open(2, 3);
        target.open(3, 3);

        assertFalse(target.isFull(3, 1));
    }

    public void testIfIllegalArgumentExceptionThrownOnZeroSize() {
        boolean thrown = false;
        try {
            new Percolation(0);
        } catch (Exception e) {
            thrown = e.getClass() == IllegalArgumentException.class;
        }

        assertTrue(thrown);
    }
}
