namespace DesignPatterns.TemplateMethod
{
    public abstract class BaseTask
    {
        private readonly AuditTrial _auditTrial;

        protected BaseTask(AuditTrial auditTrial)
        {
            _auditTrial = auditTrial;
        }

        public void Execute()
        {
            _auditTrial.Record();

            DoExecute();
        }

        protected abstract void DoExecute();
    }
}