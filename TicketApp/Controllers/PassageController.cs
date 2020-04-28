using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Service.PassageService;
using TicketApp.Service.PassageService.Abstractions;
using TicketApp.Service.PassageService.Abstractions.Models;
using TicketApp.Services.PassageService.Models;

namespace TicketApp.Controllers
{
    [Route("/Passages")]
    [ApiController]
    public class PassageController : ControllerBase
    {
        private readonly IPassageService _passageService;
        public PassageController(IPassageService passageService)
        {
            _passageService = passageService;
        }
        
        [HttpGet]
        public ActionResult<List<PassageShortModel>> GetPassages([FromQuery]GetAllPassagesParameters parameters)
        {
            return _passageService.GetAllPassages(parameters);
        }
        
        [HttpGet("{id}")]
        public ActionResult<PassageModel> GetPassages([FromRoute]Guid id)
        {
            return _passageService.GetPassage(id);
        }
        
        [HttpPost]
        public ActionResult<Guid> CreatePassage([FromBody]PassageInfo passage)
        {
            return _passageService.CreatePassage(passage);
        }
        
        [HttpDelete]
        public void DeletePassage([FromBody]PassageRemoveInfo passageRemoveInfo)
        {
            _passageService.DeletePassage(passageRemoveInfo);
        }
        
        [HttpPut("{passageId}")]
        public void UpdatePassage([FromBody]PassageInfo passage, [FromRoute]Guid passageId)
        {
            _passageService.UpdatePassage(passageId, passage);
        }
    }
}
