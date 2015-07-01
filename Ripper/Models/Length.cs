using System;

namespace Ripper.Models
{
    public class Length
    {
        // this class is for the required lengths
        public Length(float size)
        {
            Size = size;
        }

        public float Size { get; set; }
        public uint Pieces { get; set; }

        private int _stockPercent;
        public int Percent
        {
            get { return _stockPercent; }
            set { _stockPercent = Convert.ToInt32(Math.Round((double) value, 0)); }
        }

    }
}