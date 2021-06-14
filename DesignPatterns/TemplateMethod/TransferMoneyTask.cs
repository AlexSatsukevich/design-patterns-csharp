using System;

namespace DesignPatterns.TemplateMethod
{
    public class TransferMoneyTask : BaseTask
    {
        public TransferMoneyTask(AuditTrial auditTrial) 
            : base(auditTrial) { }

        protected override void DoExecute()
        {
            Console.WriteLine("Transfer money");
        }
    }
}
