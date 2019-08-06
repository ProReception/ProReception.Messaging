namespace ProReception.Messaging
{
    using System;

    public interface IPublish<in T> : IDisposable
        where T : class
    {
        int Publish(string channel, T message);
    }
}
