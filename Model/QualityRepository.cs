using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database.Context;

namespace WebApp.Model
{
    public class QualityRepository : IQualityRepository
    {
        private readonly MainContex _context;

        public QualityRepository(MainContex context)
        {
            _context = context;
        }

        public IEnumerable<Quality> GetAllQualities()
        {
            return _context.Qualities.ToList();
        }

        public IEnumerable<Quality> GetAllQualitiesByUserId(string id)
        {
            return _context.Qualities.Where(q => q.Person.Id == id).ToList();
        }

        public Quality GetQualityById(int id)
        {
            return _context.Qualities.Where(q => q.Id == id).First();
        }

        public void Create(Quality quality)
        {
            _context.Qualities.Add(quality);
            _context.SaveChanges();
        }

        public void Delete(Quality quality)
        {
            _context.Qualities.Remove(quality);
            _context.SaveChanges();
        }
    }
}
