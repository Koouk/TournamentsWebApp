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
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MatchesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Matches/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            var list = new List<string> { match.LicenceNumberFirst, match.LicenceNumberSecond };
            ViewData["Players"] = new SelectList(list);

            return View(match);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,WinnerID,TournamentID,OpponentFirstID", "OpponentSecondID", "LicenceNumberFirst", "LicenceNumberSecond")] Match match)
        {
            if (id != match.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userID = _userManager.GetUserId(User);

                    lock(Lock.resultLock){
                        var matchMain =  _context.Matches.Find(id);
                        _context.Entry(matchMain).State = EntityState.Detached;
                        if(matchMain.isFinished == true)
                        {
                            return NotFound();
                        }

                        if (userID != matchMain.OpponentFirstID && userID != matchMain.OpponentSecondID)
                        {
                            return NotFound();
                        }
                        if (match.OpponentFirstID != matchMain.OpponentFirstID || match.OpponentSecondID != matchMain.OpponentSecondID)
                        {
                            return NotFound();
                        }
                        if (match.WinnerID != matchMain.LicenceNumberFirst && match.WinnerID != matchMain.LicenceNumberSecond)
                        {
                            return NotFound();
                        }

                        if (match.TournamentID != matchMain.TournamentID)
                        {
                            return NotFound();
                        }

                        match.LicenceNumberFirst = matchMain.LicenceNumberFirst;
                        match.LicenceNumberSecond = matchMain.LicenceNumberSecond;

                        if (matchMain.TemporaryResult == null || match.TemporaryResult == "-1")
                        {
                            match.TemporaryResult = match.WinnerID;
                            match.WinnerID = null;

                        }
                        else
                        {
                            if (match.TemporaryResult == match.WinnerID)
                            {

                                match.isFinished = true;

                            }
                            else
                            {
                                match.TemporaryResult = "-1";
                                match.WinnerID = null;
                            }
                        }
                    }

                    _context.Update(match);
                    await _context.SaveChangesAsync();

                    if(match.isFinished && match.nextMatchNumber != null)
                    {
                        var nextMatch = await _context.Matches.Include(m => m.OpponentFirst).Include(m => m.OpponentSecond).Include(m => m.tournament)
                            .Where(m => m.TournamentID == id).Where(m => m.MatchNumber == match.nextMatchNumber).FirstOrDefaultAsync();

                        if(nextMatch.OpponentFirstID == null)
                        {
                            nextMatch.OpponentFirstID = match.OpponentFirstID;
                        }
                        else
                        {
                            nextMatch.OpponentSecondID = match.OpponentSecondID;
                        }
                        _context.Update(nextMatch);
                        await _context.SaveChangesAsync();
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var correct = await _context.Matches.FindAsync(id);
            _context.Entry(correct).State = EntityState.Detached;
            if (match == null)
            {
                return NotFound();
            }
            var list = new List<string> { correct.LicenceNumberFirst, correct.LicenceNumberSecond };
            ViewData["Players"] = new SelectList(list);

            return View(match);
        }


        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.ID == id);
        }
    }
}
