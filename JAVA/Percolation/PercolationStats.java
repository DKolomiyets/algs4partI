import java.util.Random;

/**
 * Created by D.Kolomiyets on 2/3/14.
 */

public class PercolationStats {
    private double deviation = 0;
    private double avg = 0;
    private int numberOfExperiments;

    public PercolationStats(int n, int t) {
        if (n <= 0) {
            throw new IllegalArgumentException("Invalid grid size specified.");
        }

        if (t <= 0) {
            throw new IllegalArgumentException("Invalid number of experiments specified.");
        }

        numberOfExperiments = t;
        double[] x = new double[t];
        for (int i = 0; i < t; i++) {
            x[i] = runExperiment(n);
            avg += x[i];
        }
        avg /= t;

        for (int i = 0; i < t; i++) {
            deviation += (x[i] - avg) * (x[i] - avg);
        }

        if (t != 1) {
            deviation /= (t - 1);
        } else {
            deviation = Double.NaN;
        }
    }

    public double mean() {
        return avg;
    }

    public double stddev() {
        return Math.sqrt(deviation);
    }

    public double confidenceLo() {
        return avg - 1.96 * Math.sqrt(deviation / numberOfExperiments);
    }

    public double confidenceHi() {
        return avg + 1.96 * Math.sqrt(deviation / numberOfExperiments);
    }

    private double runExperiment(int n) {
        Percolation p = new Percolation(n);
        double openedSites = 0;
        while (!p.percolates()) {
            Random r = new Random();
            int i = r.nextInt(n) + 1;
            int j = r.nextInt(n) + 1;
            while (p.isOpen(i, j)) {
                i = r.nextInt(n) + 1;
                j = r.nextInt(n) + 1;
            }

            p.open(i, j);
            openedSites++;
        }

        return openedSites / (n * n);
    }

    public static void main(String[] args) {
        int n = Integer.parseInt(args[0]);
        int t = Integer.parseInt(args[1]);

        PercolationStats stats = new PercolationStats(n, t);

        System.out.printf("mean                    = %f%n", stats.mean());
        System.out.printf("stddev                  = %f%n", stats.stddev());
        System.out.printf("95%% confidence interval = %f1, %f2%n", stats.confidenceLo(), stats.confidenceHi());
    }
}
