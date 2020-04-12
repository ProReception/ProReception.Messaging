namespace ProReception.Messaging.Messages
{
    using System.Runtime.Serialization;

    public enum VisitorArrivalAction
    {
        PrintLabel = 0,
        [EnumMember(Value = "1")]
        SendSkypeMessage = 1
    }
}
