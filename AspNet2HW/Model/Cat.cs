
namespace AspNet2HW.Model
{
    public class Cat : Animal
    {

        public Cat() 
        {
            animalType = AnimalType.Cat;            
        }

        public override string MakeSound()
        {
            return Sound;
        }

        public override string ShowName()
        {
            return Name;
        }
    }
}
