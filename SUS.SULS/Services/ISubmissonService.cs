namespace SUS.SULS
{
    public interface ISubmissonService
    {
        void Create(string name, string code,string problemId);
        void Delete(string id);
    }
}