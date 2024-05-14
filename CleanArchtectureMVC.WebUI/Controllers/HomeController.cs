using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CleanArchtectureMVC.WebUI.Models;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Application.DTOs;

namespace CleanArchtectureMVC.WebUI.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
