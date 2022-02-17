using System;

namespace Larry.Messenger.Rules
{
    public class ConditionalRule : IMessageRule{
        
        private readonly string _RequestMessage;
        private readonly Func<string,bool> _Condition;
        private readonly Func<string, bool> _RuleCondition;
        private readonly string _TrueResponse;
        private readonly string _FalseResponse;

        public ConditionalRule(string requestMessage, Func<string,bool> ruleCondition, Func<string,bool> condition, string trueResponse = "Yes", string falseResponse = "No"){
            _RequestMessage = requestMessage;
            _Condition = condition;
            _TrueResponse = trueResponse;
            _FalseResponse = falseResponse;
            _RuleCondition = ruleCondition;
        }

        public bool DoesRuleApply(){
           return _RuleCondition(_RequestMessage);
        }

        public string GetResponse(){
            return _Condition(_RequestMessage) ? _TrueResponse : _FalseResponse;
        }
    }
}