using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraDistance : MonoBehaviour
{

    public CinemachineVirtualCamera camera;
    float distanceStart=3.44f;
    public GameObject player1;
    public GameObject player2;
   // public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Proportion();
        
    }


    public void  Proportion(){


       // float distance = Mathf.Abs(Mathf.Abs(player2.transform.position.x)+Mathf.Abs(player1.transform.position.x));
        float distance = Mathf.Abs(player2.transform.position.x-player1.transform.position.x);
        Debug.Log(distance);
        float result= -(distanceStart-distance)*.25f;
        distanceStart=distance;
       // camera.gameObject.transform.position=new Vector3(0,1.49f,camera.gameObject.transform.position.z+result);
       // camera.

       camera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance+=result;
        
        
    }
}
