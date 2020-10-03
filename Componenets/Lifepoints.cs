using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Components
{
    public class Lifepoints : Component
    {
        private int _lifepoints;
        public Lifepoints(int initialValue)
        {
            _lifepoints = initialValue;
        }

        public int LifepointRemaining{ get => _lifepoints; set { _lifepoints = value; } }
    }
}
