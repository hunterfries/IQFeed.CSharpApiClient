using System.Collections.Generic;
using System.Text.RegularExpressions;
using IQFeed.CSharpApiClient.Extensions;
using IQFeed.CSharpApiClient.Streaming.Common.Messages;
using IQFeed.CSharpApiClient.Streaming.Level1.Messages;

namespace IQFeed.CSharpApiClient.Streaming.Derivative
{
    public static class SystemMessageExtensions
    {
        private const string DerivativeWatchesPattern = "^S,WATCHES,(.*)$";
        private static readonly Regex DerivativeWatchesRegex = new Regex(DerivativeWatchesPattern);

        public static IEnumerable<DerivativeWatchDefinition> ToDerivativeWatchDefinitions(this SystemMessage systemMessage)
        {
            var match = DerivativeWatchesRegex.Match(systemMessage.Message);
            if (match.Success)
            {
                var watches = match.Groups[1].Value.SplitFeedMessage();
                var offset = 0;

                while (offset < watches.Length)
                {
                    yield return new DerivativeWatchDefinition(watches[offset], watches[offset + 1], watches[offset + 2]);
                    offset += 3;
                }
            }
        }
    }
}