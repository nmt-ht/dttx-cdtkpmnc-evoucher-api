﻿using eVoucher.Service.Dtos;
using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries;
public interface IReportQueries
{
    Task<IList<ReportDto>> GetAllCampaigns();
}

