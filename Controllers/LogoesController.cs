using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TournamentsWebApp.Data;
using TournamentsWebApp.Models;

namespace TournamentsWebApp.Controllers
{
    public class LogoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public LogoesController(IAuthorizationService authorizationService, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _authorizationService = authorizationService;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var logo = new Logo();
            logo.TournamentId = (int)id;
            return View(logo);
        }

        // POST: Logoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("link,TournamentId")] Logo logo)
        {
            if (ModelState.IsValid)
            {
                if (logo.TournamentId == null)
                {
                    return NotFound();
                }

                var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == logo.TournamentId);
                if (tournament == null)
                {
                    return NotFound();
                }

                var userID = _userManager.GetUserId(User);
                var ownerID = tournament.Owner.Id;
                if (ownerID == userID)
                {
                    _context.Add(logo);
                    await _context.SaveChangesAsync();

                }
                return RedirectToAction("Index", "Tournaments");

            }

            return View(logo);
        }
        private bool LogoExists(int id)
        {
            return _context.Logos.Any(e => e.ID == id);
        }
    }
}
