using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using HCZLock;
using HCZSystems;
using LabApi.Features.Wrappers;
using MEC;
using Steamworks.Data;

namespace HCZSequence
{

[CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SequenceCommand : ICommand
    {
        

        public bool SequenceIsStarted = false;

        HCZSystems.HeavyContainmentZone properties = new HeavyContainmentZone();

        HCZLock.HeavyCZLock heavyCZ = new HCZLock.HeavyCZLock();
        public string Command => "forceHCZSequence";

        public string[] Aliases => new [] {"hczsequence"};

        public string Description => "Engage locked down sequence in Heavy Containment Zone";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!Round.IsRoundStarted)
            {

                response = "Round must be started for use this command";

                return false;

            }


            response = "Done! H.C.Z Locked Down Sequence engaged.";

            heavyCZ.Sequence();

            SequenceIsStarted = true;

            if (Cassie.IsSpeaking && SequenceIsStarted == true && !Round.IsRoundEnded)
            {

                response = "H.C.Z Sequence already engaged.";

                return false;
            }

            if (Round.IsRoundEnded)
            {

                properties.SetLightColor(UnityEngine.Color.clear);

                properties.TurnOnHCZLights();

                properties.UnlockHCZDoors();

                SequenceIsStarted = false;

                return false;
            }

            return true;
        }
        
    }
}
