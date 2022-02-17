using System;
using System.Text.RegularExpressions;

namespace Larry.Messenger.Rules
{
    public class ReplicateRule : IMessageRule{
        
        private readonly string _RequestMessage;
        private readonly string _MatchingRule;

        public ReplicateRule(string requestMessage, string matchingRule){
            _MatchingRule = matchingRule;
            _RequestMessage = requestMessage;
        }

        public bool DoesRuleApply(){
            return Regex.Match(_RequestMessage, _MatchingRule).Success;
        }

        public string GetResponse(){
            return _MatchingRule;
        }
    }
}