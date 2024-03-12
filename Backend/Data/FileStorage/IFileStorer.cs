namespace Backend.Data.FileStorage;

public interface IFileStorer
{
    List<string> LoadAllLines(string path);
    //void WriteAllLines(string path, List<string> lines);
}