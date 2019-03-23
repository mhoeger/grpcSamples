﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using TestGrpc.Messages;

namespace GrpcMessages.Events
{
    public class RpcEvent : ScriptEvent
    {
        internal RpcEvent(string workerId, StreamingMessage message, string eventStreamId = null, MessageOrigin origin = MessageOrigin.Host)
            : base(message.ContentCase.ToString(), EventSources.Rpc)
        {
            Message = message;
            Origin = origin;
            WorkerId = workerId;
            EventStreamId = eventStreamId;
        }

        public enum MessageOrigin
        {
            Worker,
            Host
        }

        public MessageOrigin Origin { get; }

        public StreamingMessage.ContentOneofCase MessageType => Message.ContentCase;

        public string WorkerId { get; }

        public string EventStreamId { get; }

        public StreamingMessage Message { get; }
    }
}
