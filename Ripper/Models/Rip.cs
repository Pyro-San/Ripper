using System.Collections.Generic;

namespace Ripper.Models
{
    public class Rip
    {
        // This class stores the solution
        public bool IsLinQable { get; set; }
        public float Stock { get; set; }
        public float Cost { get; set; }
        public float Employ { get; set; }
        public float Reject { get; set; }
        public List<Length> LengthsAssigned { get; set; }

        public Rip(float size, float cost)
        {
            IsLinQable = true;
            Stock = size;
            Cost = cost;
            Employ = 0;
            Reject = size;
            LengthsAssigned = new List<Length>();
        }
    }

}