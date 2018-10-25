using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 모두의마블_TEST
{
    class Player
    {
        public string name;
        public int asset;
        public int position;
        public int status;
        public bool warp;
        public bool freepass;

        public Player(string name, int asset)
        {
            this.name = name;
            this.asset = asset;
            this.position = 0;
            this.status = 3;
            this.warp = false;
            this.freepass = true;
        }

        public void AddMoney(int money)
        { asset += money; }

        public void DrawMoney(int money)
        {
            if (asset >= money)
                asset -= money;
            else
            {
            }
        }

        public void SetPosition(int move)
        {
            if ((position + move) >= 28)
                position = (position + move) % 28;
            else
                position += move;
        }

        public int getPosition()
        { return position; }

    }
}
