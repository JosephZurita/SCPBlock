using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

using System;

using Player = Exiled.Events.Handlers.Player;

namespace SCPBlock
{
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
            Player.ChangingRole += OnChangingRole;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.ChangingRole -= OnChangingRole;
            base.OnDisabled();
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!ev.IsAllowed || ev.Reason == SpawnReason.ForceClass || !Config.blockList.Contains(ev.NewRole) ) return;
            ev.NewRole = Config.swapList.RandomItem<RoleTypeId>();
        }
    }
}
