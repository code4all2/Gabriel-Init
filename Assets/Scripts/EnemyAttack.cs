using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Color gizmoColor = Color.white;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyDamage();
    }

     public void ApplyDamage()
    {
        /// variavel local
        Collider[] colliders = Physics.OverlapSphere(attackPosition.position, radius, layerMask);

        foreach (Collider coll in colliders)
        {
            if(coll != null)
            {
                if(coll.TryGetComponent<HealthManager>(out HealthManager healthManager))
                {
                    healthManager.TakeDamage(damage);
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(attackPosition.position, radius);
    }

}
