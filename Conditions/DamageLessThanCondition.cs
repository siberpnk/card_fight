using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Commands;

namespace card_fight.Conditions
{
    public class DamageLessThanCondition : Condition
    {

        int _expectation;
        public DamageLessThanCondition(int expectation)
        {
            _expectation = expectation;
            Damage.EDamageCalled += DamageEvent;
        }

        public void DamageEvent(object source, DamageArgs e)
        {
            if (e.DamageDelt < _expectation)
                _fulfilled = true;
        }
    }
}
