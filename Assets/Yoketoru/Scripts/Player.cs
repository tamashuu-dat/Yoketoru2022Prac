using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Tooltip("����"), SerializeField]
    float speed = 20;
    float cameraDistance;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mpos = Input.mousePosition;
        //Debug.Log(mpos);
        mpos.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mpos);

        // to = ���݈ʒu����ړI�nwp�ւ̌����Ƒ傫��(�x�N�g��)
        Vector3 to = wp - transform.position;

        // to.magnitude = to�̒���
        if(to.magnitude<0.01f)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            float step = speed * Time.deltaTime;
            float dist = Mathf.Min(to.magnitude, step);
            float v = dist / Time.deltaTime;
            rb.velocity = v * to.normalized;
        }
        //transform.position = wp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }

}
