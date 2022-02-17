using Larry.Messenger.Services;
using Larry.Messenger.Rules;
using System;
using Microsoft.Extensions.Logging;

namespace Larry.Messenger.Services
{
    public class ResponseService : IResponseService{

        private readonly RulesService _RulesService;
        private readonly ILogger _logger;

        public ResponseService(ILogger logger){
            //TODO: consider using dependency injection
            _RulesService = new RulesService(logger);
            _logger = logger;
        }
        
        public string GetResponse(){
            return "Busy right now, can't talk";
        }

        public string GetResponse(string requestMessage){
            _logger.LogInformation("Getting rules");
            var rules = _RulesService.GetRules();
            _logger.LogInformation($"Configured {rules.Length} rules.");
            
            foreach(var rule in rules){
                _logger.LogInformation($"Applying message {requestMessage} to rule");
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