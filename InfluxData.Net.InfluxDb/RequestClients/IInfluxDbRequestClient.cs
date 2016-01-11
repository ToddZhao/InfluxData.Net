﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InfluxData.Net.InfluxDb.Formatters;
using InfluxData.Net.InfluxDb.Infrastructure;
using InfluxData.Net.InfluxDb.Models;

namespace InfluxData.Net.InfluxDb.RequestClients
{
    public interface IInfluxDbRequestClient
    {
        IInfluxDbFormatter GetFormatter();

        /// <summary>Pings the server.</summary>
        /// <param name="errorHandlers">The error handlers.</param>
        /// <returns></returns>
        Task<IInfluxDbApiResponse> PingAsync();

        /// <summary>
        /// Writes series to the database based on <see cref="{WriteRequest}"/> object.
        /// </summary>
        /// <param name="dbName"><see cref="{WriteRequest}"/> object that describes the data to write.</param>
        /// <returns></returns>
        Task<IInfluxDbApiResponse> WriteAsync(WriteRequest writeRequest);

        /// <summary>
        /// Executes a query against the InfluxDb API in a single request. Multiple queries can be 
        /// passed in in the form of semicolon-delimited string.
        /// </summary>
        /// <param name="query">Queries to execute. For language specification please see
        /// <a href="https://influxdb.com/docs/v0.9/concepts/reading_and_writing_data.html">InfluxDb documentation</a>.</param>
        /// <returns></returns>
        Task<IInfluxDbApiResponse> QueryAsync(string query);

        /// <summary>
        /// Executes a query against the database in a single request. Multiple queries can be 
        /// passed in in the form of semicolon-delimited string.
        /// </summary>
        /// <param name="dbName">Database name.</param>
        /// <param name="query">Queries to execute. For language specification please see
        /// <a href="https://influxdb.com/docs/v0.9/concepts/reading_and_writing_data.html">InfluxDb documentation</a>.</param>
        /// <returns></returns>
        Task<IInfluxDbApiResponse> QueryAsync(string dbName, string query);

        Task<IInfluxDbApiResponse> GetQueryAsync(IDictionary<string, string> requestParams);

        Task<IInfluxDbApiResponse> GetQueryAsync(HttpContent content = null, IDictionary<string, string> requestParams = null, bool includeAuthToQuery = true, bool headerIsBody = false);

        Task<IInfluxDbApiResponse> PostDataAsync(IDictionary<string, string> requestParams);

        Task<IInfluxDbApiResponse> PostDataAsync(HttpContent content = null, IDictionary<string, string> requestParams = null, bool includeAuthToQuery = true, bool headerIsBody = false);
    }
}