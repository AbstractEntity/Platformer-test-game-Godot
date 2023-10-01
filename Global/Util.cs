using Godot;
using Godot.Collections;
using System;

public partial class Util : Node
{
    const string savePath = "res://savegame.bin";

    public static void SaveGame()
    {
        var file = FileAccess.Open(savePath, FileAccess.ModeFlags.Write);
        var data = new Dictionary<string, int>()
        {
            {"playerHP", Game.game.playerHP},
            {"gold", Game.game.gold}
        };
        string json = Json.Stringify(data);
        file.StoreLine(json);
        file.Close();
    }

    public static void LoadGame()
    {
        var file = FileAccess.Open(savePath, FileAccess.ModeFlags.Read);
        if (FileAccess.FileExists(savePath))
        {            
            string text = file.GetAsText();
            Dictionary jsonDict = (Dictionary)Json.ParseString(text);                     
            Game.game.gold = (int)jsonDict["gold"];
            Game.game.playerHP = (int)jsonDict["playerHP"];
        }
    }
}
