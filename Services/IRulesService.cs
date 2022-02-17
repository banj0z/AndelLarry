using Larry.Messenger.Rules;
using System;

namespace Larry.Messenger.Services
{
    public interface IRulesService{
        Func<string,IMessageRule>[] GetRules();
    }
}