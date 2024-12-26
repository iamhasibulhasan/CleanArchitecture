using Dapper;
using System.Data;

namespace CleanArchitecture.Application.RepositoryInterfaces.Common;

public interface IDapperRepository : IDisposable
{
    Task<T?> GetAsync<T>(string query, DynamicParameters? dynamicParameters = null, CommandType commandType = CommandType.Text);
    Task<List<T>> GetAllAsync<T>(string query, DynamicParameters dynamicParameters, CommandType commandType = CommandType.Text);
    Task<List<dynamic>> GetJsonData(string sp, DynamicParameters? dynamicParameters = null);
    Task<T> GetBySingleParamAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
    Task<T> GetBySingleParamAsyncWithWrite<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
}
