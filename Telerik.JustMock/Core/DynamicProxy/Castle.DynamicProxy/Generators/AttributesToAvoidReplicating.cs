// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Telerik.JustMock
{
	using System;
	using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using Telerik.JustMock.Core;

    /// <summary>
    /// A list of attributes that must not be replicated when building a proxy. JustMock
    /// tries to copy all attributes from the types and methods being proxied, but that is
    /// not always a good idea for every type of attribute. Add additional attributes
    /// to this list that prevent the proxy from working correctly.
    /// </summary>
    /// <example>
    /// <see cref="AttributesToAvoidReplicating"/>.Add(typeof(ServiceContractAttribute));
    /// </example>
	public static class AttributesToAvoidReplicating
	{
		private static readonly List<Type> attributes = new List<Type>();

		static AttributesToAvoidReplicating()
		{
			Add<ComImportAttribute>();
#if !SILVERLIGHT
			Add<SecurityPermissionAttribute>();
#endif
#if DOTNET40
			Add<TypeIdentifierAttribute>();
#endif
		}

        /// <summary>
        /// Add an attribute type that must not be replicated when building a proxy.
        /// </summary>
        /// <param name="attribute"></param>
		public static void Add(Type attribute)
		{
            ProfilerInterceptor.GuardInternal(() =>
                {
                    if (attributes.Contains(attribute) == false)
                    {
                        attributes.Add(attribute);
                    }
                });
		}

        /// <summary>
        /// Add an attribute type that must not be replicated when building a proxy.
        /// </summary>
        /// <param name="attribute"></param>
        public static void Add<T>()
		{
            ProfilerInterceptor.GuardInternal(() => Add(typeof(T)));
		}

		internal static bool Contains(Type type)
		{
            return attributes.Any(attr => attr.IsAssignableFrom(type));
		}
	}
}