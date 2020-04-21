using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LanguageMain : MonoBehaviour {
    private string currentLang;
    
    public bool async = true;

	// Use this for initialization
	void Awake () {
        var lang = PlayerPrefs.GetString("language", GetLocalIdLanguage()); // get lang from PlayerPrefs
        currentLang = lang; // set currentLang with lang
        LanguageBuilder.Instance.SyncGenerateLangList(currentLang); // generate language by currentLang Syncrounous
	}
    // used by button in language page
    public void ChangeLanguage(string lang)
    {
        if(currentLang != lang)
        {
            PlayerPrefs.SetString("language", lang); // save language to PlayerPrefs, you can change key name whatever you want
            
            if(async){
                if (generateLanguage != null)
                {
                    StopCoroutine(generateLanguage);
                }
                generateLanguage = StartCoroutine(LanguageBuilder.Instance.AsyncGenerateLangList(lang)); // run Asyncrounous
            }else{
                LanguageBuilder.Instance.SyncGenerateLangList(currentLang); // run Syncrounous
            }
            currentLang = lang;
        }
    }
    // function to get Id, you can change it whatever you want for xml file, it is just for me
    private string GetLocalIdLanguage()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Afrikaans:
                return "af";
            case SystemLanguage.Arabic:
                return "sa";
            case SystemLanguage.Basque:
                return "ba";
            case SystemLanguage.Belarusian:
                return "be";
            case SystemLanguage.Bulgarian:
                return "bu";
            case SystemLanguage.Catalan:
                return "ca";
            case SystemLanguage.Chinese:
                return "ch";
            case SystemLanguage.ChineseSimplified:
                return "ch";
            case SystemLanguage.ChineseTraditional:
                return "ch";
            case SystemLanguage.Czech:
                return "cz";
            case SystemLanguage.Danish:
                return "da";
            case SystemLanguage.Dutch:
                return "du";
            case SystemLanguage.English:
                return "en";
            case SystemLanguage.Estonian:
                return "ee";
            case SystemLanguage.Faroese:
                return "fa";
            case SystemLanguage.Finnish:
                return "fi";
            case SystemLanguage.French:
                return "fr";
            case SystemLanguage.German:
                return "ge";
            case SystemLanguage.Greek:
                return "gr";
            case SystemLanguage.Hebrew:
                return "he";
            case SystemLanguage.Hungarian:
                return "hu";
            case SystemLanguage.Icelandic:
                return "il";
            case SystemLanguage.Indonesian:
                return "id";
            case SystemLanguage.Italian:
                return "it";
            case SystemLanguage.Japanese:
                return "jp";
            case SystemLanguage.Korean:
                return "kr";
            case SystemLanguage.Latvian:
                return "lv";
            case SystemLanguage.Lithuanian:
                return "lt";
            case SystemLanguage.Norwegian:
                return "no";
            case SystemLanguage.Polish:
                return "po";
            case SystemLanguage.Portuguese:
                return "pt";
            case SystemLanguage.Romanian:
                return "ro";
            case SystemLanguage.Russian:
                return "ru";
            case SystemLanguage.SerboCroatian:
                return "hr";
            case SystemLanguage.Slovak:
                return "sk";
            case SystemLanguage.Slovenian:
                return "si";
            case SystemLanguage.Spanish:
                return "es";
            case SystemLanguage.Swedish:
                return "se";
            case SystemLanguage.Thai:
                return "th";
            case SystemLanguage.Turkish:
                return "tr";
            case SystemLanguage.Ukrainian:
                return "ua";
            case SystemLanguage.Unknown:
                return "en";
            case SystemLanguage.Vietnamese:
                return "vn";
            default:
                return "en";

        }
    }
}
