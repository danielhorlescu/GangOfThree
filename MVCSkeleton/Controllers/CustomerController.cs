using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public ViewResult GetCustomers()
        {
            return View(new CustomersModel {CustomerList = mapper.Map(service.GetCustomers(), new List<CustomerModel>())});
        }

        public ActionResult Create_Customer([DataSourceRequest] DataSourceRequest request, CustomerModel customer)
        {
            if (customer != null && ModelState.IsValid)
            {
                customer.Id = service.SaveCustomer(mapper.Map(customer, new CustomerDTO()));
            }
            return Json(new[] {customer}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Delete_Customer([DataSourceRequest] DataSourceRequest request, CustomerModel customer)
        {
            if (customer != null)
            {
                service.DeleteCustomer(customer.Id);
            }
            return Json(ModelState.ToDataSourceResult());
        }


        public ActionResult Update_Customer([DataSourceRequest] DataSourceRequest request, CustomerModel customer)
        {
            if (customer != null && ModelState.IsValid)
            {
                service.UpdateCustomer(mapper.Map(customer, new CustomerDTO()));
            }
            return Json(ModelState.ToDataSourceResult());
        }
    }
}