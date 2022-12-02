using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// struct GameObjectPair
// {
//         public GameObject a;
//         public GameObject b;
//         public float angle; 
// };

public class CopHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] cops; 
    private enum CopState{
        active, 
        inactive
    }
    private CopState copState = CopState.inactive; 

    // [SerializeField] private TheifHandler tHandler;
    [Header("Spawn Area")]
    [SerializeField] private float maxX, maxZ, minX, minZ;

    void Start()
    {
        PositionCops();
    }

    public void Reposition()
    {
        PositionCops();
        // RecalculateAngles();
    }
    void PositionCops()
    {
        if(copState == CopState.active) DisableCops(); 

        Vector3 getPos = GetPosition(); 
        for(int i = 0; i<cops.Length; i++)
        {
            while(PosIsTaken(getPos))
            {
                getPos = GetPosition();
            }
            cops[i].transform.position = getPos; 
        }
        EnableCops();

    }

    Vector3 GetPosition()
    {
        float x = Random.Range(minX, maxX); 
        float z= Random.Range(minZ, maxZ); 
        return new Vector3(x,1,z);
    }

    bool PosIsTaken(Vector3 posToCheck)
    {
        for(int i = 0; i<cops.Length; i++)
        {
            if(posToCheck == cops[i].transform.position || posToCheck == Vector3.up) return true;
        }
        return false;  
    }

    void DisableCops()
    {
        for(int i = 0; i < cops.Length; i++)
        {
            cops[i].SetActive(false);
        }
        copState = CopState.inactive; 
    }

    void EnableCops()
    {
        for(int i = 0; i < cops.Length; i++)
        {
            cops[i].SetActive(true);
        }
        copState= CopState.active;
    }

    public GameObject[] GetCops()
    {
        return cops; 
    }

    // private void GetLeastAngle()
    // {
    //     int counter = 0; 
    //     for(int i = 0; i<cops.Length; i++)
    //     {
    //         GameObjectPair pair = new GameObjectPair(); 
        
    //         pair.a = cops[i];
            

    //         float minAngle = 360; 
    //         for(int j = 0; j<cops.Length; j++)
    //         {
    //             if(cops[i]==cops[j])
    //             {
    //                 continue; 
    //             }
    //             Vector3 a = Vector3.Normalize(transform.position-cops[i].transform.position); 
    //             Vector3 b = Vector3.Normalize(transform.position-cops[j].transform.position); 

    //             float angle = Vector3.Angle(a,b); 

    //             if(angle<=minAngle) 
    //             {   minAngle = angle; 
    //                 // Debug.Log("Minimum angle between: " + cops[i] + " & " + cops[j] + " is: " + minAngle);
    //                 pair.b = cops[j];
    //                 pair.angle = minAngle;      
    //             }
    //         }
    //         counter+=1;
    //         Debug.Log(counter + " " + pair + "\ta: "+ pair.a + "b:" +pair.b + "angle betn them: " + pair.angle); 
    //         Debug.DrawLine(pair.a.transform.position, pair.b.transform.position, Color.yellow, 2f);
    //       }
    // }

    // public void RecalculateAngles()
    // {
    //     GetLeastAngle(); 
    // }
}
