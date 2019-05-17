using System.Collections.Generic;

namespace WebAPIForCURD.Models
{
    /// <summary>
    /// Grade视图模型
    /// </summary>
    public class GradeViewModel
    {
        public int GradeID { get; set; }

        public string GradeName { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}