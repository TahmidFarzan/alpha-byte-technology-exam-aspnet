using AlphaByteTechnologyExam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaByteTechnologyExam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DBContext _dbContext = new DBContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> employeeList = _dbContext.tEmployee.OrderBy(e => e.Id).ToList();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.divisionList = _dbContext.tDivision.ToList();
            ViewBag.departmentList = _dbContext.tDepartment.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Details(long id)
        {

            Employee employee = _dbContext.tEmployee.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
           
            Employee employee = _dbContext.tEmployee.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.divisionList = _dbContext.tDivision.ToList();
            ViewBag.departmentList = _dbContext.tDepartment.Where(d => d.DivId == employee.DivId).ToList();

            return View(employee);
        }

        [HttpGet]
        public JsonResult GetDepartmentByDivision(long divID)
        {
            List<Department> departmentList = _dbContext.tDepartment.Where(e => e.DivId == divID).ToList();

            return Json(departmentList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee formRecord) {
            List<string> extraFormValidation = ExtraFormValidation(null, formRecord);
            if (ModelState.IsValid && extraFormValidation.Count() == 0)
            {
                try
                {
                    int sameEmployeeIdCount = _dbContext.tEmployee.Count(e => e.Id == formRecord.Id);
                    if (!(sameEmployeeIdCount == 0))
                    {
                        ModelState.AddModelError("Id", "Same id exit.Id Must be unique.");
                    }
                    Employee newRecord = new Employee();
                    newRecord.IdNumber = formRecord.IdNumber;
                    newRecord.Name = formRecord.Name;
                    newRecord.Dob = formRecord.Dob;
                    newRecord.DeptId = formRecord.DeptId;
                    newRecord.DivId = formRecord.DivId;

                    if (formRecord.ResumeFile != null && formRecord.ResumeFile.ContentLength > 0)
                    {
                        

                        string fileUrl = null;
                        string appDataFolderPath = Server.MapPath("~/Storage");
                        if (!Directory.Exists(appDataFolderPath))
                        {
                            Directory.CreateDirectory(appDataFolderPath);
                        }
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(formRecord.ResumeFile.FileName);
                        string filePath = Path.Combine(appDataFolderPath, uniqueFileName);
                        formRecord.ResumeFile.SaveAs(filePath);
                        fileUrl = VirtualPathUtility.ToAbsolute("~/Storage/" + uniqueFileName);
                        newRecord.FileParh = fileUrl;
                    }
                    _dbContext.tEmployee.Add(newRecord);
                    _dbContext.SaveChanges();
                    TempData["successMessage"] = "Record saved successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the employee data."+ ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Extra validation fail.");
                foreach (var row in extraFormValidation)
                {
                    ModelState.AddModelError("", row);
                }
            }

            ViewBag.DivisionList = _dbContext.tDivision.ToList();
            ViewBag.DepartmentList = _dbContext.tDepartment.ToList();
            return View("Create", formRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(long id, Employee formRecord)
        {
            List<string> extraFormValidation = ExtraFormValidation(id, formRecord);
            if (ModelState.IsValid && extraFormValidation.Count() == 0)
            {
                try
                {
                    Employee employee = _dbContext.tEmployee.FirstOrDefault(e => e.Id == id);

                    if (employee == null)
                    {
                        return HttpNotFound();
                    }
                    employee.IdNumber = formRecord.IdNumber;
                    employee.Name = formRecord.Name;
                    employee.Dob = formRecord.Dob;
                    employee.DeptId = formRecord.DeptId;
                    employee.DivId = formRecord.DivId;

                    if ( (formRecord.ResumeFile != null) && (formRecord.ResumeFile.ContentLength > 0) )
                    {
                        string filePhysicalPath = Server.MapPath(employee.FileParh);
                        if (System.IO.File.Exists(filePhysicalPath))
                        {
                            System.IO.File.Delete(filePhysicalPath);

                        }

                        string fileUrl = null;
                        string appDataFolderPath = Server.MapPath("~/Storage");
                        if (!Directory.Exists(appDataFolderPath))
                        {
                            Directory.CreateDirectory(appDataFolderPath);
                        }
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(formRecord.ResumeFile.FileName);
                        string filePath = Path.Combine(appDataFolderPath, uniqueFileName);
                        formRecord.ResumeFile.SaveAs(filePath);
                        fileUrl = VirtualPathUtility.ToAbsolute("~/Storage/" + uniqueFileName);
                        employee.FileParh = fileUrl;
                    }

                    _dbContext.Entry(employee).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    TempData["successMessage"] = "Record saved successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the employee data." + ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Extra validation fail.");
                foreach (var row in extraFormValidation)
                {
                    ModelState.AddModelError("", row);
                }
            }

            ViewBag.DivisionList = _dbContext.tDivision.ToList();
            ViewBag.DepartmentList = _dbContext.tDepartment.ToList();
            return View("Edit", formRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Employee employee = _dbContext.tEmployee.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            string filePhysicalPath = Server.MapPath(employee.FileParh);
            if (System.IO.File.Exists(filePhysicalPath))
            {
                System.IO.File.Delete(filePhysicalPath);

            }

            _dbContext.tEmployee.Remove(employee);
            _dbContext.SaveChanges();
            TempData["successMessage"] = "Record saved deleted.";
            return RedirectToAction("Index");
        }


        private List<string> ExtraFormValidation(long? id,Employee employee)
        {
            List<string> errors = new List<string>();

            List<Employee> filterEmployees = _dbContext.tEmployee.Where(e => e.IdNumber == employee.IdNumber).ToList();

            if (!(id == null))
            {
                filterEmployees = filterEmployees.Where(e => e.Id != id).ToList();
            }

            filterEmployees = filterEmployees.ToList();

            if (!(filterEmployees.Count() == 0))
            {
                errors.Add("Id Number must be unique.");
            }

            return errors;
        }

    }
}