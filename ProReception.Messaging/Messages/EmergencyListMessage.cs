using ProReception.Messaging.Messages.Nested;

namespace ProReception.Messaging.Messages
{
    using System.Collections.Generic;

    public class EmergencyListMessage
    {
        public int ClientLevelId { get; set; }

        public List<EmergencyListVisitorData> Visitors { get; set; } = new List<EmergencyListVisitorData>();
    }
}
