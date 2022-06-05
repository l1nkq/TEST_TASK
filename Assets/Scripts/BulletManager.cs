using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float endTime;
    
    private float _startTime;

    private void Update()
    {
        _startTime += Time.deltaTime;

        if (_startTime >= endTime)
        {
            Destroy(gameObject);
        }
    }
}
