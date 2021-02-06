using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Laboratorio0_MVC.Models.Data;

namespace Laboratorio0_MVC.Controllers
{
    public class ClientsController : Controller
    {


        // GET: ClientController1

        public ActionResult Index()
        {

            return View(Singleton.Instance.ClientsList);
        }

        // GET: ClientController1/Details/5
        public ActionResult Details(int id)
        {
            var ViewClient = Singleton.Instance.ClientsList.Find(x => x.Id == id);
            return View(ViewClient);
            
        }

        // GET: ClientController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                
                var newClient = new Models.Client
                {
                    Id = Convert.ToInt32(collection["Id"]),
                    Name = collection["Name"],
                    Surname = collection["Surname"],
           
                    Phone = Convert.ToInt32(collection["Phone"]),
                    Description = collection["Description"],

                };
                Singleton.Instance.ClientsList.Add(newClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController1/Edit/5
        public ActionResult Edit(int id)
        {
            var editClient = Singleton.Instance.ClientsList.Find(x => x.Id == id);
            return View(editClient);
        }

        // POST: ClientController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

    

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController1/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteClient = Singleton.Instance.ClientsList.Find(x => x.Id == id);
            return View(deleteClient);
        }

        // POST: ClientController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(string id, IFormCollection collection)
        {
            try
            {
                var order = Singleton.Instance.ClientsList;

                Models.Client aux;

                for (int j = 0; j <= order.Count; j++)
                {
                    for (int i = 0; i <= order.Count - 2; i++)
                    {
                        if ((order[i].Name.CompareTo(order[i + 1].Name)) > 0)
                        {
                            aux = order[i + 1];
                            order[i + 1] = order[i];
                            order[i] = aux;
                        }
                    }
                }

            
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
