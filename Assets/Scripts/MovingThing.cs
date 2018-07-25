
using UnityEngine;
using System.Collections;

public class MovingThing : MonoBehaviour {
    //float speed: How quick the platform will be moving
    public float speed;
    public Vector3 point1;
    public Vector3 point2;
    float timeWait;
    public bool goToSecond = true;
    public float pathWaitTime;
    float pathWaitTimeLeft;
    Transform trans;


    // Initializes the game object to get its Transform component
    void Start() {

        trans = GetComponent<Transform>();
        pathWaitTimeLeft = pathWaitTime;
    }

    // Update is called once per frame
    void Update() {
        move();
    }




    //This function moves the structure from its current position, to a bit closer
    //towards its destination. It will be called every frame. The movement is smooth
    //Vector3.MoveTowards is used
    public void move() {



        //Each path has two points, figure out which point is your goal.
        if (!goToSecond) {
            //now first check if you have reached your goal. 
            if (Vector3.Distance(trans.localPosition, point1) <= 0.1) {
                if (pathWaitTimeLeft <= 0) {
                    //Reset the waiting time, and change the goal to go to
                    pathWaitTimeLeft = pathWaitTime;
                    goToSecond = true;

                }
                pathWaitTimeLeft -= Time.deltaTime;
            }

            //Now if you didn't reach your goal, move towards it
            else {
                trans.localPosition = Vector3.MoveTowards(transform.localPosition, point1, Time.deltaTime * speed);
            }

        } else if (goToSecond) {
            //now first check if you have reached your goal. 
            if (Vector3.Distance(trans.localPosition, point2) <= 0.1) {
                if (pathWaitTimeLeft <= 0) {
                    //Reset the waiting time, and change the goal to go to
                    pathWaitTimeLeft = pathWaitTime;
                    goToSecond = false;

                }
                pathWaitTimeLeft -= Time.deltaTime;
            }

            //Now if you didn't reach your goal, move towards it
            else {
                trans.localPosition = Vector3.MoveTowards(transform.localPosition, point2, Time.deltaTime * speed);
            }

        }



    }

}
