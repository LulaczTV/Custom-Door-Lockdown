using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Map;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;

namespace Custom_Door_Lockdown
{
    internal sealed class EventHandlers
    {
        public void OnRoundStarted()
        {

            foreach (DoorType doorType in Plugin.Instance.Config.DoorTypes)
            {
                Door.Get(doorType).ChangeLock(DoorLockType.AdminCommand);
            }
        }

        public void OnStartingWH(StartingEventArgs ev)
        {
            if (Plugin.Instance.Config.UnlockOnWarheadStart == true)
            {
                foreach (DoorType doorType in Plugin.Instance.Config.DoorTypes)
                {
                    Door.Get(doorType).ChangeLock(DoorLockType.None);
                }
            }
            else return;
        }

        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            if (Generator.Get(GeneratorState.Engaged).Count() == 2)
            {
                if (Plugin.Instance.Config.UnlockOnAllGenerators == true)
                {
                    foreach (DoorType doorType in Plugin.Instance.Config.DoorTypes)
                    {
                        Door.Get(doorType).ChangeLock(DoorLockType.None);
                    }
                }
                else return;
            }
        }
    }
}


