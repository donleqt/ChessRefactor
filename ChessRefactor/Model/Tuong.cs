using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
    class Tuong : QuanCo
    {
       

        public Tuong(string mau)
        {
            // TODO: Complete member initialization
            this.mauCo = mau[0];
        }
        protected override bool KiemTraVT(int x0, int y0, int x1, int y1, BanCo mBanCo)
        {
            if ((y1 - y0 == x1 - x0) || (y1 - y0 == x0 - x1))
            {
                // Kiểm tra các ô trên đường đi xem có trống hay k
                int dichX = (x1 - x0 > 0) ? 1 : -1;
                int dichY = (y1 - y0 > 0) ? 1 : -1;
                int kiemTraX;
                int kiemTraY;
                for (kiemTraX = x0 + dichX, kiemTraY = y0 + dichY; kiemTraX != x1; kiemTraX = kiemTraX + dichX, kiemTraY = kiemTraY + dichY)
                {
                    if (mBanCo.banCo[kiemTraX,kiemTraY] != null)
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
            return 'B';
        }
        public override QuanCo clone()
        {
            // clone instance memberwise
            return this.MemberwiseClone() as QuanCo;
        }
    }
}
