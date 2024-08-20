namespace AutoPunisher;

using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;  //For .NET use
using System.Text.Json;	//For non-.NET use
//pick one of them
using Events;
using Exiled.API.Enums;
using Exiled.API.Features;


public class JSONReader
{
    static JObject wholeJsonFile;
    static string currentFileName;
    
    public JSONReader()
	{
        
    }

    //Reads the JSON file by using a streamreader. This method is to be called on awake in the ReasonReader class. - Messenger
	public static void ReadJson(string fileName)
	{
        currentFileName = fileName;
        StreamReader file = File.OpenText(fileName);
        JsonTextReader reader = new JsonTextReader(file);
        wholeJsonFile = JObject.Load(reader);
    }

    public static BanRecord GetPlayerBySteamID(string steamID)
    {
        //Add code here to create an empty ban record if the steamID is not found. - Messenger
        JObject obj = (JObject)wholeJsonFile.GetValue(steamID);
        return GetBanRecord(obj);
    }

    public static BanRecord GetBanRecord(JObject player)
    {
        //Converts the info in the JSON file into primitive C# types. - Messenger
        string id = Convert.ToString(player.GetValue("playerID"));
        string name = Convert.ToString(player.GetValue("name"));
        int racismBans = Convert.ToInt32(player.GetValue("racismBans"));

        //Uses said type to return a ban record.
        BanRecord playerBanRecord = new BanRecord(id, name, racismBans);
        reutrn playerBanRecord;
    }

    public static JObject WholeJsonFile { get { return wholeJsonFile; } }
    public static string CurrentFileName { get { return currentFileName; } }
}
