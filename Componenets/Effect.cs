using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Conditions;
using card_fight.Commands;

namespace card_fight.Components
{
    public class EffectArgs : EventArgs
    {
        public Effect EffectCaller { get; set; }
    }
    public class Effect
    {
        private List<Condition> _conditions;
        private List<Command> _commands;
        public static event EventHandler ETrigger;
        public Effect(List<Condition> conditions, List<Command> commands)
        {
            _conditions = conditions;
            _commands = commands;
        }

        public bool Evaluate()
        {
            foreach(Condition c in _conditions)
            {
                if (c.IsFulfilled == false)
                    return false;
            }
            return true;
        }

        public void Activate()
        {
            if (Evaluate())
            {
                foreach(Command command in _commands)
                {
                    command.Execute();
                }
            }
        }
    }
}
