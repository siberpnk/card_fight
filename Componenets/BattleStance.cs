using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Components
{
    public class BattleStance : Component
    {
        private bool _defPosition;

        public event EventHandler PositionChange; 

        public void ChangePosition()
        {
            _defPosition = !_defPosition;
            PositionChange?.Invoke(this, EventArgs.Empty);
        }

        public bool DefencePosition { get => _defPosition; }
        public bool AttackPosition { get => !_defPosition; }
    }
}
