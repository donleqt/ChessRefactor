using ChessRefactor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Helper
{
    class CsvMemory:MemoryStrategy
    {
        public override bool Save(BanCo mBanCo, FileStream fout)
        {
            if (!fout.CanWrite)
                return false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    QuanCo hienTai = mBanCo.banCo[i,j];
                    string content;
                    if (hienTai != null)
                    {
                       content = hienTai.LayMau() + " " + hienTai.LayTen() + "\n";
                      
                    }
                    else
                    {
                       content=0 + " " + 0;
                    }
                    fout.Write(Encoding.ASCII.GetBytes(content), 0, content.Length);
                }

            }
            return true;
        }
        public override bool Load(FileStream fin, BanCo mBanCo)
        {
            var file = new StreamReader(fin);
            try
            {
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        string content = file.ReadLine();
                        var coId = content;
                        mBanCo.banCo[i, j] = QuanCoFactory.taoQuanCo(coId[1].ToString(), coId[0].ToString());
                    }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                file.Close();
                fin.Close();
            }



        }
    }
}
