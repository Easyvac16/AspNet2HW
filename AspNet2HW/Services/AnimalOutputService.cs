using AspNet2HW.Abstract;
using AspNet2HW.Model;
using Newtonsoft.Json;
using System;
using System.Xml.Linq;

namespace AspNet2HW.Services
{
    public class AnimalOutputService : IAnimalOutputService
    {
        public void SaveToFile(Animal animal, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(animal.ToString());
                sw.WriteLine("*************");
            }
        }

        public List<Animal> LoadAnimal(string filePath)
        {
            List<Animal> animals = new List<Animal>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (!line.Any(c => c == '*' || c == '?' || c == '%' || c == '$' || c == '#' || c == '@' || c == '!'))
                {
                    string[] parts = line.Split(' ');

                    string name = "", sound = "", type = "";

                    for (int i = 0; i < parts.Length; i++)
                    {
                        string partValue = parts[i].Trim().Split(':')[1].Trim();

                        switch (parts[i].Split(':')[0].Trim())
                        {
                            case "Name":
                                name = partValue;
                                break;

                            case "Sound":
                                sound = partValue;
                                break;
                            case "Type":
                                type = partValue;
                                break;

                        }
                    }

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(sound))
                    {
                        switch (type)
                        {
                            case "Cat":
                                animals.Add(new Cat()
                                { 
                                    Name = name,
                                    Sound = sound,
                                    animalType = (AnimalType)Enum.Parse(typeof(AnimalType), type, true)
                                });

                                break;
                            case "Dog":
                                animals.Add(new Dog()
                                {
                                    Name = name,
                                    Sound = sound,
                                    animalType = (AnimalType)Enum.Parse(typeof(AnimalType), type, true)
                                });
                                break;
                            case "Goose":
                                animals.Add(new Goose()
                                {
                                    Name = name,
                                    Sound = sound,
                                    animalType = (AnimalType)Enum.Parse(typeof(AnimalType), type, true)
                                });
                                break;
                        }
                    }
                }
            }
            return animals;
        }
        public List<Animal> LoadAnimalFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Animal>>(jsonString, new AnimalConverter());
        }
        public void SaveToFileJson(Animal animal, string filePath)
        {
            List<Animal> animals = new List<Animal>();

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    animals = JsonConvert.DeserializeObject<List<Animal>>(jsonString, new AnimalConverter());
                }
            }

            animals.Add(animal);

            string updatedJson = JsonConvert.SerializeObject(animals, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }

}
