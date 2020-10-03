using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Commands;

namespace card_fight.Conditions
{
    public class AttackCondition : Condition
    {

        public AttackCondition()
        {
            Attack.EAttackCalled += AttackEvent;
        }
        
        public void AttackEvent(object sender, AttackArgs e)
        {
            _fulfilled = true;
        }
    }
}
