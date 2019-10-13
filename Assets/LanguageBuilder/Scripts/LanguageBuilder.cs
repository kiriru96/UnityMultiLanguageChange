using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LanguageBuilder {
    private static string language;
    private static Dictionary<string, string> storeLang = new Dictionary<string, string>();
    private static readonly LanguageBuilder instance = new LanguageBuilder();

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
    public void generateLangList(string lang)
    {
        language = lang; // set language with lang parameter
        storeLang.Clear(); // clear all data from storeLang
        TextAsset xmlfile = Resources.Load<TextAsset>("Language\\"+lang); // get resources of xml from Resources/Language path
        var doc = XDocument.Parse(xmlfile.text); // parse file to xml

        var allDict = doc.Element("language").Elements("string"); // get all elements string inside language tag
        foreach (var oneDic in allDict) // loop
        {
            //Debug.Log(oneDic.Attribute("id").Value);
            //Debug.Log(oneDic.Value);
            storeLang.Add(oneDic.Attribute("id").Value, oneDic.Value); // add state to storeLang with attribute id from string tag as key, and value from string tag value
        }
    }

    // get current language
    public string getCurrentLang()
    {
        return language;
    }

    // get string from storeLang
    public string getLangString(string key)
    {
        return storeLang[key];
    }
}
