
namespace AspNet2HW.Model
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public string Sound { get; set; }  
        
        public AnimalType animalType { get; set; }

        public override string ToString()
        {
            return $"Name:{Name} Sound:{Sound} Type:{animalType}";
        }

        public abstract string MakeSound();
        public abstract string ShowName();
    }
}
