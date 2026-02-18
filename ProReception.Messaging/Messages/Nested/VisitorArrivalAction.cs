using System.Runtime.Serialization;

namespace ProReception.Messaging.Messages.Nested
{
    public enum VisitorArrivalAction
    {
        PrintLabel = 0,
        [EnumMember(Value = "1")]
        SendSkypeMessage = 1
    }
}
