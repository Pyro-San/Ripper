using System;
using System.Collections.Generic;

namespace Ripper.Models
{
    [Serializable]
    public class Stock
    {
        // This class is for the available stock
        // TODO: Add Cost per piece & piece limit

        public int Id { get; private set; }
        public float Size { get; set; }
        public float Cost { get; set; }
        public float Remaining { get; set; }
        public int Ticks { get; private set; }
        private readonly List<Length> _cuts;

        public Stock(float size, float cost, int id)
        {
            Cost = cost;
            Size = size;
            Id = id;
            Remaining = size;
            _cuts = new List<Length>();

            Ticks = Convert.ToInt32(size/100);

        }

        public bool AddCut(Length l)
        {
            var cut = l.Size;
            if (cut > 0 && cut >= Remaining) return false;
            l.Percent = (int) (l.Size / Ticks);
            _cuts.Add(l);
            Remaining = Remaining - cut;
            return true;
        }

        public List<Length> GetCutList()
        {
            return _cuts;
        }

        public int CountCuts()
        {
            return _cuts.Count;
        }
    }
}