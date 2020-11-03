using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task13
{
    class PositionComparer : IComparer<Worker>
    {
        public int Compare(Worker x, Worker y)
        {
            return String.Compare(x.Position, y.Position);
        }
    }
}
