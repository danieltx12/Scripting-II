using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : PowerUpBase
{
    protected override void PowerUp(Player player)
    {
        player.isInvincible = true;
        player.InvincibleMaterialChange();
    }
    protected override void PowerDown(Player player)
    {
        player.isInvincible = false;
        player.NormalMaterialChange();
    }
}
