using System;
using System.Collections.Generic;

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
                    Load();
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
            Load();
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
                    data = (TIData)Activator.CreateInstance(concreteType, Config);
            }
            return data;
            //return Create(Config);
        }
        public TIData Create(params object[] args)
        {
            // object[] newArgs = new object[args.Length + 1];
            // for (int i = 0; i < args.Length; i++)
            // {
            //     newArgs[i] = args[i];
            // }
            // if(!(newArgs[newArgs.Length-1] is Config){
            //     newArgs[newArgs.Length-1]=Config;
            // }
            TIData data = default(TIData);
            Type interfaceType = typeof(TIData);
            Dictionary<string, Type> dbConcretes = GetDbConcretes(Config.DbServer.Type);
            if (dbConcretes != null)
            {
                Type concreteType = GetConcreteType(interfaceType, dbConcretes);
                if (concreteType != null)
                    data = (TIData)Activator.CreateInstance(concreteType, args);
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
                {typeof(IGroupData).Name,typeof(Mongodb.GroupData) },
                {typeof(IApplicationData).Name,typeof(Mongodb.ApplicationData)}
            });
        }
    }
}
