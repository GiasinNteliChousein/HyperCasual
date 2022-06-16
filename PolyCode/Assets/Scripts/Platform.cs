using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject Star;

    // Start is called before the first frame update
    void Start()
    {
        // platforda yildizlarin ne kadar aralikla cikacagini burdan ayarliyoruz. Mesela range kismini (0,1) yapsam daha cok cikacak, (0,20) yaparsam cok nadir cikacak
        int RandomStar = Random.Range(0, 7);

        Vector3 starPosition = transform.position;
        starPosition.y += 1f;

        if(RandomStar < 1)
        {
            //platforma yildiz cikar
          GameObject StarInstance =   Instantiate(Star, starPosition, Star.transform.rotation);
          
          StarInstance.transform.SetParent(gameObject.transform);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlatformDusme()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {

            Invoke("PlatformDusme", 0.2f);
        }
    }
}
