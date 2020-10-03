using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using card_fight;
using card_fight.Components;
using card_fight.Conditions;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Point2D pt = new Point2D();
        pt.X = 0;
        pt.Y = 0;

        Combat combat = new Combat(100, 2000, false);
        AttackCondition ccond = new AttackCondition();

        Map map = new Map("", 20, 20, "", "");
        do
        {
            SplashKit.ProcessEvents();

            if (SplashKit.KeyTyped(KeyCode.RightKey))
            {
                pt.X += Map.MapUnit;
            }

            if (SplashKit.KeyTyped(KeyCode.LeftKey))
            {
                pt.X -= Map.MapUnit;
            }
             if (SplashKit.KeyTyped(KeyCode.UpKey))
            {
                pt.Y -= Map.MapUnit;
            }

            if (SplashKit.KeyTyped(KeyCode.DownKey))
            {
                pt.Y += Map.MapUnit;
            }

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                if(Game.MonsterCardCollection["Bastard Joker"].IsAt(SplashKit.MousePosition()))
                {
                    pt.X += Map.MapUnit;
                }
            }
            SplashKit.ClearScreen();

            //Game.MapCollection[""].DrawGrid();
            map.DrawGrid();
            Game.MonsterCardCollection["Bastard Joker"].MoveTo(pt);
            Game.MonsterCardCollection["Bastard Joker"].Update();

            SplashKit.RefreshScreen();
        } while (!SplashKit.WindowCloseRequested(Game.GameWindow.Caption));
    }

    private static void Combat_Trigger(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
