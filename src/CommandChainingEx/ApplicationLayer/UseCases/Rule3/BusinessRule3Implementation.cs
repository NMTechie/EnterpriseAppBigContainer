using ApplicationLayer.BusinessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Rule3
{
    internal class BusinessRule3Implementation : IRule
    {
        public void Execute()
        {
            Console.WriteLine(" BusinessRule3Implementation Executed ");
        }
    }
}
