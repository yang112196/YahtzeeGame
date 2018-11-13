using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    Rigidbody rb;

    bool hasLanded;
    bool thrown;

    Vector3 initPosition;

    int diceValue;

    public DiceSide[] diceSides;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
        //else if(Input.GetMouseButtonDown(0) && hasLanded)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if(Physics.Raycast(ray, out hit, 100.0f))
        //    {

        //        if(rb2 = hit.transform.GetComponent<Rigidbody>())
        //        {
        //            SelectDice(rb2);
        //        }
        //    }
        //}

        if(rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;

            SideValueCheck();
        }
        else if(rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }

    }

    void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0,500), Random.Range(0, 800), Random.Range(0, 200));
        }
        else if(thrown && hasLanded)
        {
            //When the dice landed but still throwing, then what do you want to do
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach(DiceSide side in diceSides)
        {
            if(side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + " has been rolled!");
            }
        }

    }
    //void SelectDice(Rigidbody rbb)
    //{
    //    rbb.transform.position = new Vector3(-7.50f, 1.6f, -7.50f);
    //}
}
