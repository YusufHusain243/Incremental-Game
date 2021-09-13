using UnityEngine;
using UnityEngine.EventSystems;

public class TapArea : MonoBehaviour, IPointerDownHandler
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startPosition = transform.position;
        Launch();
    }

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.AddForce(new Vector2(speed * x, speed * y));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audio.Play();
        GameManager.Instance.CollectByTap(eventData.position, transform);
    }
}