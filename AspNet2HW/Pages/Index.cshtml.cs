using AspNet2HW.Abstract;
using AspNet2HW.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AspNet2HW.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IAnimalOutputService _animalOutputService;
        public Animal Animal { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();


        public IndexModel(IAnimalOutputService animalOutputService)
        {
            _animalOutputService = animalOutputService;
        }


        public void OnGet()
        {
            /*Cat garry = new Cat()
            {
                Name = "Arh",
                Sound = "mwwe"
            };

            

            _animalOutputService.SaveToFile(cat, "animals.txt");

            Animals = _animalOutputService.LoadAnimal("animals.txt");*/

            //Animals = _animalOutputService.LoadAnimalFromJson("animal.json");
            //_animalOutputService.SaveToFileJson(garry, "animal.json");


        }
    }
}
