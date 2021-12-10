using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using GestionFormation.Entity;
using GestionFormation.Models;
using GestionFormation.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace GestionFormation.Controllers
{
    public class FormationController : Controller
    {
        
        private readonly ILogger<FormationController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly INotyfService _notifyService;


        public FormationController(ILogger<FormationController> logger,AppDbContext dbContext,IMapper mapper,INotyfService notifyService)
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

            return View(_dbContext.formations
                .Select(x => _mapper.Map<FormationViewModel>(x))
                .ToList());
        }

        public IActionResult Create()
        {
            return RedirectToAction("Edit");
        }

        public IActionResult Edit(Guid id)
        { 
            Formation _formation = null;

            if (id != Guid.Empty)
                _formation = _dbContext.formations.Find(id);

            _formation ??= new Formation();
            var viewModel = _mapper.Map<FormationViewModel>(_formation);
            viewModel.SliFormateurs = _dbContext.formateurs
                .Select(x => new SelectListItem(x.Nom, x.Id.ToString()))
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(FormationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _logger.LogTrace($"Received model with code {model.code}");

            Formation _formation = null;

            if (model.Id != Guid.Empty)
                _formation = _dbContext.formations.Find(model.Id);

            _formation ??= new Formation();
            _mapper.Map(model, _formation);

            _dbContext.formations.Update(_formation);
            _dbContext.SaveChanges();
            
            _notifyService.Success("sauvegarde reussi");
            return RedirectToAction("Index");
            throw new NotImplementedException(); 
        }

        public IActionResult Delete(Guid Id)
        {
            
            Formation _formation = null;

            if (Id != Guid.Empty)
                _formation = _dbContext.formations.Find(Id);

            if (_formation != null)
            {
                _dbContext.Remove(_formation);
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