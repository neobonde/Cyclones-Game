using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Rect bounds = Rect.zero;
    [HideInInspector]
    public Rect cameraBounds;

    Transform leftEdge; 
    Transform rightEdge; 
    EdgeCollider2D leftCollider;
    EdgeCollider2D rightCollider;

    List<Vector2> colliderPoints;
    void Awake()
    {
        transform.position = Vector2.zero;
        cameraBounds = bounds;
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = Camera.main.aspect * halfHeight;
        
        leftEdge = new GameObject().transform;
        rightEdge = new GameObject().transform;
        leftEdge.name = "leftEdge";
        rightEdge.name = "rightEdge";        
        leftEdge.parent = transform;
        rightEdge.parent = transform;
        leftEdge.tag = "Wall";
        rightEdge.tag = "Wall";
        leftCollider = leftEdge.gameObject.AddComponent<EdgeCollider2D>();
        rightCollider = rightEdge.gameObject.AddComponent<EdgeCollider2D>();

        leftEdge.position = new Vector2(bounds.xMin-halfWidth,0);
        rightEdge.position = new Vector2(bounds.xMax+halfWidth,0);
        
        colliderPoints = new List<Vector2>();
        colliderPoints.Add(new Vector2(0,halfHeight));
        colliderPoints.Add(new Vector2(0,-halfHeight));

        leftCollider.points = colliderPoints.ToArray();
        rightCollider.points = colliderPoints.ToArray();

    }
}
