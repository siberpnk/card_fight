using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SplashKitSDK;

namespace card_fight
{
    public static class Game
    {
        private static string _projRoot = "../../../";
        private static Dictionary<string,MonsterCard> _monsterCardCollection = new Dictionary<string,MonsterCard>();
        private static Dictionary<string,Map> _mapCollection = new Dictionary<string,Map>();
        private static Window _gameWindow;
        private static float _scaleFactor;
        static Game()
        {
            _gameWindow = new Window("Card Fight", 1800, 1000);
            _scaleFactor = GameWindow.Width/GameWindow.Height;
            GenerateCards(_scaleFactor);
            GenerateMaps();
        }


        public static Window GameWindow { get => _gameWindow; }
        public static string ProjectRoot
        {
            get { return _projRoot; }
        }
       public static Dictionary<string, MonsterCard> MonsterCardCollection { get => _monsterCardCollection; }
       public static Dictionary<string, Map> MapCollection { get => _mapCollection; }

        private static void GenerateMaps()
        {
            string name = "";
        }
       private static void GenerateCards(float scaleFactor)
        {
            XmlReader cardData = XmlReader.Create(_projRoot+"xml/monster_cards.xml");

            string name = "";
            int level = 0;
            int atk = 0;
            int def = 0;
            MonsterCard.Element element = 0;
            MonsterCard.Type c_type = 0;
            MonsterCard.SubType c_stype = 0;
            string flav_txt = "";
            string eff_txt = "";
            int cond_flags = 0;
            Sprite card_graphic = null;
            Sprite world_sprite = null;

            while (cardData.Read())
            {

                if((cardData.NodeType == XmlNodeType.Element) && (cardData.Name == "card"))
                {
                    if (cardData.HasAttributes && cardData.GetAttribute("name").Trim() != "")
                    {
                        name = cardData.GetAttribute("name");
                    }
                }  

                if((cardData.NodeType == XmlNodeType.Element) && (cardData.Name == "stats"))
                {
                    if (cardData.HasAttributes)
                    {
                        level = int.Parse(cardData.GetAttribute("lvl"));
                        atk = int.Parse(cardData.GetAttribute("atk"));
                        def = int.Parse(cardData.GetAttribute("def"));
                        element = (MonsterCard.Element)Enum.Parse(typeof(MonsterCard.Element), cardData.GetAttribute("elem"), true);
                        c_type = (MonsterCard.Type)Enum.Parse(typeof(MonsterCard.Type), cardData.GetAttribute("type"), true);
                        c_stype = (MonsterCard.SubType)Enum.Parse(typeof(MonsterCard.SubType), cardData.GetAttribute("s_type"), true);
                    }
                } 

                if((cardData.NodeType == XmlNodeType.Element) && (cardData.Name == "flav_txt"))
                {
                    cardData.Read();
                    if (cardData.NodeType == XmlNodeType.Text)
                    {
                        flav_txt = cardData.Value;
                    }
                }
 
                if((cardData.NodeType == XmlNodeType.Element) && (cardData.Name == "eff_txt"))
                {
                    cardData.Read();
                    if (cardData.NodeType == XmlNodeType.Text)
                    {
                       eff_txt = cardData.Value;
                    }
                }
  
                if((cardData.NodeType == XmlNodeType.Element) && (cardData.Name == "condition_flags"))
                {
                    if (cardData.HasAttributes)
                    {
                        cond_flags = 1;
                    }
                }
   
                if((cardData.NodeType == XmlNodeType.Element) && (cardData.Name == "assets"))
                {
                    if (cardData.HasAttributes)
                    {
                        card_graphic = new Sprite(name, new Bitmap(name, "../../../assets/"+cardData.GetAttribute("card_s")));
                        world_sprite = new Sprite(name, new Bitmap(name, "../../../assets/w_sprites/"+cardData.GetAttribute("world_s")));
                    }
                }

                if (!_monsterCardCollection.ContainsKey(name) && name.Trim() != "" && world_sprite != null && card_graphic != null)
                {
                    _monsterCardCollection.Add(name, new MonsterCard(name, level, atk, def, element, c_type, c_stype, flav_txt, eff_txt, cond_flags, card_graphic, world_sprite, scaleFactor));
                    MonsterCard mon_card = (MonsterCard)_monsterCardCollection[name];
                    Console.WriteLine("name : {0}, level : {1}, atk : {2}, def : {3}, elem : {4}, type : {5}, stype : {6}, flav_text : {7}, eff_text : {8}, cond_flag : {9}, scaleFactor : {10}",
                                mon_card.Name,
                                mon_card.Level,
                                mon_card.AttackStat,
                                mon_card.DefenseStat,
                                mon_card.CardElement,
                                mon_card.CardType,
                                mon_card.CardSubType,
                                mon_card.FlavorText,
                                mon_card.EffectText,
                                mon_card.ConditionalFlags,
                                mon_card.SpriteScale);

                    name = "";
                    level = 0;
                    atk = 0;
                    def = 0;
                    element = 0;
                    c_type = 0;
                    c_stype = 0;
                    flav_txt = "";
                    eff_txt = "";
                    cond_flags = 0;
                    card_graphic = null;
                    world_sprite = null;
                }
            }
        }

        
    }
}
