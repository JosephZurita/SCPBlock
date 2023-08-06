using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using Players = Exiled.Events.Handlers.Player;

namespace SCPBlock
{
    /// <inheritdoc />
    public class SCPBlock : Plugin<Config>
    {
        /// <inheritdoc />
        public override string Author => "JZ";

        /// <inheritdoc />
        public override string Name => "SCPBlock";

        /// <inheritdoc />
        public override string Prefix => Name;

        /// <inheritdoc />
        public override Version RequiredExiledVersion => new Version(7, 2, 0);

        /// <inheritdoc />
        public override Version Version => new Version(1, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Players.ChangingRole += OnChangingRole;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Players.ChangingRole -= OnChangingRole;
            base.OnDisabled();
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!ev.IsAllowed || ev.Reason == SpawnReason.ForceClass || !Config.blockList.Contains(ev.NewRole) ) return;

            List<RoleTypeId> swapScps = Config.swapList.Except(Player.Get(Team.SCPs).Select(scp => (RoleTypeId)scp.Role)).ToList();

            if (swapScps.Count == 0) return;

            ev.SpawnFlags = RoleSpawnFlags.UseSpawnpoint;
            ev.NewRole = swapScps.RandomItem();
        }
    }
}
