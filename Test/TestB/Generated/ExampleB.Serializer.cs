﻿// 
// This is the backend code for reading and writing
// Report bugs to: https://silentorbit.com/protobuf/
// 
// Generated by ProtocolBuffer
//  - a pure c# code generation implementation of protocol buffers
// 
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ProtocolBuffers;

namespace Theirs
{
    public partial class TheirMessage
    {
        public static TheirMessage Deserialize(Stream stream)
        {
            TheirMessage instance = new TheirMessage();
            Deserialize(stream, instance);
            return instance;
        }

        public static TheirMessage Deserialize(byte[] buffer)
        {
            TheirMessage instance = new TheirMessage();
            using (MemoryStream ms = new MemoryStream(buffer))
            Deserialize(ms, instance);
            return instance;
        }

        public static Theirs.TheirMessage Deserialize(byte[] buffer, Theirs.TheirMessage instance)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
                Deserialize(ms, instance);
            return instance;
        }

        public static Theirs.TheirMessage Deserialize(Stream stream, Theirs.TheirMessage instance)
        {
            while (true)
            {
                ProtocolBuffers.Key key = null;
                int keyByte = stream.ReadByte();
                if (keyByte == -1)
                    break;
                // Optimized reading of known fields with field ID < 16
                switch (keyByte)
                {
                    // Field 1 Varint
                case 8:
                    instance.FieldA = (int)ProtocolParser.ReadUInt32(stream);
                    break;
                default:
                    key = ProtocolParser.ReadKey((byte)keyByte, stream);
                    break;
                }

                if (key == null)
                    continue;

                // Reading field ID > 16 and unknown field ID/wire type combinations
                switch (key.Field)
                {
                case 0:
                    throw new InvalidDataException("Invalid field id: 0, something went wrong in the stream");
                default:
                    ProtocolParser.SkipKey(stream, key);
                    break;
                }
            }

            return instance;
        }

        public static Theirs.TheirMessage DeserializeLengthDelimited(Stream stream, Theirs.TheirMessage instance)
        {
            long limit = ProtocolParser.ReadUInt32(stream);
            limit += stream.Position;
            while (true)
            {
                if (stream.Position >= limit)
                {
                    if(stream.Position == limit)
                        break;
                    else
                        throw new InvalidOperationException("Read past max limit");
                }
                ProtocolBuffers.Key key = null;
                int keyByte = stream.ReadByte();
                if (keyByte == -1)
                    throw new System.IO.EndOfStreamException();
                // Optimized reading of known fields with field ID < 16
                switch (keyByte)
                {
                    // Field 1 Varint
                case 8:
                    instance.FieldA = (int)ProtocolParser.ReadUInt32(stream);
                    break;
                default:
                    key = ProtocolParser.ReadKey((byte)keyByte, stream);
                    break;
                }

                if (key == null)
                    continue;

                // Reading field ID > 16 and unknown field ID/wire type combinations
                switch (key.Field)
                {
                case 0:
                    throw new InvalidDataException("Invalid field id: 0, something went wrong in the stream");
                default:
                    ProtocolParser.SkipKey(stream, key);
                    break;
                }
            }

            return instance;
        }

        public static void Serialize(Stream stream, TheirMessage instance)
        {
            ProtocolParser.WriteKey(stream, new ProtocolBuffers.Key(1, Wire.Varint));
            ProtocolParser.WriteUInt32(stream,(uint)instance.FieldA);
        }

        public static byte[] SerializeToBytes(TheirMessage instance)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serialize(ms, instance);
                return ms.ToArray();
            }
        }
    }

}
