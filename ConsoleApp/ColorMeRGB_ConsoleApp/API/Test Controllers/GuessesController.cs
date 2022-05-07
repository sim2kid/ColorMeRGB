using Microsoft.AspNetCore.Mvc;
using Services.Data_Access_Layers;
using Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Test_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuessesController : ControllerBase
    {
        GuessesDataAccessLayer dataService = new GuessesDataAccessLayer();

        // GET: api/<GuessesController>
        [HttpGet]
        [Route("get-all")]
        public IEnumerable<GuessRecordModel> Get()
        {
            return dataService.GuessesGetAll();
        }

        // GET api/<GuessesController>/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public IEnumerable<GuessRecordModel> GetId(Guid id)
        {
            return dataService.GuessesGetById(id);
        }

        // GET api/<GuessesController>/5
        [HttpGet]
        [Route("get-by-game-id/{gameId}")]
        public IEnumerable<GuessRecordModel> GetGameId(Guid id)
        {
            return dataService.GuessessGetByGameId(id);
        }

        // POST api/<GuessesController>
        [HttpPost]
        [Route("insert-records")]
        public Guid Post([FromBody] GuessRecordModel model)
        {
            return dataService.GuessesInsertRecords(model);
        }

        // PUT api/<GuessController>/5
        [HttpPut]
        [Route("update-by-id/{id}")]
        public string Put(Guid id, [FromBody] GuessRecordModel model)
        {
            return dataService.GuessesUpdateRecordById(id, model);
        }

        // DELETE api/<GuessesController>/5
        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public string Delete(Guid id)
        {
            return dataService.GuessesDeleteByID(id);
        }
    }
}
