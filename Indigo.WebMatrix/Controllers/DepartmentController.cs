﻿using System.Linq;
using System.Web.Mvc;
using Indigo.Modules.Attributes;
using Indigo.Organization;
using Indigo.Organization.Search;
using Indigo.Web.Mvc;
using Indigo.WebMatrix.Models.DepartmentModels;
using Spring.Objects.Factory.Attributes;

namespace Indigo.WebMatrix.Controllers
{
    [Component("部门管理", 90)]
    public class DepartmentController : BaseController
    {
        [Autowired]
        public IOrganizationService OrganizationService { get; set; }

        [Function("部门列表")]
        public ActionResult Index(DepartmentSearchForm searchForm)
        {
            ViewBag.SearchResult = OrganizationService.Search(searchForm);
            ViewBag.RootDepartments = OrganizationService.GetRootDepartments();

            return View(searchForm);
        }

        [Function("新增部门", "创建新的部门")]
        public ActionResult Add()
        {
            ViewBag.Departments = OrganizationService.GetDepartments(User).Select(d => new SelectListItem {Text = d.Name, Value = d.Id});

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(AddModel model)
        {
            if (ModelState.IsValid)
            {
                Department superDepartment = model.SuperDepartmentId != null ? OrganizationService.GetDepartmentById(model.SuperDepartmentId, User) : null;
                Department department = OrganizationService.AddDepartment(model.Name, model.Description, superDepartment, 0, User);

                TempData["Message"] = string.Format("部门【{0}】新增成功！", department.Name);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public JsonResult IsNameUnique(string name, string id)
        {
            Department department = OrganizationService.GetDepartmentByName(name);

            return Json(department == null || department.Id == id, JsonRequestBehavior.AllowGet);
        }
    }
}