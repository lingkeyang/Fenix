﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DotNetty.Codecs.Http2
{
    using System;

    public abstract class AbstractHttp2StreamFrame : IHttp2StreamFrame, IEquatable<IHttp2StreamFrame>
    {
        private IHttp2FrameStream _stream;

        public abstract string Name { get; }

        public IHttp2FrameStream Stream
        {
            get => _stream;
            set => _stream = value;
        }

        public sealed override bool Equals(object obj)
        {
            return obj is IHttp2StreamFrame streamFrame && Equals(streamFrame);
        }

        public bool Equals(IHttp2StreamFrame other)
        {
            if (ReferenceEquals(this, other)) { return true; }

            if (other is null) { return false; }

            return Equals0(other);
        }

        protected virtual bool Equals0(IHttp2StreamFrame other)
        {
            var thisStream = _stream;
            var otherStream = other.Stream;
            return ReferenceEquals(thisStream, otherStream) || (thisStream is object && thisStream.Equals(otherStream));
        }

        public override int GetHashCode()
        {
            var thisStream = _stream;
            if (thisStream is null) { return base.GetHashCode(); }

            return thisStream.GetHashCode();
        }
    }
}
