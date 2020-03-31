using UnityEngine.AddressableAssets;
using GameUtils;

public class LevelArenaLoader : SingletonObject<LevelArenaLoader>
{
    public AssetReference[] objectToLoad;

    public static void LoadArena(Packet _packet)
    {
        int mapNumber = _packet.ReadInt();
        Instance.Load(mapNumber);
    }

    public void Load(int mapNumber)
    {
        Addressables.InstantiateAsync(objectToLoad[mapNumber]);
    }

}
