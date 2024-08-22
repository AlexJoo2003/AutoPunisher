using System.Diagnostics;
using AutoPunisher.DataHandler;

namespace AutoPunisher.ReasonHandler;

using System.Text;

public class Reason
{
    public string Name { get; set; }
    public ReasonType Type { get; set; }
    public List<int>? Durations { get; set; }
    public List<string>? Aliases { get; set; }
    public int? Variable { get; set; }
    public string? Message { get; set; }
    
    // Used to calculate the duration of the players ban based on repeat occurrences and reason type 
    public int CalculateDuration(Player player)
    {
        int repeatedOffences = 1;
        
        // checks if the player has been banned for this reason before
        foreach (KeyValuePair<string, int> kvp in player.ReasonRepeats)
        {
            string reasonName = kvp.Key;
            if (Name == reasonName)
            {
                repeatedOffences = kvp.Value + 1;
            }
        }
        
        switch (Type)
        {
            case ReasonType.Set:
                // using predefined durations.
                if (repeatedOffences >= Durations!.Count)
                {
                    // uses the last listed ban duration if the repeated offences has passed the max
                    return Durations[Durations.Count - 1];
                }
                return Durations[repeatedOffences - 1];
            case ReasonType.Exponential:
                break;
            case ReasonType.Linear:
                break;
        }
        return -1;
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("  Name: " + Name + "\n");
        stringBuilder.Append("  Type: " + Type.ToString() + "\n");

        stringBuilder.Append("  Durations: \n");
        if (Durations != null)
        {
            for (int i = 0; i < Durations.Count; i++)
            {
                stringBuilder.Append("      " + i + ". " + Durations[i] + "\n");
            }
        }

        stringBuilder.Append("  Aliases: \n");
        if (Aliases != null)
        {
            foreach (string alias in Aliases)
            {
                stringBuilder.Append("    - " + alias + "\n");
            }
        }

        stringBuilder.Append("  Variable: " + Variable + "\n");
        stringBuilder.Append("  Message: " + Message + "\n");

        return stringBuilder.ToString();
    }
}