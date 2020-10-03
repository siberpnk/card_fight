using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight
{
    public class Card : Entity
    {
        private Player _owner;
        private Sprite _cardGraphic;
        private string _flavTxt;
        private string _effText;

   
        public Card(string name, string flav_txt, string eff_text, int conditional_flags, Sprite card_graphic, Sprite world_sprite, double spriteScale) : base(name, world_sprite, spriteScale)
        {
            _cardGraphic = card_graphic;
            _flavTxt = flav_txt;
            _effText = eff_text;
        }
        public Player Owner { get => _owner; }

        public Sprite CardGraphic { get => _cardGraphic; }

        public string FlavorText { get => _flavTxt; } 

        public string EffectText { get => _effText; }
    }
}
