using System.Threading.Tasks;
using Wolverine.Configuration;
using Wolverine.Runtime;

namespace Wolverine.Transports;

/// <summary>
/// Abstract base class suitable for brokered messaging infrastructure
/// </summary>
/// <typeparam name="TEndpoint"></typeparam>
public abstract class BrokerTransport<TEndpoint> : TransportBase<TEndpoint> where TEndpoint : Endpoint
{
    protected BrokerTransport(string protocol, string name) : base(protocol, name)
    {
    }
    
    /// <summary>
    /// Should Wolverine attempt to auto-provision all declared or discovered objects?
    /// </summary>
    public bool AutoProvision { get; set; }

    /// <summary>
    /// Should Wolverine attempt to purge all messages out of existing or discovered queues
    /// on application start up? This can be useful for testing, and occasionally for ephemeral
    /// messages
    /// </summary>
    public bool AutoPurgeAllQueues { get; set; }


    //public abstract ValueTask ConnectAsync();
    protected virtual void tryBuildResponseQueueEndpoint(IWolverineRuntime runtime)
    {
        
    }
}