using System;
using System.Collections.Generic;

namespace Ripper.Models
{
    public class BranchAndBound
    {
        /*
         * This class generates the solution's space of research: the Branch & Bound data structure.
         * A status label shows information during the process.         
         */
        public string Status;
        private float _maxBranch;
        private float _evaluatedBranchCounter;
        private readonly float _totalItemsSum;
        private readonly float _boundValue;
        private readonly int[] _maxStocksQuantity;
        private readonly List<Stock> _branchListOfStocks;
        private List<Length> _branchListOfItems;

        public struct BranchBound
        {
            public float Size;
            public float Cost;
            public float[] SetOfStocks;
            public float[] SetOfStocksCost;
        }

        private readonly List<BranchBound> _branchBoundList;

        public BranchAndBound(List<Stock> theStocks, List<Length> theItems, float theTotalItemsSum, float theBound)
        {
            _totalItemsSum = theTotalItemsSum;
            _boundValue = theBound;

            _branchListOfStocks = new List<Stock>();
            _branchListOfStocks = theStocks;

            _branchListOfItems = new List<Length>();
            _branchListOfItems = theItems;

            _maxStocksQuantity = new int[theStocks.Count];
            _branchBoundList = new List<BranchBound>();
        }


        public List<BranchBound> GetBranchAndBound()
        {
            // This is the driver method for all the operations in this class.
            // It returns a Branch & Bound set of potential solutions.
            GetMaxStocksQuantity();
            GetBranchBoundList();
            return _branchBoundList;
        }


        private void GetMaxStocksQuantity()
        {
            // Calculate the maximum number of each Stocks needed to reach the Bound and the maximum number of branches
            _maxBranch = 1;
            for (var i = 0; i < _maxStocksQuantity.Length; ++i)
            {
                var qmax = (int)Math.Ceiling(_boundValue / _branchListOfStocks[i].Size);
                //if (BranchListOfStocks[i].ConsiderMaxPieces && qmax > BranchListOfStocks[i].MaxPieces)
                //{
                //    qmax = (int)BranchListOfStocks[i].MaxPieces;
                //}
                _maxStocksQuantity[i] = qmax;
                _maxBranch *= qmax;
            }
        }


