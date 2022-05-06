using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace APIFILMES.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {

        [HttpPost]
        public Models.TbFilme Salvar(Models.TbFilme filme)
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            context.Add(filme);
            context.SaveChanges();

            return filme;
        }

        [HttpGet]
        public List<Models.TbFilme> Listar()
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            List<Models.TbFilme> filmes = context.TbFilmes.ToList();

            return filmes;
        }

        [HttpGet("consultar")]
        public List<Models.TbFilme> ConsultarPorGenero(string genero)
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            List<Models.TbFilme> filmes = context.TbFilmes.Where(x => x.DsGenero == genero)
                                                            .ToList();

            return filmes;
        }

        [HttpPut]
        public Models.TbFilme Alterar(Models.TbFilme filme) 
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            context.TbFilmes.Update(filme);
            context.SaveChanges();

            return filme;
        }

        [HttpDelete]
        public void Delete(Models.TbFilme filme)
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            context.TbFilmes.Remove(filme);
        }


    }
}
