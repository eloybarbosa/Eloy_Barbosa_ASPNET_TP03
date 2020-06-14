using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eloy_Barbosa_ASPNET_TP03.Models;
using Microsoft.AspNetCore.Mvc;


namespace Eloy_Barbosa_ASPNET_TP03.Controllers
{
    public class AniversariantesController : Controller
    {
        public static List<Aniversariante> aniversariantes { get; set; }  = new List<Aniversariante>();

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Exibir(string? message)
        {
            ViewBag.Message = message;
            //List<Aniversariante> aniversariantes = new List<Aniversariante>();
            return View(aniversariantes);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Exclusao([FromQuery] Guid id)
        {
            var aniversariante = aniversariantes.Where(x => x.Id == id).FirstOrDefault();

            return View(aniversariante);
        }

        public IActionResult Edicao([FromQuery] Guid id)
        {
            var aniversariante = aniversariantes.Where(x => x.Id == id).FirstOrDefault();

            return View(aniversariante);
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Aniversariante model)
        {
            model.Id = Guid.NewGuid();

            aniversariantes.Add(model);
            return RedirectToAction("Exibir", "Aniversariantes", new {message = "Aniversariante cadastrado com sucesso"});
        }

        [HttpPost]
        public IActionResult Editar(Guid id, Aniversariante model)
        {

            var aniversarianteEdit = aniversariantes.Where(x => x.Id == id).FirstOrDefault();

            aniversarianteEdit.Nome = model.Nome;
            aniversarianteEdit.Sobrenome = model.Sobrenome;
            aniversarianteEdit.Nascimento = model.Nascimento;

            aniversariantes.Remove(aniversarianteEdit);
            aniversariantes.Add(aniversarianteEdit);

            return RedirectToAction("Exibir", "Aniversariantes", new { message = "Aniversariante editado com sucesso" });
        }

        [HttpPost]
        public IActionResult Excluir(Guid id)
        {

            var aniversariante = aniversariantes.Where(x => x.Id == id).FirstOrDefault();

           
            aniversariantes.Remove(aniversariante);
           
            return RedirectToAction("Exibir", "Aniversariantes", new { message = "Aniversariante apagado com sucesso" });
        }

    }
}