using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DapperDino.GettingStarted.ScriptableObjects
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private TMP_Text damageTextPrefab = null;
        [SerializeField] private DamageType[] damageTypes = new DamageType[0];

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) { return; }

            DealDamage();
        }

        private void DealDamage()
        {
            int damageToDeal = Random.Range(1, 11);
            DamageType damageType = damageTypes[Random.Range(0, damageTypes.Length)];

            SpawnDamageText(damageToDeal, damageType);
        }

        private void SpawnDamageText(int damageToDeal, DamageType damageType)
        {
            TMP_Text damageTextInstance = Instantiate(damageTextPrefab, transform.position + Vector3.up, transform.rotation);

            damageTextInstance.text = damageToDeal.ToString();
            damageTextInstance.color = damageType.Colour;

            Destroy(damageTextInstance.gameObject, 1f);
        }
    }
}
