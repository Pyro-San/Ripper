using System;
using System.Collections.Generic;
using System.Linq;

namespace Ripper.Models
{
    public class Cutter
    {
        readonly List<Stock> _stock;
        readonly List<Length> _lengthsNeeded;
        readonly float _cutWidth;
        public List<string> Summary;

        public Cutter(IEnumerable<float> stock, IEnumerable<float> lengs)
        {
            _cutWidth = 2;
            _stock = new List<Stock>();
            _lengthsNeeded = new List<Length>();
            Summary = new List<string>();

            foreach (var s in stock)
            {
                AddStock(s);
            }
            foreach (var l in lengs)
            {
                AddLength(l);
            }

            var totalStockLength = StockTotal();
            var totalLengthNeeded = LengthTotal();

            if (totalStockLength < totalLengthNeeded)
            {
                Summary.Add("Insufficent boards available");
                Summary.Add(string.Format("Available: {0}", totalStockLength));
                Summary.Add(string.Format("Required: {0}", totalLengthNeeded));
            }
            else
            {
                _stock = _stock.OrderByDescending(i => i.GetLength()).ToList();
                _lengthsNeeded = _lengthsNeeded.OrderByDescending(i => i.GetLength()).ToList();

                // TODO: this requires work
                // Here is where we need to implement cut optimisation.
                // for each length, try to find a board to cut from
                foreach (var l in _lengthsNeeded.Where(l => l != null))
                {
                    foreach (var s in _stock)
                    {
                        if (TryCut(l, s)) break;
                    }
                }
            }

        }

        public void AddStock(float s)
        {
            var id = _stock.Count + 1;
            _stock.Add(new Stock(s, id));
        }

        public void AddLength(float length)
        {
            _lengthsNeeded.Add(new Length(length, _cutWidth));
        }

        static bool TryCut(Length l, Stock b)
        {
            return !(l.GetLength() <= 0) && b.AddCut(l);
        }

        public List<Stock> Stock()
        {
            return _stock;
        }

        public double StockTotal()
        {
            return _stock.Select(i => i.GetLength()).Sum();
        }

        public List<Length> Lengths()
        {
            return _lengthsNeeded;
        }

        public double LengthTotal()
        {
            return _lengthsNeeded.Select(i => i.GetLength()).Sum();
        }

    }
}

