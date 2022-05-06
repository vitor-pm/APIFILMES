using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFILMES.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtorController
    {

        [HttpPost]
        public Models.TbAtor Salvar(Models.TbAtor ator)
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            context.Add(ator);
            context.SaveChanges();

            return ator;
        }

        [HttpGet]
        public List<Models.TbAtor> Listar()
        {
            Models.APIFILMESContext context = new Models.APIFILMESContext();

            List<Models.TbAtor> atores = context.TbAtors.ToList();

            return atores;
        }

    }
}
