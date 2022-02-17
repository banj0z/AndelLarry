using System;
using System.Text.RegularExpressions;

namespace Larry.Messenger.Rules
{
    public class ReplicateRule : IMessageRule{
        
        private readonly string _requestMessage;
        private readonly string _matchingRule;

        public ReplicateRule(string requestMessage, string matchingRule){
            _matchingRule = matchingRule ?? throw new ArgumentNullException(nameof(matchingRule));
            _requestMessage = requestMessage ?? throw new ArgumentNullException(nameof(requestMessage));
        }

        public bool DoesRuleApply(){
            return Regex.Match(_requestMessage, _matchingRule).Success;
        }

        public string GetResponse(){
            return _matchingRule;
        }
    }
}