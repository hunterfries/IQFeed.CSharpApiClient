namespace IQFeed.CSharpApiClient.Streaming.Derivative
{
    public class DerivativeWatchDefinition
    {
        public DerivativeWatchDefinition(string symbol, string interval, string requestId)
        {
            Symbol = symbol;
            Interval = interval;
            RequestId = requestId;
        }

        public string Symbol { get; }
        public string Interval { get; }
        public string RequestId { get; }
    }
}