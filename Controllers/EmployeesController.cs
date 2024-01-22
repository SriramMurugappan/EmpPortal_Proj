using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Domain;

namespace WebApplication2.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcDBContext mvcDBContext;//used for communicating with the database

        public EmployeesController(MvcDBContext mvcDBContext) //created via assigned field from mvcDBContext
        {
            this.mvcDBContext = mvcDBContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDBContext.Employees.ToListAsync();
            return View(employees);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //Method is totally Asynchronous (can perform multiple tasks at a time)
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest) //addEmployeeRequest is used as value to call the ef and save the values in the database.
        {
            var employee = new Employee() //creating new object to convert AddEmployeeViewModel to Employee model
            {
                Id = Guid.NewGuid(), //new properties for new objects
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department,
            };
            
            await mvcDBContext.Employees.AddAsync(employee); // used for adding the details inside the database
            await mvcDBContext.SaveChangesAsync(); //used for saving changes in the entity framework
            return RedirectToAction("Index");//once submitted the page will redirect to home index page
            
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var employee = await mvcDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            if(employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                };
                return await Task.Run(()=>View("View", viewModel)); //syntax used for returning as async value, Run this view as task
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDBContext.Employees.FindAsync(model.Id);

            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Email= model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth= model.DateOfBirth;
                employee.Department = model.Department;

                await mvcDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index"); //If the employee is null return to index
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee =  await mvcDBContext.Employees.FindAsync(model.Id);

            if(employee != null)
            {
                mvcDBContext.Employees.Remove(employee);
                await mvcDBContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index"); 
        }
    }
}
