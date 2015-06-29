using System;

namespace Ripper.Models
{
    public class Length
    {
        private readonly float _length;
        private readonly float _cutWidth;
        private int _stockPercent;

        public Length(float length, float cutWidth)
        {
            _length = length;
            _cutWidth = cutWidth;
        }

        public void SetPercent(float p)
        {
            _stockPercent = Convert.ToInt32(Math.Round(p, 0));
        }

        public double GetLength()
        {
            return _length + _cutWidth;
        }

        public double GetPercent()
        {
            return _stockPercent;
        }
    }
}