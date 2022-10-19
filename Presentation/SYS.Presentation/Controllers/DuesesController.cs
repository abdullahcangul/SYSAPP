using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SYS.Application.DTOs.DuesDtos;
using SYS.Application.DTOs.Home;
using SYS.Application.DTOs.OwnerDtos;
using SYS.Application.Utility;
using SYS.Application.Utility.Result;
using SYS.Domain.Entities;

namespace SYS.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DuesesController:ControllerBase
{
           private readonly IDuesService _duesService;
           private readonly IMapper _mapper;
        
           public DuesesController(IMapper mapper, IDuesService duesService)
           {
              _mapper = mapper;
              _duesService = duesService;
           }
        
           [HttpGet("GetAll")]
           public ActionResult<List<HomeListDto>> GetAllHome()
           {
              var result = _mapper.Map<List<DuesUpdateDto>>(_duesService.GetAll());
              if (result != null)
              {
                 return Ok(result);
              }
              return Ok(Message.EMPTY_GET_ALL_DATA);
           }
           [HttpGet("ById/{{id}}")]
           public async Task<ActionResult<HomeListDto>> GetHomeById(int id)
           {
              var result = _mapper.Map<DuesUpdateDto>(await _duesService.GetByIdAsync(id));
              if (result != null)
              {
                 return Ok(result);
              }
              return Ok(Message.EMPTY_GET_BYID_DATA);
           }
           [HttpPost("Add")]
           public async Task<ActionResult<IDataResult<HomeListDto>>> Post([FromBody]DuesAddDto addDto)
           {
              var addEntity = _mapper.Map<Dues>(addDto);
              var result = await _duesService.AddAsync(addEntity);
             
              if (result!=null)
              {
                 return Ok(_mapper.Map<DuesUpdateDto>(result));
              }
              return BadRequest(Message.ERROR_ADD_DATA);
           }
           
           [HttpPut("Update")]
           public  ActionResult<IDataResult<Boolean>> Put([FromBody] DuesUpdateDto updateDto)
           {
              var updateEntity = _mapper.Map<Dues>(updateDto);
              _duesService.Update(updateEntity);
              
              return Ok();
           }
           [HttpDelete("Delete")]
           public async Task<IActionResult> Delete(int id)
           {
              var entity=await _duesService.GetByIdAsync(id);
              if (entity != null)
              {
                _duesService.Delete(entity);
                return Ok();
              }
              return BadRequest(Message.ERROR_DELETE);
           }
}