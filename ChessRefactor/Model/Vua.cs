using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
    class Vua :QuanCo
    {
        
        public Vua(string mau)
        {   
            // TODO: Complete member initialization
            this.mauCo = mau[0];
        }
        protected override bool KiemTraVT(int x0, int y0, int x1, int y1, BanCo mBanCo)
        {
            int dentaX = x1 - x0;
            int dentaY = y1 - y0;
            if (((dentaX >= -1) && (dentaX <= 1)) &&
                ((dentaY >= -1) && (dentaY <= 1)))
            {
                return true;
            }
            return false;
        }

        public override char LayTen()
        {
            return 'K';
        }
        public override QuanCo clone()
        {
            // clone instance memberwise
            return this.MemberwiseClone() as QuanCo;
        }
    }
}
