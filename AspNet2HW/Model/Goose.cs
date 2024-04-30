
namespace AspNet2HW.Model
{
    public class Goose : Animal
    {
        public Goose() 
        {
            animalType = AnimalType.Goose;
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
