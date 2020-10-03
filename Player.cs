using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Commands;

namespace card_fight
{
    public class Player
    {
        private string _name;
        private Summoner _summoner;

        public Player()
        {
            _summoner = new Summoner();
        }

        public Summoner Summoner { get => _summoner; }
    }
}
