using System;

namespace Percolation
{
    public class Percolation
    {
        private bool[] sites;
        private int size;
        private WeightedQuickUnionUF relations;
        private WeightedQuickUnionUF toTopSiteRelations;
        private int topSiteIndex;
        private int bottomSiteIndex;

        public Percolation( int n )
        {
            if( n <= 0 )
            {
                throw new ArgumentException( "Invalid grid size specified." );
            }

            size = n;
            sites = new bool[size * size + 1];

            for( int i = 0; i < size * size + 1; i++ )
                sites[i] = false;

            relations = new WeightedQuickUnionUF( size * size + 2 );
            topSiteIndex = 0;
            bottomSiteIndex = size * size + 1;

            toTopSiteRelations = new WeightedQuickUnionUF( size * size + 1 );
        }

        public bool Percolates()
        {
            return relations.Connected( topSiteIndex, bottomSiteIndex );
        }

        public void Open( int i, int j )
        {
            CheckIndexes( i, j );

            int index = XyTo1D( i, j );

            sites[index] = true;

            if( size == 1 )
            {
                relations.Union( topSiteIndex, index );
                relations.Union( bottomSiteIndex, index );
                toTopSiteRelations.Union( topSiteIndex, index );
            }
            else if( i == 1 && j == 1 )
            {
                if( IsOpen( i + 1, j ) )
                {
                    relations.Union( index, XyTo1D( i + 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i + 1, j ) );
                }
                if( IsOpen( i, j + 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j + 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j + 1 ) );
                }
                relations.Union( topSiteIndex, index );
                toTopSiteRelations.Union( topSiteIndex, index );
            }
            else if( i == size && j == size )
            {
                if( IsOpen( i - 1, j ) )
                {
                    relations.Union( index, XyTo1D( i - 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i - 1, j ) );
                }
                if( IsOpen( i, j - 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j - 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j - 1 ) );
                }
                relations.Union( bottomSiteIndex, index );
            }
            else if( i == size && j == 1 )
            {
                if( IsOpen( i - 1, j ) )
                {
                    relations.Union( index, XyTo1D( i - 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i - 1, j ) );
                }
                if( IsOpen( i, j + 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j + 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j + 1 ) );
                }
                relations.Union( bottomSiteIndex, index );
            }
            else if( i == 1 && j == size )
            {
                if( IsOpen( i + 1, j ) )
                {
                    relations.Union( index, XyTo1D( i + 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i + 1, j ) );
                }
                if( IsOpen( i, j - 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j - 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j - 1 ) );
                }
                relations.Union( topSiteIndex, index );
                toTopSiteRelations.Union( topSiteIndex, index );
            }
            else if( i == 1 )
            {
                if( IsOpen( i + 1, j ) )
                {
                    relations.Union( index, XyTo1D( i + 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i + 1, j ) );
                }
                if( IsOpen( i, j + 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j + 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j + 1 ) );
                }
                if( IsOpen( i, j - 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j - 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j - 1 ) );
                }
                relations.Union( topSiteIndex, index );
                toTopSiteRelations.Union( topSiteIndex, index );
            }
            else if( i == size )
            {
                if( IsOpen( i - 1, j ) )
                {
                    relations.Union( index, XyTo1D( i - 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i - 1, j ) );
                }
                if( IsOpen( i, j + 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j + 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j + 1 ) );
                }
                if( IsOpen( i, j - 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j - 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j - 1 ) );
                }
                relations.Union( bottomSiteIndex, index );
            }
            else if( j == 1 )
            {
                if( IsOpen( i - 1, j ) )
                {
                    relations.Union( index, XyTo1D( i - 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i - 1, j ) );
                }
                if( IsOpen( i + 1, j ) )
                {
                    relations.Union( index, XyTo1D( i + 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i + 1, j ) );
                }
                if( IsOpen( i, j + 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j + 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j + 1 ) );
                }
            }
            else if( j == size )
            {
                if( IsOpen( i - 1, j ) )
                {
                    relations.Union( index, XyTo1D( i - 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i - 1, j ) );
                }
                if( IsOpen( i + 1, j ) )
                {
                    relations.Union( index, XyTo1D( i + 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i + 1, j ) );
                }
                if( IsOpen( i, j - 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j - 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j - 1 ) );
                }
            }
            else
            {
                if( IsOpen( i - 1, j ) )
                {
                    relations.Union( index, XyTo1D( i - 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i - 1, j ) );
                }
                if( IsOpen( i + 1, j ) )
                {
                    relations.Union( index, XyTo1D( i + 1, j ) );
                    toTopSiteRelations.Union( index, XyTo1D( i + 1, j ) );
                }
                if( IsOpen( i, j + 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j + 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j + 1 ) );
                }
                if( IsOpen( i, j - 1 ) )
                {
                    relations.Union( index, XyTo1D( i, j - 1 ) );
                    toTopSiteRelations.Union( index, XyTo1D( i, j - 1 ) );
                }
            }
        }

        public bool IsOpen( int i, int j )
        {
            CheckIndexes( i, j );

            int index = XyTo1D( i, j );

            return sites[index];
        }

        public bool IsFull( int i, int j )
        {
            CheckIndexes( i, j );

            return IsOpen( i, j ) && toTopSiteRelations.Connected( topSiteIndex, XyTo1D( i, j ) );
        }

        private int XyTo1D( int x, int y )
        {
            return ( x - 1 ) * size + y;
        }

        private void CheckIndexes( int x, int y )
        {
            if( x <= 0 || x > size )
                throw new ArgumentOutOfRangeException();

            if( y <= 0 || y > size )
                throw new ArgumentOutOfRangeException();
        }
    }

}
