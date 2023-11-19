using System.Linq;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.DataModel;
using Il2CppMonomiPark.World;
using MelonLoader;
using UnityEngine;

namespace UnlockAllPortals
{
    internal class Entry : MelonMod
    {
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            if (sceneName != "LoadScene")
                return;

            foreach (var item in Resources.FindObjectsOfTypeAll<WorldStatePrimarySwitch>())
            {
                if(item._model.state == SwitchHandler.State.DOWN)
                    return;
                
                item._model.state = SwitchHandler.State.DOWN;
                item.SetStateForAll(SwitchHandler.State.DOWN, true);
            }
        }
    }
}
