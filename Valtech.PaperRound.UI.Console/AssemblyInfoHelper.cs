using System;
using System.Reflection;

namespace Valtech.PaperRound.UI.Console
{
    public static class AssemblyInfoHelper
    {
        private static Assembly _assembly;

        static AssemblyInfoHelper()
        {
            _assembly = Assembly.GetEntryAssembly();
        }


        public static void Configure(Assembly ass)
        {
            _assembly = ass;
        }


        public static T GetCustomAttribute<T>() where T : Attribute
        {
            object[] customAttributes = _assembly.GetCustomAttributes(typeof(T), false);
            if (customAttributes.Length != 0)
            {
                return (T)((object)customAttributes[0]);
            }
            return default(T);
        }

        public static string GetCustomAttribute<T>(Func<T, string> getProperty) where T : Attribute
        {
            T customAttribute = GetCustomAttribute<T>();
            if (customAttribute != null)
            {
                return getProperty(customAttribute);
            }
            return null;
        }

        public static int GetCustomAttribute<T>(Func<T, int> getProperty) where T : Attribute
        {
            T customAttribute = GetCustomAttribute<T>();
            if (customAttribute != null)
            {
                return getProperty(customAttribute);
            }
            return 0;
        }

        public static Version Version
        {
            get
            {
                return _assembly.GetName().Version;
            }
        }

        public static string Title
        {
            get
            {
                return GetCustomAttribute< AssemblyTitleAttribute>(
                     a => a.Title
                );
            }
        }

        public static string Description
        {
            get
            {
                return GetCustomAttribute(
                    (AssemblyDescriptionAttribute a) => a.Description
                );
            }
        }


        public static string Product
        {
            get
            {
                return GetCustomAttribute< AssemblyProductAttribute>(
                    a => a.Product
                );
            }
        }

        public static string Copyright
        {
            get
            {
                return GetCustomAttribute< AssemblyCopyrightAttribute>(
                     a => a.Copyright
                );
            }
        }

        public static string Company
        {
            get
            {
                return GetCustomAttribute<AssemblyCompanyAttribute>(
                    a => a.Company
                );
            }
        }

        public static string InformationalVersion
        {
            get
            {
                return GetCustomAttribute<AssemblyInformationalVersionAttribute>(
                    a => a.InformationalVersion
                );
            }
        }

        public static string Location
        {
            get
            {
                return _assembly.Location;
            }
        }
    }
}