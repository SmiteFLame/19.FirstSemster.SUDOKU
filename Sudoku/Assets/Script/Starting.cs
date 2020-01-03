using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : MonoBehaviour
{
    public GameObject Box;

    private GetData GD;
    private GameObject Temp;

    void Awake()
    {
        Screen.SetResolution(480, 840, true);   
    }

    void Start()
    {
        float x = -2.5f;      
        for(int i = 0; i < 9; i++)
        {
            float y = 4.5f;
            for (int j = 0; j < 9; j++)
            {
                Temp = Instantiate(Box, new Vector3(x, y, 0), Quaternion.identity);
                GD = Temp.GetComponent<GetData>();
                GD.Set(i, j);
                y -= 0.5f;
            }
            x += 0.5f;
        }
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)     
            if (Input.GetKey(KeyCode.Escape))            
                Application.Quit();        
    }
}
    
