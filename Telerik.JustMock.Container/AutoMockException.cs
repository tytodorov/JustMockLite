/*
 JustMock Lite
 Copyright © 2010-2014 Telerik AD

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.JustMock.Container
{
	/// <summary>
	/// The exception thrown by the mocking container.
	/// </summary>
	public sealed class AutoMockException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AutoMockException" /> class.
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		public AutoMockException(string message) : base(message)
		{
			// intentionally left blank
		}
	}
}