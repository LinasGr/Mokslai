﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class AssociationsController : Controller
    {
        private readonly DocumentsContext _context;

        public AssociationsController(DocumentsContext context)
        {
            _context = context;
        }

        // GET: Associations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Association.ToListAsync());
        }

        // GET: Associations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association
                .FirstOrDefaultAsync(m => m.ID == id);
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
        }

        // GET: Associations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreationDate,Name,ShortName")] Association association)
        {
            if (ModelState.IsValid)
            {
                _context.Add(association);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(association);
        }

        // GET: Associations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association.FindAsync(id);
            if (association == null)
            {
                return NotFound();
            }
            return View(association);
        }

        // POST: Associations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CreationDate,Name,ShortName")] Association association)
        {
            if (id != association.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(association);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationExists(association.ID))
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
            return View(association);
        }

        // GET: Associations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association
                .FirstOrDefaultAsync(m => m.ID == id);
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
        }

        // POST: Associations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var association = await _context.Association.FindAsync(id);
            _context.Association.Remove(association);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationExists(int id)
        {
            return _context.Association.Any(e => e.ID == id);
        }
    }
}