        private void GetBranchBoundList()
        {
            // A maximum number of Stock sizes is managed by this algorithm. This is a design choice based on the practice.

            try
            {
                // 1 Stock
                float measure;
                if (_maxStocksQuantity.Length == 1)
                {
                    for (var c1 = 0; c1 <= _maxStocksQuantity[0]; ++c1)
                    {
                        ++_evaluatedBranchCounter;
                        if (_evaluatedBranchCounter % 500 == 0)
                        {
                            UpdateStatus();
                        }

                        measure = c1 * _branchListOfStocks[0].Size;
                        if (!(measure >= _totalItemsSum) || !(measure < _boundValue)) continue;
                        var bb = new BranchBound {Size = measure, Cost = c1*_branchListOfStocks[0].Cost};
                        Array.Resize(ref bb.SetOfStocks, c1);
                        Array.Resize(ref bb.SetOfStocksCost, c1);
                        var coeff = new[] { c1 };
                        AddItemToBranchBoundList(bb, coeff);
                    }
                }

                // 2 Stocks
                if (_maxStocksQuantity.Length == 2)
                {
                    for (var c1 = 0; c1 <= _maxStocksQuantity[0]; ++c1)
                    {
                        for (var c2 = 0; c2 <= _maxStocksQuantity[1]; ++c2)
                        {
                            ++_evaluatedBranchCounter;
                            if (_evaluatedBranchCounter % 500 == 0)
                            {
                                UpdateStatus();
                            }

                            measure = c1 * _branchListOfStocks[0].Size + c2 * _branchListOfStocks[1].Size;
                            if (!(measure >= _totalItemsSum) || !(measure < _boundValue)) continue;
                            var bb = new BranchBound
                            {
                                Size = measure,
                                Cost = c1*_branchListOfStocks[0].Cost + c2*_branchListOfStocks[1].Cost
                            };
                            Array.Resize(ref bb.SetOfStocks, c1 + c2);
                            Array.Resize(ref bb.SetOfStocksCost, c1 + c2);
                            var coeff = new[] { c1, c2 };
                            AddItemToBranchBoundList(bb, coeff);
                        }
                    }
                }

                // 3 Stocks
                if (_maxStocksQuantity.Length == 3)
                {
                    for (var c1 = 0; c1 <= _maxStocksQuantity[0]; ++c1)
                    {
                        for (var c2 = 0; c2 <= _maxStocksQuantity[1]; ++c2)
                        {
                            for (var c3 = 0; c3 <= _maxStocksQuantity[2]; ++c3)
                            {
                                ++_evaluatedBranchCounter;
                                if (_evaluatedBranchCounter % 500 == 0)
                                {
                                    UpdateStatus();
                                }

                                measure = c1 * _branchListOfStocks[0].Size + c2 * _branchListOfStocks[1].Size + c3 * _branchListOfStocks[2].Size;
                                if (!(measure >= _totalItemsSum) || !(measure < _boundValue)) continue;
                                var bb = new BranchBound
                                {
                                    Size = measure,
                                    Cost =
                                        c1*_branchListOfStocks[0].Cost + c2*_branchListOfStocks[1].Cost +
                                        c3*_branchListOfStocks[2].Cost
                                };
                                Array.Resize(ref bb.SetOfStocks, c1 + c2 + c3);
                                Array.Resize(ref bb.SetOfStocksCost, c1 + c2 + c3);
                                var coeff = new[] { c1, c2, c3 };
                                AddItemToBranchBoundList(bb, coeff);
                            }
                        }
                    }
                }

                // 4 Stocks
                if (_maxStocksQuantity.Length == 4)
                {
                    for (var c1 = 0; c1 <= _maxStocksQuantity[0]; ++c1)
                    {
                        for (var c2 = 0; c2 <= _maxStocksQuantity[1]; ++c2)
                        {
                            for (var c3 = 0; c3 <= _maxStocksQuantity[2]; ++c3)
                            {
                                for (var c4 = 0; c4 <= _maxStocksQuantity[3]; ++c4)
                                {
                                    ++_evaluatedBranchCounter;
                                    if (_evaluatedBranchCounter % 5000 == 0)
                                    {
                                        UpdateStatus();
                                    }

                                    measure = c1 * _branchListOfStocks[0].Size + c2 * _branchListOfStocks[1].Size + c3 * _branchListOfStocks[2].Size
                                   + c4 * _branchListOfStocks[3].Size;

                                    if (!(measure >= _totalItemsSum) || !(measure < _boundValue)) continue;
                                    var bb = new BranchBound
                                    {
                                        Size = measure,
                                        Cost =
                                            c1*_branchListOfStocks[0].Cost + c2*_branchListOfStocks[1].Cost +
                                            c3*_branchListOfStocks[2].Cost
                                            + c4*_branchListOfStocks[3].Cost
                                    };
                                    Array.Resize(ref bb.SetOfStocks, c1 + c2 + c3 + c4);
                                    Array.Resize(ref bb.SetOfStocksCost, c1 + c2 + c3 + c4);
                                    var coeff = new[] { c1, c2, c3, c4 };
                                    AddItemToBranchBoundList(bb, coeff);
                                }
                            }
                        }
                    }
                }

                // 5 Stocks
                if (_maxStocksQuantity.Length == 5)
                {
                    for (var c1 = 0; c1 <= _maxStocksQuantity[0]; ++c1)
                    {
                        for (var c2 = 0; c2 <= _maxStocksQuantity[1]; ++c2)
                        {
                            for (var c3 = 0; c3 <= _maxStocksQuantity[2]; ++c3)
                            {
                                for (var c4 = 0; c4 <= _maxStocksQuantity[3]; ++c4)
                                {
                                    for (var c5 = 0; c5 <= _maxStocksQuantity[4]; ++c5)
                                    {
                                        ++_evaluatedBranchCounter;
                                        if (_branchBoundList.Count % 5000 == 0)
                                        {
                                            UpdateStatus();
                                        }
                                        measure = c1 * _branchListOfStocks[0].Size + c2 * _branchListOfStocks[1].Size + c3 * _branchListOfStocks[2].Size
                                       + c4 * _branchListOfStocks[3].Size + c5 * _branchListOfStocks[4].Size;

                                        if (!(measure >= _totalItemsSum) || !(measure < _boundValue)) continue;
                                        var bb = new BranchBound
                                        {
                                            Size = measure,
                                            Cost = c1*_branchListOfStocks[0].Cost + c2*_branchListOfStocks[1].Cost +
                                                   c3*_branchListOfStocks[2].Cost + c4*_branchListOfStocks[3].Cost +
                                                   c5*_branchListOfStocks[4].Cost
                                        };
                                        Array.Resize(ref bb.SetOfStocks, c1 + c2 + c3 + c4 + c5);
                                        Array.Resize(ref bb.SetOfStocksCost, c1 + c2 + c3 + c4 + c5);
                                        var coeff = new[] { c1, c2, c3, c4, c5 };
                                        AddItemToBranchBoundList(bb, coeff);
                                    }
                                }
                            }
                        }
                    }
                }

                // 6 Stocks
                if (_maxStocksQuantity.Length != 6) return;
                for (var c1 = 0; c1 <= _maxStocksQuantity[0]; ++c1)
                {
                    for (var c2 = 0; c2 <= _maxStocksQuantity[1]; ++c2)
                    {
                        for (var c3 = 0; c3 <= _maxStocksQuantity[2]; ++c3)
                        {
                            for (var c4 = 0; c4 <= _maxStocksQuantity[3]; ++c4)
                            {
                                for (var c5 = 0; c5 <= _maxStocksQuantity[4]; ++c5)
                                {
                                    for (var c6 = 0; c6 <= _maxStocksQuantity[5]; ++c6)
                                    {
                                        ++_evaluatedBranchCounter;
                                        if (_branchBoundList.Count % 10000 == 0)
                                        {
                                            UpdateStatus();
                                        }
                                        measure = c1 * _branchListOfStocks[0].Size + c2 * _branchListOfStocks[1].Size
                                                  + c3 * _branchListOfStocks[2].Size + c4 * _branchListOfStocks[3].Size
                                                  + c5 * _branchListOfStocks[4].Size + c6 * _branchListOfStocks[5].Size;

                                        if (!(measure >= _totalItemsSum) || !(measure < _boundValue)) continue;
                                        var bb = new BranchBound
                                        {
                                            Size = measure,
                                            Cost = c1*_branchListOfStocks[0].Cost + c2*_branchListOfStocks[1].Cost +
                                                   c3*_branchListOfStocks[2].Cost + c4*_branchListOfStocks[3].Cost +
                                                   c5*_branchListOfStocks[4].Cost + c6*_branchListOfStocks[5].Cost
                                        };
                                        Array.Resize(ref bb.SetOfStocks, c1 + c2 + c3 + c4 + c5 + c6);
                                        Array.Resize(ref bb.SetOfStocksCost, c1 + c2 + c3 + c4 + c5 + c6);
                                        var coeff = new[] { c1, c2, c3, c4, c5, c6 };
                                        AddItemToBranchBoundList(bb, coeff);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (OutOfMemoryException)
            {
                Status += "Memory Full!\nThe application will be quitted.\nRetry with less Items or remove some Stocks.";
                return;
            }
        }

        private void AddItemToBranchBoundList(BranchBound myB, params int[] myCoeff)
        {
            // Adds a new branch to the Branch & Bound List
            var j = 0;
            for (var k = 0; k < _branchListOfStocks.Count; ++k)
            {
                while (myCoeff[k] > 0)
                {
                    myB.SetOfStocks[j] = _branchListOfStocks[k].Size;
                    myB.SetOfStocksCost[j] = _branchListOfStocks[k].Cost;
                    --myCoeff[k];
                    ++j;
                }
            }
            _branchBoundList.Add(myB);
        }

        private void UpdateStatus()
        {
            // Shows information on the process
            Status += "Branch and Bound. Evaluating branch " + _evaluatedBranchCounter.ToString("#,###") + " of " + _maxBranch.ToString("#,###");
        }
    }
}