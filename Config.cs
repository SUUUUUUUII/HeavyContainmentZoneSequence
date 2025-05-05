using System;
using LabApi.Features.Wrappers;
using LabApi.Loader.Features.Plugins.Configuration;
using UnityEngine;

namespace Configuration
{
    internal class Config : Properties
    {

        public Color HCZColor = Color.cyan;

        public readonly string MessageToAllPlayers = "Запущена последовательность блокировки\n Зоны Тяжелого Содержания";

        public readonly string CassieWords = "pitch_00.15 .g4 .g4 .g4 pitch_00.95 . Heavy Containment Zone locked down sequence engaged . Heavy Containment Zone will lock down in . tminus 3 minutes . all personnel must evacuate from heavy containment zone immediately yield_50 2 minutes yield_29 90 seconds yield_29 60 seconds yield_9 50 yield_9 40 yield_9 30 seconds all heavy doors and checkpoint doors locked down yield_7 20 yield_6 10 seconds . 9 . 8 . 7 . 6 . 5 . 4 . 3 . 2 . 1 . pitch_00.15 .g4 . pitch_00.25 .g3 . pitch_00.95 Heavy Containment Zone locked down sequence begun . . . . .  . . . . . pitch_00.05 .g5 pitch_01.00 .g4 .g4 .g4 .g4 .g3 cassiesystem detected locked down sequence in Heavy Containment Zone . all remaining personnel in Heavy Containment Zone please wait any repair personnel for repaired Heavy Containment Doors pitch_00.97 . Secure . pitch_00.94 Contain . pitch_00.92 Protect";

    }

}