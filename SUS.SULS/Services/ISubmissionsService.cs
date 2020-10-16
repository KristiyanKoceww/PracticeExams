namespace SUS.SULS
{
    public interface ISubmissionsService
    {
        void Create(string userdId, string code,string problemId);
        void Delete(string id);
    }
}