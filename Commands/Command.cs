using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Commands
{
    public abstract class Command
    {

        public Command() { }
        public abstract void Execute();
    }
}
