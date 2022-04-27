using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Vector.Lib;

[Serializable]
public partial struct Vector2
    : ISerializable
    , IXmlSerializable
{
    public void GetObjectData(SerializationInfo info,
        StreamingContext context)
    {
        info.AddValue("X", X);
        info.AddValue("Y", Y);
    }

    public XmlSchema GetSchema() => new XmlSchema();

    public void ReadXml(XmlReader reader)
    {
        var valueX = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
        var valueY = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
        unsafe
        {
            fixed (Vector2* t = &this)
            {
                *t = new Vector2(valueX, valueY);
            }
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("X", X.ToString(CultureInfo.InvariantCulture));
        writer.WriteElementString("Y", Y.ToString(CultureInfo.InvariantCulture));
    }
}