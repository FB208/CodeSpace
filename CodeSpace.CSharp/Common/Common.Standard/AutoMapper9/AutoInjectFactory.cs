using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Common.Standard.AutoMapper9
{
    public class AutoInjectFactory
    {
        public List<(Type, Type)> ConvertList { get; } = new List<(Type, Type)>();

        public void AddAssemblys(params Assembly[] assemblys)
        {
            foreach (var assembly in assemblys)
            {
                var atributes = assembly.GetTypes()
                    .Where(_type => _type.GetCustomAttribute<AutoInjectAttribute>() != null)
                    .Select(_type => _type.GetCustomAttribute<AutoInjectAttribute>());

                foreach (var atribute in atributes)
                {
                    ConvertList.Add((atribute.SourceType, atribute.TargetType));
                }
            }
        }
    }
}
