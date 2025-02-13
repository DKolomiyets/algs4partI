﻿namespace Percolation
{
    /**
     *  The <tt>WeightedQuickUnionUF</tt> class represents a Union-find data structure.
     *  It supports the <em>Union</em> and <em>find</em> operations, along with
     *  methods for determinig whether two objects are in the same component
     *  and the total number of components.
     *  <p>
     *  This implementation uses weighted quick Union by size (without path compression).
     *  Initializing a data structure with <em>N</em> objects takes linear time.
     *  Afterwards, <em>Union</em>, <em>find</em>, and <em>connected</em> take
     *  logarithmic time (in the worst case) and <em>count</em> takes constant
     *  time.
     *  <p>
     *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/15uf">Section 1.5</a> of
     *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
     *     
     *  @author Robert Sedgewick
     *  @author Kevin Wayne
     */
    public class WeightedQuickUnionUF
    {
        private int[] id;    // id[i] = parent of i
        private int[] sz;    // sz[i] = number of objects in subtree rooted at i
        private int count;   // number of components

        /**
         * Initializes an empty Union-find data structure with n isolated components 0 through n-1.
         * @throws java.lang.IllegalArgumentException if n < 0
         * @param n the number of objects
         */
        public WeightedQuickUnionUF( int n )
        {
            count = n;
            id = new int[n];
            sz = new int[n];
            for( int i = 0; i < n; i++ )
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        /**
         * Returns the number of components.
         * @return the number of components (between 1 and N)
         */
        public int Count
        {
            get { return count; }
        }

        /**
         * Returns the component identifier for the component containing site <tt>p</tt>.
         * @param p the integer representing one site
         * @return the component identifier for the component containing site <tt>p</tt>
         * @throws java.lang.IndexOutOfBoundsException unless 0 <= p < N
         */
        public int Find( int p )
        {
            while( p != id[p] )
                p = id[p];
            return p;
        }

        /**
         * Are the two sites <tt>p</tt> and <tt>q</tt> in the same component?
         * @param p the integer representing one site
         * @param q the integer representing the other site
         * @return <tt>true</tt> if the two sites <tt>p</tt> and <tt>q</tt>
         *    are in the same component, and <tt>false</tt> otherwise
         * @throws java.lang.IndexOutOfBoundsException unless both 0 <= p < N and 0 <= q < N
         */
        public bool Connected( int p, int q )
        {
            return Find( p ) == Find( q );
        }


        /**
         * Merges the component containing site<tt>p</tt> with the component
         * containing site <tt>q</tt>.
         * @param p the integer representing one site
         * @param q the integer representing the other site
         * @throws java.lang.IndexOutOfBoundsException unless both 0 <= p < N and 0 <= q < N
         */
        public void Union( int p, int q )
        {
            int rootP = Find( p );
            int rootQ = Find( q );
            if( rootP == rootQ )
                return;

            // make smaller root point to larger one
            if( sz[rootP] < sz[rootQ] )
            {
                id[rootP] = rootQ;
                sz[rootQ] += sz[rootP];
            }
            else
            {
                id[rootQ] = rootP;
                sz[rootP] += sz[rootQ];
            }
            count--;
        }
    }
}
