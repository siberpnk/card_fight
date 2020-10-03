using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Commands;

namespace card_fight.Conditions
{
    public class DestroyCondition : Condition
    {
        public DestroyCondition()
        {
            Destroy.EDestroyCalled += OnDestroyEvent;
        }
        public void OnDestroyEvent(object source, EventArgs e)
        {
            Fulfill();
        }
    }
}
