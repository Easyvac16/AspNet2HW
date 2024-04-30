using AspNet2HW.Abstract;
using AspNet2HW.Model;
using Newtonsoft.Json;

namespace AspNet2HW.Services
{
    public class FigureOutputService : IFiguresOutputService
    {

        public void SaveToFile(Figure figure, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(figure.ToString());
                sw.WriteLine("*************");
            }
        }

        public List<Figure> LoadFigure(string filePath)
        {
            List<Figure> figures = new List<Figure>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (!line.Any(c => c == '*' || c == '?' || c == '%' || c == '$' || c == '#' || c == '@' || c == '!'))
                {
                    string[] parts = line.Split(' ');

                    double widht = 0, height = 0;

                    for (int i = 0; i < parts.Length; i++)
                    {
                        string partValue = parts[i].Trim().Split(':')[1].Trim();

                        switch (parts[i].Split(':')[0].Trim())
                        {
                            case "Widht":
                                widht = int.Parse(partValue);
                                break;

                            case "Height":
                                height = int.Parse(partValue);
                                break;

                        }
                    }

                    if (widht >= 0 && height >= 0)
                    {
                        if (widht >= 0 && height >= 0)
                        {
                            figures.Add(new Rectangle()
                            {
                                Width = widht,
                                Height = height
                            });
                        }
                    }
                }
            }
            return figures;
        }
        public List<Figure> LoadFigureFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            List<Rectangle> rectangles = JsonConvert.DeserializeObject<List<Rectangle>>(jsonString);

            List<Figure> figures = rectangles.Cast<Figure>().ToList();
            return figures;
        }


        public void SaveToFileJson(Figure figure, string filePath)
        {
            List<Figure> animals = new List<Figure>();

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    animals = JsonConvert.DeserializeObject<List<Figure>>(jsonString);
                }
            }

            animals.Add(figure);

            string updatedJson = JsonConvert.SerializeObject(animals, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}

