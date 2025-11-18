using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolBullet : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    ObjectPool<Projectile> projectilePool;

    private void Awake() {
        projectilePool = new ObjectPool<Projectile>(CreatePoolItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, 10, 100);
    }

    private Projectile CreatePoolItem() {
        Projectile newProjectile = Instantiate(projectilePrefab);
        newProjectile.gameObject.SetActive(true);
        newProjectile.pool = projectilePool;// << le hago la referencia a cual pool es usando la misma Clase Projectile.cs
        return newProjectile;
    }

    private void OnTakeFromPool(Projectile currentProjectile) {
        currentProjectile.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(Projectile oldProjectile) {
        oldProjectile.transform.position = Vector3.zero;//Opcional la position y rotation
        oldProjectile.transform.rotation = Quaternion.identity;
        oldProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;//Setearlas a 0 asi no crea efectos no deseados
        oldProjectile.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Projectile projectile) {
        Destroy(projectile);
    }

    public void GetBullet(Vector3 position, Quaternion rotation) { //El arma llama a la funcion para obtener el Pool
        Projectile projectileIntance = projectilePool.Get();

        //esto combina las dos rotaciones. Se llama rotación compuesta.
                //"Apunta como el arma, y luego rota 90° sobre el eje X".
        Quaternion spawnRotation = rotation * Quaternion.Euler(90f, 0f, 0f);
        projectileIntance.transform.SetPositionAndRotation(position, spawnRotation);

        //"Dispara la bala hacia donde está apuntando el arma."
        projectileIntance.Launch(rotation * Vector3.forward);
        Debug.Log(rotation * Vector3.forward); // < Cuando no tengo acceso al transform del arma
        //Si el arma o el jugador está rotado hacia la derecha (90° sobre Y), entonces:
        //Vector3.forward > sigue apuntando hacia (0, 0, 1)
        //Pero rotation * Vector3.forward > se convierte en (1, 0, 0) hacia la derecha del mundo
    }

    /*
        Balas en juegos de disparos.
        Efectos visuales que aparecen y desaparecen (como explosiones o partículas).
        Enemigos o NPCs que se generan y destruyen constantemente.
    */
}
