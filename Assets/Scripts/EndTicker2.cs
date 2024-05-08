using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTicker2 : MonoBehaviour
{
    [SerializeField] public GameObject parent;
    [SerializeField] public GameObject otherparent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (otherparent == null)
        {
            if (parent == null)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
