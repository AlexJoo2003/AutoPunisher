namespace AutoPunisher.ReasonHandler;

using System.Text;
using YamlDotNet.Serialization;

public class Reasons
{
    [YamlMember(Alias = "reasons")]
    public List<Reason> List { get; set; }
    
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (Reason reason in List)
        {
            stringBuilder.Append(reason.ToString());
            stringBuilder.Append("\n");
        }

        return stringBuilder.ToString();
    }
}