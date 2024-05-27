using Mirror;

public class Minion : NetworkBehaviour
{
    private MinionHealth minionHealth;
    public MinionHealth MinionHealth
    {
        get
        {
            if (minionHealth == null) minionHealth = GetComponent<MinionHealth>();

            return minionHealth;
        }
    }

}
