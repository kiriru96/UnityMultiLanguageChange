using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LanguageBuilder {
    private static string language;
    private static Dictionary<string, string> storeLang = new Dictionary<string, string>();
    private static readonly LanguageBuilder instance = new LanguageBuilder();
    public delegate void LanguageChange();
    public event LanguageChange OnLanguageChange;
    private bool isGenerate = false;

    static LanguageBuilder()
    {

    }

    private LanguageBuilder()
    {

    }
    // Singleton of LanguageBuilder
    public static LanguageBuilder Instance
    {
        get
        {
            return instance;
        }
    }
    //function to store all string from xml file to Dictionary object
    public void SyncGenerateLangList(string lang)
    {
        if(isGenerate) return;
        isGenerate = true;
        language = lang; // set language with lang parameter
        storeLang.Clear(); // clear all data from storeLang
        TextAsset xmlfile = Resources.Load<TextAsset>("Language\\"+lang); // get resources of xml from Resources/Language path
        var doc = XDocument.Parse(xmlfile.text); // parse file to xml

        var allDict = doc.Element("language").Elements("string"); // get all elements string inside language tag
        foreach (var oneDic in allDict) // loop
        {
            storeLang.Add(oneDic.Attribute("id").Value, oneDic.Value); // add state to storeLang with attribute id from string tag as key, and value from string tag value
        }
        if(OnLanguageChange != null)
        {
            OnLanguageChange();
        }
        isGenerate = false;
    }
    // function to store all string from xml file to Dictionary object Asyncrounous
    public void AsyncGenerateLangList(string lang)
    {
        if(isGenerate) yield return null;
        isGenerate = true;
        language = lang;
        storeLang.Clear();
        System.GC.Collect();
        ResourceRequest xmlFile = Resources.LoadAsync<TextAsset>("Language\\"+lang);
        if(!xmlFile.isDone)
        {
            yield return 0;
        }

        var doc = XDocument.Parse((xmlFile.asset as TextAsset).text);
        var allDict = doc.Element("language").Elements("string");

        foreach(var oneDic in allDict)
        {
            storeLang.Add(oneDic.Attribute("id").Value, oneDic.Value);
        }
        if(OnLanguageChange != null)
        {
            OnLanguageChange();
        }
        isGenerate = false;
        yield return null;
    }

    // get current language
    public string GetCurrentLang()
    {
        return language;
    }

    // get string from storeLang
    public string GetLangString(string key)
    {
        return storeLang[key];
    }
}
