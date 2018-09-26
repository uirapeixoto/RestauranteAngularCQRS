using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreEFCrud
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();

            container.Register<ICafeContext, CafeContext>();
            container.Register<MyRootType>();

            container.Verify();
        }

        static void Main(string[] args)
        {
            
        }
    }
}
