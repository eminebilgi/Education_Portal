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
    public class EfMembersEducation : IMembersEducationDal
    {
        private SqlDbContext _context;
        public EfMembersEducation(SqlDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddEducationStatus(MembersEducationDto dto)
        {
            try
            {
                var education = _context.MembersEducation.Where(e => e.EducationID == dto.EducationID && e.MemberID == dto.MemberID).FirstOrDefault();
                if (education != null)
                {
                    education.TransactionDate = DateTime.Now;
                    education.TransactionType = dto.TransactionType;
                    _context.MembersEducation.Update(education);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<EducationListDto>> GetByMemberID(int memberID)
        {
            try
            {
                List<EducationListDto> educationLists = new List<EducationListDto>();
                var membersEducation = _context.MembersEducation.Where(e => e.MemberID == memberID).ToList();
                foreach (var item in membersEducation)
                {
                    var education = _context.Education.Where(e => e.ID == item.EducationID).FirstOrDefault();
                    if (education != null)
                    {
                        EducationListDto educationListDto = new EducationListDto();
                        educationListDto.EducationID = education.ID;
                        educationListDto.Description = education.Description;
                        educationListDto.Category = _context.Category.Where(c => c.ID == education.CategoryID).Select(c => c.CategoryName).FirstOrDefault();
                        educationListDto.TrainerID = education.TrainerID;
                        var TrainerName = _context.Trainer.Where(t => t.ID == education.TrainerID).Select(t => new Trainer
                        {
                            FirstName = t.FirstName,
                            LastName = t.LastName
                        }).FirstOrDefault();
                        educationListDto.TrainerName = TrainerName.FirstName + ' ' + TrainerName.LastName;
                        educationListDto.TransactionDate = item.TransactionDate;
                        educationListDto.TransactionType = item.TransactionType;
                        educationLists.Add(educationListDto);
                    }
                }
                return Task.FromResult(educationLists);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Education>> GetByTrainerID(int trainerID)
        {
            try
            {
                var trainersEducation = _context.Education.Where(e => e.TrainerID == trainerID).Include(t=>t.MembersEducations).ToList();
                if(trainersEducation.Count > 0)
                {
                    return Task.FromResult(trainersEducation);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Insert(MembersEducationDto dto)
        {
            try
            {
                MembersEducation membersEducation = new MembersEducation();
                membersEducation.EducationID = dto.EducationID;
                membersEducation.MemberID = dto.MemberID;
                membersEducation.TransactionDate = DateTime.Now;
                membersEducation.TransactionType = "Active";
                _context.MembersEducation.Add(membersEducation);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
