using System;

namespace DesignPatterns.TemplateMethod
{
    public class GenerateReportTask : BaseTask
    {
        public GenerateReportTask(AuditTrial auditTrial) 
            : base(auditTrial) { }

        protected override void DoExecute()
        {
            Console.WriteLine("Generate report");
        }
    }
}