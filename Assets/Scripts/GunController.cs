using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject gunLevel1;
    public GameObject gunLevel2;
    public GameObject gunLevel3;

    private int currentGunLevel = 1;
    private bool hasUpgraded = false;
    private bool hasDowngraded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinningObstacle") && !hasUpgraded)
        {
            UpgradeGun();
            hasUpgraded = true;
            Invoke("ResetUpgradeFlag", 1.0f);
        }
         if (other.CompareTag("Obstacle") && !hasDowngraded)
        {
            DowngradeGun();
            hasDowngraded = true;
            Invoke("ResetDowngradeFlag", 1.0f);
        }
    }

    private void UpgradeGun()
    {
        currentGunLevel++;

        if (currentGunLevel == 2)
        {
            gunLevel1.SetActive(false);
            gunLevel2.SetActive(true);
        }
        else if (currentGunLevel == 3)
        {
            gunLevel2.SetActive(false);
            gunLevel3.SetActive(true);
        }
    }

    private void DowngradeGun()
    { 
        if (currentGunLevel == 2)
        {
            gunLevel2.SetActive(false);
            gunLevel1.SetActive(true);
        }
        else if (currentGunLevel == 3)
        {
            gunLevel3.SetActive(false);
            gunLevel2.SetActive(true);
        }
    }



    private void ResetUpgradeFlag()
    {
        hasUpgraded = false;
    }

    private void ResetDowngradeFlag()
    {
        hasDowngraded = false;
    }
}
