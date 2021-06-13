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
    public class TournamentEnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private static readonly object partLock = new object();

        public TournamentEnrollmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TournamentEnrollments
        [Authorize]

        // GET: TournamentEnrollments/Create
        public IActionResult Create(int id)
        {
            var userID = _userManager.GetUserId(User);
            var count = (from row in _context.Enrollments
                         where userID == row.ApplicationUserID && id == row.TournamentID
                         select row).Count();
            if (count > 0)
                return RedirectToAction("Index","Tournaments");

            var model = new TournamentEnrollment();
            model.TournamentID = id;
            return View(model);
        }

        // POST: TournamentEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicenceNumber,Ranking,TournamentID")] TournamentEnrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                var userID = _userManager.GetUserId(User);
                var count = (from row in _context.Enrollments
                             where userID == row.ApplicationUserID && enrollment.TournamentID == row.TournamentID
                             select row).Count();
                if (count > 0)
                    return RedirectToAction("Index", "Tournaments");


                enrollment.ApplicationUserID = userID;
                var canAdd = false;
                lock (partLock)
                {
                    var tournament = _context.Tournament.Include(m => m.Owner).FirstOrDefault(m => m.ID == enrollment.TournamentID);
                    if (tournament.maxPart - tournament.currentPart > 0)
                    {
                        canAdd = true;
                        tournament.currentPart += 1;
                        _context.Update(tournament);
                        _context.SaveChanges();
                    }
                }
                if (canAdd == true)
                {
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                }
                //TODO KOMUNIKAT
                return RedirectToAction("Index", "Tournaments");
            }

            return RedirectToAction("Index", "Tournaments");
        }

        // GET: TournamentEnrollments/Edit/5

        [Authorize]
        // GET: TournamentEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournamentEnrollment = await _context.Enrollments
                .Include(t => t.tournament)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tournamentEnrollment == null)
            {
                return NotFound();
            }

            return View(tournamentEnrollment);
        }
        [Authorize]
        // POST: TournamentEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournamentEnrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(tournamentEnrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentEnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.ID == id);
        }
    }
}
