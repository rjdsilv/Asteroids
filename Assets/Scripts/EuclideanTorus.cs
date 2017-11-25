using UnityEngine;

public class EuclideanTorus : MonoBehaviour {
    /// Update is called once per frame
    /// This method will updated the ship position after it left the screen.
    /// If the ship left the screen on up, it will appear down.
    /// If the ship left the screen on down, it will appear up.
    /// If the ship left the screen on right, it will appear left.
    /// If the ship left the screen on left, it will appear right.
    void Update ()
    {
        // Setting up the x axis.
		if(transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
        if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }

        // Setting up the y axis.
        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, -6, 0);
        }
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
    }
}
