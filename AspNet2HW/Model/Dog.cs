
namespace AspNet2HW.Model
{
    public class Dog : Animal
    {
        public Dog() 
        {
            animalType = AnimalType.Dog;
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
