namespace ProReception.Messaging.Messages
{
    using System.ComponentModel;

    public enum PrinterType
    {
        [Description("Dymo")]
        Dymo = 0,
        [Description("Brother")]
        Brother = 1,
        [Description("Nippon")]
        Nippon = 2
    }
}
