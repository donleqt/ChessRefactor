using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
    class Tot:QuanCo
    {
       

        public Tot(string mau)
        {
            // TODO: Complete member initialization
            this.mauCo = mau[0];
        }
        protected override bool KiemTraVT(int x0, int y0, int x1, int y1, BanCo mBanCo)
        {
            QuanCo vtMoi = mBanCo.banCo[x1,y1];
            if (vtMoi == null) //Nếu vị trí mới trống
            {
                if (y0 == y1)
                {
                    if (LayMau() == 'W')
                    {
                        if (x0 == 1)
                        {
                            if (x1 == x0 + 1 || x1 == x0 + 2)
                                return true;

                        }
                        else
                        {
                            if (x1 == x0 + 1)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (x0 == 6)
                        {
                            if (x1 == x0 - 1 || x1 == x0 - 2)
                            {
                                return true;
                            }
                        }
                        else
                            if (x1 == x0 - 1)
                            {
                                return true;
                            }
                    }
                }
            }
            else
            { //Nếu vị trí mới đã bị chiếm
                {
                    if ((y0 == y1 + 1) || (y0 == y1 - 1))
                    {
                        if (LayMau() == 'W')
                        { //Nếu trước mặt là quân đen
                            if (x1 == x0 + 1)
                            {
                                return true;
                            }
                        }
                        else
                        { //Nếu trước mặt là quân trắng
                            if (x1 == x0 - 1)
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
        }

        public override char LayTen()
        {
            return 'P';
        }

        public override QuanCo clone()
        {
            // clone instance memberwise
            return this.MemberwiseClone() as QuanCo;
        }
    }
}
