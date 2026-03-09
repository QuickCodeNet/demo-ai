using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.Holiday;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.Holiday
{
    public partial class HolidayService : IHolidayService
    {
        private readonly ILogger<HolidayService> _logger;
        private readonly IHolidayRepository _repository;
        public HolidayService(ILogger<HolidayService> logger, IHolidayRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<HolidayDto>> InsertAsync(HolidayDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(HolidayDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, HolidayDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<HolidayDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<HolidayDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAllResponseDto>>> GetAllAsync()
        {
            var returnValue = await _repository.GetAllAsync();
            return returnValue.ToResponse();
        }
    }
}