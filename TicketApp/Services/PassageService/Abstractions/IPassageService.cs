using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.Service.PassageService.Abstractions.Models;
using TicketApp.Services.PassageService.Models;

namespace TicketApp.Service.PassageService.Abstractions
{
    public interface IPassageService
    {
        PassageModel GetPassage(Guid Id);

        List<PassageShortModel> GetAllPassages();

        void UpdatePassage(Guid Id, PassageInfo passage);

        Guid CreatePassage(PassageInfo passageInfo);

        void DeletePassage(PassageRemoveInfo passageRemoveInfo);
    }
}
