﻿#region License
//
// Copyright (c) 2008-2014, Dolittle (http://www.dolittle.com)
//
// Licensed under the MIT License (http://opensource.org/licenses/MIT)
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://github.com/dolittle/Bifrost/blob/master/MIT-LICENSE.txt
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System;
using Bifrost.Rules;

namespace Bifrost.Validation.Rules
{
    /// <summary>
    /// Represents the <see cref="ValueRule"/> for specific regular expression - any value must conform with a regular expression
    /// </summary>
    public class Regex : ValueRule
    {
        System.Text.RegularExpressions.Regex _actualRegex;

        /// <summary>
        /// Initializes an instance of <see cref="Regex"/>
        /// </summary>
        /// <param name="expression"></param>
        public Regex(string expression)
        {
            Expression = expression;
            _actualRegex = new System.Text.RegularExpressions.Regex(expression);
        }

        /// <summary>
        /// Get the expression that values must conform to
        /// </summary>
        public string Expression { get; private set; }

#pragma warning disable 1591 // Xml Comments
        public override bool IsSatisfiedBy(IRuleContext context, object instance)
        {
            ThrowIfValueTypeMismatch<string>(instance);
            return _actualRegex.IsMatch((string)instance);
        }
#pragma warning restore 1591 // Xml Comments
    }
}
