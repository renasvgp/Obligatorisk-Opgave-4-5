using Microsoft.AspNetCore.Mvc;
using obl1;
using opgave4.repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace opgave4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarRepository _carRepository;

        public CarsController(CarRepository carRepository)
        {
            _carRepository = carRepository;


        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {

            List<Car> result = _carRepository.getAll();


            if (result.Count < 1)
            {

                return NoContent();
            }

            return Ok(result);




        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<Car?> Get(int id)
        {

            Car? foundCar = _carRepository.GetById(id);

            if (foundCar == null)
            {

                return NotFound();


            }

            return Ok(foundCar);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newcar)

        {
            try
            {

                Car createnewcar = _carRepository.Add(newcar);
                return Created($"api/cars/{createnewcar.Id}", createnewcar);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }



        }

        // PUT api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public ActionResult<Car> put(int id, [FromBody] Car newcar)
        {
            try
            {
                Car? updatecars = _carRepository.Update(id, newcar);
                if (updatecars == null)

                {
                    return NotFound();

                }
                return Ok(updatecars);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE api/<CarsController>/5

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? Deletepokemon = _carRepository.Delete(id);
            if (Deletepokemon == null)
            {

                return NotFound();
            }
            return NoContent();
        }

    }
}
