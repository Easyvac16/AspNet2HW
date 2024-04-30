using AspNet2HW.Model;

namespace AspNet2HW.Abstract
{
    public interface IFiguresOutputService
    {
        public void SaveToFile(Figure figure, string filePath);
        public void SaveToFileJson(Figure figure, string filePath);

        public List<Figure> LoadFigure(string filePath);
        public List<Figure> LoadFigureFromJson(string filePath);
    }
}
