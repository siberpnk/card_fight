using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Piles;

namespace card_fight.Commands
{
    public class MoveCard : Command
    {
        private Card _card;
        private Pile _pile;
        private int _position;

        public MoveCard(Card card, Pile pile, int position)
        {
            _card = card;
            _pile = pile;
            _position = position;
        }

        public override void Execute()
        {
            _pile.Cards.Insert(_position, _card);
            CommandEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
