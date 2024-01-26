﻿using ProjetFinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjetFinal.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArticleController : ApiController
    {
        // GET: api/Article
        public IEnumerable<articles> Get()
        {
            return new DAOArticle().FindAll();

        }

        // GET api/Article/?min=10&max=15
        [HttpGet]
        public IEnumerable<articles> FindByPrixMinMax(int min, int max)
        {
            return new DAOArticle().FindByPrixMinMax(min, max);
        }

      

        // GET: api/Article/5
        public articles Get(int id)
        {
            return new DAOArticle().FindById(id);
        }

        // POST: api/Article
        public void Post([FromBody]articles value)
        {
            new DAOArticle().Create(value);

        }

        // PUT: api/Article
        public void Put([FromBody]articles value)
        {
            new DAOArticle().Update(value);
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
            new DAOArticle().Delete(id);
        }
    }
}