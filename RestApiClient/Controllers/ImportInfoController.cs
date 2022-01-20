using RestApiClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Common.Extentions;
using ApiNews.Api;
using RestSharp;

namespace RestApiClient.Controllers
{
    [Authorize]
    public class ImportInfoController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var info = Import();
            return View(info);
        }


        private Info Import()
        {
            

            var api = new InfoApi();
            var entity = api.InfoGet();
            
            var info = new Info()
            {
                Version = entity.Version,
                
            };
            ApplayImport(entity, info);
            return info;
        }

        private Info ApplayImport(ApiNews.Model.Info entity, Info info)
        {
            var db = new KinoAfishaContext();

            foreach (var infoDto in entity.NewsSites)
            {

                info.NewsSites = entity.NewsSites;
            }
            db.Infos.RemoveRange(db.Infos);
            db.Infos.Add(info);
            db.SaveChanges();

            


            return info;
        }

    }
}