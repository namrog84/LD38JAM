using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour {

    public static int referenceCount;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
     private void Start()
    {
        referenceCount++;
        if (referenceCount > 1)
        {
            DestroyImmediate(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
