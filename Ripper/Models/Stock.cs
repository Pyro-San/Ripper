using System;
using System.Collections.Generic;

namespace Ripper.Models
{
    public class Stock
    {
        private readonly int _id;
        private readonly float _length;
        private float _remaining;
        private readonly List<Length> _cuts;

        private readonly int _boardTicks;

        public Stock(float length, int id)
        {
            _length = length;
            _id = id;
            _remaining = length;
            _cuts = new List<Length>();

            _boardTicks = Convert.ToInt32(length/100);

        }

        public bool AddCut(Length l)
        {
            var cut = l.GetLength();
            if (cut > 0 && cut >= _remaining) return false;
            l.SetPercent((float)l.GetLength() / _boardTicks);
            _cuts.Add(l);
            _remaining = (float) (_remaining - cut);
            return true;
        }

        public double GetLength()
        {
            return _length;
        }

        public double GetRemainder()
        {
            return _remaining;
        }

        public int GetTicks()
        {
            return _boardTicks;
        }

        public void SetRemaining(float d)
        {
            _remaining = d;
        }

        public List<Length> GetCutList()
        {
            return _cuts;
        }

        public int GetId()
        {
            return _id;
        }

        public int CountCuts()
        {
            return _cuts.Count;
        }
    }
}