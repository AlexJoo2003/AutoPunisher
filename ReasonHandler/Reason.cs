namespace AutoPunisher.ReasonHandler;

using System.Text;

public class Reason
{
    public string Name { get; set; }
    public ReasonType Type { get; set; }
    public List<int> Durations { get; set; }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("  Name: " + Name + "\n");
        stringBuilder.Append("  Type: " + Type.ToString() + "\n");
        stringBuilder.Append("  Durations: \n");
        foreach (int duration in Durations)
        {
            stringBuilder.Append("      " + duration + "\n");
        }

        return stringBuilder.ToString();
    }
}