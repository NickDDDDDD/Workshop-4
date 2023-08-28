using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MeshRenderer))]
public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        this._meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

    }

    public void UpdateColor(float frac)
    {
        this._meshRenderer.material.color = Color.red * frac;
    }


    

}
