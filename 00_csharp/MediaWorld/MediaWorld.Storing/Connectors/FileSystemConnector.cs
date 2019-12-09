
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Storing.Connectors
{
  public class FileSystemConnector 
  {
    private const string _path = @"storage.xml";
    public List<AMedia> ReadXml(string path = _path)
    {
      var xml = new XmlSerializer(typeof(List<AMedia>));
      var reader = new StreamReader(path);
      return xml.Deserialize(reader) as List<AMedia>;
      
    }
    public void WriteXml(List<AMedia> data, string path = _path)
    {
      var xml = new XmlSerializer(typeof(List<AMedia>));
      var writer = new StreamWriter(path);
      xml.Serialize(writer, data);
    }
  }
}