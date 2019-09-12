using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Standard.AutoMapper9
{
    public sealed class AutoInjectAttribute: Attribute
    {
        public Type SourceType { get; }
        public Type TargetType { get; }

        public AutoInjectAttribute(Type sourceType, Type targetType)
        {
            SourceType = sourceType;
            TargetType = targetType;
        }
    }
}
