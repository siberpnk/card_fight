using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using SplashKitSDK;

namespace card_fight
{
    public class Map
    {
        private string _name;
        private float _width;
        private float _height;
        private static double _mapUnit;
        //file location of map overlay
        private string _terrainOverlay;
        //file location of map bitmap
        private string _mapFile;

        public Map(string name, int width, int height, string mapFile, string terrainOverlay)
        {
            _name = name;
            _width = width;
            _height = height;
            _mapFile = mapFile;
            _terrainOverlay = terrainOverlay;
            _mapUnit = Game.GameWindow.Height/_width;
        }

        public float Width { get => _width; }
        public float Height { get => _height; }
        public static double MapUnit { get => _mapUnit; }

        public void DrawGrid()
        {
            for(int i = 0; i <= Width; i++)
            {
                SplashKit.DrawLine(SplashKitSDK.Color.Black, i * MapUnit, 0, i * MapUnit, Game.GameWindow.Height);
            }
            for(int i = 0; i <= Height; i++)
            {
                SplashKit.DrawLine(SplashKitSDK.Color.Black, 0, i * MapUnit, Game.GameWindow.Height, i * MapUnit);
            }
        }
    }
}
