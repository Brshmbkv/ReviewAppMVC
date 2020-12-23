using System.Collections.Generic;

namespace WebApp.Model
{
    public interface IQualityRepository
    {
        void Create(Quality quality);
        void Delete(Quality quality);
        IEnumerable<Quality> GetAllQualities();
        IEnumerable<Quality> GetAllQualitiesByUserId(string id);
        Quality GetQualityById(int id);
    }
}