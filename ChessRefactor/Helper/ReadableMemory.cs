using ChessRefactor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Helper
{
    class ReadableMemory:MemoryStrategy
    {
        public override bool Save(BanCo mBanCo, FileStream fout)
        {
            if (!fout.CanWrite)
                return false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    QuanCo hienTai = mBanCo.banCo[i, j];
                    string content;
                    if (hienTai != null)
                    {
                        content = "Quan Co: @" + hienTai.LayMau() + " " + hienTai.LayTen() + "- Vi tri: ["+i+","+j+ "]\n";

                    }
                    else
                    {
                        content = "Quan Co: @" + 0 + " " + 0 + "- Vi tri: [" + i + "," + j + "]\n";
                    }
                    fout.Write(Encoding.ASCII.GetBytes(content), 0, content.Length);
                }

            }
            fout.Close();
            return true;
        }
    }
}
