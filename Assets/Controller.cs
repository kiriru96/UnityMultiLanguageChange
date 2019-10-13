using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Controller : MonoBehaviour {
    private Dictionary<string, GameObject> objMap = new Dictionary<string, GameObject>();
    public bool containerActive = false;
    public string activePage = "Main";
    public string currentPage;
    void Awake()
    {
        GameObject[] gamelist = GameObject.FindGameObjectsWithTag("Page");
        foreach (GameObject game in gamelist)
        {
            objMap.Add(game.name, game);
            if (activePage != game.name)
            {
                game.SetActive(false);
            }
            else
            {
                currentPage = game.name;
            }
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (activePage != "Main")
            {
                activePage = "Main";
            }
            else
            {
                EditorApplication.Exit(0);
            }
        }
        if (activePage != currentPage)
        {
            if (objMap.ContainsKey(activePage))
            {
                objMap[currentPage].SetActive(false);
                objMap[activePage].SetActive(true);
                currentPage = activePage;
            }
        }
	}

    public void changePage(string pageName)
    {
        activePage = pageName;
    }
}
