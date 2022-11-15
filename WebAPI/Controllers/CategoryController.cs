using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [Controller]
  public class CategoryController : ControllerBase
  { 
    ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet("getallcategories")]
    public IActionResult GetAllCategories()
    {
      var result = _categoryService.GetAll();
      if(result.IsSuccess)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    
    [HttpPost("addcategory")]
    public IActionResult AddCategory(Category category)
    {
      var result = _categoryService.Add(category);
      if(result.IsSuccess)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getcategorybyid")]
    public IActionResult GetCategoryById(int categoryId)
    {
      var result = _categoryService.GetById(categoryId);
      if(result.IsSuccess)
      {
        return Ok(result);
      }
      return BadRequest(result);

    }
  }

}
