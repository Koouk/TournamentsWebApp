using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentsWebApp.Controllers;
using TournamentsWebApp.Models;

namespace TournamentsWebApp.Services
{
    public class Bracket
    {

        public static void generateBracket(Data.ApplicationDbContext _context, Models.Tournament tournament)
        {
            if (tournament.isBracket == false)
            {
                lock (Lock.bracketLock)
                {
                    var enrollments = _context.Enrollments.Where(e => e.TournamentID == tournament.ID).Include(e => e.tournament).Include(e => e.user).OrderBy(x => x.Ranking).ToList();


                    var teams_round = enrollments.Count;

                    var matches = new List<Match>();

                    // jest n-1 meczy w single-bracket i indeks od 0
                    for (var i = enrollments.Count - 2; i >= 0; i--)
                    {
                        var tempMatch = new Match
                        {
                            TournamentID = tournament.ID,
                            positionID = i,
                            nextMatchID = (i == 0) ? null : (i - 1) / 2
                        };
                        matches.Add(tempMatch);
                    }

                    //dodawanie zawodnikow do lisci
                    for (int i = 0, j = 0; i < enrollments.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            matches[j].OpponentFirst = enrollments[i].user;
                            matches[j].OpponentFirstID = enrollments[i].ApplicationUserID;
                        }
                        else
                        {
                            matches[j].OpponentSecond = enrollments[i].user;
                            matches[j].OpponentSecondID = enrollments[i].ApplicationUserID;
                            j++;
                        }
                    }
                    foreach (var i in matches)
                    {
                        _context.Add(i);
                    }
                    tournament.isBracket = true;
                    _context.Update(tournament);
                    _context.SaveChanges();
                    
                }
            }
        }

    }
}
