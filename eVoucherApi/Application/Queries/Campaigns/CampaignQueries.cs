﻿using Dapper;
using eVoucherApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace eVoucher.Services.Api.Application.Queries;
public class CampaignQueries: ICampaignQueries
{
    private string _connectionString;

    public CampaignQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IList<Campaign>> GetCampaigns()
    {
        var campaigns = new List<Campaign>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();

            var result = await connection.QueryAsync<Campaign>(@"spr_eVoucherApi_GetCampaigns", commandType: CommandType.StoredProcedure);
            campaigns = result.AsList<Campaign>();
        }

        return campaigns;
    }
}
