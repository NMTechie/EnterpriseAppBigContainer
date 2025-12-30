using ApplicationLayer.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationLayer.BusinessHandlers
{
    public class RuleEnginePipelineBuilder 
    {
        private readonly Dictionary<string, IRuleFactory> _factories;
        public RuleEnginePipelineBuilder(IEnumerable<IRuleFactory> factories)
        {
            _factories = factories.ToDictionary(f => f.Name);
        }
        public IReadOnlyList<IRule> Build(IEnumerable<string> steps)
        {
            return steps.Select(step =>
            {
                if (!_factories.TryGetValue(step, out var factory))
                    throw new InvalidOperationException($"Unknown step: {step}");

                return factory.Create();
            }).ToList();
        }
    }
}
