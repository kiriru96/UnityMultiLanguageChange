using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LanguageMain : MonoBehaviour {
    private string currentLang;

	// Use this for initialization
	void Start () {
        var lang = PlayerPrefs.GetString("language", "id"); // get lang from PlayerPrefs
        currentLang = lang; // set currentLang with lang
        LanguageBuilder.Instance.generateLangList(currentLang); // generate language by currentLang
	}
	
	// Update is called once per frame
	void Update () {
        if (!PlayerPrefs.GetString("language", "id").Equals(currentLang))// check if language from PlayerPrefs not equal currentLang
        {
            currentLang = PlayerPrefs.GetString("language", "id"); // get language from PlayerPrefs and pass it to currentLang
            LanguageBuilder.Instance.generateLangList(currentLang); // generate again
        }
	}

    // used by button in language page
    public void changeLanguage(string lang)
    {
        PlayerPrefs.SetString("language", lang); // save language to PlayerPrefs
    }
}
