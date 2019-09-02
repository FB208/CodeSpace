using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace WebMvc.Emit
{
    public class PersonEmit
    {
        public void Do()
        {
            AssemblyName assemblyName = new AssemblyName("assemblyName");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("PersonModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("Person", TypeAttributes.Public);

            MethodBuilder sayHelloMethod = typeBuilder.DefineMethod("SayHello", MethodAttributes.Public, typeof(string), new Type[] { typeof(string) });
            ILGenerator ilOfSayHello = sayHelloMethod.GetILGenerator();
            //ilOfSayHello.Emit(OpCodes.Ldstr, "蝈蝈");
            ////为什么加OpCodes.Pop
            //ilOfSayHello.Emit(OpCodes.Pop);
            //返回值部分
            LocalBuilder local = ilOfSayHello.DeclareLocal(typeof(string));
            ilOfSayHello.Emit(OpCodes.Ldstr, "Hello,{0}");
            //【不同点2】
            ilOfSayHello.Emit(OpCodes.Ldarg_1);
            ilOfSayHello.Emit(OpCodes.Call, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(string) }));
            ilOfSayHello.Emit(OpCodes.Stloc_0, local);
            ilOfSayHello.Emit(OpCodes.Ldloc_0, local);
            ilOfSayHello.Emit(OpCodes.Ret);
            Type personType = typeBuilder.CreateType();
            object obj = Activator.CreateInstance(personType);
            MethodInfo methodInfo = personType.GetMethod("SayHello");

            //
            object result = methodInfo.Invoke(obj, new object[] {"张三" });
           
        }
    }
}
