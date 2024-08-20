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
    private Reasons ReadReasonsFromFile(string filePath)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        using (var reader = new StreamReader(filePath))
        {
            Reasons = deserializer.Deserialize<Reasons>(reader);
        }

        return Reasons;
    }

    public static void Main()
    {
        string filePath = "C:\\Users\\alexa\\RiderProjects\\ReasonReader\\Reasons\\example.yaml";

        try
        {
            ReasonReader reader = new ReasonReader(filePath);

            Reasons reasons = reader.Reasons;
            
            Console.WriteLine(reasons.ToString());

        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception when trying to parse the yaml file: " + ex);
        }
    }
}