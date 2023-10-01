using Godot;
using Godot.Collections;
using System;

public partial class Util : Node
{
    public static Util util = new Util();
    const string savePath = "res://savegame.bin";

    public void SaveGame()
    {
        var file = FileAccess.Open(savePath, FileAccess.ModeFlags.Write);
        var data = new Dictionary<string, int>()
        {
            {"playerHP", Global.global.playerHP},
            {"Gold", Global.global.Gold}
        };
        var json = Json.Stringify(data);
        file.StoreLine(json);
    }

    public void LoadGame()
    {
        var file = FileAccess.Open(savePath, FileAccess.ModeFlags.Read);
        if (FileAccess.FileExists(savePath))
        {
            string text = file.GetAsText();
            var jsonDict = Json.ParseString(text).AsGodotDictionary<string, int>;
            
            //foreach (KeyValuePair<string, int> kvp in jsonDict)
            //{

            //}

            //if (!file.EofReached())
            //{
            //    currentLine = Json.ParseString(file.GetLine());
            //    Global.global.playerHP = currentLine["PlayerHP"];
            //    {

            //    }
            //}
        }
    }
}
