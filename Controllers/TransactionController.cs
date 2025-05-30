﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jQueryAjaxEFASPNetCore.Models;

namespace jQueryAjaxEFASPNetCore.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        
        //GET: Transaction/AddOrEdit

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new TransactionModel());
            }
            else
            {
                var transaction = await _context.Transactions.FindAsync(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                return View(transaction);
            }


        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] TransactionModel transactionModel)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    transactionModel.Date = DateTime.Now;
                    _context.Add(transactionModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(transactionModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(transactionModel.TransactionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList() ) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
        }

       

        private bool TransactionModelExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
