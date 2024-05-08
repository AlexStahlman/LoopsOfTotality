using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTicker : MonoBehaviour
{
    [SerializeField] public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(parent == null)
        {
            SceneManager.LoadScene(2);
        }
    }
}
