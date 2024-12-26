using CleanArchitecture.Application.RepositoryInterfaces.Common;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CleanArchitecture.Infrastructure.RepositoryImplementations.Common;

public class DapperRepository : IDapperRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _defaultConnectionstring = "DbConnection";
    private readonly IDbConnection _dbConnection;
    bool disposed = false;
    public DapperRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString(_defaultConnectionstring));
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            _dbConnection?.Dispose();
        }
        disposed = true;
    }

    public async Task<T?> GetAsync<T>(string query, DynamicParameters? dynamicParameters = null, CommandType commandType = CommandType.Text)
    {
        return (await _dbConnection.QueryAsync<T>(query, dynamicParameters, commandType: commandType)).FirstOrDefault();
    }
    public async Task<List<T>> GetAllAsync<T>(string query, DynamicParameters? dynamicParameters = null, CommandType commandType = CommandType.Text)
    {
        return (await _dbConnection.QueryAsync<T>(query, dynamicParameters, commandType: commandType)).ToList();
    }

    public async Task<List<dynamic>> GetJsonData(string sp, DynamicParameters? dynamicParameters = null)
    {
        var result = (await _dbConnection.QueryAsync(sp, dynamicParameters));
        return (List<dynamic>)result;
    }

    public async Task<T?> GetBySingleParamAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
    {
        return (await _dbConnection.QueryAsync<T>(sp, parms, commandType: commandType)).FirstOrDefault();
    }
    public async Task<T?> GetBySingleParamAsyncWithWrite<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
    {
        return (await _dbConnection.QueryAsync<T>(sp, parms, commandType: commandType)).FirstOrDefault();
    }
}
