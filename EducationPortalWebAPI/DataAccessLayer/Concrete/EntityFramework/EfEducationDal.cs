using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfEducationDal : IEducationDal
    {
        private SqlDbContext _context;
        public EfEducationDal(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<List<Education>> GetAllEducation()
        {
            try
            {
                List<Education> educations = new List<Education>();
                educations =await _context.Education.Include(e=>e.Sources).ToListAsync();
                return educations;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Task<int> AddEducation(EducationDto educationDto)
        {
            try
            {
                Education education = new Education();
                education.EducationName = educationDto.EducationName;
                education.Description = educationDto.Description;
                education.CategoryID = educationDto.CategoryID;
                education.TrainerID = educationDto.TrainerID;
                education.Quota = educationDto.Quota;
                education.Duration = educationDto.Duration;
                education.Price = educationDto.Price;
                education.Currency = educationDto.Currency;
                _context.Education.Add(education);
                _context.SaveChanges();
                return Task.FromResult(education.ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteEducation(int id)
        {
            try
            {
                var education = _context.Education.Where(e => e.ID == id).FirstOrDefault();
                if (education != null)
                {
                    education.IsDeleted = true;
                    _context.Education.Update(education);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }
                else
                    return Task.FromResult(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> UpdateEducation(EducationDto educationDto, int id)
        {
            try
            {
                var education = _context.Education.Where(e => e.ID == id).FirstOrDefault();
                if (education == null)
                    return Task.FromResult(false);
                else
                {
                    education.EducationName = educationDto.EducationName;
                    education.Description = educationDto.Description;
                    education.CategoryID = educationDto.CategoryID;
                    education.TrainerID = educationDto.TrainerID;
                    education.Quota = educationDto.Quota;
                    education.Duration = educationDto.Duration;
                    education.Price = educationDto.Price;
                    education.Currency = educationDto.Currency;
                    _context.Education.Update(education);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Education> GetEducationById(int id)
        {
            try
            {
                var education = _context.Education.Where(e => e.ID == id).FirstOrDefault();
                return Task.FromResult(education);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
