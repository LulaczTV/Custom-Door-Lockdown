using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled;
using Exiled.API.Features;
using Exiled.API.Extensions;

namespace Custom_Door_Lockdown
{
    public class Plugin : Plugin<Config>
    {

        public static Plugin Instance;


        public override string Name => "Custom Door Lockdown";
        public override string Author => "pan andrzej";
        public override Version Version => new Version(1, 1, 3);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        private EventHandlers EventHandler { get; set; }

        public override void OnEnabled()
        {
            Instance = this;
            EventHandler = new EventHandlers();

            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            EventHandler = null;

            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Warhead.Starting += EventHandler.OnStartingWH;
            Exiled.Events.Handlers.Map.GeneratorActivated += EventHandler.OnGeneratorActivated;
            Exiled.Events.Handlers.Server.RoundStarted += EventHandler.OnRoundStarted;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Warhead.Starting -= EventHandler.OnStartingWH;
            Exiled.Events.Handlers.Map.GeneratorActivated -= EventHandler.OnGeneratorActivated;
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandler.OnRoundStarted;

        }


    }
}
