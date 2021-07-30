using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Services;

namespace MidAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        private IBorrowingRequestService _borrowingService;
        public BorrowingController(IBorrowingRequestService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_borrowingService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpGet("{id}")]
        public ActionResult<BorrowingRequest> Detail(int id)
        {
            try
            {
                return Ok(_borrowingService.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BorrowingRequestDTO request, [FromRoute] List<int> bookIDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Borrowing request is invalid"});
            }

            if (bookIDs.Count > 5)
            {
                return BadRequest(new { message = "User just borrow maximum is 5 books"});
            }

            int countRequest = _borrowingService.CountRequestUser(request.UserId);

            if (countRequest >= 3)
            {
                return BadRequest(new { message = "User just have 3 borrowing requests in a month"});
            }

            try
            {
                return Ok(await _borrowingService.Create(request, bookIDs));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BorrowingRequestDTO request)
        {
            try
            {
                return Ok(await _borrowingService.Update(request));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }
    }
}