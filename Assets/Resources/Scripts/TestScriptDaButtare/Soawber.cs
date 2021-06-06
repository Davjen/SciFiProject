using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soawber : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);
        }
    }
}
