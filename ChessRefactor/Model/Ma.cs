using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
    class Ma:QuanCo
    {
      

        public Ma(string mau)
        {
            // TODO: Complete member initialization
            this.mauCo = mau[0];
        }
        protected override bool KiemTraVT(int x0, int y0, int x1, int y1, BanCo mBanCo)
        {
            if ((y0 == y1 + 1) || (y0 == y1 - 1))
            {
                if ((x0 == x1 + 2) || (x0 == x1 - 2))
                {
                    return true;
                }
            }
            if ((y0 == y1 + 2) || (y0 == y1 - 2))
            {
                if ((x0 == x1 + 1) || (x0 == x1 - 1))
                {
                    return true;
                }
            }
            return false;
        }

        public override char LayTen()
        {
            return 'N';
        }
        public override QuanCo clone()
        {
            // clone instance memberwise
            return this.MemberwiseClone() as QuanCo;
        }
    }
}
