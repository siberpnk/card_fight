using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace card_fight
{
    public abstract class Entity
    {
        protected const string proj_root = "../../../";
        protected string _name;
        private Point2D _pos;
        private int _zOrder;
        private Sprite _worldSprite;
        private double _spriteScale;
        private double _unitHeight;
        private double _unitWidth;
        private int _cardStatus;

        protected Entity(string name, Sprite worldSprite, double spriteScale)
        {
            Name = name;
            WorldSprite = worldSprite;
            _spriteScale = spriteScale;
            _worldSprite.Scale = (float) SpriteScale;
            _unitWidth = Map.MapUnit;
            _unitHeight = Map.MapUnit;
        }

        public double UnitHeight
        {
            get { return _unitHeight;}
            set { _unitHeight = Map.MapUnit * value;}
        } 

        public double UnitWidth
        {
            get { return _unitWidth;}
            set { _unitWidth = Map.MapUnit * value;}
        }

        public Sprite WorldSprite
        {
            set
            {
                _worldSprite = value;
            }

            get
            {
                return _worldSprite;
            }
        }

        public double SpriteScale
        {
            get { return _spriteScale; }
            set { _spriteScale = value; }
        }

        public string Name
        {
            set
            {
                _name = value;
            }

            get
            {
                return _name;
            }
        }

        public void Update()
        {
            DrawUnit();
        }

        public void MoveTo(Point2D pt)
        {
            WorldSprite.MoveTo(pt.X, pt.Y);
        }

        public void DrawUnit()
        {
            SplashKit.DrawSprite(WorldSprite);
            DrawOutline();
        }

        public void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Red, _worldSprite.X, _worldSprite.Y, UnitHeight, UnitWidth);
        }

        public bool IsAt(Point2D pt)
        {
            return pt.X <= _worldSprite.X + UnitWidth && pt.Y <= _worldSprite.Y + UnitHeight && pt.X > _worldSprite.X && pt.Y > _worldSprite.Y;
        }
    }
}
