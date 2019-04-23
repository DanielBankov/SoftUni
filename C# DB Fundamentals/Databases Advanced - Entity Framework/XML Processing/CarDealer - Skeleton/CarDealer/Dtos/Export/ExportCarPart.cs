using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("part")]
    public class ExportCarPart
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
//<parts>
//  <part name = "Master cylinder" price="130.99" />
//  <part name = "Water tank" price="100.99" />
//  <part name = "Front Right Side Inner door handle" price="100.99" />
//</parts>
