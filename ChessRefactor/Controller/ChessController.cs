using ChessRefactor.Helper;
using ChessRefactor.Model;
using ChessRefactor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRefactor.Controller
{
    class ChessController
    {
        BanCo mBanCo;
        SaveLoad saveLoad;
        char luot;
        bool isChieuTuong;


        ConsoleView boardView; // View console thể hiện giao diện
        //Hàm thực hiện di chuyển quân cờ

        public ChessController()
        {
            QuanCoFactory.khoiTaoCacLoaiQuanCo();
            luot = 'W';
            isChieuTuong = false;
            mBanCo = BanCo.getBanCo();
            boardView = new ConsoleView(mBanCo);
            saveLoad = new SaveLoad("save.txt");
        }
        public void Move()
        {
            int x0=0, y0=0, x1=0, y1=0;
            if (!vuaDauRoi(luot)) //Nếu vua không còn tồn tại thì thông báo GAME OVER
            {
                boardView.renderGameOver(luot);
                Environment.Exit(0);
            }

        tt:
            if (isChieuTuong) //Kiểm tra và cảnh báo chiếu tướng
            { boardView.printMessage("!!!......CHIEU TUONG......!!!\n"); isChieuTuong = false; }
            
            boardView.getMoveInput(ref x0, ref y0, ref x1,ref y1,luot);
          
            if (x1 < 0 || x1 > 7 || y1 < 0 || y1 > 7)
            {
                boardView.printMessage("Toa do khong hop le...\n");
                goto tt;
            }

            QuanCo hienTai = mBanCo.banCo[x0, y0];
            if (hienTai == null)
            {
                boardView.printMessage("Toa do khong hop le...\n");
                goto tt;

            }
            if (hienTai.MoveHopLe(x0, y0, x1, y1, mBanCo) && hienTai.LayMau() == luot)
            {
                QuanCo temp = mBanCo.banCo[x1,y1];
                mBanCo.banCo[x1, y1] = mBanCo.banCo[x0,y0];
                mBanCo.banCo[x0,y0] = null;

                if (mBanCo.banCo[x1,y1].LayTen() == 'P')
                    phong(x1,ref mBanCo.banCo[x1,y1]);
                isChieuTuong = this.chieuTuong(luot, x1, y1, mBanCo.banCo[x1,y1]);
                this.changeTurn();
            }
            else
            {

                boardView.printMessage("Buoc di khong hop le...\n");
                boardView.printMessage("Nhan phim bat ky de di lai...\n");
             
                goto tt;


            }
        }
        public void Print() {
            boardView.renderBoard();
        } // Ra lệnh in bàn cờ
        public void changeTurn()
        {
            luot = luot == 'W' ? 'B' : 'W';
        } // Thay đổi lượt đi
        public void save() {
            saveLoad.SaveGame(mBanCo);
        } //Lưu ván cờ
        public void load() {
            if (saveLoad.LoadGame(mBanCo))
            {

            }
            else
            {
                boardView.printMessage("Co loi xay ra, khong load duoc game da luu...");
                Environment.Exit(1);
            }
        } // Tiếp tục ván đã lưu
        public void play()
        {
            int ch = 1;
            ch = boardView.menuSelection();
            switch (ch)
            {
                case 1:
                    while (true)
                    {
                       
                        Print();
                        Move();
                        save();

                    }
                  
                case 2:
                    load();
                    while (true)
                    {
                    
                        Print();
                        Move();
                        save();

                    }
                case 3:
                    chonPhuongThucLuuTru();
                    play();
                    break;
                   
                default:
                    break;
            }
        }
        public bool chieuTuong(char luot, int x0, int y0, QuanCo cur) {
            int i, j=0;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    QuanCo hienTai = mBanCo.banCo[i,j];
                    if (hienTai != null)
                        if (hienTai.LayMau() != luot && hienTai.LayTen() == 'K')
                            break;
                }
                if (j < 8)
                    break;
            }
            if (i == 8 && j == 8)
                return false;
            if (cur.MoveHopLe(x0, y0, i, j, mBanCo))
                return true;
            else
                return false;
        } //Kiểm tra chiếu tướng 
	    public bool vuaDauRoi(char luot)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    QuanCo hienTai = mBanCo.banCo[i,j];
                    if (hienTai != null)
                        if (hienTai.LayMau() == luot && hienTai.LayTen() == 'K')
                            return true;
                }

            }
            return false;
        }
        public void phong(int x, ref QuanCo cur)
        {
            string color = cur.LayMau().ToString();

            if (cur.LayTen() != 'P')
            {
                return;
            }
            if ((color == "W" && x == 7) || (color == "B" && x == 0))
            {
                int ch;
                ch = boardView.luaChonPhong();
                switch (ch)
                {
                    case 1:
                        cur = QuanCoFactory.taoQuanCo("Q", color);
                        break;
                    case 2:
                        cur = QuanCoFactory.taoQuanCo("R", color);
                        break;
                    case 3:
                        cur = QuanCoFactory.taoQuanCo("B", color);
                        break;

                    case 4:
                        cur = QuanCoFactory.taoQuanCo("N", color);
                        break;
                    default:
                        break;
                }
                boardView.printMessage("Da phong xong...!\n");
            }
        }

        private void chonPhuongThucLuuTru()
        {
            int ch = boardView.luaChonLuuTru();
            saveLoad.thayDoiPhuongThucLuuTru(ch);
        }

    }        
}
