using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextLang : MonoBehaviour {
    Text textUI; // Component Text
    public string id; // id of string in xml
    private string activeLang;
    LanguageBuilder lb;
	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>(); // Get Text Component from gameObject
        lb = LanguageBuilder.Instance; // Initiate LanguageBuilder
        textUI.text = lb.getLangString(id); // set text with current language state by id
        activeLang = lb.getCurrentLang(); // save current language
	}

    void Update()
    {
        var currentLang = lb.getCurrentLang(); // get current language active
        if (!currentLang.Equals(activeLang) && gameObject.activeInHierarchy)// check if current language not equal activeLang
        {
            activeLang = currentLang; // update activeLang with current Language
            textUI.text = lb.getLangString(id); // update text with current string language
        }
    }
}
