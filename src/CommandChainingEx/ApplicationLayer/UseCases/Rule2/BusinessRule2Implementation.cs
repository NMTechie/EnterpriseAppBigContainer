using ApplicationLayer.BusinessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Rule2
{
    internal class BusinessRule2Implementation : IRule
    {
        public void Execute()
        {
            Console.WriteLine(" BusinessRule2Implementation Executed ");
        }
    }
}
