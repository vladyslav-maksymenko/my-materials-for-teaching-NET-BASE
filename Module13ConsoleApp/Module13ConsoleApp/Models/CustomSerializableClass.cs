using System;
using System.Runtime.Serialization;

namespace Module13ConsoleApp.Models;

[Serializable]
public class CustomSerializableClass : ISerializable
{
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; }
    public DateTime CreatedDate { get; set; }
    
    [NonSerialized]
    private string? temporaryData;

    public CustomSerializableClass()
    {
        CreatedDate = DateTime.Now;
    }

    public CustomSerializableClass(string name, int value)
    {
        Name = name;
        Value = value;
        CreatedDate = DateTime.Now;
    }

    // Constructor for deserialization
    protected CustomSerializableClass(SerializationInfo info, StreamingContext context)
    {
        Name = info.GetString(nameof(Name)) ?? string.Empty;
        Value = info.GetInt32(nameof(Value));
        CreatedDate = info.GetDateTime(nameof(CreatedDate));
        
        // Temporary data is not deserialized (it was marked as NonSerialized)
        temporaryData = null;
    }

    // ISerializable implementation
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Name), Name);
        info.AddValue(nameof(Value), Value);
        info.AddValue(nameof(CreatedDate), CreatedDate);
        
        // Add version information for future compatibility
        info.AddValue("Version", 1);
    }

    public void SetTemporaryData(string data)
    {
        temporaryData = data;
    }

    public string? GetTemporaryData()
    {
        return temporaryData;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Value: {Value}, Created: {CreatedDate:yyyy-MM-dd HH:mm:ss}";
    }
}

