using Microsoft.AspNetCore.Mvc;
using ST10294145_prog_2.Models;
using ST10294145_prog_2.Models.ST10294145_prog_2.Models;

namespace ST10294145_prog_2.Controllers
{
    public class ClaimsController : Controller
    {
        public IActionResult Dashboard()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(userRole)) return RedirectToAction("Index", "Home");

            var claims = userRole == "Lecturer"
                ? InMemoryData.Claims.Where(c => c.LecturerName == "lecturer") // Hardcoded for demo
                : InMemoryData.Claims;

            return View(claims.ToList());
        }

        // Display form to submit a claim
        public IActionResult SubmitClaim() => View();

        [HttpPost]
        public IActionResult SubmitClaim(SubmitClaim SubmitClaim)
        {
            var claim = new Claim
            {
                Id = InMemoryData.Claims.Count + 1,
            };

            claim.LecturerName = "lecturer"; // Hardcoded for demo
            InMemoryData.Claims.Add(claim);
            return RedirectToAction("Dashboard");
        }

        // Approve or Reject Claim
        [HttpPost]
        public IActionResult UpdateClaimStatus(int claimId, string action)
        {
            var claim = InMemoryData.Claims.FirstOrDefault(c => c.Id == claimId);
            if (claim != null)
            {
                claim.Status = action == "approve" ? "Approved" : "Rejected";
            }
            return RedirectToAction("Dashboard");
        }

        // Upload Supporting Document
        [HttpPost]
        public IActionResult UploadDocument(int claimId, IFormFile document)
        {
            var claim = InMemoryData.Claims.FirstOrDefault(c => c.Id == claimId);
            if (claim != null && document != null)
            {
                var filePath = Path.Combine("wwwroot", "uploads", document.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    document.CopyTo(stream);
                }
                claim.SupportingDocument = document.FileName;
            }
            return RedirectToAction("Dashboard");
        }
    }
}
