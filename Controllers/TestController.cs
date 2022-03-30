using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingEcomindo.Models;

namespace OnboardingEcomindo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestContext _context;

        public TestController(TestContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all names
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestModel>>> GetTestModel()
        {
            return await _context.TestModels.ToListAsync();
        }

        /// <summary>
        /// Get specific name with ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TestModel>> GetTestModel(long id)
        {
            var TestModel = await _context.TestModels.FindAsync(id);

            if (TestModel == null)
            {
                return NotFound();
            }

            return TestModel;
        }

        /// <summary>
        /// Create a name
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///        "id": 1,
        ///        "name": "Udin"
        ///     }
        ///
        /// </remarks>
        /// <param name="TestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TestModel>> PostTestModel(TestModel TestModel)
        {
            _context.TestModels.Add(TestModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTestModel), new { id = TestModel.Id }, TestModel);
        }
    }
}
