using ChessRefactor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Helper
{
    class SaveLoad
    {
        string path;
        MemoryStrategy loadSaveEngine;

        public SaveLoad(string mPath,int i=0)
        {
            path = mPath;
            if (i == 1)   // i==1 luu dang khong doc duoc
              loadSaveEngine = new CsvMemory();
            else
              loadSaveEngine = new ReadableMemory();
        }
        public void thayDoiPhuongThucLuuTru(int ch)
        {
            if (ch == 1)
                loadSaveEngine = new CsvMemory();
            else
                return;
        }
        public bool SaveGame(BanCo mBanco)
        {
            // Mở file
            FileStream fout = new FileStream(path,FileMode.Create, FileAccess.Write);
            bool result = loadSaveEngine.Save(mBanco, fout);
            return result;
            
        }
        public bool LoadGame(BanCo mBanco)
        {
            try
            {
                FileStream fin = new FileStream(path, FileMode.Open, FileAccess.Read);
                bool result = loadSaveEngine.Load(fin, mBanco);
                return result;
            }
            catch (Exception)
            { return false; }
        }

      
    }
}
