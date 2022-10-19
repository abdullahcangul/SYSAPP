using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SYS.Application.DTOs.DeptDtos;
using SYS.Application.DTOs.DuesDtos;
using SYS.Application.DTOs.Home;
using SYS.Application.Utility;
using SYS.Application.Utility.Result;
using SYS.Domain.Entities;

namespace SYS.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeptsController:ControllerBase
{
           private readonly IDeptService _deptService;
           private readonly IMapper _mapper;
        
           public DeptsController(IMapper mapper, IDeptService deptService)
           {
              _mapper = mapper;
              _deptService = deptService;
           }
        
           [HttpGet("GetAll")]
           public ActionResult<List<DeptUpdateDto>> GetAllHome()
           {
              var result = _mapper.Map<List<DeptUpdateDto>>(_deptService.GetAll());
              if (result != null)
              {
                 return Ok(result);
              }
              return Ok(Message.EMPTY_GET_ALL_DATA);
           }
           [HttpGet("ById/{{id}}")]
           public async Task<ActionResult<DeptUpdateDto>> GetHomeById(int id)
           {
              var result = _mapper.Map<DeptUpdateDto>(await _deptService.GetByIdAsync(id));
              if (result != null)
              {
                 return Ok(result);
              }
              return Ok(Message.EMPTY_GET_BYID_DATA);
           }
           [HttpPost("Add")]
           public async Task<ActionResult<IDataResult<DeptUpdateDto>>> Post([FromBody]DeptAddDto addDto)
           {
              var addEntity = _mapper.Map<Dept>(addDto);
              var result = await _deptService.AddAsync(addEntity);
             
              if (result!=null)
              {
                 return Ok(_mapper.Map<DuesUpdateDto>(result));
              }
              return BadRequest(Message.ERROR_ADD_DATA);
           }
           
           [HttpPut("Update")]
           public  ActionResult<IDataResult<Boolean>> Put([FromBody] DeptUpdateDto updateDto)
           {
              var updateEntity = _mapper.Map<Dept>(updateDto);
              _deptService.Update(updateEntity);
              
              return Ok();
           }
           [HttpDelete("Delete")]
           public async Task<IActionResult> Delete(int id)
           {
              var entity=await _deptService.GetByIdAsync(id);
              if (entity != null)
              {
                _deptService.Delete(entity);
                return Ok();
              }
              return BadRequest(Message.ERROR_DELETE);
           }
}