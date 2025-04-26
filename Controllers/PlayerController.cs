using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VeronicaSofiaPrograParcial.Data;
using VeronicaSofiaPrograParcial.Models;

namespace VeronicaSofiaPrograParcial.Controllers
{
    
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

         public IActionResult Index()
        {
            var players = _context.Players
                .Include(p => p.PlayerTeams)
                .ThenInclude(pt => pt.Team)
                .ToList();
                
            return View(players);
        }


        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Player player, int teamId)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                
                // Asociar con equipo
                var playerTeam = new PlayerTeam
                {
                    PlayerId = player.Id,
                    TeamId = teamId
                };
                
                _context.PlayerTeams.Add(playerTeam);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Teams = _context.Teams.ToList();
            return View(player);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}