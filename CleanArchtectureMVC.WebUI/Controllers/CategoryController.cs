using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CleanArchtectureMVC.WebUI.Models;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Application.DTOs;

namespace CleanArchtectureMVC.WebUI.Controllers;

public class CategoryController : Controller
{

    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<CategoryDTO> categories = await _categoryService.GetAllAsync();
        return View(categories);
    }
}
