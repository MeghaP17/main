using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestCoreWebAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public string XMLData { get; set; }
    }
    [XmlRoot(ElementName = "ICEMessage")]
    public sealed class ICEMessage
    {
        public string InterfaceIdentifier { get; set; }
        public Trade Trade { get; set; }

    }

    public class Trade {
        public string InterfaceIdentifier { get; set; }
        public int MessageSequenceNumber { get; set; }
        public DateTime SendingTime { get; set; }
        public string UniqueId { get; set; }
        public string ExecType { get; set; }
        public string MessageType { get; set; }

    }
}