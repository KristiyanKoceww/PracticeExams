using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.SULS.ViewModels.ProblemViewModel
{
    public class ProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
