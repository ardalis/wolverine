using JasperFx.Core;

namespace Wolverine;

public class DurabilitySettings
{
    private readonly CancellationTokenSource _cancellation = new();

    /// <summary>
    ///     Should the message durability agent be enabled during execution.
    ///     The default is true.
    /// </summary>
    public bool DurabilityAgentEnabled { get; set; } = true;

    /// <summary>
    ///     How long should successfully handled messages be kept to use in idempotency checking
    /// </summary>
    public TimeSpan KeepAfterMessageHandling { get; set; } = 5.Minutes();

    /// <summary>
    ///     Governs the page size for how many persisted incoming or outgoing messages
    ///     will be loaded at one time for attempted retries or scheduled jobs
    /// </summary>
    public int RecoveryBatchSize { get; set; } = 100;

    /// <summary>
    ///     How frequently Wolverine will attempt to reassign incoming or outgoing
    ///     persisted methods from nodes that are detected to be offline
    /// </summary>
    public TimeSpan NodeReassignmentPollingTime { get; set; } = 1.Minutes();

    /// <summary>
    ///     When should the first execution of the node reassignment job
    ///     execute after application startup.
    /// </summary>
    public TimeSpan FirstNodeReassignmentExecution { get; set; } = 0.Seconds();

    /// <summary>
    ///     Interval between collecting persisted and queued message metrics
    /// </summary>
    public TimeSpan MetricsCollectionSamplingInterval { get; set; } = 5.Seconds();

    /// <summary>
    ///     How long to wait before the first execution of polling
    ///     for ready, persisted scheduled messages
    /// </summary>
    public TimeSpan ScheduledJobFirstExecution { get; set; } = 0.Seconds();

    /// <summary>
    ///     Polling interval for executing scheduled messages
    /// </summary>
    public TimeSpan ScheduledJobPollingTime { get; set; } = 5.Seconds();

    public int AssignedNodeNumber { get; internal set; } = Guid.NewGuid().ToString().GetDeterministicHashCode();

    public CancellationToken Cancellation => _cancellation.Token;

    
    /// <summary>
    /// Time span before the first health check is executed
    /// </summary>
    public TimeSpan FirstHealthCheckExecution { get; set; } = 3.Seconds();
    
    /// <summary>
    /// Polling time between health checks
    /// </summary>
    public TimeSpan HealthCheckPollingTime { get; set; } = 10.Seconds();

    /// <summary>
    /// Age of health check data before a node is considered to be "stale" or dormant and
    /// will be recovered by the durability agent
    /// </summary>
    public TimeSpan StaleNodeTimeout { get; set; } = 1.Minutes();

    /// <summary>
    ///     How long should Wolverine buffer requests to evaluate assignments
    ///     to prevent unnecessary assignment operations
    /// </summary>
    public TimeSpan EvaluateAssignmentBufferTime { get; set; } = 1.Seconds();

    /// <summary>
    ///     How often should Wolverine do a full check that all assigned agents are
    ///     really running and try to restart (or stop) any differences from the last
    ///     good set of assignments
    /// </summary>
    public TimeSpan CheckAssignmentPeriod { get; set; } = 30.Seconds();


    /// <summary>
    ///     Get or set the logical Wolverine service name. By default, this is
    ///     derived from the name of a custom WolverineOptions
    /// </summary>
    internal void Cancel()
    {
        _cancellation.Cancel();
    }
}