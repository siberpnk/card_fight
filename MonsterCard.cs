using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;
using card_fight.Components;

namespace card_fight
{
    public class MonsterCard : Card
    {
        private BattleStance _battleStance;
        private Combat _combatStats;
        private int _level;
        private Element _element;
        private Type _type;
        private SubType _subType;
        public MonsterCard(string name, int level, int atk, int def, Element element , Type type, string flavText, string effText, int conditionalFlags, Sprite cardGraphics, Sprite worldSprite, double spriteScale) : base(name, flavText, effText, conditionalFlags, cardGraphics, worldSprite, spriteScale)
        {
            _level = level;
            _combatStats = new Combat(atk, def);
            CardElement = element;
            CardType = type;
        }

        public MonsterCard(string name, int level, int atk, int def, Element element , Type type, SubType subType, string flavText, string effText, int conditionalFlags, Sprite cardSprite, Sprite worldSprite, float spriteScale) : this(name, level, atk, def, element, type, flavText, effText, conditionalFlags, cardSprite, worldSprite, spriteScale)
        {
            CardSubType = subType;
        }

        public Combat Combat { get => _combatStats; }
        public BattleStance Stance { get => _battleStance; }
        public enum Element 
        {
            DARK,
            DIVINE, 
            EARTH, 
            FIRE, 
            LIGHT, 
            WATER, 
            WIND
        }
        public enum Type
        {
            Aqua,
            Beast,
            BeastWarrior,
            Cyberse,
            Dinosaur,
            DivineBeast,
            Dragon,
            Fairy,
            Fiend,
            Fish,
            Insect,
            Machine,
            Plant,
            Psychic,
            Pyro,
            Reptile,
            Rock,
            SeaSerpent,
            Spellcaster,
            Thunder,
            Warrior,
            WingedBeast,
            Wyrm,
            Undead
        }

        public enum SubType
        {
            Normal,
            Effect,
            Ritual,
            Fusion,
            Token,
        }        
        public int Level
        {
            set
            {
                _level = value;
            }

            get
            {
                return _level;
            }
        } 
        public Element CardElement
        {
            set
            {
                _element = value;
            }

            get
            {
                return _element;
            }
        } 
        public Type CardType
        {
            set
            {
                _type = value;
            }

            get
            {
                return _type;
            }
        } 
        public SubType CardSubType
        {
            set
            {
                _subType = value;
            }

            get
            {
                return _subType;
            }
        }
    }
}
