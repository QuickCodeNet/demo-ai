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
    public partial interface IPaymentService
    {
        Task<Response<PaymentDto>> InsertAsync(PaymentDto request);
        Task<Response<bool>> DeleteAsync(PaymentDto request);
        Task<Response<bool>> UpdateAsync(int id, PaymentDto request);
        Task<Response<List<PaymentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PaymentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByOrderIdResponseDto>> GetByOrderIdAsync(int paymentOrderId);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(PaymentStatus paymentStatus, int? page, int? size);
        Task<Response<List<GetPaymentsByDateRangeResponseDto>>> GetPaymentsByDateRangeAsync(DateTime paymentPaymentDateFrom, DateTime paymentPaymentDateTo, int? page, int? size);
        Task<Response<int>> UpdateStatusAsync(int paymentId, UpdateStatusRequestDto updateRequest);
    }
}