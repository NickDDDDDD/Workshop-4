
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damageAmountt = 50;
    // Start is called before the first frame update





    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.velocity * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == this.tagToDamage)
        {

            var healthManager = other.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(this.damageAmountt);


            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }


}
