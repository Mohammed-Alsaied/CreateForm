

using AutoMapper;
using DataContext;
using Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using NToastNotify;

namespace Create_Form.Controllers
{
    public class PersonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        protected readonly IValidator<PersonViewModel> _validator;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonsController> _logger;
        public PersonsController(ApplicationDbContext context, IToastNotification toastNotification, IValidator<PersonViewModel> validator, IMapper mapper, ILogger<PersonsController> logger)
        {
            _context = context;
            _toastNotification = toastNotification;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _context.Persons.ToListAsync();
            return View(items);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new PersonViewModel
            {
            };
            return View("PersonForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View("PersonForm", model);
            }
            var person = _mapper.Map<Person>(model);

            _context.Persons.Add(person);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Person Created Successfully");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
                return NotFound();
            var personByIdData = _mapper.Map<PersonViewModel>(person);

            return View("PersonForm", personByIdData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View("PersonForm", model);
            }

            var person = await _context.Persons.FindAsync(model.Id);

            if (person == null)
                return NotFound();
            _mapper.Map(model, person);
            _context.Persons.Update(person);
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Person has been modified successfully");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
                return NotFound();

            _context.Persons.Remove(person);
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Person Deleted successfully");

            return Ok();
        }
    }
}
