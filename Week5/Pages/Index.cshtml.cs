using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week5.Models;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Week5.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public bool IsEditMode { get; set; }


        public static List<ClassInformationModel> ClassList { get; set; } = new List<ClassInformationModel>();


        [BindProperty]
        public ClassInformationModel NewClass { get; set; } = new ClassInformationModel();

        public List<ClassInformationModel> Classes => ClassList;

        public void OnGet()
        {
        }

        public IActionResult OnPostAdd()
        {
            
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var newItem = new ClassInformationModel
            {
                ClassName = NewClass.ClassName,
                StudentCount = NewClass.StudentCount,
                Description = NewClass.Description

            };

            ClassList.Add(newItem);
            return RedirectToPage();
        }
        public IActionResult OnPostDelete(int id)
        {
            var itemToDelete = ClassList.FirstOrDefault(c=>c.Id == id);
            if(itemToDelete != null)
            {
                ClassList.Remove(itemToDelete);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostEdit(int id)
        {
            var item = ClassList.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                NewClass = new ClassInformationModel
                {
                    Id = item.Id,
                    ClassName = item.ClassName,
                    StudentCount = item.StudentCount,
                    Description = item.Description
                };
                IsEditMode = true;
            }
             return Page();
        }


        public IActionResult OnPostUpdate()
        {
            var existing = ClassList.FirstOrDefault(c=>c.Id == NewClass.Id);
            if(existing != null)
            {
                existing.ClassName = NewClass.ClassName;
                existing.StudentCount = NewClass.StudentCount;
                existing.Description = NewClass.Description;
            }

            return RedirectToPage();
        }
    }
}
