using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ripper.Models
{
    public class Board
    {
        private readonly double _length;
        private double _remaining;
        private readonly List<Length> _cuts;

        private readonly int _boardTicks;

        public Board(double length)
        {
            _length = length;
            _remaining = length;
            _cuts = new List<Length>();

            _boardTicks = Convert.ToInt32(length/100);

        }

        public bool AddCut(Length l)
        {
            var cut = l.GetLength();
            if (cut > 0 && cut >= _remaining) return false;
            l.SetPercent(l.GetLength()/_boardTicks);
            _cuts.Add(l);
            _remaining = _remaining - cut;
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

        public int GetBoardTicks()
        {
            return _boardTicks;
        }

        public void SetRemaining(double d)
        {
            _remaining = d;
        }

        public List<Length> GetCutList()
        {
            return _cuts;
        }


    }
}