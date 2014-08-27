/**
 * Created by D.Kolomiyets on 2/2/14.
 */

public class Percolation {
    private boolean[] sites;
    private int size;
    private WeightedQuickUnionUF relations;
    private WeightedQuickUnionUF toTopSiteRelations;
    private int topSiteIndex;
    private int bottomSiteIndex;

    public Percolation(int n) {
        if (n <= 0) {
            throw new IllegalArgumentException("Invalid grid size specified.");
        }

        size = n;
        sites = new boolean[size * size + 1];

        for (int i = 0; i < size * size + 1; i++)
            sites[i] = false;

        relations = new WeightedQuickUnionUF(size * size + 2);
        topSiteIndex = 0;
        bottomSiteIndex = size * size + 1;

        toTopSiteRelations = new WeightedQuickUnionUF(size * size + 1);
    }

    public boolean percolates() {
        return relations.connected(topSiteIndex, bottomSiteIndex);
    }

    public void open(int i, int j) {
        checkIndexes(i, j);

        int index = xyTo1D(i, j);

        sites[index] = true;

        if (size == 1) {
            relations.union(topSiteIndex, index);
            relations.union(bottomSiteIndex, index);
            toTopSiteRelations.union(topSiteIndex, index);
        } else if (i == 1 && j == 1) {
            if (isOpen(i + 1, j)) {
                relations.union(index, xyTo1D(i + 1, j));
                toTopSiteRelations.union(index, xyTo1D(i + 1, j));
            }
            if (isOpen(i, j + 1)) {
                relations.union(index, xyTo1D(i, j + 1));
                toTopSiteRelations.union(index, xyTo1D(i, j + 1));
            }
            relations.union(topSiteIndex, index);
            toTopSiteRelations.union(topSiteIndex, index);
        } else if (i == size && j == size) {
            if (isOpen(i - 1, j)) {
                relations.union(index, xyTo1D(i - 1, j));
                toTopSiteRelations.union(index, xyTo1D(i - 1, j));
            }
            if (isOpen(i, j - 1)) {
                relations.union(index, xyTo1D(i, j - 1));
                toTopSiteRelations.union(index, xyTo1D(i, j - 1));
            }
            relations.union(bottomSiteIndex, index);
        } else if (i == size && j == 1) {
            if (isOpen(i - 1, j)) {
                relations.union(index, xyTo1D(i - 1, j));
                toTopSiteRelations.union(index, xyTo1D(i - 1, j));
            }
            if (isOpen(i, j + 1)) {
                relations.union(index, xyTo1D(i, j + 1));
                toTopSiteRelations.union(index, xyTo1D(i, j + 1));
            }
            relations.union(bottomSiteIndex, index);
        } else if (i == 1 && j == size) {
            if (isOpen(i + 1, j)) {
                relations.union(index, xyTo1D(i + 1, j));
                toTopSiteRelations.union(index, xyTo1D(i + 1, j));
            }
            if (isOpen(i, j - 1)) {
                relations.union(index, xyTo1D(i, j - 1));
                toTopSiteRelations.union(index, xyTo1D(i, j - 1));
            }
            relations.union(topSiteIndex, index);
            toTopSiteRelations.union(topSiteIndex, index);
        } else if (i == 1) {
            if (isOpen(i + 1, j)) {
                relations.union(index, xyTo1D(i + 1, j));
                toTopSiteRelations.union(index, xyTo1D(i + 1, j));
            }
            if (isOpen(i, j + 1)) {
                relations.union(index, xyTo1D(i, j + 1));
                toTopSiteRelations.union(index, xyTo1D(i, j + 1));
            }
            if (isOpen(i, j - 1)) {
                relations.union(index, xyTo1D(i, j - 1));
                toTopSiteRelations.union(index, xyTo1D(i, j - 1));
            }
            relations.union(topSiteIndex, index);
            toTopSiteRelations.union(topSiteIndex, index);
        } else if (i == size) {
            if (isOpen(i - 1, j)) {
                relations.union(index, xyTo1D(i - 1, j));
                toTopSiteRelations.union(index, xyTo1D(i - 1, j));
            }
            if (isOpen(i, j + 1)) {
                relations.union(index, xyTo1D(i, j + 1));
                toTopSiteRelations.union(index, xyTo1D(i, j + 1));
            }
            if (isOpen(i, j - 1)) {
                relations.union(index, xyTo1D(i, j - 1));
                toTopSiteRelations.union(index, xyTo1D(i, j - 1));
            }
            relations.union(bottomSiteIndex, index);
        } else if (j == 1) {
            if (isOpen(i - 1, j)) {
                relations.union(index, xyTo1D(i - 1, j));
                toTopSiteRelations.union(index, xyTo1D(i - 1, j));
            }
            if (isOpen(i + 1, j)) {
                relations.union(index, xyTo1D(i + 1, j));
                toTopSiteRelations.union(index, xyTo1D(i + 1, j));
            }
            if (isOpen(i, j + 1)) {
                relations.union(index, xyTo1D(i, j + 1));
                toTopSiteRelations.union(index, xyTo1D(i, j + 1));
            }
        } else if (j == size) {
            if (isOpen(i - 1, j)) {
                relations.union(index, xyTo1D(i - 1, j));
                toTopSiteRelations.union(index, xyTo1D(i - 1, j));
            }
            if (isOpen(i + 1, j)) {
                relations.union(index, xyTo1D(i + 1, j));
                toTopSiteRelations.union(index, xyTo1D(i + 1, j));
            }
            if (isOpen(i, j - 1)) {
                relations.union(index, xyTo1D(i, j - 1));
                toTopSiteRelations.union(index, xyTo1D(i, j - 1));
            }
        } else {
            if (isOpen(i - 1, j)) {
                relations.union(index, xyTo1D(i - 1, j));
                toTopSiteRelations.union(index, xyTo1D(i - 1, j));
            }
            if (isOpen(i + 1, j)) {
                relations.union(index, xyTo1D(i + 1, j));
                toTopSiteRelations.union(index, xyTo1D(i + 1, j));
            }
            if (isOpen(i, j + 1)) {
                relations.union(index, xyTo1D(i, j + 1));
                toTopSiteRelations.union(index, xyTo1D(i, j + 1));
            }
            if (isOpen(i, j - 1)) {
                relations.union(index, xyTo1D(i, j - 1));
                toTopSiteRelations.union(index, xyTo1D(i, j - 1));
            }
        }
    }

    public boolean isOpen(int i, int j) {
        checkIndexes(i, j);

        int index = xyTo1D(i, j);

        return sites[index];
    }

    public boolean isFull(int i, int j) {
        checkIndexes(i, j);

        return isOpen(i, j) && toTopSiteRelations.connected(topSiteIndex, xyTo1D(i, j));
    }

    private int xyTo1D(int x, int y) {
        return (x - 1) * size + y;
    }

    private void checkIndexes(int x, int y) {
        if (x <= 0 || x > size) throw new IndexOutOfBoundsException();

        if (y <= 0 || y > size) throw new IndexOutOfBoundsException();
    }
}
