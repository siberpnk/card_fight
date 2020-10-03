using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Commands
{
    public class DamageArgs : EventArgs
    {
        public DamageArgs(int damageDelt) { DamageDelt = damageDelt; }
        public int DamageDelt { get; set; }
    }

    public class Damage : Command
    {
        private int _damage;
        private Summoner _summoner;
        private DamageArgs _damageArgs;
        public static event EventHandler<DamageArgs> EDamageCalled;
        public static event EventHandler<DamageArgs> EDamageResolved;
        
        public Damage(int damage, Summoner summoner)
        {
            _damage = damage;
            _summoner = summoner;

            _damageArgs = new DamageArgs(_damage);
        }

        public static void DamageCalled(object source, DamageArgs e)
        {
            EDamageCalled?.Invoke(source, e);
        } 
        public static void DamageResolved(object source, DamageArgs e)
        {
            EDamageResolved?.Invoke(source, e);
        }

        public override void Execute()
        {
            DamageCalled(this, _damageArgs);
            _summoner.Lifepoints.LifepointRemaining -= _damage;
            DamageResolved(this, _damageArgs);
        }
    }
}
