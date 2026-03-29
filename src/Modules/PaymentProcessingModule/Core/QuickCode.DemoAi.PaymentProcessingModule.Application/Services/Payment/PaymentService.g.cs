using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.PaymentProcessingModule.Domain.Entities;
using QuickCode.DemoAi.PaymentProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.PaymentProcessingModule.Application.Dtos.Payment;
using QuickCode.DemoAi.PaymentProcessingModule.Domain.Enums;

namespace QuickCode.DemoAi.PaymentProcessingModule.Application.Services.Payment
{
    public partial class PaymentService : IPaymentService
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly IPaymentRepository _repository;
        public PaymentService(ILogger<PaymentService> logger, IPaymentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PaymentDto>> InsertAsync(PaymentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PaymentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PaymentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PaymentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PaymentDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByOrderIdResponseDto>> GetByOrderIdAsync(int paymentOrderId)
        {
            var returnValue = await _repository.GetByOrderIdAsync(paymentOrderId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(PaymentStatus paymentStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(paymentStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPaymentsByDateRangeResponseDto>>> GetPaymentsByDateRangeAsync(DateTime paymentPaymentDateFrom, DateTime paymentPaymentDateTo, int? page, int? size)
        {
            var returnValue = await _repository.GetPaymentsByDateRangeAsync(paymentPaymentDateFrom, paymentPaymentDateTo, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int paymentId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(paymentId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}