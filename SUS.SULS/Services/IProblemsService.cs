using SUS.SULS.ViewModels.ProblemViewModel;
using System.Collections;
using System.Collections.Generic;

namespace SUS.SULS
{
    public interface IProblemsService
    {
        void Create(string name,ushort points);
        string GetNameById(string id);
        IEnumerable<HomePageProblemViewModel> GetAll();
        ProblemViewModel GetById(string id);

    }
}