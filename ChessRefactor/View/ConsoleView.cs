using ChessRefactor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.View
{
    class ConsoleView
    {
        // Trường bàn cờ
        BanCo mBanCo;

        public ConsoleView(BanCo banCo)
        {
            mBanCo = banCo;
        }
        internal void renderGameOver(char luot)
        {
            Console.Write("==============GAME OVER==============\n");
            Console.Write( "\n- " + luot + " THUA....!\n\n");
          
        } // Hiển thị thông tin GameOver

        // Hiển thị nhập liệu di chuyển
        internal void getMoveInput(ref int x0, ref int y0, ref int x1,ref int y1,char luot)
        {
            string s;
            Console.Write("________Den luot phe '" + luot + "'________\n\n");
        again1: 
            Console.Write("Nhap toa do hien tai (vd: 1A) : ");
            s=Console.ReadLine();
            if (s.Length != 2) goto again1;
            s = s.ToUpper();
            x0 = s[0] - 48 - 1;
            y0 = s[1] - 65;
        again2: 
            Console.Write("Nhap toa do muon den (vd: 2B) : ");
            s = Console.ReadLine();
            if (s.Length != 2) goto again2;
            s = s.ToUpper();
            x1 = s[0] - 48 - 1;
            y1 = s[1] - 65;
        }

        // Hiển thị message
        internal void printMessage(string p)
        {
            Console.Write(p);
        }

        // Hiển thị UI lựa chọn kiểu phong tốt
        internal int luaChonPhong()
        {
            throw new NotImplementedException();
        }

        // In ra bàn cờ
        internal void renderBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write( "   ---------------------------------------------------------\n");
                for (int n = 0; n < 9; n++)
                {
                    if (n == 0)
                    {
                        if ((i + n) % 2 != 0)
                            Console.Write("   |      ");
                        else
                            Console.Write("   |======");
                    }

                    else if (n == 8)
                    {
                        Console.Write("|      ");
                    }

                    else
                    {
                        if ((i + n) % 2 != 0)
                            Console.Write( "|      ");
                        else
                            Console.Write("|======");
                    }
                }


                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    if (mBanCo.banCo[i,j] != null)
                    {
                        if (j == 0)
                        {
                            Console.Write(" " + (i+1) + " ");
                        }
                       Console.Write( "|");
                        if ((i + j) % 2 == 0)
                        {
                            Console.Write( "==" + mBanCo.banCo[i,j].LayMau() +  mBanCo.banCo[i,j].LayTen() + "==");
                        }
                        else
                        {
                            Console.Write( "  " + mBanCo.banCo[i,j].LayMau() +  mBanCo.banCo[i,j].LayTen() + "  ");
                        }
                    }

                    else
                    {
                        if (j == 0)
                        {
                            Console.Write( " " + (i + 1) + " ");
                        }
                        Console.Write( "|");
                        if ((i + j) % 2 == 0)
                        {
                            Console.Write( "======");
                        }
                        else
                            Console.Write( "      ");
                    }
                }
                Console.Write( "|");
                Console.WriteLine();
                for (int n = 0; n < 9; n++)
                {
                    if (n == 0)
                    {
                        if ((i + n) % 2 != 0)
                            Console.Write( "   |      ");
                        else
                            Console.Write( "   |======");
                    }
                    else if (n == 8)
                    {
                        Console.Write("|      ");
                    }
                    else
                    {
                        if ((i + n) % 2 != 0)
                            Console.Write( "|      ");
                        else
                            Console.Write( "|======");
                    }
                }
               Console.Write("\n");

            }
            Console.Write( "   ---------------------------------------------------------\n");
            Console.Write("      A      B      C      D      E      F      G      H    \n");
            Console.WriteLine();
        }

        // In menu game
        internal int menuSelection()
        {
            int ch = 1;
            Console.Write( "____________________WELCOME TO CHESS GAME____________________\n");
            Console.Write( "1. CHOI MOI TU DAU (NEW GAME)\n");
            Console.Write("2. CHOI TIEP (LOAD GAME)\n");
            Console.Write("3. CAI DAT LUU TRU\n");
            Console.Write( "4. THOAT (EXIT)\n");
            Console.Write(  "Nhap lua chon: _\n");
            ch = Console.ReadLine()[0] - 48; ;

            return ch;
        }

        // In màn hình lựa chọn lưu trữ
        internal int luaChonLuuTru()
        {
            int ch = 1;
            Console.Write("____________________WELCOME TO CHESS GAME____________________\n");
            Console.Write("1. LUU KIEU CSV \n");
            Console.Write("2. LUU KIEU DAC TA(Mac dinh) \n");
            Console.Write("Nhap lua chon: _\n");
            ch = Console.ReadLine()[0] - 48; ;

            return ch;
        }
    }
}
