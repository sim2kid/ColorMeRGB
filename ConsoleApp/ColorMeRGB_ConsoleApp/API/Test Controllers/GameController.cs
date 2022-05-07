using Microsoft.AspNetCore.Mvc;
using Services.Data_Access_Layers;
using Services.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Test_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private GamesDataAccessLayer dataService = new GamesDataAccessLayer();

        // GET: api/<GameController>
        [HttpGet]
        [Route("get-all")]
        public IEnumerable<GameRecordModel> Get()
        {
            return dataService.GamesGetAll();
        }

        // GET api/<GameController>/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public IEnumerable<GameRecordModel> GetId(Guid id)
        {
            return dataService.GamesGetById(id);
        }

        // GET api/<GameController>/5
        [HttpGet]
        [Route("get-by-user-id/{userId}")]
        public IEnumerable<GameRecordModel> GetUserId(Guid userId)
        {
            return dataService.GamesGetByUserId(userId);
        }

        // POST api/<GameController>
        [HttpPost]
        [Route("insert-records")]
        public Guid Post([FromBody] GameRecordModel model)
        {
           return dataService.GamesInsertRecords(model);
        }

        // PUT api/<GamesController>/5
        [HttpPut]
        [Route("update-by-id/{id}")]
        public string Put(Guid id, [FromBody] GameRecordModel model)
        {
            return dataService.GamesUpdateRecordById(id, model);
        }

        // DELETE api/<GameController>/5
        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public string Delete(Guid id)
        {
            return dataService.GamesDeleteByID(id);
        }
    }
}
