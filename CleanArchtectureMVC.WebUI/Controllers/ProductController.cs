using Microsoft.AspNetCore.Mvc;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchtectureMVC.WebUI.Controllers;

public class ProductController : Controller
{

    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<ProductDTO> products = await _productService.GetAllAsync();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0) return NotFound();

        ProductDTO? productDTO = await _productService.GetByIdAsync(id);

        if (productDTO == null) return NotFound();

        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryList = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.CreateAsync(productDTO);
            return RedirectToAction("Index");
        }

        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (id <= 0) return NotFound();

        ProductDTO? productDTO = await _productService.GetByIdAsync(id);

        if (productDTO == null) return NotFound();

        ViewBag.CategoryList = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", productDTO.CategoryId);

        return View(productDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.UpdateAsync(productDTO);
            return RedirectToAction("Index");
        }

        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return NotFound();

        ProductDTO? productDTO = await _productService.GetByIdAsync(id);

        if (productDTO == null) return NotFound();

        return View(productDTO);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id <= 0) return NotFound();

        await _productService.RemoveAsync(id);
        return RedirectToAction("Index");
    }
}
