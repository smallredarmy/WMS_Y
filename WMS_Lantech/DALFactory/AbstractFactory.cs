using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory {
    public class AbstractFactory {
        public static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        public static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        public static IUserInfoDal CreateUserInfoDal() {
            string fullClassString = NameSpace + ".UserInfoDal";
            return CreateInstance(fullClassString) as IUserInfoDal;
        }

        private static object CreateInstance(string fullClassString) {
            var assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(fullClassString);
        }
    }
}
