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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SequoiaDB.Bson.Serialization.Conventions
{
    /// <summary>
    /// A convention that sets a class's IdMember to null.
    /// </summary>
#pragma warning disable 618 // about obsolete IIdMemberConvention
    public class NoIdMemberConvention : ConventionBase, IPostProcessingConvention, IIdMemberConvention
#pragma warning restore 618
    {
        // public methods
        /// <summary>
        /// Applies a post processing modification to the class map.
        /// </summary>
        /// <param name="classMap">The class map.</param>
        public void PostProcess(BsonClassMap classMap)
        {
            classMap.SetIdMember(null);
        }

        /// <summary>
        /// Finds the Id member of a class.
        /// </summary>
        /// <param name="type">The class.</param>
        /// <returns>The name of the Id member.</returns>
        [Obsolete("Use Apply instead.")]
        public string FindIdMember(Type type)
        {
            return null;
        }
    }
}