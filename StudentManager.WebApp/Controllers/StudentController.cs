using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using StudentManager.DataAccess.Entities;
using StudentManager.Model.Model.StudentModels;
using StudentManager.Service.Mapper;
using StudentManager.Service.Service;
using Microsoft.AspNetCore.Authorization;

namespace StudentManager.WebApp.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private IClassService _classService;
        private readonly IToastNotification _toastNotification;
        public StudentController(IStudentService studentService, IToastNotification toastNotification, IClassService classService)
        {
            _studentService = studentService;
            _toastNotification = toastNotification;
            _classService = classService;
    }
        public IActionResult Index()
        {
            return View();
        }
        public  async Task<IActionResult> GetStudentPartial(int? studentId = null)
        {
            var model = new Student();
            if (studentId != null)
            {
                ViewBag.Type = "Edit";
                model = await _studentService.GetById(studentId.Value);
                var studentModel = model.MapToModel();
                return PartialView("/Views/Student/Partial/_FormInput.cshtml", studentModel);
            }

            // return View();
            ViewBag.Type = "Create";
            return PartialView("/Views/Student/Partial/_FormInput.cshtml");
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ClassList = await _classService.GetAll();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _studentService.Insert(model.MapToEntity());
                if(student != null)
                {
                    _toastNotification.AddSuccessToastMessage("Tạo mới thành công !");
                    return RedirectToAction("Index");
                }
            }
            _toastNotification.AddErrorToastMessage("Tạo mới thất bại !");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit (int studentId)
        {
            var studentModel = await _studentService.GetById(studentId);
            return View(studentModel.MapToModel());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentService.Update(model.MapToEntity());
                if (student != null)
                {
                    _toastNotification.AddSuccessToastMessage("Cập nhật thành công !");
                    return RedirectToAction("Index");
                }
            }
            _toastNotification.AddErrorToastMessage("Cập nhật thất bại !");
            return RedirectToAction("Index");
        }
        public async Task <IActionResult> Delete(int studentId)
        {         
            var student = await _studentService.GetById(studentId);
            if (student != null)
            {
                if (_studentService.Delete(student))
                {
                    _toastNotification.AddSuccessToastMessage("Xóa bản ghi thành công !");
                    return RedirectToAction("Index");
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Xóa bản ghi thất bại !");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                _toastNotification.AddInfoToastMessage("Bản ghi không tồn tại !");
                return RedirectToAction("Index");
            }           
        }
        [HttpPost]
        public IActionResult GetStudents()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var textSearch = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecord = 0;

            var students = _studentService.GetAllStudent(pageSize, skip, textSearch, sortColumn, sortColumnDirection , out totalRecord);
            var recordsFiltered = students.Count();

            return Ok(new {recordsFiltered = totalRecord, recordsTotal = totalRecord, data = students });
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
