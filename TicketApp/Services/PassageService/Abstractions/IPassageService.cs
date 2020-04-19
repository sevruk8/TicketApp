using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.Service.PassageService.Abstractions.Models;

namespace TicketApp.Service.PassageService.Abstractions
{
    public interface IPassageService
    {
        PassageModel GetPassage(Guid id);

        List<PassageShortModel> GetAllPassages();

        void UpdatePassage(Guid passageId, PassageInfo passage);

        Guid CreatePassage(PassageInfo passage);

        void DeletePassage(Guid id);
    }
}
