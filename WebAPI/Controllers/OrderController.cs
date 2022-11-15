using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
      _orderService = orderService;
    }

    [HttpGet("getallorder")]
    public IActionResult GetAllOrders()
    {
      var result = _orderService.GetAll();
      if(result.IsSuccess)
      {
        return Ok(result); 
      }
      return BadRequest(result);
    }
    [HttpGet("getorderbyid")]
    public IActionResult GetOrderById(int orderId)
    {
      var result = _orderService.GetById(orderId);
      if(result.IsSuccess)
      { 
        return Ok(result);
      }
      return BadRequest(result);


    }
  }
}
