using UnityEngine;

public class ShootManager : MonoBehaviour
{
    private static readonly int IsShoot = Animator.StringToHash("shoot");

    [SerializeField] private Camera camera;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject prefabBullet;

    private bool _canShoot;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_canShoot == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(prefabBullet, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Quaternion.identity);
                    }

                    animator.SetTrigger(IsShoot);

                }
            }
        }
     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CanShoot"))
        {
            _canShoot = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CanShoot"))
        {
            _canShoot = false;
        }
    }

}
