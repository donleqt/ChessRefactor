using ChessRefactor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
    public class BanCo
    {
        public QuanCo[,] banCo;
        static public BanCo Obj=null;
        BanCo() {
            
        }
        static public BanCo getBanCo()
        {
            if (Obj ==null)
            {
                Obj = new BanCo();
                Obj.banCo = new QuanCo[8, 8];
                Obj.xepQuanCo();
            }
            return Obj;
        }

        private void xepQuanCo() {
            for (int cot = 0; cot < 8; cot++) 
		    {
			    banCo[6,cot] = QuanCoFactory.taoQuanCo("P","B");
		    }
            banCo[7, 0] = QuanCoFactory.taoQuanCo("R", "B");
            banCo[7, 1] = QuanCoFactory.taoQuanCo("N", "B");
            banCo[7, 2] = QuanCoFactory.taoQuanCo("B", "B");
            banCo[7, 3] = QuanCoFactory.taoQuanCo("K", "B");
            banCo[7, 4] = QuanCoFactory.taoQuanCo("Q", "B");
            banCo[7, 5] = QuanCoFactory.taoQuanCo("B", "B");
            banCo[7, 6] = QuanCoFactory.taoQuanCo("N", "B");
            banCo[7, 7] = QuanCoFactory.taoQuanCo("R", "B");
		    // Xếp quân trắng
		    for (int cot = 0; cot < 8; cot++)
		    {
                banCo[1, cot] = QuanCoFactory.taoQuanCo("P", "W");
		    }
            banCo[0, 0] = QuanCoFactory.taoQuanCo("R", "W");
            banCo[0, 1] = QuanCoFactory.taoQuanCo("N", "W");
            banCo[0, 2] = QuanCoFactory.taoQuanCo("B", "W");
            banCo[0, 3] = QuanCoFactory.taoQuanCo("K", "W");
            banCo[0, 4] = QuanCoFactory.taoQuanCo("Q", "W");
            banCo[0, 5] = QuanCoFactory.taoQuanCo("B", "W");
            banCo[0, 6] = QuanCoFactory.taoQuanCo("N", "W");
            banCo[0, 7] = QuanCoFactory.taoQuanCo("R", "W");
            }
        
    }
}
