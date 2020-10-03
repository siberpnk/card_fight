using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Components;
using card_fight.Piles;

namespace card_fight
{
    public class Summoner
    {
        private Lifepoints _lifepoints;
        private Deck _deck;
        private GraveYard _graveYard;
        public Lifepoints Lifepoints { get => _lifepoints; }
        public Deck Deck { get => _deck; }
        public GraveYard GraveYard { get => _graveYard; }
    }
}
