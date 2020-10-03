using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Commands
{
    public class AttackArgs : EventArgs
    {
        public AttackArgs(MonsterCard target, MonsterCard attacker)
        {
            Target = target;
            Attacker = attacker;
        }
        public MonsterCard Target { get; set; }
        public MonsterCard Attacker { get; set; }
    }
    public class Attack : Command
    {
        private MonsterCard _target;
        private MonsterCard _attacker;
        private AttackArgs _attackArgs;
        public static event EventHandler<AttackArgs> EAttackCalled;

        public Attack(MonsterCard target, MonsterCard attacker)
        {
            _target = target;
            _attacker = attacker;

            _attackArgs = new AttackArgs(target, attacker);
        }

        public static void AttackCalled(object source, AttackArgs e)
        {
            EAttackCalled?.Invoke(source, e);
        } 
        public override void Execute()
        {
            AttackCalled(this, _attackArgs);
        }
    }
}
