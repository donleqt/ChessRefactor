using ChessRefactor.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessController chess = new ChessController();
            chess.play();
        }
    }
}
