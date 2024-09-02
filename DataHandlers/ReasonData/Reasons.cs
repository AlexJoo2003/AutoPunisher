namespace AutoPunisher.ReasonHandler;

using System.Text;
using YamlDotNet.Serialization;

public class Reasons
{
    [YamlMember(Alias = "reasons")]
    public List<Reason> List { get; set; }

    public Reason GetReasonByName(string name)
    {
        foreach (Reason reason in List)
        {
            if (reason.Name == name)
            {
                return reason;
            }
        }

        throw new Exception("Reason does not exist");
    }
    
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