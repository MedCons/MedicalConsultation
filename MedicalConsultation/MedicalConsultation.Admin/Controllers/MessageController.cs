using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalConsultation.Models;
using MedicalConsultation.Repos.Interfaces;
using MedicalConsultation.Repos;
using System;
using System.Linq;

namespace MedicalConsultation.Admin.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageRepo messageRepo;

        public MessageController(IMessageRepo messageRepo)
        {
            this.messageRepo = messageRepo;
        }

        // GET: Message
        public IActionResult Index(string searchString)
        {
            var messages = messageRepo.GetAll();

            if (UserState.IsLoggedIn && UserState.Role == 1)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    messages = messageRepo.GetAll().Where(s => s.Email.Contains(searchString));
                }

                return View(messages.ToList());
            }
            else
            {
                return RedirectToAction(nameof(LogInOffer));
            }
        }

        // GET: Message/Create
        public IActionResult Create()
        {
            if (UserState.IsLoggedIn && UserState.Role == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(LogInOffer));
            }
        }

        // POST: Message/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,Description")] Message message)
        {

            if (ModelState.IsValid)
            {
                await messageRepo.CreateAsync(message);
                return RedirectToAction(nameof(MsgSent));
            }
            return View(message);

        }

        // GET: Message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (UserState.IsLoggedIn && UserState.Role == 0)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var message = await messageRepo.GetAsync(id);
                if (message == null)
                {
                    return NotFound();
                }
                return View(message);
            }
            else
            {
                return RedirectToAction(nameof(LogInOffer));
            }
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,Description")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await messageRepo.UpdateAsync(message);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            return View(message);
        }

        // GET: Message/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (UserState.IsLoggedIn && UserState.Role == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var message = await messageRepo.GetAsync(id);

                if (message == null)
                {
                    return NotFound();
                }

                return View(message);
            }
            else
            {
                return RedirectToAction(nameof(LogInOffer));
            }
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await messageRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return messageRepo.GetAsync(id) != null;
        }

        public ActionResult MsgSent()
        {
            return View();
        }

        public ActionResult LogInOffer()
        {
            return View();
        }
    }
}
