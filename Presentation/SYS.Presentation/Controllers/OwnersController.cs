using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SYS.Application.DTOs.Home;
using SYS.Application.DTOs.OwnerDtos;
using SYS.Application.Utility;
using SYS.Application.Utility.Result;
using SYS.Domain.Entities;

namespace SYS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnersController:ControllerBase
{
       private readonly IOwnerService _ownerService;
       private readonly IMapper _mapper;
    
       public OwnersController(IMapper mapper, IOwnerService ownerService)
       {
          _mapper = mapper;
          _ownerService = ownerService;
       }
    
       [HttpGet("GetAll")]
       public ActionResult<List<OwnerUpdateDto>> GetAllHome()
       {
          var result = _mapper.Map<List<OwnerUpdateDto>>(_ownerService.GetAll());
          if (result != null)
          {
             return Ok(result);
          }
          return Ok(Message.EMPTY_GET_ALL_DATA);
       }
       [HttpGet("ById/{{id}}")]
       public async Task<ActionResult<OwnerUpdateDto>> GetHomeById(int id)
       {
          var result = _mapper.Map<OwnerUpdateDto>(await _ownerService.GetByIdAsync(id));
          if (result != null)
          {
             return Ok(result);
          }
          return Ok(Message.EMPTY_GET_BYID_DATA);
       }
       [HttpPost("Add")]
       public async Task<ActionResult<OwnerUpdateDto>> Post([FromBody]OwnerAddDto addDto)
       {
          var addEntity = _mapper.Map<Owner>(addDto);
          var result = await _ownerService.AddAsync(addEntity);
         
          if (result!=null)
          {
             return Ok(_mapper.Map<OwnerUpdateDto>(result));
          }
          return BadRequest(Message.ERROR_ADD_DATA);
       }
       
       [HttpPut("Update")]
       public  ActionResult<IDataResult<Boolean>> Put([FromBody] OwnerUpdateDto updateDto)
       {
          var updateEntity = _mapper.Map<Owner>(updateDto);
          _ownerService.Update(updateEntity);
          
          return Ok();
       }
       [HttpDelete("Delete")]
       public async Task<IActionResult> Delete(int id)
       {
          var entity=await _ownerService.GetByIdAsync(id);
          if (entity != null)
          {
            _ownerService.Delete(entity);
            return Ok();
          }
          return BadRequest(Message.ERROR_DELETE);
       }
}