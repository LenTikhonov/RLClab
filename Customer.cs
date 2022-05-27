using System;

namespace RLClab
{
    public class Customer
    {
        private int bonus;
        private String name;
        public Customer(String name, int bonus)
        {
            this.name = name;
            this.bonus = bonus;
        }
        public String GetName()
        {
            return name;
        }
        public int GetBonus()
        {
            return bonus;
        }
        public void ReceiveBonus(int bonus)
        {
            this.bonus = bonus;
        }
        public int UseBonus(int needBonus)
        {
            int bonusTaken;
            if (needBonus > bonus)
            {
                bonusTaken = bonus;
                bonus = 0;
            }
            else
            {
                bonusTaken = needBonus;
                bonus -= needBonus;
            }
            return bonusTaken;
        }
    }
}