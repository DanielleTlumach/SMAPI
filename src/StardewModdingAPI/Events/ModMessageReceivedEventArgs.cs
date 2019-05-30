using System;
using StardewModdingAPI.Framework.Networking;

namespace StardewModdingAPI.Events
{
    /// <summary>Event arguments for an <see cref="IMultiplayerEvents.ModMessageReceived"/> event.</summary>
    public class ModMessageReceivedEventArgs : EventArgs
    {
        /*********
        ** Fields
        *********/
        /// <summary>The underlying message model.</summary>
        private readonly ModMessageModel Message;


        /*********
        ** Accessors
        *********/
        /// <summary>The unique ID of the player from whose computer the message was sent.</summary>
        public long FromPlayerID => this.Message.FromPlayerID;

        /// <summary>The unique ID of the mod which sent the message.</summary>
        public string FromModID => this.Message.FromModID;

        /// <summary>A message type which can be used to decide whether it's the one you want to handle, like <c>SetPlayerLocation</c>. This doesn't need to be globally unique, so mods should check the <see cref="FromModID"/>.</summary>
        public string Type => this.Message.Type;


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="message">The received message.</param>
        internal ModMessageReceivedEventArgs(ModMessageModel message)
        {
            this.Message = message;
        }

        /// <summary>Read the message data into the given model type.</summary>
        /// <typeparam name="TModel">The message model type.</typeparam>
        public TModel ReadAs<TModel>()
        {
            return this.Message.Data.ToObject<TModel>();
        }
    }
}