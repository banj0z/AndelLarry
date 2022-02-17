namespace Larry.Messenger.Rules
{
    public interface IMessageRule{
        
        public bool DoesRuleApply();
        public string GetResponse();
    }
}