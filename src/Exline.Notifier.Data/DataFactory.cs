using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data
{
    public class DataFactory<TIData> where TIData : IData
    {
        private static Dictionary<DbType, Dictionary<string, Type>> _concretes;
        internal static Dictionary<DbType, Dictionary<string, Type>> Concretes
        {
            get
            {
                if (_concretes == null)
                {

                }
                return _concretes;
            }
            private set
            {
                _concretes = value;
            }
        }
        static DataFactory()
        {
        }
        protected Config Config { get; set; }

        public DataFactory(Config config)
        {
            Config = config;
        }

        public TIData Create()
        {
            TIData data = default(TIData);
            Type interfaceType = typeof(TIData);
            Dictionary<string, Type> dbConcretes = GetDbConcretes(Config.DbServer.Type);
            if (dbConcretes != null)
            {
                Type concreteType = GetConcreteType(interfaceType, dbConcretes);
                if (concreteType != null)
                    data = (TIData)Activator.CreateInstance(concreteType);
            }
            return data;
        }

        private Type GetConcreteType(Type interfaceType, Dictionary<string, Type> concretes)
        {
            return concretes[interfaceType.Name];
        }
        private Dictionary<string, Type> GetDbConcretes(DbType dbType)
        {
            return Concretes[dbType];
        }


        private static void Load()
        {
            Concretes = new Dictionary<DbType, Dictionary<string, Type>>();
            Concretes.Add(DbType.Mongodb, new Dictionary<string, Type>()
            {
                {typeof(IClientData).Name,typeof(Mongodb.ClientData)},
                {typeof(IGroupData).Name,typeof(Mongodb.GroupData) }
            });
        }
    }
}
