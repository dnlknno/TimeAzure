using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using TimeAzure.Functions.Entities;

namespace TimeAzure.Functions.Functions
{
    public static class ScheduleFunction
    {
        [FunctionName("ScheduleFunction")]
        public static void Run(
            [TimerTrigger("0 */1 * * * *")]TimerInfo myTimer,
            [Table("time", Connection = "AzureWebJobsStorage")] CloudTable timeTable,
            ILogger log)
        {
            log.LogInformation($"Consolidated function executed at: {DateTime.Now}");

            string filter = TableQuery.GenerateFilterConditionForBool("Consolidado", QueryComparisons.Equal, false);
            TableQuery<TimeEntity> query = new TableQuery<TimeEntity>().Where(filter);

        }
    }
}
