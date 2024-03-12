namespace ConsoleClient.Data;

public interface IFileStorer
{
    List<string> LoadAllLines(string path);
    //void WriteAllLines(string path, List<string> lines);
}