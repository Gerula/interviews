// The point of the reactor pattern is basically to make possible the handling of concurrent connections using a single thread
// and avoid creating one thread per connection. It does this by processing the connections sequentially using event handlers.
//
// http://www.robertsindall.co.uk/blog/the-reactor-pattern-using-c-sharp/
//
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

public interface IEventHandler {
    void HandleEvent(byte[] data);
    TcpListener GetHandler();
}

public interface ISyncronousEventDemux {
    IList<TcpListener> SelectListener(IList<TcpListener> listeners);
}

public interface IReactor {
    void RegisterHandle(IEventHandler eventHandler);
    void RemoveHandle(IEventHandler eventHandler);
    void HandleEvents();
}

public class MessageEventHandler: IEventHandler {
    private readonly TcpListener listener;

    public MessageEventHandler(IPAddress address, int port) {
        listener = new TcpListener(address, port);
    }

    public void HandleEvent(byte[] data) {
        string message = Encoding.UTF8.GetString(data);
    }

    public TcpListener GetHandler() {
        return listener;
    }
}

public class SyncronousEventDemux: ISyncronousEventDemux {
    public IList<TcpListener> SelectListener(IList<TcpListener> listeners) {
        return listeners.Where(x => x.Pending()).ToList();
    }
}

public class Reactor: IReactor {
    private readonly ISyncronousEventDemux syncronousEventDemux;
    private readonly IDictionary<TcpListener, IEventHandler> handlers;

    public Reactor(ISyncronousEventDemux eventDemux) {
        syncronousEventDemux = eventDemux;
        handlers = new Dictionary<TcpListener, IEventHandler>();
    }

    public void RegisterHandle(IEventHandler eventHandler) {
        handlers.Add(eventHandler.GetHandler(), eventHandler);
    }

    public void RemoveHandle(IEventHandler eventHandler) {
        handlers.Remove(eventHandler.GetHandler());
    }
    
    public void HandleEvents() {
        while (true) {
            IList<TcpListener> listeners = syncronousEventDemux.SelectListener(handlers.Keys.ToList());

            foreach (var listener in listeners) {
                int dataReceived = 0;
                byte[] buffer = new byte[1];
                IList<byte> data = new List<byte>();

                Socket socket = listener.AcceptSocket();
                do {
                    dataReceived = socket.Receive(buffer);
                    if (dataReceived > 0) {
                        data.Add(buffer[0]);
                    }
                } while (dataReceived > 0);

                socket.Close();
                handlers[listener].HandleEvent(data.ToArray());
            }
        }
    }
}

class Program {
    public static void Main(string[] args) {

    }
}
