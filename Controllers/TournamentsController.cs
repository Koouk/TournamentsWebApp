using System;
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

            if(tournament.isBracket)
            {
                return View(); //view z drabinka
            }
            else
                return View(tournament);
        }

        [Authorize]
        // GET: Tournaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // POST: Tournaments1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            if (ownerID != userID)
                return RedirectToAction(nameof(Index));
            _context.Tournament.Remove(tournament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> MyTournaments()
        {
            var userID = _userManager.GetUserId(User);

            var tournaments = _context.Enrollments.Where(e => e.ApplicationUserID == userID).Include(e => e.tournament);

            if (tournaments == null)
            {
                return NotFound();
            }
            return View(await tournaments.ToListAsync());
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

            var userID = _userManager.GetUserId(User);
            var ownerID = tournament.Owner.Id;
            if (ownerID == userID)
            {
                Bracket.generateBracket(_context, tournament);
                
                return RedirectToAction("Details", "Tournaments", id);
            }
                
            else
                return RedirectToAction(nameof(Index));

        }


        private bool TournamentExists(int id)
        {
            return _context.Tournament.Any(e => e.ID == id);
        }
    }
}