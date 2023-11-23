namespace AFZV31_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class AreaController
    {
        IAnnualLogic logic;
        public AreaController(IAreaLogic logic)
        { this.logic = logic; }


        [HttpGet]
        public IEnumerable<Annual> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Annual Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Annual value)
        {
            this.logic.Create(value);
        }


        [HttpPut("{id}")]
        public void Update([FromBody] Annual value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
