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

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0) return NotFound();

        CategoryDTO? categoryDTO = await _categoryService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.CreateAsync(categoryDTO);
            return RedirectToAction("Index");
        }

        return View(categoryDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (id <= 0) return NotFound();

        CategoryDTO? categoryDTO = await _categoryService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.UpdateAsync(categoryDTO);
            return RedirectToAction("Index");
        }

        return View(categoryDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return NotFound();

        CategoryDTO? categoryDTO = await _categoryService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id <= 0) return NotFound();

        await _categoryService.RemoveAsync(id);
        return RedirectToAction("Index");
    }
}
