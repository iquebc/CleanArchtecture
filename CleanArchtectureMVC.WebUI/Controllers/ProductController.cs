using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CleanArchtectureMVC.WebUI.Models;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Application.DTOs;

namespace CleanArchtectureMVC.WebUI.Controllers;

public class ProductController : Controller
{

    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<ProductDTO> products = await _productService.GetAllAsync();
        return View(products);
    }
}
