using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SYS.Application.DTOs.Home;
using SYS.Application.Utility;
using SYS.Application.Utility.Result;
using SYS.Domain.Entities;

namespace SYS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomesController : ControllerBase
{
   private readonly IHomeService _homeService;
   private readonly IMapper _mapper;

   public HomesController(IMapper mapper, IHomeService homeService)
   {
      _mapper = mapper;
      _homeService = homeService;
   }

   [HttpGet("GetAll")]
   public ActionResult<List<HomeListDto>> GetAllHome()
   {
      var result = _mapper.Map<List<HomeListDto>>(_homeService.GetAll());
      if (result != null)
      {
         return Ok(result);
      }
      return Ok(Message.EMPTY_GET_ALL_DATA);
   }
   [HttpGet("ById/{{id}}")]
   public async Task<ActionResult<HomeListDto>> GetHomeById(int id)
   {
      var result = _mapper.Map<HomeListDto>(await _homeService.GetByIdAsync(id));
      if (result != null)
      {
         return Ok(result);
      }
      return Ok(Message.EMPTY_GET_BYID_DATA);
   }
   [HttpPost("Add")]
   public async Task<ActionResult<IDataResult<HomeListDto>>> Post([FromBody]HomeAddDto addDto)
   {
      var addEntity = _mapper.Map<Home>(addDto);
      var result = await _homeService.AddAsync(addEntity);
     
      if (result!=null)
      {
         return Ok(_mapper.Map<HomeListDto>(result));
      }
      return BadRequest(Message.ERROR_ADD_DATA);
   }
   
   [HttpPut("Update")]
   public  ActionResult<IDataResult<Boolean>> Put([FromBody] HomeUpdateDto updateDto)
   {
      var updateEntity = _mapper.Map<Home>(updateDto);
      _homeService.Update(updateEntity);
      
      return Ok(new SuccessResult());
   }
   [HttpDelete("{id}")]
   public async Task<IActionResult> Delete(int id)
   {
      var home=await _homeService.GetByIdAsync(id);
      if (home != null)
      {
        _homeService.Delete(home);
        return Ok();
      }
      return BadRequest(Message.ERROR_DELETE);
   }
}