using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using GestionFormation.Entity;
using GestionFormation.Models;
using GestionFormation.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionFormation.Controllers
{
    public class FormateurController : Controller
    {
       private readonly ILogger<FormateurController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly INotyfService _notifyService;


        public FormateurController(ILogger<FormateurController> logger,AppDbContext dbContext,IMapper mapper,INotyfService notifyService)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _notifyService = notifyService;
        }

        // GET
        public IActionResult Index()
        {
            
            // var viewModels = new List<PcrTestViewModel>();
            //
            // foreach (var pcrTest in _dbContext.PcrTests)
            //     viewModels.Add(_mapper.Map<PcrTestViewModel>(pcrTest));
            //
            // return View(viewModels);

            return View(_dbContext.formateurs
                .Select(x => _mapper.Map<FormateurViewModel>(x))
                .ToList());
        }
        
        public IActionResult Detail(Guid id)
        {
            
            Formateur _formateur = null;

            if (id != Guid.Empty)
                _formateur = _dbContext.formateurs.Find(id);

            _formateur ??= new Formateur();
            var viewModel = _mapper.Map<FormateurViewModel>(_formateur);
            viewModel.SliFormations = _dbContext.formations
                .Where(x=>x.Formateur.Id == id)
                .ToList();

            return View(viewModel);
            return View(_dbContext.formateurs
                .Select(x => _mapper.Map<FormateurViewModel>(x))
                .ToList());
        }

        public IActionResult Create()
        {
            return RedirectToAction("Edit");
        }

        public IActionResult Edit(Guid id)
        { 
            Formateur _formateur = null;

            if (id != Guid.Empty)
                _formateur = _dbContext.formateurs.Find(id);

            _formateur ??= new Formateur();
            var viewModel = _mapper.Map<FormateurViewModel>(_formateur);
            /*viewModel.SliPersons = _dbContext.enseignants
                .Select(x => new SelectListItem(x.FullName, x.Id.ToString()))
                .ToList();*/

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(FormateurViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _logger.LogTrace($"Received model with code {model.code}");

            Formateur _formateur = null;

            if (model.Id != Guid.Empty)
                _formateur = _dbContext.formateurs.Find(model.Id);

            _formateur ??= new Formateur();
            _mapper.Map(model, _formateur);

            _dbContext.formateurs.Update(_formateur);
            _dbContext.SaveChanges();
            
            _notifyService.Success("sauvegarde reussi");
            return RedirectToAction("Index");
            throw new NotImplementedException(); 
        }

        public IActionResult Delete(Guid Id)
        {
            
            Formateur _formateur = null;

            if (Id != Guid.Empty)
                _formateur = _dbContext.formateurs.Find(Id);

            if (_formateur != null)
            {
                _dbContext.Remove(_formateur);
                _dbContext.SaveChanges();
                _notifyService.Success("echec de suppression");
            }
            else
            {
                Console.Write(1);
                _notifyService.Warning("Aucun enseignant trouvé avec cet identifiant");
            }

            return RedirectToAction("Index");
        }
    }
}