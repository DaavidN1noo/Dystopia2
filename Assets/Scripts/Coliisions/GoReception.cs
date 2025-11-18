using UnityEngine;

public class Receptio : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LabDoor"))
        {
            transform.position = GameObject.FindWithTag("Reception").GetComponent<Transform>().position;
        }
        if (collision.gameObject.CompareTag("ReceptionDoor"))
        {
            transform.position = GameObject.FindWithTag("Lab").GetComponent<Transform>().position;
        }
    }

}
