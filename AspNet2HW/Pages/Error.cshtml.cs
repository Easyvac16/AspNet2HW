using AspNet2HW.Abstract;
using AspNet2HW.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace AspNet2HW.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        private readonly IFiguresOutputService _figureOutputService;
        public Figure Figure { get; set; }

        public List<Figure> Figures { get; set; } = new List<Figure>();

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }
        
        public ErrorModel(IFiguresOutputService figureOutputService)
        {
            _figureOutputService = figureOutputService;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            Rectangle garry = new Rectangle()
            {
                Width = 15,
                Height = 10
            };



            //_figureOutputService.SaveToFile(garry, "figure.txt");

            Figures = _figureOutputService.LoadFigure("figure.txt");

            Figures = _figureOutputService.LoadFigureFromJson("figure.json");
            //_figureOutputService.SaveToFileJson(garry, "figure.json");
        }


    }

}
