using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
    class Xe : QuanCo
    {
     
        public Xe(string mau)
        {
            // TODO: Complete member initialization
            this.mauCo = mau[0];
        }
        protected override bool KiemTraVT(int x0, int y0, int x1, int y1, BanCo mBanCo)
        {
            if (x0 == x1)
            {
                // Kiểm tra các ô trên đường đi xem có trống hay k
                int dichY = (y1 - y0 > 0) ? 1 : -1;
                for (int kiemTraY = y0 + dichY; kiemTraY != y1; kiemTraY = kiemTraY + dichY)
                {
                    if (mBanCo.banCo[x0,kiemTraY] != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (y1 == y0)
            {
                // Kiểm tra các ô trên đường đi xem có trống hay k
                int dichX = (x1 - x0 > 0) ? 1 : -1;
                for (int kiemTraX = x0 + dichX; kiemTraX != x1; kiemTraX = kiemTraX + dichX)
                {
                    if (mBanCo.banCo[kiemTraX,y0] != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public override char LayTen()
        {
            return 'R';
        }
        public override QuanCo clone()
        {
            // clone instance memberwise
            return this.MemberwiseClone() as QuanCo;
        }
    }
}
