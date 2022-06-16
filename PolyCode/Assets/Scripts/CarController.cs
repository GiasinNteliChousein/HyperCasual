using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    public float HizLimiti;
    bool movingLeft = true;
    bool firstInput = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.gamestarted)
        {
             Move();
             checkInput();

        }

        if(transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if(moveSpeed < HizLimiti)
        {
            moveSpeed += 0.3f * Time.deltaTime;
        }

    }

    void changeDirection()
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else{
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void checkInput()
    {
        // ilk tiklama ile yon degistirmeye baslamamasi icin, ilk tiklamayi ignoreluyoruz. Cunku ilk tiklamada menu bolumunden oyuna gececegiz.
        if(firstInput)
        {
            firstInput = false;
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            changeDirection();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        {
            GameManager.instance.SkoruArttir();
            other.gameObject.SetActive(false);
        }
    }


}
