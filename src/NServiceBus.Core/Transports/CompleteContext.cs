﻿namespace NServiceBus.Transport
{
    using System;
    using System.Collections.Generic;
    using NServiceBus.Extensibility;

    /// <summary>
    /// Allows the transport to pass signal that a message has been completed.
    /// </summary>
    public class CompleteContext
    {
        /// <summary>
        /// Initializes the context.
        /// </summary>
        /// <param name="nativeMessageId">The native message ID.</param>
        /// <param name="wasAcknowledged">True if the message was acknowledged and removed from the queue.</param>
        /// <param name="headers">The message headers.</param>
        /// <param name="startedAt">The time that processing started.</param>
        /// <param name="completedAt">The time that processing started.</param>
        /// <param name="onMessageFailed"><c>true</c> if the call to <see cref="OnMessage"/> threw an exception.</param>
        /// <param name="context">A <see cref="ReadOnlyContextBag" /> containing the context for the message receive operation.</param>
        public CompleteContext(string nativeMessageId, bool wasAcknowledged, Dictionary<string, string> headers, DateTimeOffset startedAt, DateTimeOffset completedAt, bool onMessageFailed, ReadOnlyContextBag context)
        {
            Guard.AgainstNullAndEmpty(nameof(nativeMessageId), nativeMessageId);
            Guard.AgainstNull(nameof(headers), headers);
            Guard.AgainstNull(nameof(startedAt), startedAt);
            Guard.AgainstNull(nameof(completedAt), completedAt);
            Guard.AgainstNull(nameof(context), context);

            NativeMessageId = nativeMessageId;
            WasAcknowledged = wasAcknowledged;
            Headers = headers;
            StartedAt = startedAt;
            CompletedAt = completedAt;
            OnMessageFailed = onMessageFailed;
            Extensions = context;
        }

        /// <summary>
        /// The native message ID.
        /// </summary>
        public string NativeMessageId { get; }

        /// <summary>
        /// True if the message was acknowledged and removed from the queue.
        /// </summary>
        public bool WasAcknowledged { get; }

        /// <summary>
        /// The message headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; }

        /// <summary>
        /// The time that processing started.
        /// </summary>
        public DateTimeOffset StartedAt { get; }

        /// <summary>
        /// The time processing completed.
        /// </summary>
        public DateTimeOffset CompletedAt { get; }

        /// <summary>
        /// <c>true</c> if the call to <see cref="OnMessage"/> threw an exception.
        /// </summary>
        public bool OnMessageFailed { get; }

        /// <summary>
        /// A collection of additional information for this receive operation.
        /// </summary>
        public ReadOnlyContextBag Extensions { get; }
    }
}