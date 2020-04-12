namespace ProReception.Messaging
{
    public interface IMessageSerializer<T>
        where T : class
    {
        string Serialize(T message);

        byte[] SerializeBytes(T message);

        T Deserialize(string message);

        T Deserialize(byte[] message);
    }
}
