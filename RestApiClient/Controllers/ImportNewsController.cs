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
    public class ImportNewsController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var newslogs = Import();

            return View("ImportLog", newslogs);
        }


        private ImportLog Import()
        {
            var startTime = DateTime.Now;

            var api = new ArticlesApi();
            var newslogs = new List<ImportItemLog>();
            
            //while (true)
            //{
            //    try
            //    {
            var entity = api.ArticlesGet();
            ApplayImport(entity, newslogs);
            //        page++;
            //    }
            //    catch
            //    {
            //        break;
            //    }              
            //}


            var successCount = newslogs.Count(x => x.Type == ImportItemLogType.Success);
            var failedCount = newslogs.Count(x => x.Type == ImportItemLogType.Error);
            var finishTime = DateTime.Now;

            var result = new ImportLog()
            {
                StartImport = startTime,
                EndImport = finishTime,
                SuccessCount = successCount,
                FailedCount = failedCount,
                ImportLogs = newslogs
            };

            return result;
        }

        private List<ImportItemLog> ApplayImport(ApiNews.Model.Articles entity, List<ImportItemLog> newslogs)
        {
            var db = new KinoAfishaContext();

            db.News.RemoveRange(db.News);

            foreach (var newsDto in entity)
            {

                var news = new News()
                {
                    Title = newsDto.Title,
                    Featured = newsDto.Featured,
                    Url = newsDto.Url,
                    ImageUrl = newsDto.ImageUrl,
                    NewsSite = newsDto.NewsSite,
                    PublishedAt = newsDto.PublishedAt,
                    Summary = newsDto.Summary
                };
                db.News.Add(news);
                db.SaveChanges();
                newslogs.Add(new ImportItemLog() { Message = $"Add news {news.Title}", Type = ImportItemLogType.Success });
            }


            return newslogs;
        }

    }
}