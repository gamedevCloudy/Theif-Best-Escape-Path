using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Pairs
{
    public GameObject a;
    public GameObject b;
    public float angleBetn;
}
public class TheifHandler : MonoBehaviour
{  
   [SerializeField] private CopHandler cHandler; 
   private GameObject[] cops;
   private LineRenderer lr; 

   private int[] angles; 


   private Pairs[] pair = new Pairs[10]; 

   
   
   void Start()
   {
        cops = cHandler.GetCops(); 
        lr = gameObject.GetComponent<LineRenderer>();
   }

   void Update()
   { 
        for (int i = 0; i< cops.Length; i++)
        {
            Debug.DrawLine(transform.position, cops[i].transform.position, Color.green);
        }
   }

//    void CalculateAngles()
//    {
//         float[] angles = {0,0,0,0,0,0,0,0,0,0};
//         float[] anglesRet = {0,0,0,0,0,0,0,0,0,0};


//         Vector3 dirA = Vector3.Normalize(transform.position-cops[0].transform.position); 

//         for(int i = 0; i< 10; i++)
//         {
//             Vector3 dirB = Vector3.Normalize(transform.position-cops[i].transform.position);
            
//             float angleX = Vector3.Angle(dirA,dirB); 
//             if(angleX == 0)
//             {
//                 continue;
//             }
//             else angles[i] = angleX; 
//         }

//         float minVal = 360; 
//         int item = 0; 

//         for(int i = 0; i <10; i++)
//         {
//             if(minVal >= angles[i]) minVal = angles[i];
//             item = i;   
//         }

//         pair[1].a = cops[0]; 
//         pair[1].b = cops[item];
//         pair[1].angleBetn =  minVal; 
//         Debug.Log(pair[1].a +" "+ pair[1].b +" "+pair[1].angleBetn);
//    }

//    void LeastAngleArr()
//    {
//         GameObjectPair[] collection = new GameObjectPair[10]; 
//         int counter = 0;
//         for(int i = 0; i<10;i++)
//         {
//             GameObjectPair pair = new GameObjectPair(); 
//             float minAngle = 360; 
//             pair.a = cops[i];
//             for(int j=0; j<10;j++)
//             {
//                 if(cops[i]==cops[j]) continue; 

//                 Vector3 dirA = Vector3.Normalize(transform.position - cops[i].transform.position); 
//                 Vector3 dirB = Vector3.Normalize(transform.position - cops[j].transform.position); 

//                 float angle = Vector3.Angle(dirA,dirB); 

//                 if(angle<=minAngle && angle !=0){
//                     minAngle = angle; 
//                     pair.b = cops[j]; 
//                     pair.angle = minAngle; 
//                 }

//             }
//             Debug.Log(pair.a+" "+ pair.b + " " + pair.angle);
//             Debug.DrawLine(pair.a.transform.position, pair.b.transform.position, Color.yellow, 10f); 
//             collection[counter] = pair; 
//             counter+=1;
//         }

//         float minAngles = 0; 
//         GameObjectPair px = new GameObjectPair(); 
//         foreach(GameObjectPair pair in collection)
//         {
//             if(pair.angle >= minAngles)
//             {
//                 minAngles = pair.angle; 
//                 px = pair; 
//             }
//         }

//         Vector3 ax = Vector3.Normalize(transform.position-px.a.transform.position); 
//         Vector3 bx = Vector3.Normalize(transform.position-px.b.transform.position);
//         Vector3 cx= ax + bx; 
//         Vector3 zx = ax+cx; 

//         Debug.DrawLine(transform.position, cx, Color.red,10f);
//         Debug.DrawLine(transform.position, zx, Color.red, 10f);


//    }

}

