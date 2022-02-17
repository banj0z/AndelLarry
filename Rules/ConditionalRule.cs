using System;

namespace Larry.Messenger.Rules
{
    public class ConditionalRule : IMessageRule{
        
        private readonly string _requestMessage;
        private readonly Func<string,bool> _condition;
        private readonly Func<string, bool> _ruleCondition;
        private readonly string _trueResponse;
        private readonly string _falseResponse;

        public ConditionalRule(string requestMessage, Func<string,bool> ruleCondition, Func<string,bool> condition, string trueResponse = "Yes", string falseResponse = "No"){
            _requestMessage = requestMessage ?? throw new ArgumentNullException(nameof(requestMessage));
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
            _trueResponse = trueResponse ?? throw new ArgumentNullException(nameof(trueResponse));
            _falseResponse = falseResponse ?? throw new ArgumentNullException(nameof(falseResponse));
            _ruleCondition = ruleCondition ?? throw new ArgumentNullException(nameof(ruleCondition));
        }

        public bool DoesRuleApply(){
           return _ruleCondition(_requestMessage);
        }

        public string GetResponse(){
            return _condition(_requestMessage) ? _trueResponse : _falseResponse;
        }
    }
}