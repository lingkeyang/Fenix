// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Fenix
{
    using System;
    using System.Buffers;
    using MessagePack;

    public sealed class HostInfoFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Fenix.HostInfo>
    {


        public void Serialize(ref MessagePackWriter writer, global::Fenix.HostInfo value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(5);
            writer.Write(value.HostId);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.HostName, options);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.HostAddr, options);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<uint, string>>().Serialize(ref writer, value.ServiceId2Name, options);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<uint, string>>().Serialize(ref writer, value.ServiceId2TName, options);
        }

        public global::Fenix.HostInfo Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __HostId__ = default(uint);
            var __HostName__ = default(string);
            var __HostAddr__ = default(string);
            var __ServiceId2Name__ = default(global::System.Collections.Generic.Dictionary<uint, string>);
            var __ServiceId2TName__ = default(global::System.Collections.Generic.Dictionary<uint, string>);

            for (int i = 0; i < length; i++)
            {
                var key = i;

                switch (key)
                {
                    case 0:
                        __HostId__ = reader.ReadUInt32();
                        break;
                    case 1:
                        __HostName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        __HostAddr__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 3:
                        __ServiceId2Name__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<uint, string>>().Deserialize(ref reader, options);
                        break;
                    case 4:
                        __ServiceId2TName__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<uint, string>>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::Fenix.HostInfo();
            ____result.HostId = __HostId__;
            ____result.HostName = __HostName__;
            ____result.HostAddr = __HostAddr__;
            ____result.ServiceId2Name = __ServiceId2Name__;
            ____result.ServiceId2TName = __ServiceId2TName__;
            reader.Depth--;
            return ____result;
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name
