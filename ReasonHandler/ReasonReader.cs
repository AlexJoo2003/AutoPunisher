namespace AutoPunisher.ReasonHandler;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class ReasonReader
{
    internal Reasons Reasons { get; set; }
    public ReasonReader(string filePath)
    {
        Reasons = ReadReasonsFromFile(filePath);
    }
    
    // Reads the yaml file provided and deserializes it into Reasons class
    private Reasons ReadReasonsFromFile(string filePath)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        using (var reader = new StreamReader(filePath))
        {
            Reasons = deserializer.Deserialize<Reasons>(reader);
        }

        string isValid = IsValid(Reasons);
        if (isValid != "valid")
        {
            throw new Exception(isValid);   
        }

        return Reasons;
    }
    // checks if the deserializer has done everything correctly
    private string IsValid(Reasons? reasons)
    {
        if (reasons == null)
        {
            return "Reasons is null";
        }
        if (reasons.List.Count <= 0)
        {
            return "There are no reasons";
        }

        List<string> reasonNames = new List<string>();
        foreach (Reason reason in reasons.List)
        {
            if (reasonNames.Contains(reason.Name))
            {
                return "Reason with name " + reason.Name + " already exists";
            }
            if (reason.Type == ReasonType.Set && (reason.Durations == null || reason.Durations.Count <= 0))
            {
                return "Reason " + reason.Name + " has Set type but duration is either null or has no durations";
            }
            if ((reason.Type == ReasonType.Exponential || reason.Type == ReasonType.Linear) && reason.Variable == null)
            {
                return "Reason " + reason.Name + " has type of " + reason.Type + " but doesn't have a set Variable";
            }
        }

        return "valid";
    }
}