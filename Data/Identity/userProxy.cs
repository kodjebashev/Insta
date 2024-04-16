using System.IO;
using System.Xml.Serialization;

namespace Insta.Data.Identity
{
    [XmlRoot]
    public class userProxy
    {
        [XmlElement]
        public string Email { get; set; }
        [XmlElement]
        public string Password { get; set; }
        
        public void Serialize()
        {
            XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(this.GetType());
            using(TextWriter writer = new StreamWriter("..\\..\\..\\UserData.xml"))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
