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

namespace SequoiaDB.Bson.Serialization.Conventions
{
    /// <summary>
    /// Represents an ignore extra elements convention.
    /// </summary>
    [Obsolete("Use IClassMapConvention instead.")]
    public interface IIgnoreExtraElementsConvention
    {
        /// <summary>
        /// Determines whether to ignore extra elements for a class.
        /// </summary>
        /// <param name="type">The class.</param>
        /// <returns>Whether to ignore extra elements.</returns>
        bool IgnoreExtraElements(Type type);
    }

    /// <summary>
    /// Represents an ignore extra elements convention where extra elements are never ignored.
    /// </summary>
    [Obsolete("Use IgnoreExtraElementsConvention instead.")]
    public class NeverIgnoreExtraElementsConvention : IIgnoreExtraElementsConvention
    {
        /// <summary>
        /// Determines whether to ignore extra elements for a class.
        /// </summary>
        /// <param name="type">The class.</param>
        /// <returns>Whether to ignore extra elements.</returns>
        public bool IgnoreExtraElements(Type type)
        {
            return false;
        }
    }

    /// <summary>
    /// Represents an ignore extra elements convention where extra elements are always ignored.
    /// </summary>
    [Obsolete("Use IgnoreExtraElementsConvention instead.")]
    public class AlwaysIgnoreExtraElementsConvention : IIgnoreExtraElementsConvention
    {
        /// <summary>
        /// Determines whether to ignore extra elements for a class.
        /// </summary>
        /// <param name="type">The class.</param>
        /// <returns>Whether to ignore extra elements.</returns>
        public bool IgnoreExtraElements(Type type)
        {
            return true;
        }
    }
}