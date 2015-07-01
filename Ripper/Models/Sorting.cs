using System.Collections.Generic;

namespace Ripper.Models
{
    // Method for Non Increasing Sort of Stocks
    public class NonIncreasingSortOnStockSize : IComparer<Stock>
    {
        public int Compare(Stock x, Stock y)
        {
            if (x.Size < y.Size) return 1;
            if (x.Size > y.Size) return -1;
            return 0;
        }
    }


    // Method for Non Decreasing Sort of Items
    public class NonDecreasingSortOnItemSize : IComparer<Length>
    {
        public int Compare(Length x, Length y)
        {
            if (x.Size > y.Size) return 1;
            if (x.Size < y.Size) return -1;
            return 0;
        }
    }


    // Method for Non Increasing Sort of Items
    public class NonIncreasingSortOnItemSize : IComparer<Length>
    {
        public int Compare(Length x, Length y)
        {
            if (x.Size < y.Size) return 1;
            if (x.Size > y.Size) return -1;
            return 0;
        }
    }


    // Method for Non Decreasing Sort on Size of the Branch & Bound List
    public class NonDecreasingSortOnBranchAndBoundSize : IComparer<BranchAndBound.BranchBound>
    {
        public int Compare(BranchAndBound.BranchBound x, BranchAndBound.BranchBound y)
        {
            if (x.Size > y.Size) return 1;
            if (x.Size < y.Size) return -1;
            return 0;
        }
    }


    // Method for Non Decreasing Sort on Cost of the Branch & Bound List
    public class NonDecreasingSortOnBranchAndBoundCost : IComparer<BranchAndBound.BranchBound>
    {
        public int Compare(BranchAndBound.BranchBound x, BranchAndBound.BranchBound y)
        {
            if (x.Cost > y.Cost) return 1;
            if (x.Cost < y.Cost) return -1;
            return 0;
        }
    }
}
