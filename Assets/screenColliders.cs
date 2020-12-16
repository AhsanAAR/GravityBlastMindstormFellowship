using UnityEngine;

public class screenColliders : MonoBehaviour
{
    private Camera cam;
    private EdgeCollider2D edge1;
    private EdgeCollider2D edge2;
    private Vector2[] edgePoints1;
    private Vector2[] edgePoints2;

    void Awake()
    {
        if (Camera.main == null) Debug.LogError("Camera.main not found, failed to create edge colliders");
        else cam = Camera.main;

        if (!cam.orthographic) Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders");

        // add or use existing EdgeCollider2D
        edge1 = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();
        edge2 = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

        edgePoints1 = new Vector2[5];
        edgePoints2 = new Vector2[5];


        AddCollider();
    }

    //Use this if you're okay with using the global fields and code in Awake() (more efficient)
    //You can just ignore/delete StandaloneAddCollider() if thats the case
    void AddCollider()
    {
        //Vector2's for the corners of the screen
        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
        Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

        //Update Vector2 array for edge collider
        edgePoints1[0] = bottomLeft;
        edgePoints1[1] = topLeft;
        edgePoints1[2] = topLeft + new Vector2(-2, 0) ;
        edgePoints1[3] = bottomLeft + new Vector2(-2, 0);
        edgePoints1[4] = bottomLeft;

        edgePoints1[0] = bottomRight;
        edgePoints1[1] = topRight;
        edgePoints1[2] = topRight+ new Vector2(2, 0);
        edgePoints1[3] = bottomRight + new Vector2(2, 0);
        edgePoints1[4] = bottomRight;

        edge1.points = edgePoints1;
        edge2.points = edgePoints2;

    }
}
