using Database;
using Database.Database.Entities;
using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketApp.Service.PassageService.Abstractions;
using TicketApp.Service.PassageService.Abstractions.Models;

namespace TicketApp.Service.PassageService
{
    public class PassageService : IPassageService
    {
        private readonly DatabaseContext _dbContext;
        public PassageService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Guid CreatePassage(PassageInfo passageInfo)
        {
            if (_dbContext.Users.First(e => e.Id == passageInfo.UserId).Type != UserType.User)
            {
                var passage = new Passage()
                {
                    Id = Guid.NewGuid(),
                    From = passageInfo.From,
                    To = passageInfo.To,
                    MaxTickets = passageInfo.MaxTickets
                };
                _dbContext.Passages.Add(passage);
                _dbContext.SaveChanges();
                return passage.Id;
            }
            throw new Exception("У вас нет прав доступа");
          

        }
        public void DeletePassage(Guid id)
        {

            var passage = _dbContext.Passages.First(e => e.Id == id);
            _dbContext.Passages.Remove(passage);
            _dbContext.SaveChanges();
        }
        public List<PassageShortModel> GetAllPassages()
        {
            var passages = _dbContext.Passages;

            var resultPassages = new List<PassageShortModel>();

            foreach (var dbPassage in passages)
            {
                var passage = new PassageShortModel()
                {
                    From = dbPassage.From,
                    To = dbPassage.To,
                    Id = dbPassage.Id,
                    MaxTickets = dbPassage.MaxTickets
                };
                resultPassages.Add(passage);
            }

            return resultPassages;
        }
        public PassageModel GetPassage(Guid id)
        {
            var dbPassage = _dbContext.Passages.First(e => e.Id == id);

            var passage = new PassageModel()
            {
                From = dbPassage.From,
                To = dbPassage.To,
                Id = dbPassage.Id
            };

            return passage;
        }
        public void UpdatePassage(Guid passageId, PassageInfo passageInfo)
        {
            var passage = _dbContext.Passages.First(e => e.Id == passageId);

            passage.From = passageInfo.From;
            passage.To = passageInfo.To;
            _dbContext.SaveChanges();
        }
    }
}
