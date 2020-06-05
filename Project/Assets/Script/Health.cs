using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    public float health = 100f;
    
    // Start is called before the first frame update
    public float HealthPoints {
        get {
            return health;
        }
        set {
            health = value;
            if (health <= 0) {
                Destroy (gameObject);
            }
        }
    }
}