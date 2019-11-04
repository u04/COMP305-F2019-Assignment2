using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DeathPlaneController : MonoBehaviour
{
    public Transform activeCheckpoint;
    public GameObject player;
    public Text DeathLable;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    private int _death;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") 
        {
            other.gameObject.transform.position = activeCheckpoint.position;
            _death = _death + 1;
            Debug.Log($"I died {_death} times");
            DeathLable.text = $"death: {_death}";
 
        }
    }
}
