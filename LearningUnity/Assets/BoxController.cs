using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform movePoint;

    public TurnListener listener;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (listener.GetCurrentTurn() == false)
        {
            boxMove();
        }
    }

    void boxMove()
    {

        movePoint.position += new Vector3(1f, 0f, 0f);
        listener.endCurrentTurn();

        //GameEvents.current.playerAction();
    }
}
