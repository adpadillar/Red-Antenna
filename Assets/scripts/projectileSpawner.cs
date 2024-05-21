using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float spawnRate = 3;
    // Start is called before the first frame update
    void Start()
    {
        spawnProjectile();
        StartCoroutine(SpawnProjectiles());
    }
 
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnProjectiles()
    {
      while (true)
      {
        yield return new WaitForSeconds(spawnRate);
        spawnProjectile();
      }
    }

    
 
    void spawnProjectile()
    {
      Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
