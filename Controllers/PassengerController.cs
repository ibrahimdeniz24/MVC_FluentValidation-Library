using Mapster;
using Microsoft.AspNetCore.Mvc;
using MVC_FluentValidation.Entites;
using MVC_FluentValidation.Models;

namespace MVC_FluentValidation.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult Index()
        {
            if (DataBase.passengers.Count <= 0)
            {
                Passenger passenger = new Passenger()
                {
                    Gender = Gender.Male,
                    FirstName = "Ahmet",
                    LastName = "Cunda",
                    TicketNumber = 101
                };

                Passenger passenger2 = new Passenger()
                {
                    Gender = Gender.Male,
                    FirstName = "Mehmet",
                    LastName = "Aksoy",
                    TicketNumber = 102
                };

                DataBase.passengers.Add(passenger);
                DataBase.passengers.Add(passenger2);
            }
            return View(DataBase.passengers.Adapt<List<PassengerListVM>>());

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PassengerCreateVM createVM)
        {
            if(!ModelState.IsValid)
            {
                return View(createVM);
            }

            DataBase.passengers.Add(createVM.Adapt<Passenger>());

            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var updateModel = DataBase.passengers.FirstOrDefault(x => x.Id == id);

            if(updateModel != null)
            {
                return View();
            }

            return View(updateModel);
        }

        [HttpPost]
        public IActionResult Update(PassengerUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var updateModel = DataBase.passengers.FirstOrDefault(x => x.Id == model.Id);
                if (updateModel == null)
                {
                    return View();
                }

                // Verileri güncelle
                updateModel.FirstName = model.FirstName;
                updateModel.LastName = model.LastName;
                updateModel.TicketNumber = Convert.ToInt32(model.TicketNumber);

                return RedirectToAction("Index");
            }

            return View(model);


        }

        public IActionResult Delete (Guid id)
        {
            var deleted = DataBase.passengers.FirstOrDefault(x => x.Id == id);
            if (deleted != null)
            {
                DataBase.passengers.Remove(deleted);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
