using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentsWebApp.Data;
using TournamentsWebApp.Models;
using TournamentsWebApp.Services;


namespace TournamentsWebApp.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        
        public TournamentsController(IAuthorizationService authorizationService, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _authorizationService = authorizationService;
            _context = context;
            _userManager = userManager;
        }

        // GET: Tournaments
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";

            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var tournaments = from row in _context.Tournament select row;

            if (!String.IsNullOrEmpty(searchString))
            {
                tournaments = tournaments.Where(s => s.Name.Contains(searchString)
                                       || s.StartDate.ToString().Contains(searchString));
            }
            

            switch (sortOrder)
            {
                case "name_desc":
                    tournaments = tournaments.OrderByDescending(s => s.Name).ThenBy(s => s.StartDate);
                    break;
                case "name":
                    tournaments = tournaments.OrderBy(s => s.Name).ThenBy(s => s.StartDate);
                    break;
                case "date_desc":
                    tournaments = tournaments.OrderByDescending(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                default:
                    tournaments = tournaments.OrderBy(s => s.StartDate).ThenBy(s => s.Name); ;
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Tournament>.CreateAsync(tournaments.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Tournaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);

            if (tournament == null)
            {
                return NotFound();
            }

            if(tournament.StartDate < DateTime.Now && tournament.isBracket == false)
            {
                Bracket.generateBracket(_context, tournament);
            }

            if (tournament.isBracket)
            {
                return RedirectToAction("Started", new { id }); //view z drabinka
            }
            else
            {
                var logos = await _context.Logos.Include(m => m.tournament).Where(m => m.TournamentId == id).ToListAsync();
                var model = new DetailsModel
                {
                    tournament = tournament,
                    allLogos = logos
                };
                return View(model);
            }
        }


        public async Task<IActionResult> Started(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);
            var allMatches = await _context.Matches.Include(m => m.OpponentFirst).Include(m => m.OpponentSecond).Include(m => m.tournament).Where(m => m.TournamentID == id).ToListAsync();
            var logos = await _context.Logos.Include(m => m.tournament).Where(m => m.TournamentId == id).ToListAsync();
            var userID = _userManager.GetUserId(User);
            List<Match> userMatches = null;

            if (userID != null)
            {
                userMatches = allMatches.Where(m =>( m.OpponentFirstID == userID || m.OpponentSecondID == userID )&& m.isFinished != true ).ToList();
            }


            var bracket = new List<List<List<BracketModel>>>();
            var round = new List<List<BracketModel>>();

            for (var i = 0; i < allMatches.Count; i++ )
            {
                var b1 = new BracketModel
                {
                    name = allMatches[i].LicenceNumberFirst ?? "TBD",
                    id = allMatches[i].LicenceNumberFirst  
                };

                var b2 = new BracketModel
                {
                    name = allMatches[i].LicenceNumberSecond ?? "TBD",
                    id = allMatches[i].LicenceNumberSecond 
                };
                var match = new List<BracketModel> { b1, b2 };
                round.Add(match);
                if(allMatches[i].MatchNumber != 1 && ((allMatches[i].MatchNumber - 1) & allMatches[i].MatchNumber) == 0)
                {
                    bracket.Add(round);
                    round = new List<List<BracketModel>>();
                }

            }
            bracket.Add(round);

            allMatches.Reverse();
            bracket.Reverse();
            var x = new BracketModel
            {
                name = allMatches.Last().WinnerID ?? "TBD",
                id = allMatches.Last().WinnerID
            };
            var dM = new List<BracketModel>() { x };
            bracket.Add(new List<List<BracketModel>>() { dM });

            

            var model = new ViewModel
            {
                bracket = bracket,
                allMatches = allMatches,
                userMatches = userMatches,
                tournament = tournament,
                allLogos = logos
            };


            return View(model);
        }


        [Authorize]
        // GET: Tournaments/Create
        public IActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StartDate,Deadline,Discipline,localization,maxPart")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                tournament.Owner = await _userManager.GetUserAsync(User);
                _context.Add(tournament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(tournament);
        }

        // GET: Tournaments1/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);
            if (tournament == null)
            {
                return NotFound();
            }

            var userID = _userManager.GetUserId(User);
            var ownerID = tournament.Owner.Id;
            if (ownerID == userID)
                return View(tournament);
            else
                return RedirectToAction(nameof(Index));

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartDate,Deadline,Discipline,currentPart,localization,maxPart")] Tournament tournament)
        {
            if (id != tournament.ID)
            {
                return NotFound();
            }
            

            var current = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);
            _context.Entry(current).State = EntityState.Detached;

            if (current.isBracket == true)
            {
                //todo info
                return NotFound();
            }

            var userID = _userManager.GetUserId(User);
            var ownerID = current.Owner.Id;
            if (ownerID != userID)
                return RedirectToAction(nameof(Index));



            lock (Lock.partLock)
            {
                tournament.currentPart = current.currentPart;
                if (ModelState.IsValid && tournament.currentPart <= tournament.maxPart)
                {
                    try
                    {

                        _context.Update(tournament);
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TournamentExists(tournament.ID))
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
            }
            return View(tournament);
        }

        // GET: Tournaments1/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);

            var userID = _userManager.GetUserId(User);
            var ownerID = tournament.Owner.Id;
            if (ownerID != userID)
                return RedirectToAction(nameof(Index));

            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // POST: Tournaments1/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);

            var userID = _userManager.GetUserId(User);
            var ownerID = tournament.Owner.Id;
            if (ownerID != userID || tournament.isBracket == true)
                return RedirectToAction(nameof(Index));
            _context.Tournament.Remove(tournament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> MyTournaments()
        {
            var userID = _userManager.GetUserId(User);

            var enrollmentsT = await _context.Enrollments.Where(e => e.ApplicationUserID == userID).Include(e => e.tournament).ToListAsync();
            var matchesT = await _context.Matches.Where(m => (m.OpponentFirstID == userID || m.OpponentSecondID == userID) && m.isFinished == false).Include(e=> e.tournament).ToListAsync();

            
            var model = new MatchesTournaments();
            model.Matches = matchesT;
            model.Tournaments = enrollmentsT;


            if (enrollmentsT == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Close(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournament.Include(m => m.Owner).FirstOrDefaultAsync(m => m.ID == id);
            if (tournament == null)
            {
                return NotFound();
            }
            if(tournament.currentPart < 2)
            {
                //nie ma sensuzamykac jak <2
                return NotFound();
            }

            var userID = _userManager.GetUserId(User);
            var ownerID = tournament.Owner.Id;
            if (ownerID == userID)
            {
                Bracket.generateBracket(_context, tournament);
                
                return RedirectToAction("Index", "Tournaments");
            }
                
            else
                return RedirectToAction(nameof(Index));

        }

        [Authorize]
        public async Task<IActionResult> Add_sponsors(int? id)
        {

            return RedirectToAction("Create", "Logoes", new { id});

        }


        private bool TournamentExists(int id)
        {
            return _context.Tournament.Any(e => e.ID == id);
        }
    }
}