using Microsoft.AspNetCore.Mvc;
using Services.Data_Access_Layers;
using Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Test_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersDataAccessLayer dataService = new UsersDataAccessLayer();

        // GET: api/<UsersController>
        [HttpGet]
        [Route("get-all")]
        public IEnumerable<UserRecordModel> Get()
        {
            return dataService.UsersGetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public IEnumerable<UserRecordModel> Get(Guid id)
        {
            return dataService.UsersGetById(id);
        }

        // GET api/<UsersController>/5
        [HttpGet]
        [Route("get-by-user/{userName}")]
        public IEnumerable<UserRecordModel> Get(string userName)
        {
            return dataService.UsersGetByUserName(userName);
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("insert-records")]
        public Guid Post([FromBody] UserRecordModel model)
        {
            return dataService.UsersInsertRecords(model);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [Route("update-by-id/{id}")]
        public string Put(Guid id, [FromBody] UserRecordModel model)
        {
            return dataService.UsersUpdateRecordById(id, model);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public string Delete(Guid id)
        {
            return dataService.UsersDeleteByID(id);
        }
    }
}
