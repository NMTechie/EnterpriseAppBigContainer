using ApplicationLayer.BusinessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Rule1
{
    internal class BusinessRule1Implementation : IRule
    {
        public void Execute()
        {
            Console.WriteLine(" BusinessRule1Implementation Executed ");
        }
    }
}
