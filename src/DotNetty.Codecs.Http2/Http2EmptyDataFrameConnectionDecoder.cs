﻿namespace DotNetty.Codecs.Http2
{
    using System.Collections.Generic;
    using DotNetty.Buffers;
    using DotNetty.Common.Utilities;
    using DotNetty.Transport.Channels;

    /// <summary>
    /// Enforce a limit on the maximum number of consecutive empty DATA frames (without end_of_stream flag) that are allowed
    /// before the connection will be closed.
    /// </summary>
    sealed class Http2EmptyDataFrameConnectionDecoder : DecoratingHttp2ConnectionDecoder
    {
        private readonly int _maxConsecutiveEmptyFrames;

        public Http2EmptyDataFrameConnectionDecoder(IHttp2ConnectionDecoder decoder, int maxConsecutiveEmptyFrames)
            : base(decoder)
        {
            if ((uint)(maxConsecutiveEmptyFrames - 1) > SharedConstants.TooBigOrNegative)
            {
                ThrowHelper.ThrowArgumentException_Positive(maxConsecutiveEmptyFrames, ExceptionArgument.maxConsecutiveEmptyFrames);
            }
            _maxConsecutiveEmptyFrames = maxConsecutiveEmptyFrames;
        }

        public override IHttp2FrameListener FrameListener
        {
            get
            {
                IHttp2FrameListener frameListener = base.FrameListener;
                // Unwrap the original Http2FrameListener as we add this decoder under the hood.
                if (frameListener is Http2EmptyDataFrameListener emptyDataFrameListener)
                {
                    return emptyDataFrameListener._listener;
                }
                return frameListener;
            }
            set
            {
                if (value is object)
                {
                    base.FrameListener = new Http2EmptyDataFrameListener(value, _maxConsecutiveEmptyFrames);
                }
                else
                {
                    base.FrameListener = null;
                }
            }
        }

        // Package-private for testing
        internal IHttp2FrameListener FrameListener0 => base.FrameListener;
    }
}