using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Conditions
{
    public abstract class Condition
    {
        public Condition() { _fulfilled = false; }
        protected bool _fulfilled;
        public virtual void Fulfill()
        {
            _fulfilled = true;
        }
        public virtual void Refresh()
        {
            _fulfilled = false;
        }
        public virtual bool IsFulfilled { get => _fulfilled; }
    }
}
