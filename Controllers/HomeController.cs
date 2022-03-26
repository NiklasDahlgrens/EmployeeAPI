using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    public class HomeController : Controller
    {
        string _baseURL = "http://localhost:50733/api/Employee";
        public async Task<IActionResult> Index()
        {
            List<Employee> EmployeesList = new List<Employee>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseURL);
                    HttpResponseMessage response = await client.GetAsync("Employee");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        EmployeesList = JsonConvert.DeserializeObject<List<Employee>>(content);
                    }
                    else
                        ViewBag.Message = "Tyvärr gick något fel: " + response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Tyvärr gick något fel: " + ex.Message;
            }
            return View(EmployeesList);
        }
        
  

    }
}