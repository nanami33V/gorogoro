using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{

    public Animator animMain1;
    public Animator animMain2;
    public Animator animMainG;
    public Animator animMainO;

    public BallControl ballcon;
    // Start is called before the first frame update
    void Start()
    {
        animMain1.GetComponent<Animator>();
        animMain2.GetComponent<Animator>();
        animMainG.GetComponent<Animator>();
        animMainO.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void endGet1()
    {
        animMain2.SetTrigger("2triger");
    }
    public void endGet2()
    {
        animMain1.SetTrigger("1triger");
    }
    public void endGet3()
    {
        animMainG.SetTrigger("Gtriger");
        animMainO.SetTrigger("Otriger");
    }
    public void endGet4()
    {
        
        ballcon.CallPlayDo();
    }
}
