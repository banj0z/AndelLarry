using Larry.Messenger.Services;
using Larry.Messenger.Rules;
using System;
using Microsoft.Extensions.Logging;

namespace Larry.Messenger.Rules{

    public class RuleFactory{

        private readonly ILogger _logger;
        
        public RuleFactory(ILogger logger){
            _logger = logger  ?? throw new ArgumentNullException(nameof(logger));
        }

        public Func<string,IMessageRule>[] GetRules(){
            //TODO: Read azure config as a template to construct rules
            var lengthRule = (string input) => new ConditionalRule(input, (string requestMessage) => requestMessage.Contains('?'), (string requestMessage) => requestMessage.Length < 10);
            var helloRule = (string input) => new ReplicateRule(input, "hello");
            var goodbye = (string input) => new ReplicateRule(input, "goodbye");
            var rules = new Func<string,IMessageRule>[3]{lengthRule,helloRule,goodbye};

            return rules;
        }
    }
}