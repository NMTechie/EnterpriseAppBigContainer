using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationLayer.BusinessHandlers
{
    public class RuleEngineDefinition
    {
        public List<RuleDefinition> Definitions { get; set; }

    }
    public class RuleDefinition
    {
        public int CategoryTypeId { get; set; }
        public List<string> Rules { get; set; }
    }

    public class RuleEngineBuilderFromConfig
    {
        private readonly IConfigurationRoot _configuration;
        public RuleEngineBuilderFromConfig(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        public RuleEngineDefinition Build()
        {
            var mySection = _configuration.GetSection("RuleEngineDefinition");
            var myObject = mySection.Get<RuleEngineDefinition>();

            string json = JsonSerializer.Serialize(myObject);
            return JsonSerializer.Deserialize<RuleEngineDefinition>(json);
        }
    }
}
