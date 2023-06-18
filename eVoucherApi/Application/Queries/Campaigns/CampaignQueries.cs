using Dapper;
using eVoucher.Service.Dtos;
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

    public async Task<IList<CampaignDto>> GetCampaigns()
    {
        var campaigns = new List<CampaignDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();

            var result = await connection.QueryMultipleAsync(@"spr_eVoucherApi_GetCampaigns", commandType: CommandType.StoredProcedure);
            campaigns = result.Read<CampaignDto>().AsList();
            var partners = result.Read<PartnerDto>().AsList();
            var addressDtos = result.Read<AddressDto>().AsList();
            var games = result.Read<GameDto>().AsList();

            if(campaigns is not null && campaigns.Any())
            {
                foreach(var campaign in campaigns) 
                { 
                    foreach(var partner in partners)
                    {
                        if(partner.Id == campaign.PartnerId)
                        {
                            foreach(var address in addressDtos)
                            {
                                if(address.UserId == partner.User_ID_FK)
                                {
                                    partner.CompanyAddess.Add(address);
                                }
                            }
                            campaign.Partners.Add(partner);
                        }
                    }

                    foreach (var game in games)
                    {
                        if(game.CampaignID == campaign.Id)
                        {
                            campaign.Games.Add(game);
                        }
                    }
                }
            }
        }

        return campaigns;
    }
}
