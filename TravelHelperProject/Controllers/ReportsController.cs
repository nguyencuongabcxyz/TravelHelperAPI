using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Models;
using TravelHelperProject.Services;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private IReportService _reportService;
        private IUserService _userService;
        public ReportsController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        [HttpPost("{id}")]
        public IActionResult PostReports(string id, Report report)
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return Unauthorized();
            }
            var sender = _userService.GetSingleByCondition(s => s.Id == userId, null);
            var receiver = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (sender == null || receiver == null)
            {
                return NotFound();
            }
            report.CreateDate = DateTime.Now;
            report.Sender = sender;
            report.Receiver = receiver;
            _reportService.Add(report);
            _reportService.SaveChanges();
            return Ok(report);
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteReport(int id)
        {
            var report = _reportService.GetSingleById(id);
            if (report == null)
            {
                return NotFound();
            }
            report.IsDeleted = true;
            _reportService.Update(report);
            _reportService.SaveChanges();
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult MarkIsSolved(int id)
        {
            var report = _reportService.GetSingleById(id);
            if (report == null)
            {
                return NotFound();
            }
            report.IsSolved = true;
            _reportService.Update(report);
            _reportService.SaveChanges();
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUserReports(int index)
        {
            var reports = _reportService.GetMultiPagingDescByDate(s => s.IsDeleted != true, s => s.CreateDate, index, 10, new string[] { "Receiver", "Sender" });
            return Ok(reports);
        }

    }
}