using AutoMapper;
using Database;
using Database.Database.Entities;
using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketApp.Service.PassageService.Abstractions;
using TicketApp.Service.PassageService.Abstractions.Models;
using TicketApp.Services.PassageService.Models;

namespace TicketApp.Service.PassageService
{
    /// <summary>
    /// Класс реализующий интерфейс Рейсов
    /// </summary>
    public class PassageService : IPassageService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public PassageService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
       
        public Guid CreatePassage(PassageInfo passageInfo)
        {
            if (_dbContext.Users.First(e => e.Id == passageInfo.RequestUserId).Type != UserType.User)
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
            else {throw new Exception("У вас нет прав доступа");}
            
            
        }

        public void UpdatePassage(Guid passageId, PassageInfo passageInfo)
        {
            var passage = _dbContext.Passages.First(e => e.Id == passageId);

            passage.From = passageInfo.From;
            passage.To = passageInfo.To;
            passage.MaxTickets = passageInfo.MaxTickets;
            _dbContext.SaveChanges();
        }

        public void DeletePassage(PassageRemoveInfo passageRemoveInfo)
        {
            if (_dbContext.Users.First(e => e.Id == passageRemoveInfo.RequestUserId).Type != UserType.User)
            {
                var passage = _dbContext.Passages.First(e => e.Id == passageRemoveInfo.PassageId);
                _dbContext.Passages.Remove(passage);
                _dbContext.SaveChanges();
            }
            else {throw new Exception("У вас нет прав доступа");}
            
            
        }

        
        public List<PassageShortModel> GetAllPassages()
        {
            var passages = _dbContext.Passages;
            var resultPassages = new List<PassageShortModel>();
            foreach(var passage in passages)
            {
                var passageShortModel = _mapper.Map<PassageShortModel>(passage);
                resultPassages.AddRange(passages.Select(e => _mapper.Map<PassageShortModel>(e)));
            }
            
            return resultPassages;
        }

        
        public PassageModel GetPassage(Guid passageId)
        {
            var passage = _dbContext.Passages.First(e => e.Id == passageId);
            return _mapper.Map<PassageModel>(passage);
        }
    }
}
