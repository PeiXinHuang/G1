using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BattleWorld world;
    // Start is called before the first frame update  
    void Start()
    {

        SceneMgr.Instance.LoadScene("1001", () =>
        {
            world = new BattleWorld();
            world.Enter();

        });
    }

    // Update is called once per frame  
    void Update()
    {
        if (world != null)
        {
            world.Update(Time.deltaTime);
        }
    }

    void OnDestroy()
    {
        if (world != null)
        {
            world.Exit();
            world = null;
        }
    }
}
