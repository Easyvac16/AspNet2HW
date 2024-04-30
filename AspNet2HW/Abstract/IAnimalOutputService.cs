using AspNet2HW.Model;
using System;

namespace AspNet2HW.Abstract
{
    public interface IAnimalOutputService
    {
        public void SaveToFile(Animal animal, string filePath);
        public void SaveToFileJson(Animal animal, string filePath);

        public List<Animal> LoadAnimal(string filePath);
        public List<Animal> LoadAnimalFromJson(string filePath);
    }
}
