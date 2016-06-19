using ChessRefactor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Helper
{
    public class QuanCoFactory
    {
        static public Dictionary<string, QuanCo> dsQuanCoMau = new Dictionary<string, QuanCo>();

        // Khởi tạo danh sách các quân cờ mẫu
        static public void khoiTaoCacLoaiQuanCo()
        {
            //Quân đen
            dsQuanCoMau.Add("KB", new Vua("B"));
            dsQuanCoMau.Add("QB", new Hau("B"));
            dsQuanCoMau.Add("RB", new Xe("B"));
            dsQuanCoMau.Add("BB", new Tuong("B"));
            dsQuanCoMau.Add("NB", new Ma("B"));
            dsQuanCoMau.Add("PB", new Tot("B"));

            //Quân trắng
            dsQuanCoMau.Add("KW", new Vua("W"));
            dsQuanCoMau.Add("QW", new Hau("W"));
            dsQuanCoMau.Add("RW", new Xe("W"));
            dsQuanCoMau.Add("BW", new Tuong("W"));
            dsQuanCoMau.Add("NW", new Ma("W"));
            dsQuanCoMau.Add("PW", new Tot("W"));
        }

        // Factory method
        static public QuanCo taoQuanCo(string loai, string mau)
        {
            //mã quân cờ
            string coId = loai + mau;
            if (dsQuanCoMau.ContainsKey(coId))
                return dsQuanCoMau[coId].clone();
            return null;
          
        }
    }
}
