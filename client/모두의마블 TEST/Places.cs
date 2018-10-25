using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 모두의마블_TEST
{
    class Places
    {
        public enum Kind
        {
            Villa,
            Building,
            Hotel
        }

        public string name;
        public int price;
        public int owner;
        public int pass_money;
        public int land1;
        public int land2;
        public int land3;
        public bool island1, island2, island3;

        public Places(string name, int price, int owner, int land1, int land2, int land3, int pass_money)
        {
            this.name = name;
            this.price = price;
            this.owner = owner;
            this.land1 = land1;
            this.land2 = land2;
            this.land3 = land3;
            this.pass_money = pass_money;
            island1 = island2 = island3 = false;
        }

        public int SetBuilding(Kind kind)
        {
            if (kind == Kind.Villa)
            {
                island1 = true;
                return land1;
            }
            else if (kind == Kind.Building)
            {
                island2 = true;
                return land2;
            }
            else if (kind == Kind.Hotel)
            {
                island3 = true;
                return land3;
            }
            return 0;
        }

        public int level_up(int payment)
        {
            this.pass_money += payment;
            return 0;
        }
    }
}
