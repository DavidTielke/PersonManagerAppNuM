using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.CrossCutting
{
    // Wiederverwendbarkeit: 1
    // Austauschbarkeit: 1
    // Testbarkeit: 3
    // Erweiterbarkeit: 1
    // Analysierbarkeit: 1
    // Stabilität: 2
    public interface IConfigurator
    {
        TValue Get<TValue>(string key, TValue defaultValue = default);
        void Set<TValue>(string key, TValue value);
    }

    // Wiederverwendbarkeit: 1
    // Austauschbarkeit: 1
    // Testbarkeit: 2
    // Erweiterbarkeit: 1
    // Analysierbarkeit: 3
    // Stabilität: 1
    //internal interface IConfigurator1
    //{
    //    IConfigurator1 GetSection(string sectionName);
    //    string GetValue(string key);
    //}


    // Wiederverwendbarkeit: 4
    // Austauschbarkeit: 1
    // Testbarkeit: 1
    // Erweiterbarkeit: 5
    // Analysierbarkeit: 1
    // Stabilität: 1
    //internal interface IConfigurator2
    //{
    //    public string GetCsvSeparator();
    //    public string GetPersonsParserFileName();
    //    public string GetPersonsParserFileExtension();
    //    public int GetAdultsMinAge();
    //}


    // Wiederverwendbarkeit: 1
    // Austauschbarkeit: 1
    // Testbarkeit: 2
    // Erweiterbarkeit: 2
    // Analysierbarkeit: 2
    // Stabilität: 1
    //internal interface IConfigurator3
    //{
    //    char GetChar(string key);

    //    int GetInt(string key);

    //    string GetString(string key);

    //}


    // Wiederverwendbarkeit: 4
    // Austauschbarkeit: 1
    // Testbarkeit: 1
    // Erweiterbarkeit: 4
    // Analysierbarkeit: 1
    // Stabilität: 5
    //internal interface IConfigurator4
    //{
    //    dynamic GetConfig();
    //    int GetAge();
    //}
}
