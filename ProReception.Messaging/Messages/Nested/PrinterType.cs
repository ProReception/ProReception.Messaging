using System.ComponentModel;

namespace ProReception.Messaging.Messages.Nested
{
    public enum PrinterType
    {
        [Description("Dymo")]
        Dymo = 0,
        [Description("Brother")]
        Brother = 1,
        [Description("Nippon")]
        Nippon = 2,
        [Description("Zebra")]
        Zebra = 3
    }
}
