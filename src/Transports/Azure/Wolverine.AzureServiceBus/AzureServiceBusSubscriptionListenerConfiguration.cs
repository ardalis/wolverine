using Azure.Messaging.ServiceBus.Administration;
using Wolverine.AzureServiceBus.Internal;
using Wolverine.Configuration;
using Wolverine.ErrorHandling;

namespace Wolverine.AzureServiceBus;

public class AzureServiceBusSubscriptionListenerConfiguration : ListenerConfiguration<AzureServiceBusSubscriptionListenerConfiguration,
    AzureServiceBusSubscription>
{
    public AzureServiceBusSubscriptionListenerConfiguration(AzureServiceBusSubscription endpoint) : base(endpoint)
    {
    }

    /// <summary>
    ///     Add circuit breaker exception handling to this listener
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public AzureServiceBusSubscriptionListenerConfiguration CircuitBreaker(Action<CircuitBreakerOptions>? configure = null)
    {
        add(e =>
        {
            e.CircuitBreakerOptions = new CircuitBreakerOptions();
            configure?.Invoke(e.CircuitBreakerOptions);
        });

        return this;
    }

    /// <summary>
    ///     Configure the underlying Azure Service Bus Subscription. This is only applicable when
    ///     Wolverine is creating the Subscriptions
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public AzureServiceBusSubscriptionListenerConfiguration ConfigureSubscription(Action<CreateSubscriptionOptions> configure)
    {
        add(e => configure(e.Options));
        return this;
    }
    
    /// <summary>
    ///     Configure the underlying Azure Service Bus Subscription. This is only applicable when
    ///     Wolverine is creating the Subscriptions
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public AzureServiceBusSubscriptionListenerConfiguration ConfigureTopic(Action<CreateTopicOptions> configure)
    {
        add(e => configure(e.Topic.Options));
        return this;
    }

    /// <summary>
    ///     The maximum number of messages to receive in a single batch when listening
    ///     in either buffered or durable modes. The default is 20.
    /// </summary>
    public AzureServiceBusSubscriptionListenerConfiguration MaximumMessagesToReceive(int maximum)
    {
        add(e => e.MaximumMessagesToReceive = maximum);
        return this;
    }

    /// <summary>
    ///     The duration for which the listener waits for a message to arrive in the
    ///     Subscription before returning. If a message is available, the call returns sooner than this time.
    ///     If no messages are available and the wait time expires, the call returns successfully
    ///     with an empty list of messages. Default is 5 seconds.
    /// </summary>
    public AzureServiceBusSubscriptionListenerConfiguration MaximumWaitTime(TimeSpan time)
    {
        add(e => e.MaximumWaitTime = time);
        return this;
    }
}