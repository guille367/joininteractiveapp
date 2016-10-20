using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActorsProject.Models;
using System.Web.Http.Controllers;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace ActorsProject.Controllers
{
    public class ActorsController : ApiController
    {
        HttpResponseMessage htrm;
        List<Actor> actors;

        [HttpGet]
        public IEnumerable<Actor> GetActors()
        {
            return this.getActors();
        }

        [HttpPost]
        public HttpResponseMessage AddActor([FromBody] Actor actor)
        {
            try
            {
                actors = this.getActors();
                actors.Add(actor);
                writeActors(actors);
                htrm = Request.CreateResponse(HttpStatusCode.OK, "Actor agregado");
            }
            catch (Exception ex)
            {
                htrm = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
            return htrm;
        }

        [HttpPut]
        public void EditActor([FromBody]Actor actor)
        {

        }

        [HttpDelete]
        public HttpResponseMessage DeleteActor(int id)
        {
            try
            {
                actors = this.getActors();
                actors.Remove(actors.Find(a => a.id == id));
                writeActors(actors);
                htrm = Request.CreateResponse(HttpStatusCode.OK, "Actor eliminado");
            }
            catch (Exception ex)
            {
                htrm = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return htrm;
        }

        private List<Actor> getActors()
        {
            string sActors;
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/Files/actors.json")))
            {
                sActors = sr.ReadToEnd();
            }
            actors = JsonConvert.DeserializeObject<List<Actor>>(sActors);
            return actors;
        }

        private void writeActors(List<Actor> list)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Files/actors.json")))
            {
                string s = JsonConvert.SerializeObject(list);
                sw.Write(s);
            }
        }
        
    }
}
