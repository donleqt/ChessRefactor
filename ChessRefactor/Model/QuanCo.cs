using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Model
{
   public class QuanCo
    {
      protected char mauCo;

      public QuanCo()
      {

      }
      public QuanCo(char color)
      {
            this.mauCo = color;
      }
      protected virtual bool KiemTraVT(int x0, int y0, int x1, int y1, BanCo mBanCo) { return false; } //Kiểm tra vị trí di chuyển hợp lệ
      public virtual char LayTen() {return '-';} //Hàm lấy tên quân cờ 
      public char LayMau() {
          return mauCo;
      } //Hàm lấy màu cờ
      public bool MoveHopLe(int x0, int y0, int x1, int y1, BanCo mBanCo)
      {
          QuanCo vtMoi = mBanCo.banCo[x1, y1];
          if ((vtMoi == null) || (mauCo != vtMoi.LayMau()))
          {
              return KiemTraVT(x0, y0, x1, y1, mBanCo);
          }
          return false;
      }

      public virtual QuanCo clone()
      {
          return null;
      }
    }
}
