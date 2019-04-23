﻿using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("sale")]
    public class ExportSaleDiscountDto
    {
        [XmlElement("car")]
        public CarDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }

    public class CarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
//<sale>
//  <car make = "BMW" model="M5 F10" travelled-distance="435603343" /> car is ELEMENT !!!
//  <discount>30.00</discount>
//  <customer-name>Hipolito Lamoreaux</customer-name>
//  <price>707.97</price>
//  <price-with-discount>495.58</price-with-discount>
//</sale>
