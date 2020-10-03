using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Commands
{
    public class DestroyArgs : EventArgs
    {
        public DestroyArgs(Card card) { Card = card; }
        public Card Card { get; set; }
    }
    class Destroy : Command
    {
        private Card _card;
        private MoveCard _moveCard;
        private DestroyArgs _destroyArgs;
        public static event EventHandler<DestroyArgs> EDestroyCalled;
        public static event EventHandler<DestroyArgs> EDestroyResolved;

        public Destroy(Card card)
        {
            _card = card;
            _moveCard = new MoveCard(_card, _card.Owner.Summoner.GraveYard, _card.Owner.Summoner.GraveYard.CardPositionTop);

            _destroyArgs = new DestroyArgs(card);
        }

        public static void DestroyCalled(object source, DestroyArgs e)
        {
            EDestroyCalled?.Invoke(source, e);
        }
        
        public static void DestroyResolved(object source, DestroyArgs e)
        {
            EDestroyResolved?.Invoke(source, e);
        }

        public override void Execute()
        {
            DestroyCalled(this, _destroyArgs);
            _moveCard.Execute();
            DestroyResolved(this, _destroyArgs);
        }
    }
}
