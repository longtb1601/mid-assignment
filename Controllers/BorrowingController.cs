using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Services.Implementation;

namespace MidAssignment.Controllers
{
    public class BorrowingController : ControllerBase
    {
        private BorrowingRequestService _borrowingService;
        public BorrowingController(BorrowingRequestService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet("/borrowing-request")]
        public IEnumerable<BorrowingRequest> GetAll()
        {
            return _borrowingService.GetAll();
        }

        [HttpGet("/borrowing-request/{id}")]
        public ActionResult<BorrowingRequest> GetOne(int id)
        {
            return _borrowingService.GetOne(id);
        }

        [HttpPost("/borrowing-request")]
        public async Task<BorrowingRequest> Create(BorrowingRequestDTO request, List<int> bookIDs)
        {
            return await _borrowingService.Create(request, bookIDs);
        }

        [HttpPut("/borrowing-request")]
        public async Task<BorrowingRequest> Update(BorrowingRequestDTO request)
        {
            return await _borrowingService.Update(request);
        }
    }
}