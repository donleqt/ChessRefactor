using ChessRefactor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Helper
{
    public abstract class MemoryStrategy
    {
       
        public abstract bool Save(BanCo mBanCo,FileStream fout);
        public abstract bool Load(FileStream fin,BanCo mBanCo);
    }
}
