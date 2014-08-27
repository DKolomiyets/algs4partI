import junit.framework.TestCase;

/**
 * Created by D.Kolomiyets on 2/4/14.
 */

public class PercolationStatsTests extends TestCase {
    public void testIfIllegalArgumentExceptionThrownOnZeroSize() {
        boolean thrown = false;
        try {
            new PercolationStats(0, 100);
        } catch (Exception e) {
            thrown = e.getClass() == IllegalArgumentException.class;
        }

        assertTrue(thrown);
    }

    public void testIfIllegalArgumentExceptionThrownOnZeroExperimentsCount() {
        boolean thrown = false;
        try {
            new PercolationStats(10, 0);
        } catch (Exception e) {
            thrown = e.getClass() == IllegalArgumentException.class;
        }

        assertTrue(thrown);
    }

    public void testIfDoubleNaNReturnedOn1ExperimentSpecified() {
        PercolationStats target = new PercolationStats(2, 1);

        assertEquals(Double.NaN, target.stddev());
    }

    public void testThatLowerBoundIsLessThenUpperBound() {
        PercolationStats target = new PercolationStats(3, 5);

        assertTrue(target.confidenceLo() < target.confidenceHi());
    }
}
