using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Commands;
using card_fight.Components;

namespace card_fight
{
    class Mediator
    {
        private bool _interrupt = false;
        public Mediator()
        {
            Attack.EAttackCalled += AttackListener;
        }
        public void AttackListener(object sender, AttackArgs e)
        {
            MonsterCard c = e.Attacker;
            if (!_interrupt)
            {
                Destroy d = new Destroy(c);
            }
            else if (!_interrupt)
            {
                int damage = e.Attacker.Combat.AttackStat - e.Target.Combat.AttackStat;
                Damage d = new Damage(damage, e.Target.Owner.Summoner);
            }
            else if (!_interrupt)
            {
                MoveCard m = new MoveCard(c, c.Owner.Summoner.GraveYard, 0);
            }
        }
        public void EffectListener(object sender, EffectArgs e)
        {
            _interrupt = true;
            e.EffectCaller.Activate();
        }
    }
}
