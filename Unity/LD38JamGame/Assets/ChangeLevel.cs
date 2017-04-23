using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    public string SceneToLoad = string.Empty;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneToLoad == string.Empty) throw new System.Exception("ChangeLevel>Update: SceneToLoad String Invalid");
            SceneManager.LoadScene(SceneToLoad);
        }
	}
}
