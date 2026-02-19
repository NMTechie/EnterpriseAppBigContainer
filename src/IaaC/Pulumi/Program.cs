using System.Collections.Generic;
using System.Linq;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;



return await Pulumi.Deployment.RunAsync(() =>
{
    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup("myexprg");

    // Create an Azure Storage Account
    var storageAccount = new StorageAccount("myexpsa", new StorageAccountArgs
    {
        ResourceGroupName = resourceGroup.Name,
        Sku = new SkuArgs
        {
            Name = SkuName.Standard_LRS
        },
        Kind = Kind.StorageV2
    });

    var logAnalyticsWorkspace = new Pulumi.Azure.OperationalInsights.AnalyticsWorkspace("myexploganalytics", new()
    {
        //Name = "myexploganalytics",
        Location = resourceGroup.Location,
        ResourceGroupName = resourceGroup.Name,
        Sku = "PerGB2018",
        RetentionInDays = 30,
    });

    var appInsightInstance = new Pulumi.AzureNative.ApplicationInsights.Component("myexpappins", new()
    {
        ApplicationType = "web",
        ResourceGroupName = resourceGroup.Name,
        Kind = "web",
        ForceCustomerStorageForProfiler = false,
        PublicNetworkAccessForIngestion = "Enabled",
        HockeyAppId = "ThisIsNotUsedAnymore",
        ImmediatePurgeDataOn30Days = true,
        IngestionMode = "LogAnalytics",
        DisableLocalAuth = false,
        Location = resourceGroup.Location,
        FlowType = "Bluefield",
        PublicNetworkAccessForQuery = "Enabled",
        RequestSource = "rest",
        DisableIpMasking = false,
        //ResourceName = "myexpappins",
        RetentionInDays = 30,
        SamplingPercentage = 100.0,
        Tags =
    {
        { "Dev", "AppInsight" },
    },
        WorkspaceResourceId = logAnalyticsWorkspace.Id,
    });

    // Export the storage account name
    return new Dictionary<string, object?>
    {
        ["storageAccountName"] = storageAccount.Name,
        ["AppInsightsInstrumentationKey"] = appInsightInstance.InstrumentationKey,
        ["LogAnalyticsWorkspaceId"] = logAnalyticsWorkspace.Id
    };
});
