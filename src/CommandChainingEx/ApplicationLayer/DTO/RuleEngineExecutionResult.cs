using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class RuleEngineExecutionResult
    {
        public bool IsSuccessful { get; set; }
        public NameValueCollection Messages { get; set; }
        public RuleEngineExecutionResult()
        {
            Messages = new NameValueCollection();
        }
    }
}
