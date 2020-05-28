using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Library
{
    public class MobileСonnection
    {
        //private string[] mobile_plans = { "Standart", "Premium" };
        private string mobile_plan;
        private float balance;

        public delegate void Del(object sender, float m);
        public event Del MinBalance = null;

        public MobileСonnection(string mobile_plan)
        {
            if (mobile_plan != "Standart" && mobile_plan != "Premium")
                throw new ArgumentException(message: "Enter a correct mobile plan");
            this.mobile_plan = mobile_plan;
        }
        public void ActivationPlan()
        {
            if (mobile_plan == "Standart")
            {
                balance = balance - 100;
            }
            else if (mobile_plan == "Premium")
            {
                balance = balance - 150;
            }
            if ((balance <= 0) && (MinBalance != null))
                MinBalance(this, balance);
        }
        public float AccountBalance
        {
            set
            {
                if (value <= 0)
                    throw new ArgumentException(message: "Value cannot be lower or equal than 0");
                balance += value;

                if ((balance <= 0) && (MinBalance != null))
                    MinBalance(this, balance);
            }
            get => balance;
        }

        public void TimeTalk(int minutes)
        {
            if (minutes < 0)
                throw new ArgumentException(message: "Time talking cannot be lower than 0");

            if (mobile_plan == "Standart")
                balance -= (float)(minutes * 0.3);
            else
                balance -= (float)(minutes * 0.1);

            if ((balance <= 0) && (MinBalance != null))
                MinBalance(this, balance);

        }
        

    }
}
