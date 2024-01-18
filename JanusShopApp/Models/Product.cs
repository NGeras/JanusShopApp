using System.Xml.Serialization;

namespace JanusShopApp.Models;

[XmlRoot(ElementName="product")]
public class Product {
    [XmlElement(ElementName="code")]
    public string Code { get; set; }
    [XmlElement(ElementName="ye_code")]
    public string Ye_code { get; set; }
    [XmlElement(ElementName="group")]
    public string Group { get; set; }
    [XmlElement(ElementName="type")]
    public string Type { get; set; }
    [XmlElement(ElementName="link")]
    public string Link { get; set; }
    [XmlElement(ElementName="name_est")]
    public string Name_est { get; set; }
    [XmlElement(ElementName="name_eng")]
    public string Name_eng { get; set; }
    [XmlElement(ElementName="descr_est")]
    public string Descr_est { get; set; }
    [XmlElement(ElementName="descr_eng")]
    public string Descr_eng { get; set; }
    [XmlElement(ElementName="price_neto")]
    public string Price_neto { get; set; }
    [XmlElement(ElementName="price_bruto")]
    public string Price_bruto { get; set; }
    [XmlElement(ElementName="special_price_neto")]
    public string Special_price_neto { get; set; }
    [XmlElement(ElementName="special_price_bruto")]
    public string Special_price_bruto { get; set; }
    [XmlElement(ElementName="thickness")]
    public string Thickness { get; set; }
    [XmlElement(ElementName="terminal")]
    public string Terminal { get; set; }
    [XmlElement(ElementName="grossweight")]
    public string Grossweight { get; set; }
    [XmlElement(ElementName="image")]
    public string Image { get; set; }
    [XmlElement(ElementName="delivery_days")]
    public string Delivery_days { get; set; }
    [XmlElement(ElementName="purchaser")]
    public string Purchaser { get; set; }
    [XmlElement(ElementName="in_stock")]
    public string In_stock { get; set; }
    [XmlElement(ElementName="tln_stock")]
    public string Tln_stock { get; set; }
    [XmlElement(ElementName="package")]
    public string Package { get; set; }
    [XmlElement(ElementName="GTIN")]
    public string GTIN { get; set; }
    [XmlElement(ElementName="guaranty_months")]
    public string Guaranty_months { get; set; }

    public override string ToString()
    {
        return $"{Code} {Name_est} {Type}";
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "product")] public List<Product> Product { get; set; }
    }
}