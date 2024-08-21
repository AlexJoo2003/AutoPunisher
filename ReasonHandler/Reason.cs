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