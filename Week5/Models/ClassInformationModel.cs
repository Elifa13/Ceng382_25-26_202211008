using System.ComponentModel.DataAnnotations;

namespace Week5.Models
{
    public class ClassInformationModel
    {
        private static int _idCounter = 1;

        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Student count must be at least 1")]
        public int StudentCount { get; set; }

        public string Description { get; set; }

        public ClassInformationModel()
        {
            Id = _idCounter++;
        }
    }
}
