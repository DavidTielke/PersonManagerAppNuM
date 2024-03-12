using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage;

public interface IPersonConverter
{
    string ToCsv(Person person);
}