using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.Services.MessagingService
{
    /// <summary>
    /// Consumes the queued items and routes them to the appropriate handler
    /// </summary>
    public class QueueProcessorHostedService : IHostedService
    {
        public const int QueuePollDelayMs = 100;

        private readonly MessageProcessorFactory _messageProcessorFactory;
        private readonly MessageQueue _messageQueue;

        private Task _backgroundTask;
        private CancellationToken _cancellationToken;

        public QueueProcessorHostedService(MessageProcessorFactory messageProcessorFactory, MessageQueue messageQueue)
        {
            _messageProcessorFactory = messageProcessorFactory;
            _messageQueue = messageQueue;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _backgroundTask = Task.Run(ProcessWork, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _backgroundTask;
        }

        private async Task ProcessWork()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                if (_messageQueue.TryDequeue(out var message))
                {
                    var handler = _messageProcessorFactory.GetHandleMethod(message);
                    if (handler != null)
                    {
                        await handler.Invoke();
                    }
                }
                else
                {
                    await Task.Delay(QueuePollDelayMs);
                }
            }
        }
    }
}
