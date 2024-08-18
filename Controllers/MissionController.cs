using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Calendar.Models;
using Calendar.Data;

public class MissionController : Controller
{
    private readonly ApplicationDbContext _context;

    public MissionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Calendar()
    {
        if (User.Identity.IsAuthenticated){
        var missions = await _context.Missions.ToListAsync();
        return View(missions);
        } else {
                return RedirectToAction("Login", "Account");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Mission mission)
    {
        if (User.Identity.IsAuthenticated){
        if (ModelState.IsValid)
        {
            if (mission.Id > 0)
            {
                var existingMission = await _context.Missions.FindAsync(mission.Id);
                if (existingMission != null)
                {
                    existingMission.Title = mission.Title;
                    existingMission.StartDate = mission.StartDate;
                    existingMission.EndDate = mission.EndDate;
                    existingMission.Description = mission.Description;
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
            }
            else
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return Json(new { success = true, id = mission.Id });
            }
        }
        return Json(new { success = false });
        } else {
                return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteMission(int id)
    {
        if (User.Identity.IsAuthenticated){
        var mission = await _context.Missions.FindAsync(id);
        if (mission != null)
        {
            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Mission not found." });
        } else {
                return RedirectToAction("Index", "Home");
        }
    }
}
