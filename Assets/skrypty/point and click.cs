using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointandclick : MonoBehaviour
{
    public GameObject clickEffectPrefab;
    public float effectLifetime = 3.0f;
    private Vector3 targetPosition;
    private int speed = 5;
    private float cooldown = 5;
    bool cd=true;
    private float cooldown2 = 5;
    bool cd2 = true;
    private float cooldown3 = 5;
    bool cd3 = true;
    private float cooldown4 = 5;
    bool cd4 = true;
    [SerializeField] GameObject fireball;

    public float upwardForce = 5f;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Move(out hit);
            PlayClickEffect(hit);
        }
        
        if(Input.GetKey(KeyCode.Q) && cd) 
        {
            cd = false;
            cooldown = 5f;
            cooldowns();
        }

        if (Input.GetKey(KeyCode.W) && cd2)
        {
            cd2 = false;
            cooldown2 = 5f;
            cooldowns2();
        }

        if (Input.GetKey(KeyCode.E) && cd3)
        {
            cd3 = false;
            cooldown3 = 5f;
            cooldowns3();
        }

        if (Input.GetKey(KeyCode.R) && cd4)
        {
            cd4 = false;
            cooldown4 = 5f;
            cooldowns4();
        }
    }

    void Move(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point + new Vector3(0, 0.5f, 0);
        }
    }

    void cooldowns()
    {
        if (!cd)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0)
        {
            cd = true;
        }
    }

    void cooldowns2()
    {
        if (!cd2)
        {
            cooldown2 -= Time.deltaTime;
        }
        if (cooldown2 <= 0)
        {
            cd2 = true;
        }
    }

    void cooldowns3()
    {
        if (!cd3)
        {
            cooldown3 -= Time.deltaTime;
        }
        if (cooldown3 <= 0)
        {
            cd3 = true;
        }
    }

    void cooldowns4()
    {
        if (!cd4)
        {
            cooldown4 -= Time.deltaTime;
        }
        if (cooldown4 <= 0)
        {
            cd4 = true;
        }
    }

    void PlayClickEffect(RaycastHit hit)
    {
        if (clickEffectPrefab != null)
        {
            Vector3 clickPosition = hit.point;
            clickPosition.z = 0;
            GameObject effect = Instantiate(clickEffectPrefab, clickPosition, Quaternion.identity);

            Rigidbody rb = effect.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            Destroy(effect, effectLifetime);
        }
    }
}
