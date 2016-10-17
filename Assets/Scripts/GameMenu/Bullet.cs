using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    private Vector3 _direction;
    private float _gravity = 0.001f;
    private float _beingTime = 0;
    public float force = 500f;
    public float bulletSpeed = 10f;
    public ParticleSystem hitEffect;
    // Use this for initialization
    void Start()
    {
        _direction = Camera.main.transform.forward;
        hitEffect = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        //hitEffect.SetParticles(ParticleSystem.FI)
        hitEffect.Stop();

        #region [ CASE_NEED_GRAVITY ]
        // GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region [ CASE_UNNEEDED_GRAVITY ]
        _beingTime += Time.deltaTime;
        /// If you need gravity to the bullet...
        _direction = new Vector3(_direction.x, _direction.y - _gravity, _direction.z);

        /// The bullet go straight only.
        transform.position += _direction * Time.deltaTime * bulletSpeed;
        #endregion

        /// If the bullet go to under ground (y <= 0), destroy myself.
        if (_beingTime >= 10)
        {
            DestroyBullet(false);
        }
        if (transform.position.y <= -1)
        {
            DestroyBullet(false);
        }
    //    Debug.Log(hitEffect);


    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            return;

        if (col.rigidbody != null)
            col.rigidbody.AddForce(transform.forward * force);

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().ReceiveDamage(1);
        }
        DestroyBullet(true);
    }

    void DestroyBullet(bool useParticle)
    {
        Destroy(this.gameObject);

        if (useParticle)
            if (hitEffect)
            {
                hitEffect.transform.position = this.transform.position;
                hitEffect.Play();
            }
    }

}
