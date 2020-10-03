using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Piles
{
    public abstract class Pile
    {
        private List<Card> _cards;

        public Pile(List<Card> cards)
        {
            _cards = cards;
        }

        public virtual List<Card> Look()
        {

            return null;
        }
        public List<Card> Cards { get => _cards; }
        public Card TopCard { get => _cards[CardPositionTop]; }
        public int CardPositionTop { get => _cards.Count; }
    }
}
