using System;
using System.Collections.Generic;
using csharp_gregslist.Models;
using csharp_gregslist.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_gregslist.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;
        public CarsController(CarsService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            try
            {
                return Ok(_cs.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> Get(int carId)
        {
            try
            {
                Car foundCar = _cs.Get(carId);
                return Ok(foundCar);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                return Ok(_cs.Create(newCar));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{carId}")]
        public ActionResult<Car> Edit([FromBody] Car updates, int carId)
        {
            try
            {
                updates.Id = carId;
                Car updatedCar = _cs.Edit(updates);
                return Ok(updatedCar);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("({carId})")]
        public ActionResult<Car> Delete(int carId)
        {
            try
            {
                _cs.Delete(carId);
                return Ok("Deleted");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}