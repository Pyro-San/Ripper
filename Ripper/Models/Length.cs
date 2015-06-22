using System;

namespace Ripper.Models
{
    public class Length
    {
        private readonly double _length;
        private readonly double _cutWidth;
        private int _boardPercent;

        public Length(double length, double cutWidth)
        {
            _length = length;
            _cutWidth = cutWidth;
        }

        public void SetPercent(double p)
        {
            _boardPercent = Convert.ToInt32(Math.Round(p, 0));
        }

        public double GetLength()
        {
            return _length + _cutWidth;
        }

        public double GetPercent()
        {
            return _boardPercent;
        }
    }
}