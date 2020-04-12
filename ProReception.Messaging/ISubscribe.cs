namespace ProReception.Messaging
{
    using System;

    public interface ISubscribe<out T> : IDisposable
        where T : class
    {
        void Subscribe(string channel, Action<T> work);
    }
}
