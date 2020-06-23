using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoAniversarios.Models;
using GerenciamentoAniversarios.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAniversarios.Controllers
{
    public class AniversarianteController : Controller
    {
        private AniversarianteRepository AniversarianteRepository { get; set; }

        public AniversarianteController(AniversarianteRepository aniversarianteRepository)
        {
            this.AniversarianteRepository = aniversarianteRepository;
        }

        // GET: AniversarianteController1
        public ActionResult Index()
        {
            //var model = this.AniversarianteRepository.GetAll();
            
            return View(this.AniversarianteRepository.GetAll());
        }

        // GET: AniversarianteController1/Details/5
        public ActionResult Details(int id)
        {
            var model = this.AniversarianteRepository.GetAniversarianteById(id);
            return View(model);
        }

        // GET: AniversarianteController1/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            var model = this.AniversarianteRepository.Search(query);

            return View("index", model);
        }

        // POST: AniversarianteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aniversariante aniversariante)
        {
            try
            {
                this.AniversarianteRepository.Save(aniversariante);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AniversarianteController1/Edit/5
        public ActionResult Edit(int id)
        {
            var model = this.AniversarianteRepository.GetAniversarianteById(id);
            return View(model);
        }

        // POST: AniversarianteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aniversariante model)
        {
            try
            {
                model.Id = id;

                this.AniversarianteRepository.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AniversarianteController1/Delete/5
        public ActionResult Delete(int id)
        {
            var model = this.AniversarianteRepository.GetAniversarianteById(id);
            return View(model);
        }

        // POST: AniversarianteController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Aniversariante model)
        {
            try
            {
                model.Id = id;
                this.AniversarianteRepository.Delete(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AniversarioDoDia()
        {
            DateTime hoje = DateTime.Today;
            var model = this.AniversarianteRepository.GetAll();
            var aniversarianteDia = new List<Aniversariante>();


            foreach (var aniversariante in model)
            {
                if (aniversariante.DataNascimento.Day == hoje.Day && aniversariante.DataNascimento.Month == hoje.Month)
                {
                    aniversarianteDia.Add(aniversariante);
                }
            }

            return View(aniversarianteDia);

        }
    }
}
