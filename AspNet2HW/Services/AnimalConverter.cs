using AspNet2HW.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AspNet2HW.Services
{
    public class AnimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Animal);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            AnimalType animalType = (AnimalType)Enum.Parse(typeof(AnimalType), jsonObject["animalType"].ToString());

            Animal animal;
            switch (animalType)
            {
                case AnimalType.Cat:
                    animal = new Cat();
                    break;
                case AnimalType.Dog:
                    animal = new Dog();
                    break;
                case AnimalType.Goose:
                    animal = new Goose();
                    break;
                default:
                    throw new JsonSerializationException("Unknown animal type");
            }

            serializer.Populate(jsonObject.CreateReader(), animal);
            return animal;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
