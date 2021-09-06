using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TimeAzure.Common.Models;
using TimeAzure.Functions.Entities;

namespace TimeAzure.Test.Helpers
{
    public class TestFactory
    {
        public static TimeEntity GetTodoEntity()
        {
            return new TimeEntity
            {
                ETag = "*",
                PartitionKey = "TIME",
                RowKey = Guid.NewGuid().ToString(),
                IdEmpleado = 1,
                FechaHora = DateTime.UtcNow,
                Tipo = 0,
                Consolidado = false,
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid timeId, Time timeRequest)
        {
            string request = JsonConvert.SerializeObject(timeRequest);
            DefaultHttpRequest httpRequest = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamFromString(request),
                Path = $"/{timeId}"
            };

            return httpRequest;
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid timeId)
        {
            DefaultHttpRequest httpRequest = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Path = $"/{timeId}"
            };

            return httpRequest;
        }

        public static DefaultHttpRequest CreateHttpRequest(Time timeRequest)
        {
            string request = JsonConvert.SerializeObject(timeRequest);
            DefaultHttpRequest httpRequest = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamFromString(request)
            };

            return httpRequest;
        }

        public static DefaultHttpRequest CreateHttpRequest()
        {
            DefaultHttpRequest httpRequest = new DefaultHttpRequest(new DefaultHttpContext())
            {
            };

            return httpRequest;
        }

        public static Time GetTodoRequest()
        {
            return new Time
            {
                IdEmpleado = 1,
                FechaHora = DateTime.UtcNow,
                Consolidado = false,
                Tipo = 0,
            };
        }

        public static Stream GenerateStreamFromString(string stringToConvert)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(stringToConvert);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
