using System;
using System.Collections.Generic;
using System.Linq;

namespace Ripper.Models
{
    public class BoardCutter
    {
        readonly List<Board> _boards;
        readonly List<Length> _lengthsNeeded;
        readonly double _cutWidth;
        public List<string> Summary;

        public BoardCutter()
        {
            _cutWidth = 2;

            _boards = new List<Board>();
            _lengthsNeeded = new List<Length>();
            
            //CutList = new List<Length>();

            //Instructions = new List<string>();
            Summary = new List<string>();
            
            AddBoard(6000);
            AddBoard(6000);
            AddBoard(3600);
            //AddBoard(6000);

            AddLength(1500);
            AddLength(1500);
            AddLength(1300);
            AddLength(1300);
            AddLength(950);
            AddLength(950);
            AddLength(950);
            AddLength(950);
            AddLength(600);
            AddLength(600);
            AddLength(600);
            AddLength(600);
            AddLength(600);
            AddLength(600);

            var totalBoardLength = BoardTotal();
            var totalLengthNeeded = LengthTotal();

            if (totalBoardLength < totalLengthNeeded)
            {
                Summary.Add("Insufficent boards available");
                Summary.Add(string.Format("Available: {0}", totalBoardLength));
                Summary.Add(string.Format("Required: {0}", totalLengthNeeded));
            }
            else
            {
                foreach (var l in _lengthsNeeded.Where(l => l != null))
                    TryCutNew(l);
            }
        }

        public BoardCutter(IEnumerable<int> boards, IEnumerable<int> lengs)
        {
            _cutWidth = 2;
            _boards = new List<Board>();
            _lengthsNeeded = new List<Length>();
            Summary = new List<string>();

            foreach (var board in boards)
            {
                AddBoard(Convert.ToDouble(board));
            }
            foreach (var leng in lengs)
            {
                AddLength(Convert.ToDouble(leng));
            }

            var totalBoardLength = BoardTotal();
            var totalLengthNeeded = LengthTotal();

            if (totalBoardLength < totalLengthNeeded)
            {
                Summary.Add("Insufficent boards available");
                Summary.Add(string.Format("Available: {0}", totalBoardLength));
                Summary.Add(string.Format("Required: {0}", totalLengthNeeded));
            }
            else
            {
                foreach (var l in _lengthsNeeded.Where(l => l != null))
                    TryCutNew(l);
            }

        }

        public void AddBoard(double board)
        {
            _boards.Add(new Board(board));
        }

        public void AddLength(double length)
        {
            _lengthsNeeded.Add(new Length(length, _cutWidth));
        }

        void TryCutNew(Length l)
        {
            if (l.GetLength() <= 0) return;
            foreach (var board in _boards)
            {
                if (board.AddCut(l))
                    return;
            }
        }

        public List<Board> Boards()
        {
            return _boards;
        }

        public double BoardTotal()
        {
            return _boards.Select(i => i.GetLength()).Sum();
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

