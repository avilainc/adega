using Microsoft.AspNetCore.Mvc;
using Adega.Models;
using Adega.Services;

namespace Adega.Controllers;

public sealed class LandingController : Controller
{
    private readonly ILeadSink _leadSink;

    public LandingController(ILeadSink leadSink)
    {
        _leadSink = leadSink;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Title"] = "PDV + ERP para Adegas e Lojas de Bebidas | Easy4me";
        return View(new LandingLeadInput());
    }

    [HttpPost]
    public async Task<IActionResult> Lead(LandingLeadInput input, CancellationToken ct)
    {
        // Normalize simples
        input.Nome = (input.Nome ?? "").Trim();
        input.Empresa = (input.Empresa ?? "").Trim();
        input.WhatsApp = (input.WhatsApp ?? "").Trim();

        if (!ModelState.IsValid)
        {
            ViewData["Title"] = "PDV + ERP para Adegas e Lojas de Bebidas | Easy4me";
            return View("Index", input);
        }

        await _leadSink.StoreAsync(input, HttpContext, ct);

        // Opcional: TempData para personalizar o obrigado
        TempData["LeadName"] = input.Nome;

        return RedirectToAction(nameof(Thanks));
    }

    [HttpGet]
    public IActionResult Thanks()
    {
        ViewData["Title"] = "Pedido recebido | Easy4me";
        return View();
    }
}
