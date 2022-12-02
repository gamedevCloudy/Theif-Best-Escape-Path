using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct CopPair
{
        public GameObject a;
        public GameObject b;
        public float angle; 
};

public class RayCastMax : MonoBehaviour
{
    int counter = 0;
    GameObject[] cols = new GameObject[10]; 
    CopPair[] copPair = new CopPair[10]; 

    [SerializeField] private GameObject arrow;

    [SerializeField] private  CopHandler cHandler; 
    GameObject[] copsArr;
   
    void Start()
    {
        // Invoke("FormPairs", 15f); 
        copsArr = cHandler.GetCops();

    }

    void Update()
    {
        if(counter< 10) transform.Rotate(0,1f,0, Space.Self);
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward), Color.yellow, 1f);  

        for (int i = 0; i< copsArr.Length; i++)
        {
            Debug.DrawLine(transform.position, copsArr[i].transform.position, Color.green);
        }
    }

    void FixedUpdate()
    {
        
        if(counter<10)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward); 
            RaycastHit hit; 

            if(Physics.Raycast(transform.position, fwd, out hit, 100))
            {
                if(!IsInCol(hit.collider.gameObject))
                {
                    Debug.Log(hit.collider.gameObject+" "+ hit.collider.transform.position);
                    cols[counter] = hit.collider.gameObject; 
                    StartCoroutine(DisableColsFor(hit.collider.gameObject));
                    
                    counter+=1;
                    if (counter == 10) FormPairs();
                }
            }
        }
    }

    bool IsInCol(GameObject objectToCheck)
    {
        foreach(GameObject g in cols)
        {
            if(g == objectToCheck) return true; 
        }
        return false; 
    }
    
    void FormPairs()
    {
        Debug.Log("\n\nForming Pairs.....");
        for(int i = 0; i<9;i++)
        {
            CopPair pairx = new CopPair(); 
            pairx.a = cols[i];
            pairx.b = cols[i+1];

            Vector3 dirAx = Vector3.Normalize(transform.position - cols[i].transform.position); 
            Vector3 dirBx = Vector3.Normalize(transform.position - cols[i+1].transform.position); 

            float anglex = Vector3.Angle(dirAx,dirBx); 
            pairx.angle = anglex;

            copPair[i] = pairx; 
        }
        //for cop 9 to 1; 

        CopPair pair = new CopPair(); 
        pair.a = cols[9];
        pair.b = cols[0];

        Vector3 dirA = Vector3.Normalize(transform.position - cols[9].transform.position); 
        Vector3 dirB = Vector3.Normalize(transform.position - cols[0].transform.position); 

        float angle = Vector3.Angle(dirA,dirB); 
        pair.angle = angle;
        copPair[9] = pair; 

        FindMaxPair(); 
    }

    void FindMaxPair()
    {
        CopPair p = new CopPair(); 
        float maxAngle = 0; 
        foreach(CopPair x in copPair)
        {
            if(x.angle >= maxAngle)
            {
                maxAngle = x.angle; 
                p = x; 
            }
        }
        Debug.Log(p.a + " " + p.b + " " + p.angle);  

        EscapeDirection(p); 
    }

    void EscapeDirection(CopPair px)
    {
        Vector3 ax = Vector3.Normalize(transform.position-px.a.transform.position); 
        Vector3 bx = Vector3.Normalize(transform.position-px.b.transform.position);
        Vector3 cx= ax + bx; 
        Vector3 zx = ax+cx; 

        Vector3 escapedir = cx*10; 
        escapedir.y = 1;
        Debug.DrawRay(transform.position, -escapedir, Color.red,100);
    
        arrow.SetActive(true); 
        arrow.transform.LookAt(-cx*10); 
        // arrow.transform.rotation.x =0; 
    }

    IEnumerator DisableColsFor(GameObject g){
        g.GetComponent<Collider>().enabled =(false); 
        yield return new WaitForSeconds(5f); 
        g.GetComponent<Collider>().enabled =(true); 
    }

    public void ResetMaxFinder()
    {
        counter = 0;
        cols = new GameObject[10]; 
        copPair = new CopPair[10]; 
        arrow.SetActive(false); 
    }
}
