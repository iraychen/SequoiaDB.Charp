﻿/* Copyright 2010-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.IO;
using System.Xml;
using SequoiaDB.Bson.IO;
using SequoiaDB.Bson.Serialization.Options;

namespace SequoiaDB.Bson.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializer for Int32.
    /// </summary>
    public class Int32Serializer : BsonBaseSerializer
    {
        // private static fields
        private static Int32Serializer __instance = new Int32Serializer();

        // constructors
        /// <summary>
        /// Initializes a new instance of the Int32Serializer class.
        /// </summary>
        public Int32Serializer()
            : base(new RepresentationSerializationOptions(BsonType.Int32))
        {
        }

        // public static properties
        /// <summary>
        /// Gets an instance of the Int32Serializer class.
        /// </summary>
        [Obsolete("Use constructor instead.")]
        public static Int32Serializer Instance
        {
            get { return __instance; }
        }

        // public methods
        /// <summary>
        /// Deserializes an object from a BsonReader.
        /// </summary>
        /// <param name="bsonReader">The BsonReader.</param>
        /// <param name="nominalType">The nominal type of the object.</param>
        /// <param name="actualType">The actual type of the object.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>An object.</returns>
        public override object Deserialize(
            BsonReader bsonReader,
            Type nominalType,
            Type actualType,
            IBsonSerializationOptions options)
        {
            VerifyTypes(nominalType, actualType, typeof(int));
            var representationSerializationOptions = EnsureSerializationOptions<RepresentationSerializationOptions>(options);

            var bsonType = bsonReader.GetCurrentBsonType();
            switch (bsonType)
            {
                case BsonType.Double:
                    return representationSerializationOptions.ToInt32(bsonReader.ReadDouble());
                case BsonType.Int32:
                    return bsonReader.ReadInt32();
                case BsonType.Int64:
                    return representationSerializationOptions.ToInt32(bsonReader.ReadInt64());
                case BsonType.String:
                    return XmlConvert.ToInt32(bsonReader.ReadString());
                default:
                    var message = string.Format("Cannot deserialize Int32 from BsonType {0}.", bsonType);
                    throw new FileFormatException(message);
            }
        }

        /// <summary>
        /// Serializes an object to a BsonWriter.
        /// </summary>
        /// <param name="bsonWriter">The BsonWriter.</param>
        /// <param name="nominalType">The nominal type.</param>
        /// <param name="value">The object.</param>
        /// <param name="options">The serialization options.</param>
        public override void Serialize(
            BsonWriter bsonWriter,
            Type nominalType,
            object value,
            IBsonSerializationOptions options)
        {
            var int32Value = (int)value;
            var representationSerializationOptions = EnsureSerializationOptions<RepresentationSerializationOptions>(options);

            switch (representationSerializationOptions.Representation)
            {
                case BsonType.Double:
                    bsonWriter.WriteDouble(representationSerializationOptions.ToDouble(int32Value));
                    break;
                case BsonType.Int32:
                    bsonWriter.WriteInt32(int32Value);
                    break;
                case BsonType.Int64:
                    bsonWriter.WriteInt64(representationSerializationOptions.ToInt64(int32Value));
                    break;
                case BsonType.String:
                    bsonWriter.WriteString(XmlConvert.ToString(int32Value));
                    break;
                default:
                    var message = string.Format("'{0}' is not a valid Int32 representation.", representationSerializationOptions.Representation);
                    throw new BsonSerializationException(message);
            }
        }
    }
}
