using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Hairdresser;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Hairdresser
{
    public partial interface IHairdresserService
    {
        Task<Response<HairdresserDto>> InsertAsync(HairdresserDto request);
        Task<Response<bool>> DeleteAsync(HairdresserDto request);
        Task<Response<bool>> UpdateAsync(int id, HairdresserDto request);
        Task<Response<List<HairdresserDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<HairdresserDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool hairdresserIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string hairdresserName, int? page, int? size);
        Task<Response<List<GetServicesForHairdressersResponseDto>>> GetServicesForHairdressersAsync(int hairdressersId);
        Task<Response<GetServicesForHairdressersResponseDto>> GetServicesForHairdressersDetailsAsync(int hairdressersId, int servicesId);
        Task<Response<List<GetHairdresserAvailabilitiesForHairdressersResponseDto>>> GetHairdresserAvailabilitiesForHairdressersAsync(int hairdressersId);
        Task<Response<GetHairdresserAvailabilitiesForHairdressersResponseDto>> GetHairdresserAvailabilitiesForHairdressersDetailsAsync(int hairdressersId, int hairdresserAvailabilitiesId);
        Task<Response<List<GetHairdresserNotesForHairdressersResponseDto>>> GetHairdresserNotesForHairdressersAsync(int hairdressersId);
        Task<Response<GetHairdresserNotesForHairdressersResponseDto>> GetHairdresserNotesForHairdressersDetailsAsync(int hairdressersId, int hairdresserNotesId);
        Task<Response<int>> ActivateAsync(int hairdresserId, ActivateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int hairdresserId, DeactivateRequestDto updateRequest);
    }
}