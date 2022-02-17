using Larry.Messenger.Services;
using Larry.Messenger.Rules;
using System;
using Microsoft.Extensions.Logging;

namespace Larry.Messenger.Services
{
    public class ResponseService : IResponseService{

        private readonly RuleFactory _rulesFactory;
        private readonly ILogger _logger;

        public ResponseService(ILogger logger){
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //TODO: consider using dependency injection
            _rulesFactory = new RuleFactory(logger);
        }

        public string GetResponse(string requestMessage){
            _logger.LogInformation("Getting rules");
            var rules = _rulesFactory.GetRules();
            _logger.LogInformation($"Configured {rules.Length} rules.");
            
            foreach(var rule in rules){
                var msgSpecificRule = rule(requestMessage);
                if(msgSpecificRule.DoesRuleApply()){
                    return msgSpecificRule.GetResponse();
                }
            }

            //TODO: move to azure config
            return "Busy right now, can't talk";
        }
    }
}