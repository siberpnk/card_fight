using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight.Components
{
    public class CombatArgs : EventArgs
    {
        public int Atk { get; set; }
    }
    public class Combat : Component
    {
        private int _attack;
        private int _defence;
        private bool _defencePosition;
        public static event EventHandler<CombatArgs> EAttackResolution;
        
        public Combat(int attack, int defense)
        {
            _attack = attack;
            _defence = defense;
        }
           
        public void Attack(MonsterCard attacker)
        {
            if (_defencePosition)
            {
                if (_defence < attacker.Combat.AttackStat)
                {

                }
                else
                {

                }
            }
            else
            {
                if(_attack < attacker.Combat.AttackStat)
                {

                }
                else
                {

                }
            }
            //attack resolved event
        }
        public int AttackStat { get =>_attack; }

        public int DefenceStat { get => _defence; }

        public bool DefencePosition { get => _defencePosition; }
    }
}
