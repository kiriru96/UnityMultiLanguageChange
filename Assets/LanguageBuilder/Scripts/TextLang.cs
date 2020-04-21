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
	// When Object awake
	void Awake () {
        textUI = GetComponent<Text>(); // Get Text Component from gameObject
        lb = LanguageBuilder.Instance; // Initiate LanguageBuilder
        lb.OnLanguageChange += UpdateText; //add event
	}
    // when object is active
    private void OnEnable()
    {
        UpdateText();
        if(lb != null){
            lb.OnLanguageChange += UpdateText; // add event
        }
    }
    // when object is inactive
    private void OnDisable()
    {
        if(lb != null)
        {
            lb.OnLanguageChange -= UpdateText; // remove event
        }
    }
    // Fill text component with string from Dictionary LanguageBuilder by id
    public void UpdateText(){
        textUI.text = lb.GetLangString(id);
    }

    private void OnDestroy()
    {
        if(lb != null)
        {
            lb.OnLanguageChange -= UpdateText; // remove event
            lb = null;
        }
    }
}
