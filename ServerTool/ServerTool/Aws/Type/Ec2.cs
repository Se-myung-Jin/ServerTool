using Amazon.EC2.Model;
using System.Text.Json;

namespace ServerTool
{
    public class Ec2InstanceInfo
    {
        public string InstanceName { get; set; }
        public string InstanceId { get; set; }
        public string Region { get; set; }
        public string ShortRegion { get; set; }
        public string PublicDnsName { get; set; }
        public string PrivateIpAddress { get; set; }
        public string ServiceRegion { get; set; }
        public string ServiceFlavor { get; set; }
        public InstanceStateCode StateCode { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public bool IsRunning { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public static class Ec2TagsHelper
    {
        public static Dictionary<string, string> Convert(List<Tag> tags)
        {
            if (tags is { Count: > 0 })
            {
                return tags.ToDictionary(tag => tag.Key, tag => tag.Value, StringComparer.OrdinalIgnoreCase);
            }

            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public static string GetValueOrEmpty(this Dictionary<string, string> dictionary, string key)
        {
            if (dictionary == null)
            {
                return string.Empty;
            }

            dictionary.TryGetValue(key, out var value);
            return value ?? string.Empty;
        }
    }

    public enum InstanceStateCode
    {
        Pending = 0,
        Running = 16,
        ShuttingDown = 32,
        Terminated = 48,
        Stopping = 64,
        Stopped = 80
    }

    public class ServiceRegion
    {
        public string Name { get; set; }
        public string AwsRegion { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
        public int BlockBaseNo { get; set; }
        public int ServerNameBaseNo { get; set; }
        public List<string> VpcId { get; set; }
    }

    // ServiceApp
    public class ServiceApp
    {
        public string Name { get; set; }
        public List<ServiceRegion> Regions { get; set; }
    }

    // InstanceFilter
    public class InstanceFilter
    {
        public List<string> ServiceRegions { get; set; } = new List<string>();
        public List<string> ServiceFlavors { get; set; } = new List<string>();
        public string Name { get; set; }
        public bool IsRunning { get; set; } = true;
    }
}
