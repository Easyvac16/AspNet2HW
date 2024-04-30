using AspNet2HW.Abstract;
using AspNet2HW.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet2HW.Pages
{
    public class RectangleModel : PageModel
    {
        private readonly IFiguresOutputService _figureOutputService;
        public Figure Figure { get; set; }

        public List<Figure> Figures { get; set; } = new List<Figure>();

        public RectangleModel(IFiguresOutputService figureOutputService)
        {
            _figureOutputService = figureOutputService;
        }
        public void OnGet()
        {
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
