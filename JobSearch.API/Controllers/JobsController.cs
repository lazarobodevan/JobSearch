using JobSearch.API.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase {

        private JobSearchContext _data;
        private int numberofRegistryByPage = 5;
        public JobsController(JobSearchContext data) {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<Job> GetJobs(string word, string cityState, int numberOfPages) {

            if(word == null) {
                word = "";
            }

            if(cityState == null) {
                cityState = "";
            }
          return _data.Jobs.Where(
                a => a.PublicationDate >= DateTime.Now.AddDays(-15) &&
                    a.CityState.ToLower().Contains(cityState.ToLower()) && (
                    a.CityState.ToLower().Contains(cityState.ToLower()) &&
                    a.JobTitle.ToLower().Contains(word.ToLower()) ||
                    a.TecnologyTools.ToLower().Contains(word.ToLower()) ||
                    a.Company.ToLower().Contains(word.ToLower())
                )
              ).Skip(numberofRegistryByPage * (numberOfPages -1))
                .Take(numberofRegistryByPage)
                .ToList<Job>();
        }

        //api/Jobs/1 por exemplo
        [HttpGet("{id}")]
        public IActionResult GetJob(int id) {
            Job jobDb = _data.Jobs.Find(id);

            if(jobDb == null) {
                return NotFound();
            }

            return new JsonResult(jobDb);
        }

        [HttpPost]
        public IActionResult AddJob(Job job) {
            //Validacao
            job.PublicationDate = DateTime.Now;
            _data.Jobs.Add(job);
            _data.SaveChanges();

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }

    }
}
