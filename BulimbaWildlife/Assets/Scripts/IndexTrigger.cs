using UnityEngine;

public class IndexTrigger : MonoBehaviour
{
    public GameObject detail;

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "snakecollision")
        {
            detail.SetActive(true);
        }
       
    }
}
